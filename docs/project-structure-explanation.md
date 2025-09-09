# Project Structure Explanation

## Overview

This document explains how our Music Player project is organized and why we structure it this way. Understanding this organization will help you navigate the codebase and understand where different types of code belong.

## Folder Structure

### 📁 Core/

**Purpose:** Contains the main business logic and core functionality

**What goes here:**

- `AudioEngine.cs` - Handles all audio playback (play, pause, stop, volume)
- `LibraryManager.cs` - Manages your music library (add files, organize songs)
- `SettingsManager.cs` - Saves and loads user preferences

**Why separate:** This is the "brain" of your app - the core functionality that makes it work

### 📁 Models/

**Purpose:** Defines the data structures your app uses

**What goes here:**

- `Song.cs` - Represents a single song (title, artist, duration, file path)
- `Album.cs` - Represents an album (name, artist, year, list of songs)
- `Playlist.cs` - Future feature for playlists

**Why separate:** Models are like blueprints - they define what data looks like, but don't do anything with it

### 📁 Views/

**Purpose:** Contains the user interface files (XAML)

**What goes here:**

- `MainWindow.xaml` - The main window (already exists)
- `SongListView.xaml` - The list that shows all your songs
- `AlbumGridView.xaml` - The grid that shows albums with cover art

**Why separate:** Views are just the visual design - they don't contain any logic

### 📁 ViewModels/

**Purpose:** Contains the logic that connects Views to Models

**What goes here:**

- `MainViewModel.cs` - Logic for the main window
- `SongListViewModel.cs` - Logic for the song list (what to display, how to sort)
- `AlbumGridViewModel.cs` - Logic for the album grid

**Why separate:** This follows the "MVVM" pattern (Model-View-ViewModel) which keeps UI and logic separate

### 📁 Services/

**Purpose:** Contains helper classes that provide specific services

**What goes here:**

- `MetadataService.cs` - Reads song information from files (title, artist, etc.)
- `FileService.cs` - Handles file operations (opening files, scanning folders)

**Why separate:** Services are like specialized tools - they do one specific job well

## Why This Organization Matters

1. **Easy to Find Things:** If you need to change how audio works, you know to look in `Core/`
2. **Easy to Test:** You can test each part separately
3. **Easy to Maintain:** Changes in one area don't break other areas
4. **Professional:** This is how real software companies organize their code

## MVVM Pattern Explanation

Our project follows the **MVVM (Model-View-ViewModel)** pattern:

- **Model** (`Models/`): Data structures and business logic
- **View** (`Views/`): User interface (XAML files)
- **ViewModel** (`ViewModels/`): Connects the View to the Model

### How MVVM Works:

1. **View** displays data to the user
2. **ViewModel** prepares data for the View and handles user interactions
3. **Model** stores the actual data and business rules
4. **Services** provide specialized functionality to support the other layers

## File Naming Conventions

- **Classes:** Use PascalCase (e.g., `AudioEngine.cs`, `Song.cs`)
- **Files:** Match the class name exactly
- **Folders:** Use PascalCase for consistency

## Development Workflow

When adding new features:

1. **Start with Models** - Define what data you need
2. **Create Services** - Build the tools to work with that data
3. **Add to Core** - Implement the main functionality
4. **Create ViewModels** - Connect the data to the UI
5. **Build Views** - Create the user interface
6. **Test Everything** - Make sure it all works together

## Benefits of This Structure

- **Separation of Concerns:** Each folder has a specific purpose
- **Maintainability:** Easy to find and modify specific functionality
- **Testability:** Each component can be tested independently
- **Scalability:** Easy to add new features without breaking existing code
- **Team Development:** Multiple developers can work on different parts simultaneously
