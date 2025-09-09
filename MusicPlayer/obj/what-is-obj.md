# What is obj?

The **obj** folder contains temporary build artifacts and intermediate files generated during the compilation process. This folder is used by the .NET build system to store files that are needed during compilation but not in the final output.

## Purpose

The obj folder houses:

- **Compiled assemblies** - Intermediate compiled files
- **Generated code** - Auto-generated files like App.g.cs and MainWindow.g.cs
- **Build caches** - Files that speed up subsequent builds
- **Temporary files** - Files created during the build process
- **Reference assemblies** - Intermediate reference files

## Key Responsibilities

- Store intermediate build files
- Cache build information for faster subsequent builds
- Generate temporary code files
- Manage build dependencies and references

## Build Process

This folder is automatically created and managed by the .NET build system (MSBuild). It contains temporary files that are regenerated on each build and can be safely deleted - they will be recreated when you build the project again. The folder is typically excluded from version control as it contains build-specific temporary files.
