using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using RestaurantApp.WebUI.Dtos.MailDtos;


namespace RestaurantApp.WebUI.Controllers
{
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreateMailDto createMailDto)
        {
            MimeMessage mineMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Restoran", "mail adres");
            mineMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
            mineMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = createMailDto.Body;
            mineMessage.Body = bodyBuilder.ToMessageBody();

            mineMessage.Subject = createMailDto.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mail adres", "kod");
            
            client.Send(mineMessage);
            client.Disconnect(true);


            return Redirect("/Home/Index");
        }
    }
}
