using System;
public class ExtensionsDB
{
    
    private Dictionary<string, string> _extensionsDatabase;

    public ExtensionsDB()
    {
        _extensionsDatabase = new Dictionary<string, string>();
        LoadData();
    }

    private void LoadData()
    {
        _extensionsDatabase.Add(".txt", "Plain Text File");
        _extensionsDatabase.Add(".doc", "Microsoft Word Document (Legacy)");
        _extensionsDatabase.Add(".docx", "Microsoft Word Open XML Document");
        _extensionsDatabase.Add(".pdf", "Portable Document Format");
        _extensionsDatabase.Add(".xls", "Microsoft Excel Spreadsheet (Legacy)");
        _extensionsDatabase.Add(".xlsx", "Microsoft Excel Open XML Spreadsheet");
        _extensionsDatabase.Add(".json", "JavaScript Object Notation");
        _extensionsDatabase.Add(".csv", "Comma-Separated Values");
        _extensionsDatabase.Add(".jpg", "JPEG Image");
        _extensionsDatabase.Add(".jpeg", "JPEG Image");
        _extensionsDatabase.Add(".png", "Portable Network Graphics");
        _extensionsDatabase.Add(".gif", "Graphics Interchange Format");
        _extensionsDatabase.Add(".bmp", "Bitmap Image File");
        _extensionsDatabase.Add(".svg", "Scalable Vector Graphics");
        _extensionsDatabase.Add(".mp3", "MP3 Audio File");
        _extensionsDatabase.Add(".wav", "Waveform Audio File");
        _extensionsDatabase.Add(".flac", "Free Lossless Audio Codec");
        _extensionsDatabase.Add(".mp4", "MPEG-4 Video File");
        _extensionsDatabase.Add(".mov", "Apple QuickTime Movie");
        _extensionsDatabase.Add(".avi", "Audio Video Interleave");
        _extensionsDatabase.Add(".mkv", "Matroska Video Container");
        _extensionsDatabase.Add(".zip", "ZIP Compressed Archive");
        _extensionsDatabase.Add(".rar", "RAR Compressed Archive");
        _extensionsDatabase.Add(".exe", "Windows Executable File");
        _extensionsDatabase.Add(".cs", "C# Source Code File");
        _extensionsDatabase.Add(".html", "HyperText Markup Language");
    }

    public string GetDescription(string extension)
    {
        if (string.IsNullOrWhiteSpace(extension))
        {
            return "Error: Input cannot be empty.";
        }

        //in case user do not put the value with "." e.g .pdf, add it
        string formattedExtension = extension.Trim();
        if (!formattedExtension.StartsWith("."))    
        {
            formattedExtension = "." + formattedExtension;
        }

        if (_extensionsDatabase.TryGetValue(formattedExtension, out string description))
        {
            return description;
        }
        else
        {
            Console.WriteLine("No information is stored on that file type....");
            Console.WriteLine("\nWould you like to add this new extension? (Yes/No)");
            string res = Console.ReadLine();
            if (res == "Yes" || res == "Y" || res == "yes" || res == "y")
            {
                if (!_extensionsDatabase.ContainsKey(formattedExtension))
                {
                    Console.WriteLine("\nHow would you like to save this extension? (e.g Portable Document Format)");
                    string newDescription = Console.ReadLine();
                    _extensionsDatabase.Add(formattedExtension, newDescription);
                    return $"{formattedExtension} saved as: {newDescription}";
                }
            }
            return "Action cancelled";
        }
    }
}
