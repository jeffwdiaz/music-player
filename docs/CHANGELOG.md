# Changelog

## 2025-09-09 - Tuesday

[Added]

- Set up .NET 6 WPF project structure
- Created organized folder structure (Core, Models, Views, ViewModels, Services)
- Added project structure explanation documentation
- Created "stuck" rule for troubleshooting workflow
- Installed NAudio 2.2.1 for audio playback functionality
- Installed TagLibSharp 2.3.0 for music metadata reading
- Added NuGet.org package source configuration
- Implemented Song model class with complete metadata support
- Created song-model-class.md documentation explaining the Song model
- Added build output directory with compiled application
- Created AudioEngine class for comprehensive audio playback functionality
- Implemented Album model class with track management and cover art support
- Created MetadataService for reading file metadata from multiple audio formats
- Added folder documentation files explaining each directory's purpose

[Changed]

- Updated project organization with proper MVVM architecture
- Moved documentation files to docs/ folder for better organization
- Changed target framework from .NET 8 to .NET 6 for better package compatibility

[Fixed]

- Resolved .NET SDK installation issues
- Fixed project setup workflow
- Fixed missing NuGet package source configuration
- Resolved package installation errors for NAudio and TagLibSharp

[Removed]
