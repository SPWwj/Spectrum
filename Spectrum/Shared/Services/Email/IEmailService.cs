namespace Spectrum.Shared.Services.Email
{
    public interface IEmailService
    {
        Task<string> SendEmailAsync(string ToEmailName, string Subject, EventModel Data);
        Task<string> SendEmailAsync(List<string> ToEmailNames, string Subject, EventModel Data);
        bool IsValidEmail(string EmailName);
    }
}
