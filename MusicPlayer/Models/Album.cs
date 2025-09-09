// This file defines what an "album" looks like (data model) in our music player.
// It groups songs together and stores album information like the cover picture and track order.
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicPlayer.Models
{
    /// <summary>
    /// Represents an album containing multiple songs with metadata and cover artwork.
    /// This model groups songs by album and provides album-level information.
    /// </summary>
    public class Album
    {
        #region Properties

        /// <summary>
        /// Gets or sets the album name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the album artist
        /// </summary>
        public string Artist { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the year the album was released
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the album genre
        /// </summary>
        public string Genre { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the list of songs in this album
        /// </summary>
        public List<Song> Songs { get; set; } = new List<Song>();

        /// <summary>
        /// Gets or sets the album cover artwork as byte array
        /// </summary>
        public byte[]? CoverArt { get; set; }

        /// <summary>
        /// Gets the total number of tracks in the album
        /// </summary>
        public int TrackCount => Songs.Count;

        /// <summary>
        /// Gets the total duration of all songs in the album
        /// </summary>
        public TimeSpan TotalDuration
        {
            get
            {
                return Songs.Aggregate(TimeSpan.Zero, (total, song) => total + song.Duration);
            }
        }

        /// <summary>
        /// Gets a unique identifier for the album (combination of name and artist)
        /// </summary>
        public string Id => $"{Artist} - {Name}";

        /// <summary>
        /// Gets whether the album has cover art
        /// </summary>
        public bool HasCoverArt => CoverArt != null && CoverArt.Length > 0;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Album class
        /// </summary>
        public Album()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Album class with basic information
        /// </summary>
        /// <param name="name">The album name</param>
        /// <param name="artist">The album artist</param>
        /// <param name="year">The release year</param>
        public Album(string name, string artist, int year = 0)
        {
            Name = name ?? string.Empty;
            Artist = artist ?? string.Empty;
            Year = year;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a song to the album
        /// </summary>
        /// <param name="song">The song to add</param>
        public void AddSong(Song song)
        {
            if (song == null)
                return;

            // Set album information on the song if not already set
            if (string.IsNullOrEmpty(song.Album))
                song.Album = Name;
            if (string.IsNullOrEmpty(song.AlbumArtist))
                song.AlbumArtist = Artist;

            Songs.Add(song);
        }

        /// <summary>
        /// Removes a song from the album
        /// </summary>
        /// <param name="song">The song to remove</param>
        /// <returns>True if the song was removed, false if it wasn't found</returns>
        public bool RemoveSong(Song song)
        {
            return Songs.Remove(song);
        }

        /// <summary>
        /// Gets a song by track number
        /// </summary>
        /// <param name="trackNumber">The track number (1-based)</param>
        /// <returns>The song at the specified track number, or null if not found</returns>
        public Song? GetSongByTrackNumber(int trackNumber)
        {
            if (trackNumber < 1 || trackNumber > Songs.Count)
                return null;

            return Songs.FirstOrDefault(s => s.TrackNumber == trackNumber);
        }

        /// <summary>
        /// Sorts the songs by track number
        /// </summary>
        public void SortSongsByTrackNumber()
        {
            Songs = Songs.OrderBy(s => s.TrackNumber).ToList();
        }

        /// <summary>
        /// Gets the first song in the album (by track number)
        /// </summary>
        /// <returns>The first song, or null if the album is empty</returns>
        public Song? GetFirstSong()
        {
            return Songs.OrderBy(s => s.TrackNumber).FirstOrDefault();
        }

        /// <summary>
        /// Gets the next song after the specified song
        /// </summary>
        /// <param name="currentSong">The current song</param>
        /// <returns>The next song, or null if no next song exists</returns>
        public Song? GetNextSong(Song currentSong)
        {
            if (currentSong == null)
                return GetFirstSong();

            var sortedSongs = Songs.OrderBy(s => s.TrackNumber).ToList();
            var currentIndex = sortedSongs.IndexOf(currentSong);
            
            if (currentIndex >= 0 && currentIndex < sortedSongs.Count - 1)
                return sortedSongs[currentIndex + 1];

            return null;
        }

        /// <summary>
        /// Gets the previous song before the specified song
        /// </summary>
        /// <param name="currentSong">The current song</param>
        /// <returns>The previous song, or null if no previous song exists</returns>
        public Song? GetPreviousSong(Song currentSong)
        {
            if (currentSong == null)
                return null;

            var sortedSongs = Songs.OrderBy(s => s.TrackNumber).ToList();
            var currentIndex = sortedSongs.IndexOf(currentSong);
            
            if (currentIndex > 0)
                return sortedSongs[currentIndex - 1];

            return null;
        }

        /// <summary>
        /// Sets the cover art for the album
        /// </summary>
        /// <param name="coverArtData">The cover art data as byte array</param>
        public void SetCoverArt(byte[] coverArtData)
        {
            CoverArt = coverArtData;
        }

        /// <summary>
        /// Clears the cover art
        /// </summary>
        public void ClearCoverArt()
        {
            CoverArt = null;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns a string representation of the album
        /// </summary>
        /// <returns>String representation in format "Artist - Album (Year)"</returns>
        public override string ToString()
        {
            if (Year > 0)
                return $"{Artist} - {Name} ({Year})";
            else
                return $"{Artist} - {Name}";
        }

        /// <summary>
        /// Determines whether the specified object is equal to this album
        /// </summary>
        /// <param name="obj">The object to compare</param>
        /// <returns>True if the objects are equal, false otherwise</returns>
        public override bool Equals(object? obj)
        {
            if (obj is Album other)
            {
                return string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        /// <summary>
        /// Returns a hash code for this album
        /// </summary>
        /// <returns>A hash code for the current album</returns>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        #endregion
    }
}
