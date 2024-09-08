using OpenQA.Selenium;

namespace EmailRPASystem;

public class EmailLoginService
{
    private readonly IWebDriver _webDriver;

    public EmailLoginService(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public async Task<bool> LoginToGmailAsync(string email, string password)
    {
        _webDriver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?service=mail");

        var emailField = _webDriver.FindElement(By.Id("identifierId"));
        emailField.SendKeys(email);
        _webDriver.FindElement(By.Id("identifierNext")).Click();

        await Task.Delay(3000);

        var passwordField = _webDriver.FindElement(By.Name("Passwd"));
        passwordField.SendKeys(password);
        _webDriver.FindElement(By.Id("passwordNext")).Click();

        await Task.Delay(5000);

        return _webDriver.Url.Contains("mail.google.com");
    }
}