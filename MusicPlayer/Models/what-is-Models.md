# What is Models?

The **Models** folder contains the data structures and classes that represent the core entities in the music player application. These classes define the shape and behavior of the data used throughout the application.

## Purpose

The Models folder houses the data models that represent:

- **Song.cs** - Represents individual music tracks with metadata like title, artist, album, duration, and album art
- **Album.cs** - (Future) Will represent album collections with cover art and track listings
- **Playlist.cs** - (Future) Will represent user-created playlists

## Key Responsibilities

- Define data structures for music entities
- Store metadata from audio files
- Provide data validation and formatting
- Handle data serialization/deserialization
- Maintain relationships between different music entities

## Design Pattern

This folder implements the Model layer of the MVVM (Model-View-ViewModel) pattern. The models are simple data containers that don't contain business logic, making them easy to work with and test. They serve as the foundation for data binding in the WPF user interface.
