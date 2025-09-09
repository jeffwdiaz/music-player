# What is Services?

The **Services** folder contains helper classes and utility services that provide specific functionality to other parts of the application. These services handle cross-cutting concerns and provide reusable functionality.

## Purpose

The Services folder houses utility classes that:

- **MetadataService.cs** - Reads and extracts metadata from audio files using TagLibSharp
- **FileService.cs** - Handles file system operations like file scanning, validation, and path management
- **NotificationService.cs** - (Future) May handle user notifications and system integration

## Key Responsibilities

- File metadata extraction and processing
- File system operations and validation
- External library integration
- Cross-cutting functionality that multiple components need
- Utility functions and helper methods

## Design Pattern

Services follow the Service Layer pattern, providing focused, single-responsibility classes that can be easily injected into other parts of the application. They act as a bridge between the core business logic and external dependencies, making the code more modular and testable.
