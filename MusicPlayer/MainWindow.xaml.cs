using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicPlayer.Core;
using MusicPlayer.Services;

namespace MusicPlayer;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private AudioEngine? _audioEngine;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void TestButton_Click(object sender, RoutedEventArgs e)
    {
        StatusText.Text = "Testing audio engine...";
        
        try
        {
            // Test file path
            string testFilePath = @"..\test-music\testfile.mp3";
            
            // Initialize audio engine
            _audioEngine = new AudioEngine();
            
            // Test 1: Load the file
            StatusText.Text = "Loading audio file...";
            bool loaded = _audioEngine.LoadFile(testFilePath);
            
            if (!loaded)
            {
                StatusText.Text = "❌ Failed to load audio file!\nMake sure testfile.mp3 exists in test-music folder.";
                return;
            }
            
            // Test 2: Read metadata
            StatusText.Text = "Reading metadata...";
            var metadataService = new MetadataService();
            var song = metadataService.ReadSongMetadata(testFilePath);
            
            string metadataInfo = "";
            if (song != null)
            {
                metadataInfo = $"\nTitle: {song.Title}\nArtist: {song.Artist}\nAlbum: {song.Album}\nDuration: {song.FormattedDuration}";
            }
            
            // Test 3: Start playback
            StatusText.Text = $"✅ File loaded successfully!\nDuration: {_audioEngine.Duration:mm\\:ss}{metadataInfo}\n\n🎵 Now playing... Click button again to stop.";
            
            _audioEngine.Play();
            
            // Change button to stop
            TestButton.Content = "Stop Playback";
            TestButton.Click -= TestButton_Click;
            TestButton.Click += StopButton_Click;
        }
        catch (Exception ex)
        {
            StatusText.Text = $"❌ Error: {ex.Message}";
        }
    }

    private void StopButton_Click(object sender, RoutedEventArgs e)
    {
        _audioEngine?.Stop();
        _audioEngine?.Dispose();
        _audioEngine = null;
        
        StatusText.Text = "⏹️ Playback stopped. Click button to test again.";
        TestButton.Content = "Test AudioEngine with testfile.mp3";
        TestButton.Click -= StopButton_Click;
        TestButton.Click += TestButton_Click;
    }
}