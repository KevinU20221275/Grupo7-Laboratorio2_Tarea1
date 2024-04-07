using ClothingStore.Models;
using MailKit.Net.Smtp;
using MimeKit;

namespace ClothingStore.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(Dictionary<string, string> data)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(
                    _configuration["Mailtrap:EmailUsername"],
                    _configuration["Mailtrap:EmailFrom"]
                   ));

                message.To.Add(new MailboxAddress(data["RecepientName"], data["EmailTo"]));

                message.Subject = data["Subject"];

                var builder = new BodyBuilder();

                if (data["Subject"] == "Registro de Cliente")
                {
                    var templatePath = Path.Combine(Directory.GetCurrentDirectory(),
                    "EmailTemplates", "CustomerRegistrationEmail.html");

                    var templateContent = File.ReadAllText(templatePath);

                    templateContent = templateContent.Replace("@CustomerName", data["RecepientName"]);

                    builder.HtmlBody = templateContent;
                }
                else
                {
                    var templatePath = Path.Combine(Directory.GetCurrentDirectory(),
                        "EmailTemplates", "SaleEmail.html");

                    var templateContent = File.ReadAllText(templatePath);

                    templateContent = templateContent.Replace("@ProductName", data["ProductName"]);
                    templateContent = templateContent.Replace("@Quantity", data["Quantity"]);
                    templateContent = templateContent.Replace("@SaleDate", data["SaleDate"]);
                    templateContent = templateContent.Replace("@Total", data["Total"]);
                    templateContent = templateContent.Replace("@CustomerName", data["RecepientName"]);
                    templateContent = templateContent.Replace("@Email", data["EmailTo"]);
                    templateContent = templateContent.Replace("@Address", data["Address"]);

                    builder.HtmlBody = templateContent;
                }

                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    client.Connect(_configuration["Mailtrap:Host"],
                        int.Parse(_configuration["Mailtrap:Port"]),
                        false);

                    client.Authenticate(
                        _configuration["Mailtrap:Username"],
                        _configuration["Mailtrap:Password"]
                       );

                    client.Send(message);

                    client.Disconnect(true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
