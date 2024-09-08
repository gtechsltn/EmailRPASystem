using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace EmailRPASystem;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var email = "your-email@gmail.com";
        var password = "your-password";
        var openAIApiKey = "your-openai-api-key";
        var filePath = "ResumeEmails.txt";

        using (IWebDriver webDriver = new ChromeDriver())
        {
            var loginService = new EmailLoginService(webDriver);
            var captureService = new EmailCaptureService(webDriver);
            var summaryService = new EmailSummaryService(openAIApiKey);
            var fileStorageService = new FileStorageService();

            var loginSuccess = await loginService.LoginToGmailAsync(email, password);
            if (!loginSuccess)
            {
                Console.WriteLine("Falha no login. Verifique suas credenciais.");
                return;
            }

            var emails = captureService.CaptureRecentEmails(10);

            var summary = await summaryService.SummarizeEmailsAsync(emails);

            fileStorageService.SaveToFile(summary, filePath);
        }
    }
}