using OpenAI.Chat;

namespace EmailRPASystem;

public class EmailSummaryService
{
    private readonly ChatClient _chatClient;

    public EmailSummaryService(string openAIApiKey)
    {
        _chatClient = new ChatClient("gpt-4o", openAIApiKey);
    }

    public async Task<string> SummarizeEmailsAsync(List<EmailRpa> emails)
    {
        var emailData = string.Join("\n\n", emails.Select(e => $"{e.Subject}: {e.Snippet}"));

        var prompt =
            $"Here are some recent emails:\n\n{emailData}\nPlease summarize the key points and list any pending actions.";
        var completion = await _chatClient.CompleteChatAsync(prompt);

        return completion.Value.ToString();
    }
}