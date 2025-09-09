# What is ViewModels?

The **ViewModels** folder contains the presentation logic that connects the Views (user interface) with the Models (data) in the MVVM architectural pattern. These classes handle user interactions and data binding.

## Purpose

The ViewModels folder houses classes that:

- **MainViewModel.cs** - Controls the main window logic and overall application state
- **SongListViewModel.cs** - Manages the song list view, including filtering, sorting, and selection
- **AlbumGridViewModel.cs** - Handles the album grid view with cover art display and album navigation

## Key Responsibilities

- Handle user interface logic and interactions
- Manage data binding between Views and Models
- Process user commands and events
- Coordinate between different parts of the application
- Maintain view-specific state and properties

## Design Pattern

This folder implements the ViewModel layer of the MVVM pattern. ViewModels act as intermediaries between the Views and Models, containing presentation logic and data that the Views can bind to. They use data binding and commands to create a clean separation between the UI and business logic.
