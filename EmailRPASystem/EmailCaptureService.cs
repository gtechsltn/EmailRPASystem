using OpenQA.Selenium;

namespace EmailRPASystem;

public class EmailCaptureService
{
    private readonly IWebDriver _webDriver;

    public EmailCaptureService(IWebDriver webDriver)
    {
        _webDriver = webDriver;
    }

    public List<EmailRpa> CaptureRecentEmails(int emailCount = 5)
    {
        var emails = new List<EmailRpa>();
        var emailElements = _webDriver.FindElements(By.XPath("//tr[@class='zA zE']"));

        foreach (var emailElement in emailElements.Take(emailCount))
        {
            var subject = emailElement.FindElement(By.CssSelector(".bog")).Text;
            var snippet = emailElement.FindElement(By.CssSelector(".y2")).Text;

            emails.Add(new EmailRpa
            {
                Subject = subject,
                Snippet = snippet
            });
        }

        return emails;
    }
}