# What is Core?

The **Core** folder contains the business logic and core functionality of the music player application. This folder follows the separation of concerns principle by isolating the core application logic from the user interface and data models.

## Purpose

The Core folder houses the essential components that make the music player work:

- **AudioEngine.cs** - Handles all audio playback functionality including play, pause, stop, volume control, and seeking
- **LibraryManager.cs** - Manages the music library, file scanning, and metadata organization
- **SettingsManager.cs** - Handles application settings persistence and configuration

## Key Responsibilities

- Audio playback control and management
- File system operations for music files
- Application settings and preferences
- Core business rules and logic
- Integration with external audio libraries (NAudio)

## Design Pattern

This folder implements the core business logic layer of the application, keeping it separate from the presentation layer (Views/ViewModels) and data layer (Models). This separation makes the code more maintainable, testable, and follows the MVVM architectural pattern.
