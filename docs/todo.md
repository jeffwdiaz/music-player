# Music Player - Development To-Do List

## Current task

- [ ] Design minimal black and white UI theme
  - [ ] Review current MainWindow.xaml structure
  - [ ] Plan basic layout (header, content area, controls)
  - [ ] Design volume control slider
  - [ ] Design progress bar with seeking capability
  - [ ] Design play/pause/stop button controls
  - [ ] Create minimal black/white color scheme
  - [ ] Implement basic XAML layout structure
  - [ ] Connect UI controls to AudioEngine
  - [ ] Test UI integration with audio playback
  - [ ] Refine layout and styling

## Future tasks

### Phase 1: Basic UI and Controls

- [ ] Build basic MainWindow layout
- [ ] Add volume control slider (in AudioEngine)
- [ ] Create progress bar with seeking capability (in AudioEngine)
- [ ] Connect UI controls to AudioEngine
- [ ] Test complete UI integration with audio playback

### Phase 2: File Management

- [ ] Create LibraryManager for file and folder management
- [ ] Implement file/folder selection dialog
- [ ] Test basic audio playback with MP3 files (AudioEngine only)
- [ ] Test basic audio playback with FLAC files (AudioEngine only)

### Phase 3: Library Views

- [ ] Create SongListView for displaying song list
- [ ] Create AlbumGridView for displaying album grid
- [ ] Add next/previous track navigation

### Phase 4: Polish and Features

- [ ] Implement playback position memory
- [ ] Build full music player UI with proper controls

## Completed tasks

- [x] Set up Git repository
- [x] Create .gitignore file
- [x] Set up development environment
- [x] Configure build and debug settings
- [x] Set up .NET 6 WPF project structure
- [x] Create basic project folder structure (Core, Models, Views, ViewModels, Services)
- [x] Create project structure explanation documentation
- [x] Create "stuck" rule for troubleshooting workflow
- [x] Install required NuGet packages (NAudio, TagLibSharp)
- [x] Implement basic Song model class
- [x] Create AudioEngine class for playback functionality
- [x] Create Album model class
- [x] Create MetadataService for reading file metadata
- [x] Test AudioEngine with real audio files
- [x] Create interactive test UI
- [x] Fix compilation errors and file path issues
- [x] Add BUILD_AND_RUN.md for quick reference

## Notes

- Priority: Focus on Phase 1 first to get basic playback working
- Testing: Test each phase thoroughly before moving to the next
- Performance: Monitor memory usage and startup time throughout development
- Windows Integration: Test media controls early to ensure compatibility
- Project is now properly organized with MVVM architecture
- AudioEngine is fully functional and tested with real audio files
- Ready to build full music player UI
