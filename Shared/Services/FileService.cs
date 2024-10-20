using Resources.Enums;

namespace Resources.Services;

public class FileService(string filePath)
{
    private readonly string _filePath = filePath;

    public ResultStatus SaveToFile (string content)
    {
        try
        {
            using var sw = new StreamWriter(_filePath);
            sw.WriteLine(content);
            return ResultStatus.Success;
        }
        catch(FileNotFoundException)
        {
            return ResultStatus.FileNotFound;
        }
        catch (Exception)
        {
            return ResultStatus.Failed;
        }

    }
    public string GetFromFile()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                using var sr = new StreamReader(_filePath);
                var content = sr.ReadToEnd();
                return content;
            }
        }
        catch { }

        return null!;
    }
}
