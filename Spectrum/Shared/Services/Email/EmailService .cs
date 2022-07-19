using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;

namespace Spectrum.Shared.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _mailConfig;
        private static string? _mailResponse;

        public EmailService(EmailSettings mailConfig)
        {
            _mailConfig = mailConfig;
        }


        public async Task<string> SendEmailByAPI(string toEmail ,string subject , EventModel eventModel)
        {
            // requires using System.Net.Http;
            // requires using System.Net.Http;
            var client = new HttpClient();
            // requires using System.Text.Json;
            //                    new EventModel { Id = 1, Subject = "Your Order is Ready to Collect", StartTime = DateTime.Now, EndTime = DateTime.Now, EmployeeId = 1 });

            var jsonData = JsonSerializer.Serialize(new
            {
                email = toEmail ,
                subject = subject,
                msg =  eventModel.Subject,
                startTime = eventModel.StartTime.ToString("MM/dd/yyyy hh:mm tt"),
                endTime = eventModel.EndTime.ToString("MM/dd/yyyy hh:mm tt"),
                location = "Spectrum Store",
                description = "Your order is ready to collect at Spectrum Store",
                itemId = eventModel.Id

            });


            HttpResponseMessage result = await client.PostAsync(
                // Requires DI configuration to access app settings. See https://docs.microsoft.com/azure/app-service/configure-language-dotnetcore#access-environment-variables
                _mailConfig.LogicAppApi,
                new StringContent(jsonData, Encoding.UTF8, "application/json"));

            return result.StatusCode.ToString();
        }


        public async Task<string> SendEmailAsync(string ToEmailName, string Subject, EventModel Data)
        {
            return await SendEmailAsync(new List<string>() { ToEmailName }, Subject, Data);
        }

        public async Task<string> SendEmailAsync(List<string> ToEmailName, string Subject, EventModel Data)
        {
            _mailResponse = string.Empty;

            using (SmtpClient smtpClient = new SmtpClient(_mailConfig.Host, _mailConfig.Port))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_mailConfig.Username, _mailConfig.Password);
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.SendCompleted += new SendCompletedEventHandler((object sender, AsyncCompletedEventArgs e) =>
                {
                    _mailResponse = (e.Error != null || e.Cancelled != false) ? "failure" : "success";
                });

                MailMessage message = new MailMessage
                {
                    From = new MailAddress(_mailConfig.Username, _mailConfig.DisplayName),
                    Subject = Subject,
                    SubjectEncoding = Encoding.UTF8,
                    BodyEncoding = Encoding.UTF8,
                    HeadersEncoding = Encoding.UTF8,
                    IsBodyHtml = true,
                    Body = GetEmailContent(Subject, Data),
                    Priority = MailPriority.High
                };
                foreach (string EmailName in ToEmailName)
                {
                    message.To.Add(new MailAddress(EmailName));
                }

                await smtpClient.SendMailAsync(message);
            }

            return _mailResponse;
        }

        public bool IsValidEmail(string EmailName)
        {
            return new EmailAddressAttribute().IsValid(EmailName);
        }

        private string GetEmailContent(string Title, EventModel Data)
        {
            string HTMLBody = string.Empty;

            using (FileStream fs = File.Open(Directory.GetCurrentDirectory() + "/Email_Template.html", FileMode.Open, FileAccess.ReadWrite))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    HTMLBody = sr.ReadToEnd();
                }
            }

            HTMLBody = HTMLBody.Replace("###EMAILTITLE###", Title);
            HTMLBody = HTMLBody.Replace("###EVENTSUBJECT###", Data.Subject ?? "(No Title)");
            HTMLBody = HTMLBody.Replace("###EVENTSTART###", Data.StartTime.ToString());
            HTMLBody = HTMLBody.Replace("###EVENTEND###", Data.EndTime.ToString());
            HTMLBody = HTMLBody.Replace("###EVENTLOCATION###", Data.Location ?? "NA");
            HTMLBody = HTMLBody.Replace("###EVENTDETAILS###", Data.Description ?? "NA");
            HTMLBody = HTMLBody.Replace("###CURRENTYEAR###", DateTime.Now.Year.ToString());

            return HTMLBody;
        }
    }
}