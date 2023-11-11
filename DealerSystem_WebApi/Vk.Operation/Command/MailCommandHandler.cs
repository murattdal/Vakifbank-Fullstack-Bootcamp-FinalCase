using BaseLayer.Response;
using MediatR;
using System.Net;
using System.Net.Mail;


namespace OperationLayer.Command;

public class MailCommandHandler :
    IRequestHandler<CreateMailCommand, ApiResponse>
{
    public MailCommandHandler() { }

    public async Task<ApiResponse> Handle(CreateMailCommand request, CancellationToken cancellationToken)
    {
        MailMessage myMessage = new MailMessage();
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("dealersystem@outlook.com", "Wasd1234?");
        client.Port = 587;
        client.Host = "smtp-mail.outlook.com";
        client.EnableSsl = true;
        myMessage.To.Add(request.Model.Email);
        myMessage.From = new MailAddress("dealersystem@outlook.com");
        myMessage.Subject = request.Model.Name;
        myMessage.Body = request.Model.Description;

        client.Send(myMessage);
        return new ApiResponse();
    }

}
