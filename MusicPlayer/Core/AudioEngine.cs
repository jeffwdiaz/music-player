// This is the heart of the music player (AudioEngine) - it actually plays the music files.
// It handles playing, pausing, stopping, changing volume, and jumping to different parts of songs.
using System;
using System.IO;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace MusicPlayer.Core
{
    /// <summary>
    /// Handles all audio playback functionality including play, pause, stop, volume control, and seeking.
    /// This is the core component responsible for audio processing using the NAudio library.
    /// </summary>
    public class AudioEngine : IDisposable
    {
        #region Private Fields

        private WaveOutEvent? _waveOut;
        private AudioFileReader? _audioFileReader;
        private bool _isDisposed = false;
        private bool _isPlaying = false;
        private bool _isPaused = false;
        private float _volume = 0.5f; // Default volume (50%)

        #endregion

        #region Events

        /// <summary>
        /// Fired when playback position changes (for progress bar updates)
        /// </summary>
        public event EventHandler<TimeSpan>? PositionChanged;

        /// <summary>
        /// Fired when playback stops (either by user or end of file)
        /// </summary>
        public event EventHandler? PlaybackStopped;

        /// <summary>
        /// Fired when a new file starts playing
        /// </summary>
        public event EventHandler<string>? FileStarted;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the current playback position
        /// </summary>
        public TimeSpan Position => _audioFileReader?.CurrentTime ?? TimeSpan.Zero;

        /// <summary>
        /// Gets the total duration of the current file
        /// </summary>
        public TimeSpan Duration => _audioFileReader?.TotalTime ?? TimeSpan.Zero;

        /// <summary>
        /// Gets or sets the volume (0.0 to 1.0)
        /// </summary>
        public float Volume
        {
            get => _volume;
            set
            {
                _volume = Math.Max(0.0f, Math.Min(1.0f, value));
                if (_audioFileReader != null)
                {
                    _audioFileReader.Volume = _volume;
                }
            }
        }

        /// <summary>
        /// Gets whether audio is currently playing
        /// </summary>
        public bool IsPlaying => _isPlaying && !_isPaused;

        /// <summary>
        /// Gets whether audio is currently paused
        /// </summary>
        public bool IsPaused => _isPaused;

        /// <summary>
        /// Gets the current file path being played
        /// </summary>
        public string? CurrentFilePath { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the AudioEngine class
        /// </summary>
        public AudioEngine()
        {
            // Initialize the wave output device
            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads an audio file for playback
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>True if file was loaded successfully, false otherwise</returns>
        public bool LoadFile(string filePath)
        {
            try
            {
                // Validate file exists
                if (!File.Exists(filePath))
                {
                    return false;
                }

                // Stop current playback
                Stop();

                // Dispose previous file reader
                _audioFileReader?.Dispose();

                // Create new file reader
                _audioFileReader = new AudioFileReader(filePath);
                _audioFileReader.Volume = _volume;

                // Set up the wave output
                _waveOut?.Init(_audioFileReader);

                CurrentFilePath = filePath;
                FileStarted?.Invoke(this, filePath);

                return true;
            }
            catch (Exception)
            {
                // Log error in production
                return false;
            }
        }

        /// <summary>
        /// Starts or resumes playback
        /// </summary>
        public void Play()
        {
            if (_waveOut == null || _audioFileReader == null)
                return;

            try
            {
                if (_isPaused)
                {
                    // Resume from pause
                    _waveOut.Play();
                    _isPaused = false;
                }
                else
                {
                    // Start new playback
                    _waveOut.Play();
                }

                _isPlaying = true;
            }
            catch (Exception)
            {
                // Log error in production
            }
        }

        /// <summary>
        /// Pauses playback
        /// </summary>
        public void Pause()
        {
            if (_waveOut == null || !_isPlaying)
                return;

            try
            {
                _waveOut.Pause();
                _isPaused = true;
            }
            catch (Exception)
            {
                // Log error in production
            }
        }

        /// <summary>
        /// Stops playback and resets position
        /// </summary>
        public void Stop()
        {
            if (_waveOut == null)
                return;

            try
            {
                _waveOut.Stop();
                _isPlaying = false;
                _isPaused = false;

                // Reset position to beginning
                if (_audioFileReader != null)
                {
                    _audioFileReader.Position = 0;
                }
            }
            catch (Exception)
            {
                // Log error in production
            }
        }

        /// <summary>
        /// Seeks to a specific position in the audio file
        /// </summary>
        /// <param name="position">Position to seek to</param>
        public void Seek(TimeSpan position)
        {
            if (_audioFileReader == null)
                return;

            try
            {
                // Ensure position is within bounds
                if (position < TimeSpan.Zero)
                    position = TimeSpan.Zero;
                if (position > Duration)
                    position = Duration;

                _audioFileReader.CurrentTime = position;
                PositionChanged?.Invoke(this, position);
            }
            catch (Exception)
            {
                // Log error in production
            }
        }

        /// <summary>
        /// Updates the playback position (called by timer for progress updates)
        /// </summary>
        public void UpdatePosition()
        {
            if (_audioFileReader != null && IsPlaying)
            {
                PositionChanged?.Invoke(this, Position);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Handles the playback stopped event
        /// </summary>
        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            _isPlaying = false;
            _isPaused = false;
            PlaybackStopped?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region IDisposable Implementation

        /// <summary>
        /// Disposes of the AudioEngine and releases all resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes of the AudioEngine and releases all resources
        /// </summary>
        /// <param name="disposing">True if called from Dispose(), false if called from finalizer</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed && disposing)
            {
                Stop();
                _audioFileReader?.Dispose();
                _waveOut?.Dispose();
                _isDisposed = true;
            }
        }

        #endregion
    }
}
