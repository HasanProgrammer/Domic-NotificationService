using Domic.UseCase.Commons.DTOs;
using Domic.UseCase.EmailUseCase.Contracts.Interfaces;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Domic.Infrastructure.Implementations.UseCase.Services.SmsIr;

public class LiaraEmailProvider : IEmailProvider
{
    public async Task<string> SendVerifyCodeAsync(EmailPayload payload, CancellationToken cancellationToken)
    {
        var smtpHost = Environment.GetEnvironmentVariable("MAIL_HOST") ?? "smtp.c1.liara.email";
        var smtpPort = int.Parse(Environment.GetEnvironmentVariable("MAIL_PORT") ?? "465");
        var smtpUser = Environment.GetEnvironmentVariable("MAIL_USER") ?? "";
        var smtpPassword = Environment.GetEnvironmentVariable("MAIL_PASSWORD") ?? "";
        var mailFromAddress = Environment.GetEnvironmentVariable("MAIL_FROM_ADDRESS") ?? "";
        
        var email = new MimeMessage();
        
        var messageContent = string.Format("آکادمی داتریس؛ \n کد اعتبارسنجی پست الکترونیکی شما : {0}", payload.MessageContent);
        
        email.From.Add(MailboxAddress.Parse(mailFromAddress));
        email.To.Add(MailboxAddress.Parse(payload.EmailAddress));
        email.Subject = "Verify Code";
        email.Body = new TextPart("plain") { Text = messageContent };

        email.Headers.Add("x-liara-tag", "test-tag");

        using var client = new SmtpClient();

        await client.ConnectAsync(smtpHost, smtpPort, SecureSocketOptions.SslOnConnect);
        await client.AuthenticateAsync(smtpUser, smtpPassword);
        await client.SendAsync(email);
        await client.DisconnectAsync(true);

        return messageContent;
    }
}