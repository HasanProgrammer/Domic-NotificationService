namespace Domic.UseCase.SmsUseCase.DTOs;

public class SignInMessage
{
    public string PhoneNumber { get; set; }
    public string OtpCode { get; set; }
}