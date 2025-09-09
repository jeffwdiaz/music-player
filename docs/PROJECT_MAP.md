# Project Map

## Directory Structure

. (project root)
| .gitignore
| .gitmodules
| README.md
|
+---docs
| | CHANGELOG.md
| | PROJECT_MAP.md
| | project-structure-explanation.md
| | song-model-class.md
| | spec.md
| | todo.md
| | what-is-dotnet.md
|
+---MusicPlayer
| | App.xaml
| | App.xaml.cs
| | AssemblyInfo.cs
| | MainWindow.xaml
| | MainWindow.xaml.cs
| | MusicPlayer.csproj
| |
| +---bin
| | | what-is-bin.md
| | |
| | \---Debug
| | \---net6.0-windows
| | MusicPlayer.deps.json
| | MusicPlayer.dll
| | MusicPlayer.exe
| | MusicPlayer.pdb
| | MusicPlayer.runtimeconfig.json
| | NAudio.Asio.dll
| | NAudio.Core.dll
| | NAudio.dll
| | NAudio.Midi.dll
| | NAudio.Wasapi.dll
| | NAudio.WinForms.dll
| | NAudio.WinMM.dll
| | TagLibSharp.dll
| |
| +---Core
| | | AudioEngine.cs
| | | what-is-Core.md
| |
| +---Models
| | | Album.cs
| | | Song.cs
| | | what-is-Models.md
| |
| +---obj
| | | MusicPlayer.csproj.nuget.dgspec.json
| | | MusicPlayer.csproj.nuget.g.props
| | | MusicPlayer.csproj.nuget.g.targets
| | | project.assets.json
| | | project.nuget.cache
| | | what-is-obj.md
| | |
| | \---Debug
| | \---net6.0-windows
| | | .NETCoreApp,Version=v6.0.AssemblyAttributes.cs
| | | App.g.cs
| | | apphost.exe
| | | MainWindow.baml
| | | MainWindow.g.cs
| | | MusicPla.163160C2.Up2Date
| | | MusicPlayer.AssemblyInfo.cs
| | | MusicPlayer.AssemblyInfoInputs.cache
| | | MusicPlayer.assets.cache
| | | MusicPlayer.csproj.AssemblyReference.cache
| | | MusicPlayer.csproj.CoreCompileInputs.cache
| | | MusicPlayer.csproj.FileListAbsolute.txt
| | | MusicPlayer.dll
| | | MusicPlayer.g.resources
| | | MusicPlayer.GeneratedMSBuildEditorConfig.editorconfig
| | | MusicPlayer.genruntimeconfig.cache
| | | MusicPlayer.GlobalUsings.g.cs
| | | MusicPlayer.pdb
| | | MusicPlayer.sourcelink.json
| | | MusicPlayer_deo4em0e_wpftmp.AssemblyInfo.cs
| | | MusicPlayer_deo4em0e_wpftmp.AssemblyInfoInputs.cache
| | | MusicPlayer_deo4em0e_wpftmp.assets.cache
| | | MusicPlayer_deo4em0e_wpftmp.GeneratedMSBuildEditorConfig.editorconfig
| | | MusicPlayer_deo4em0e_wpftmp.GlobalUsings.g.cs
| | | MusicPlayer_deo4em0e_wpftmp.sourcelink.json
| | | MusicPlayer_MarkupCompile.cache
| | | MusicPlayer_MarkupCompile.lref
| | |
| | +---ref
| | | MusicPlayer.dll
| | |
| | \---refint
| | MusicPlayer.dll
| |
| +---Services
| | | MetadataService.cs
| | | what-is-Services.md
| |
| +---ViewModels
| | | what-is-ViewModels.md
| |
| \---Views
| what-is-Views.md

## Folder & File Descriptions

- **.gitignore**: Git ignore rules for the project.
- **.gitmodules**: Git submodule configuration.
- **README.md**: Project overview and instructions.
- **docs/**: Project documentation folder.
  - **CHANGELOG.md**: Project changelog tracking all changes.
  - **PROJECT_MAP.md**: This file; describes the project structure.
  - **spec.md**: Technical specification document outlining project requirements.
  - **todo.md**: Development to-do list organized by implementation phases.
  - **project-structure-explanation.md**: Detailed explanation of project organization and MVVM pattern.
  - **song-model-class.md**: Detailed explanation of the Song model class and its purpose.
  - **what-is-dotnet.md**: Educational content about .NET framework.
- **MusicPlayer/**: Main WPF application project.
  - **App.xaml**: Main application definition file.
  - **App.xaml.cs**: Application startup code.
  - **MainWindow.xaml**: Main window UI design.
  - **MainWindow.xaml.cs**: Main window code-behind.
  - **MusicPlayer.csproj**: Project file with dependencies and configuration.
  - **bin/**: Compiled application output directory.
    - **Debug/net6.0-windows/**: Debug build output with executable and dependencies.
  - **Core/**: Business logic and core functionality.
    - **AudioEngine.cs**: Audio playback engine with play, pause, stop, volume control, and seeking functionality.
    - **what-is-Core.md**: Documentation explaining the Core folder's purpose.
  - **Models/**: Data structures and entities.
    - **Song.cs**: Song model class with metadata and file information.
    - **Album.cs**: Album model class with track management and cover art support.
    - **what-is-Models.md**: Documentation explaining the Models folder's purpose.
  - **Views/**: User interface files (XAML).
    - **what-is-Views.md**: Documentation explaining the Views folder's purpose.
  - **ViewModels/**: Logic connecting Views to Models (MVVM pattern).
    - **what-is-ViewModels.md**: Documentation explaining the ViewModels folder's purpose.
  - **Services/**: Helper classes and utility services.
    - **MetadataService.cs**: Service for reading file metadata from multiple audio formats using TagLibSharp.
    - **what-is-Services.md**: Documentation explaining the Services folder's purpose.
  - **obj/**: Build output and temporary files.
    - **what-is-obj.md**: Documentation explaining the obj folder's purpose.
