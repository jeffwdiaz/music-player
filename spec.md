# Music Player - Technical Specification

## Project Overview

A standalone desktop music player for Windows 11 with minimal design, focusing on essential playback functionality and basic library management.

## Technical Stack

### Recommended Platform

- Language: C# (.NET 6 or later)
- UI Framework: WPF (Windows Presentation Foundation)
- Target OS: Windows 11 (with Windows 10 compatibility)
- Architecture: 64-bit

### Core Libraries

- Audio Playback: NAudio (free, open-source)
- Metadata Reading: TagLib# (free, open-source)

## Functional Requirements

### Audio Playback

- Supported Formats: MP3, FLAC
- Basic Controls: Play, Pause, Stop, Next, Previous
- Volume Control: Master volume slider
- Progress Control: Seek bar for current track position
- Playback Position Memory: Remember and restore playback position on app restart

### Library Management

- File Addition: Manual file and folder selection via dialog
- Views:
  - List view for individual songs (title, artist, duration)
  - Grid view for albums with cover artwork
- Metadata Display:
  - Song: Title, Artist, Album, Duration
  - Album: Album name, Artist, Year, Track count
- Album Artwork: Display embedded artwork from files

### User Interface

- Design Style: Minimal, black and white color scheme
- Layout: Single window application
- Navigation: Simple tab or button switching between song list and album grid
- Responsive: Handle window resizing gracefully

### Windows Integration

- Media Transport Controls: Integration with Windows media keys (Play/Pause/Skip)
- Taskbar Controls: Media controls visible on taskbar hover
- Volume Mixer: Appear in Windows volume mixer

## Technical Architecture

### Application Structure

```
MusicPlayer/
├── Core/
│   ├── AudioEngine.cs          # Audio playback logic
│   ├── LibraryManager.cs       # File and metadata management
│   └── SettingsManager.cs      # App settings persistence
├── Models/
│   ├── Song.cs                 # Song data model
│   ├── Album.cs                # Album data model
│   └── Playlist.cs             # Future playlist support
├── Views/
│   ├── MainWindow.xaml         # Main application window
│   ├── SongListView.xaml       # List view for songs
│   └── AlbumGridView.xaml      # Grid view for albums
├── ViewModels/
│   ├── MainViewModel.cs        # Main window logic
│   ├── SongListViewModel.cs    # Song list logic
│   └── AlbumGridViewModel.cs   # Album grid logic
└── Services/
    ├── MetadataService.cs      # Read file metadata
    └── FileService.cs          # File system operations
```

### Data Models

#### Song Model

```csharp
public class Song
{
    public string FilePath { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }
    public TimeSpan Duration { get; set; }
    public byte[] AlbumArt { get; set; }
}
```

#### Album Model

```csharp
public class Album
{
    public string Name { get; set; }
    public string Artist { get; set; }
    public int Year { get; set; }
    public List<Song> Songs { get; set; }
    public byte[] CoverArt { get; set; }
}
```

## Implementation Phases

### Phase 1: Core Playback (MVP)

- Basic audio playback (play, pause, stop)
- Single file selection and playback
- Volume control
- Progress bar with seeking
- Minimal UI (black and white)

### Phase 2: Library Management

- Multiple file/folder selection
- Song list view with metadata
- Basic navigation (next/previous)
- Playback position memory

### Phase 3: Album View

- Album grouping logic
- Grid view with cover art
- Album-based navigation

### Phase 4: Windows Integration

- Media key support
- Taskbar media controls
- System volume mixer integration

### Phase 5: Polish & Future Features

- Settings persistence
- Window state memory
- Error handling improvements
- Performance optimizations

## File Structure & Storage

- Settings: Store in application folder as `settings.json`
- Library Data: In-memory only (no database initially)
- Last Position: Saved in settings file

## Performance Considerations

- Memory Usage: Target <100MB RAM usage
- Startup Time: <2 seconds on modern hardware
- Audio Latency: <50ms playback response
- File Scanning: Background threading for folder scanning

## Future Expansion Capabilities

- Playlist support (data model already considered)
- Additional audio formats (easy with NAudio)
- Equalizer integration
- Themes beyond black/white
- Cross-platform potential (with framework changes)

## Development Environment Setup

- Framework: .NET 6 LTS or .NET 8 LTS
- Package Manager: NuGet for dependencies
- Version Control: Git recommended

## Key Dependencies

```xml
<PackageReference Include="NAudio" Version="2.2.1" />
<PackageReference Include="TagLibSharp" Version="2.3.0" />
<PackageReference Include="Microsoft.WindowsAPICodePack-Shell" Version="1.1.4" />
```

## Success Criteria

- Plays MP3 and FLAC files without issues
- Responsive UI with smooth navigation
- Stable playback with proper memory management
- Integration with Windows media controls works reliably
- Clean, minimal interface matches design goals
- Application launches and runs reliably for extended periods
