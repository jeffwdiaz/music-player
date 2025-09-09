# Song Model Class - Explanation

## What is the Song Model Class?

The `Song` class is a **data model** that represents a single music track in our music player application. It's like a digital container that holds all the information about one song - both the technical details (like file location) and the metadata (like title, artist, album).

## Why Do We Need It?

### 1. **Data Organization**

- **Problem**: Music files have lots of different information scattered around (file path, metadata, artwork, etc.)
- **Solution**: The Song class brings all this information together in one organized place
- **Benefit**: Makes it easy to work with song data throughout the application

### 2. **Consistent Data Structure**

- **Problem**: Different parts of the app need to access song information in different ways
- **Solution**: The Song class provides a standard way to access song data
- **Benefit**: All parts of the app use the same format, preventing errors and confusion

### 3. **Metadata Handling**

- **Problem**: Music files might have missing or incomplete metadata
- **Solution**: The Song class provides fallback values and helper properties
- **Benefit**: The app works even when song files have missing information

## Key Properties Explained

### **Core Properties (Required)**

```csharp
public string FilePath { get; set; }        // Where the file is located
public string Title { get; set; }           // Song name
public string Artist { get; set; }          // Who made the song
public string Album { get; set; }           // Which album it's from
public TimeSpan Duration { get; set; }      // How long the song is
public byte[]? AlbumArt { get; set; }       // Cover artwork image
```

### **Additional Properties (Helpful)**

```csharp
public int TrackNumber { get; set; }        // Track position on album
public int Year { get; set; }               // When it was released
public string FileName { get; }             // Just the filename (computed)
public string DisplayName { get; }          // How to show it in UI (computed)
public string FormattedDuration { get; }    // Duration as "3:45" (computed)
```

### **Helper Properties (Smart Features)**

```csharp
public bool HasMetadata { get; }            // Does it have title/artist info?
public bool HasAlbumArt { get; }            // Does it have cover artwork?
```

## How It Works in Practice

### **Example 1: Complete Song**

```csharp
var song = new Song
{
    FilePath = "C:\\Music\\Artist\\Album\\01 - Song Title.mp3",
    Title = "Song Title",
    Artist = "Artist Name",
    Album = "Album Name",
    Duration = TimeSpan.FromMinutes(3).Add(TimeSpan.FromSeconds(45)),
    TrackNumber = 1,
    Year = 2023
};

// DisplayName will be "Song Title - Artist Name"
// FormattedDuration will be "3:45"
// HasMetadata will be true
```

### **Example 2: Incomplete Song**

```csharp
var song = new Song
{
    FilePath = "C:\\Music\\Unknown\\track01.mp3",
    Title = "",           // No title
    Artist = "",          // No artist
    Duration = TimeSpan.FromMinutes(4).Add(TimeSpan.FromSeconds(12))
};

// DisplayName will be "track01.mp3" (falls back to filename)
// FormattedDuration will be "4:12"
// HasMetadata will be false
```

## Why This Design is Good

### **1. Flexible**

- Works with complete metadata or missing information
- Handles different file formats (MP3, FLAC, etc.)
- Adapts to various music library structures

### **2. User-Friendly**

- `DisplayName` always shows something meaningful to the user
- `FormattedDuration` shows time in a readable format
- Helper properties make UI logic simple

### **3. Developer-Friendly**

- Clear property names that are easy to understand
- XML documentation explains what each property does
- Consistent data types throughout

### **4. Future-Proof**

- Easy to add new properties if needed
- Compatible with different audio libraries
- Works with the MVVM pattern for UI binding

## How It Fits in the Music Player

### **Data Flow**

1. **File Discovery**: When user selects music files, we create Song objects
2. **Metadata Reading**: We fill in the properties using TagLibSharp
3. **UI Display**: The UI binds to Song properties to show information
4. **Playback**: The AudioEngine uses the FilePath to play the song

### **Integration Points**

- **MetadataService**: Reads file metadata and populates Song properties
- **LibraryManager**: Manages collections of Song objects
- **UI Views**: Display Song information in lists and grids
- **AudioEngine**: Uses Song.FilePath for playback

## Summary

The Song model class is the **foundation** of our music player. It:

- **Organizes** all song information in one place
- **Handles** missing or incomplete metadata gracefully
- **Provides** convenient helper properties for the UI
- **Enables** consistent data handling throughout the app

Without this class, we'd have to manage song data in a messy, inconsistent way. With it, we have a clean, organized system that makes building the rest of the music player much easier.
