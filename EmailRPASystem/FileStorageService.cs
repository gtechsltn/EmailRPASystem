namespace EmailRPASystem;

public class FileStorageService
{
    public void SaveToFile(string content, string filePath)
    {
        File.WriteAllText(filePath, content);
        Console.WriteLine($"Resumo salvo em: {filePath}");
    }
}