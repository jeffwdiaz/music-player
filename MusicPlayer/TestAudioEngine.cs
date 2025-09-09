// This is a test program (TestAudioEngine) to make sure the music playing part works correctly.
// It lets you test playing music from the command line (console) to check if everything is working.
using System;
using System.Threading;
using MusicPlayer.Core;
using MusicPlayer.Services;
using MusicPlayer.Models;

namespace MusicPlayer
{
    /// <summary>
    /// Simple test program to verify AudioEngine functionality with actual music files
    /// </summary>
    public class TestAudioEngine
    {
        private static AudioEngine? _audioEngine;
        private static bool _isRunning = true;

        public static void RunTest()
        {
            Console.WriteLine("🎵 Music Player AudioEngine Test");
            Console.WriteLine("================================");
            Console.WriteLine();

            // Initialize the audio engine
            _audioEngine = new AudioEngine();
            _audioEngine.PlaybackStopped += OnPlaybackStopped;
            _audioEngine.PositionChanged += OnPositionChanged;

            // Test file path
            string testFilePath = @"..\..\..\..\test-music\testfile.mp3";
            
            Console.WriteLine($"Testing with file: {testFilePath}");
            Console.WriteLine();

            // Test 1: Load the file
            Console.WriteLine("1. Loading audio file...");
            bool loaded = _audioEngine.LoadFile(testFilePath);
            
            if (!loaded)
            {
                Console.WriteLine("❌ Failed to load audio file!");
                Console.WriteLine("Make sure the file exists and is a supported format.");
                return;
            }
            
            Console.WriteLine("✅ File loaded successfully!");
            Console.WriteLine($"   Duration: {_audioEngine.Duration:mm\\:ss}");
            Console.WriteLine();

            // Test 2: Read metadata
            Console.WriteLine("2. Reading metadata...");
            var metadataService = new MetadataService();
            var song = metadataService.ReadSongMetadata(testFilePath);
            
            if (song != null)
            {
                Console.WriteLine("✅ Metadata read successfully!");
                Console.WriteLine($"   Title: {song.Title}");
                Console.WriteLine($"   Artist: {song.Artist}");
                Console.WriteLine($"   Album: {song.Album}");
                Console.WriteLine($"   Duration: {song.FormattedDuration}");
                Console.WriteLine($"   Has Album Art: {song.HasAlbumArt}");
            }
            else
            {
                Console.WriteLine("⚠️  Could not read metadata (file may still work)");
            }
            Console.WriteLine();

            // Test 3: Play the song
            Console.WriteLine("3. Starting playback...");
            Console.WriteLine("   Press 'p' to pause/resume");
            Console.WriteLine("   Press 's' to stop");
            Console.WriteLine("   Press 'v' to change volume");
            Console.WriteLine("   Press 'j' to jump to 30 seconds");
            Console.WriteLine("   Press 'q' to quit");
            Console.WriteLine();

            _audioEngine.Play();
            Console.WriteLine("🎵 Now playing...");

            // Main test loop
            while (_isRunning)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).KeyChar;
                    
                    switch (char.ToLower(key))
                    {
                        case 'p':
                            if (_audioEngine.IsPlaying)
                            {
                                _audioEngine.Pause();
                                Console.WriteLine("⏸️  Paused");
                            }
                            else
                            {
                                _audioEngine.Play();
                                Console.WriteLine("▶️  Resumed");
                            }
                            break;
                            
                        case 's':
                            _audioEngine.Stop();
                            Console.WriteLine("⏹️  Stopped");
                            break;
                            
                        case 'v':
                            Console.WriteLine("Current volume: " + (_audioEngine.Volume * 100).ToString("F0") + "%");
                            Console.Write("Enter new volume (0-100): ");
                            if (float.TryParse(Console.ReadLine(), out float newVolume))
                            {
                                _audioEngine.Volume = newVolume / 100f;
                                Console.WriteLine($"Volume set to: {(_audioEngine.Volume * 100).ToString("F0")}%");
                            }
                            break;
                            
                        case 'j':
                            _audioEngine.Seek(TimeSpan.FromSeconds(30));
                            Console.WriteLine("⏭️  Jumped to 30 seconds");
                            break;
                            
                        case 'q':
                            _isRunning = false;
                            break;
                    }
                }
                
                // Update position display
                _audioEngine.UpdatePosition();
                Thread.Sleep(100);
            }

            // Cleanup
            Console.WriteLine("\n🛑 Stopping test...");
            _audioEngine.Stop();
            _audioEngine.Dispose();
            Console.WriteLine("✅ Test completed!");
        }

        private static void OnPlaybackStopped(object? sender, EventArgs e)
        {
            Console.WriteLine("\n🏁 Playback finished!");
            _isRunning = false;
        }

        private static void OnPositionChanged(object? sender, TimeSpan position)
        {
            // Clear current line and show position
            Console.Write($"\r⏱️  Position: {position:mm\\:ss} / {_audioEngine?.Duration:mm\\:ss}     ");
        }
    }
}
