namespace Market.Utilities;

public class Utility
{
    private readonly static string _filePath = "C:\\Users\\Zahra\\Desktop\\Store\\Store\\Logs\\TextFile.txt";

    public static string SetLog(string message)
    {
        File.AppendAllText(_filePath, $"\n{message} - {DateTime.Now}");

        File.AppendAllText(_filePath, "\n------------------------------------------");

        return "Internal Server Error";
    }
}