using System;

namespace MusicPlayer.Models
{
    /// <summary>
    /// Represents a music track with metadata and file information
    /// </summary>
    public class Song
    {
        /// <summary>
        /// Full file path to the audio file
        /// </summary>
        public string FilePath { get; set; } = string.Empty;

        /// <summary>
        /// Song title from metadata
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Artist name from metadata
        /// </summary>
        public string Artist { get; set; } = string.Empty;

        /// <summary>
        /// Album name from metadata
        /// </summary>
        public string Album { get; set; } = string.Empty;

        /// <summary>
        /// Song duration
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Album artwork as byte array
        /// </summary>
        public byte[]? AlbumArt { get; set; }

        /// <summary>
        /// Track number on the album
        /// </summary>
        public int TrackNumber { get; set; }

        /// <summary>
        /// Year the song was released
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// File name without path
        /// </summary>
        public string FileName => System.IO.Path.GetFileName(FilePath);

        /// <summary>
        /// Display name for the song (Title - Artist or FileName if no metadata)
        /// </summary>
        public string DisplayName
        {
            get
            {
                if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Artist))
                    return $"{Title} - {Artist}";
                
                return !string.IsNullOrEmpty(Title) ? Title : FileName;
            }
        }

        /// <summary>
        /// Duration formatted as MM:SS
        /// </summary>
        public string FormattedDuration => Duration.ToString(@"mm\:ss");

        /// <summary>
        /// Check if the song has valid metadata
        /// </summary>
        public bool HasMetadata => !string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Artist) || !string.IsNullOrEmpty(Album);

        /// <summary>
        /// Check if the song has album artwork
        /// </summary>
        public bool HasAlbumArt => AlbumArt != null && AlbumArt.Length > 0;
    }
}
