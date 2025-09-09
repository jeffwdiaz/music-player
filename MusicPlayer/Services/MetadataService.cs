// This file (MetadataService) reads information from music files (like song title, artist, album cover).
// It can read different types of music files like MP3 and FLAC to get this information (metadata).
using System;
using System.IO;
using TagLib;
using MusicPlayer.Models;

namespace MusicPlayer.Services
{
    /// <summary>
    /// Service for reading and extracting metadata from audio files using TagLibSharp.
    /// Handles various audio formats and provides a unified interface for metadata extraction.
    /// </summary>
    public class MetadataService
    {
        #region Private Fields

        private readonly string[] _supportedExtensions = { ".mp3", ".flac", ".wav", ".aac", ".m4a", ".ogg" };

        #endregion

        #region Public Methods

        /// <summary>
        /// Reads metadata from an audio file and creates a Song object
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>Song object with metadata, or null if file cannot be read</returns>
        public Song? ReadSongMetadata(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                return null;

            if (!IsSupportedFile(filePath))
                return null;

            try
            {
                using var file = TagLib.File.Create(filePath);
                if (file == null)
                    return null;

                var song = new Song
                {
                    FilePath = filePath,
                    Title = GetStringProperty(file.Tag.Title),
                    Artist = GetStringProperty(file.Tag.FirstPerformer),
                    Album = GetStringProperty(file.Tag.Album),
                    AlbumArtist = GetStringProperty(file.Tag.FirstAlbumArtist),
                    Genre = GetStringProperty(file.Tag.FirstGenre),
                    Year = (int)file.Tag.Year,
                    TrackNumber = (int)file.Tag.Track,
                    Duration = file.Properties.Duration,
                    Bitrate = file.Properties.AudioBitrate,
                    SampleRate = file.Properties.AudioSampleRate,
                    Channels = file.Properties.AudioChannels
                };

                // Extract album art if available
                song.AlbumArt = ExtractAlbumArt(file);

                return song;
            }
            catch (Exception)
            {
                // Log error in production
                return null;
            }
        }

        /// <summary>
        /// Reads metadata from multiple audio files
        /// </summary>
        /// <param name="filePaths">Array of file paths to read</param>
        /// <returns>Array of Song objects with metadata</returns>
        public Song[] ReadMultipleSongMetadata(string[] filePaths)
        {
            if (filePaths == null || filePaths.Length == 0)
                return Array.Empty<Song>();

            var songs = new List<Song>();

            foreach (var filePath in filePaths)
            {
                var song = ReadSongMetadata(filePath);
                if (song != null)
                {
                    songs.Add(song);
                }
            }

            return songs.ToArray();
        }

        /// <summary>
        /// Scans a directory for audio files and reads their metadata
        /// </summary>
        /// <param name="directoryPath">Path to the directory to scan</param>
        /// <param name="includeSubdirectories">Whether to include subdirectories</param>
        /// <returns>Array of Song objects found in the directory</returns>
        public Song[] ScanDirectoryForSongs(string directoryPath, bool includeSubdirectories = true)
        {
            if (string.IsNullOrEmpty(directoryPath) || !Directory.Exists(directoryPath))
                return Array.Empty<Song>();

            try
            {
                var searchOption = includeSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                var audioFiles = Directory.GetFiles(directoryPath, "*.*", searchOption)
                    .Where(IsSupportedFile)
                    .ToArray();

                return ReadMultipleSongMetadata(audioFiles);
            }
            catch (Exception)
            {
                // Log error in production
                return Array.Empty<Song>();
            }
        }

        /// <summary>
        /// Groups songs into albums based on album and artist information
        /// </summary>
        /// <param name="songs">Array of songs to group</param>
        /// <returns>Array of Album objects</returns>
        public Album[] GroupSongsIntoAlbums(Song[] songs)
        {
            if (songs == null || songs.Length == 0)
                return Array.Empty<Album>();

            var albumGroups = songs
                .Where(s => !string.IsNullOrEmpty(s.Album) && !string.IsNullOrEmpty(s.Artist))
                .GroupBy(s => new { Album = s.Album, Artist = s.AlbumArtist ?? s.Artist })
                .Select(group => new Album
                {
                    Name = group.Key.Album,
                    Artist = group.Key.Artist,
                    Year = group.First().Year,
                    Genre = group.First().Genre,
                    Songs = group.OrderBy(s => s.TrackNumber).ToList()
                })
                .ToArray();

            // Set album cover art from the first song that has it
            foreach (var album in albumGroups)
            {
                var firstSongWithArt = album.Songs.FirstOrDefault(s => s.AlbumArt != null && s.AlbumArt.Length > 0);
                if (firstSongWithArt != null && firstSongWithArt.AlbumArt != null)
                {
                    album.SetCoverArt(firstSongWithArt.AlbumArt);
                }
            }

            return albumGroups ?? Array.Empty<Album>();
        }

        /// <summary>
        /// Checks if a file is a supported audio format
        /// </summary>
        /// <param name="filePath">Path to the file to check</param>
        /// <returns>True if the file is supported, false otherwise</returns>
        public bool IsSupportedFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return false;

            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            return _supportedExtensions.Contains(extension);
        }

        /// <summary>
        /// Gets the list of supported file extensions
        /// </summary>
        /// <returns>Array of supported file extensions</returns>
        public string[] GetSupportedExtensions()
        {
            return (string[])_supportedExtensions.Clone();
        }

        /// <summary>
        /// Extracts album art from a TagLib file
        /// </summary>
        /// <param name="file">TagLib file object</param>
        /// <returns>Album art as byte array, or null if not found</returns>
        public byte[]? ExtractAlbumArt(TagLib.File file)
        {
            try
            {
                var pictures = file.Tag.Pictures;
                if (pictures != null && pictures.Length > 0)
                {
                    // Get the first picture (usually the album cover)
                    var picture = pictures[0];
                    return picture.Data.Data;
                }
            }
            catch (Exception)
            {
                // Log error in production
            }

            return null;
        }

        /// <summary>
        /// Extracts album art from a specific file path
        /// </summary>
        /// <param name="filePath">Path to the audio file</param>
        /// <returns>Album art as byte array, or null if not found</returns>
        public byte[]? ExtractAlbumArtFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !System.IO.File.Exists(filePath))
                return null;

            if (!IsSupportedFile(filePath))
                return null;

            try
            {
                using var file = TagLib.File.Create(filePath);
                return ExtractAlbumArt(file);
            }
            catch (Exception)
            {
                // Log error in production
                return null;
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Safely gets a string property from TagLib, handling null values
        /// </summary>
        /// <param name="value">The TagLib string value</param>
        /// <returns>String value or empty string if null</returns>
        private string GetStringProperty(string? value)
        {
            return string.IsNullOrEmpty(value) ? string.Empty : value.Trim();
        }

        #endregion
    }
}
