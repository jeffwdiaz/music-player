# What is Views?

The **Views** folder contains the user interface files (XAML) that define the visual appearance and layout of the music player application. These files describe how the application looks and behaves from the user's perspective.

## Purpose

The Views folder houses XAML files that define:

- **MainWindow.xaml** - The main application window with overall layout and navigation
- **SongListView.xaml** - The list view for displaying individual songs with metadata
- **AlbumGridView.xaml** - The grid view for displaying albums with cover artwork
- **SettingsView.xaml** - (Future) Settings and preferences interface

## Key Responsibilities

- Define the visual layout and design of the application
- Create user interface elements and controls
- Handle user input and interactions
- Display data from ViewModels through data binding
- Implement responsive design and styling

## Design Pattern

This folder implements the View layer of the MVVM pattern. Views are purely presentational and contain minimal code-behind logic. They use data binding to connect to ViewModels and display data, while user interactions are handled through commands and events. The XAML files define the structure, while styling and themes are applied to create the minimal black and white design.
