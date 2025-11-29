using System;
public class ExtensionInfoSystem
{
    
    private Dictionary<string, string> _extensionDatabase;

    public ExtensionInfoSystem()
    {
        _extensionDatabase = new Dictionary<string, string>();
        LoadData();
    }

    private void LoadData()
    {
        _extensionDatabase.Add(".txt", "Plain Text File");
        _extensionDatabase.Add(".doc", "Microsoft Word Document (Legacy)");
        _extensionDatabase.Add(".docx", "Microsoft Word Open XML Document");
        _extensionDatabase.Add(".pdf", "Portable Document Format");
        _extensionDatabase.Add(".xls", "Microsoft Excel Spreadsheet (Legacy)");
        _extensionDatabase.Add(".xlsx", "Microsoft Excel Open XML Spreadsheet");
        _extensionDatabase.Add(".json", "JavaScript Object Notation");
        _extensionDatabase.Add(".csv", "Comma-Separated Values");
        _extensionDatabase.Add(".jpg", "JPEG Image");
        _extensionDatabase.Add(".jpeg", "JPEG Image");
        _extensionDatabase.Add(".png", "Portable Network Graphics");
        _extensionDatabase.Add(".gif", "Graphics Interchange Format");
        _extensionDatabase.Add(".bmp", "Bitmap Image File");
        _extensionDatabase.Add(".svg", "Scalable Vector Graphics");
        _extensionDatabase.Add(".mp3", "MP3 Audio File");
        _extensionDatabase.Add(".wav", "Waveform Audio File");
        _extensionDatabase.Add(".flac", "Free Lossless Audio Codec");
        _extensionDatabase.Add(".mp4", "MPEG-4 Video File");
        _extensionDatabase.Add(".mov", "Apple QuickTime Movie");
        _extensionDatabase.Add(".avi", "Audio Video Interleave");
        _extensionDatabase.Add(".mkv", "Matroska Video Container");
        _extensionDatabase.Add(".zip", "ZIP Compressed Archive");
        _extensionDatabase.Add(".rar", "RAR Compressed Archive");
        _extensionDatabase.Add(".exe", "Windows Executable File");
        _extensionDatabase.Add(".cs", "C# Source Code File");
        _extensionDatabase.Add(".html", "HyperText Markup Language");
    }

    public string GetDescription(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return "Error: Input cannot be empty.";
        }

        // in case user do not put the value with "." e.g .pdf, add it
        string formattedExtension = extension.Trim();
        if (!formattedExtension.StartsWith("."))    
        {
            formattedExtension = "." + formattedExtension;
        }

        if (_extensionDatabase.TryGetValue(formattedExtension, out string description))
        {
            return description;
        }
        else
        {
            Console.WriteLine("Unknown extension. No information is stored on that file type yet.");
            Console.WriteLine("\nWould you like to add this new extension? (Yes/No)");
            string res = Console.ReadLine();
            if (res == "Yes" || res == "Y" || res == "yes" || res == "y")
            {
                if (!_extensionDatabase.ContainsKey(formattedExtension))
                {
                    Console.WriteLine("\nHow would you like to save this extension? (e.g Portable Document Format)");
                    string newDescription = Console.ReadLine();
                    _extensionDatabase.Add(formattedExtension, newDescription);
                    return $"Success! Saved: {newDescription}";
                }
            }
            return "Action cancelled";
        }
    }
}
