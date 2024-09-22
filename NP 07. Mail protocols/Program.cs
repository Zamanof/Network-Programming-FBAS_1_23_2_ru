using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;
using System.Net;
using System.Net.Mail;
// SMTP, IMAP, POP3

//SMTP();
IMAP();
void SMTP()
{
    var client = new SmtpClient("smtp.gmail.com", 587);
    client.EnableSsl = true;
    client.Credentials = new NetworkCredential("fbms.1223@gmail.com",
        "elyymlmkboptutvz");
    var message = new MailMessage()
    {
        Subject = "For test",
        Body = "Безнадёжно — это когда на крышку гроба падает земля. Остальное можно исправить."
    };
    message.From = new MailAddress("fbms.1223@gmail.com", "Jason Statham");
    message.To.Add(new MailAddress("zamanov@itstep.org"));
    message.To.Add(new MailAddress("atillaismayil94@gmail.com"));
    message.To.Add(new MailAddress("bogoluba.extreme3000@gmail.com"));
    message.To.Add(new MailAddress("akkcamal@gmail.com"));
    message.To.Add(new MailAddress("aslanovalyaman515@gmail.com"));
    client.Send(message);
}

void IMAP()
{
    var imapClient = new ImapClient();
    imapClient.Connect("imap.gmail.com", 993, true);

    imapClient.Authenticate("fbms.1223@gmail.com", "elyymlmkboptutvz");

    var inbox = imapClient.GetFolder("Inbox");
    inbox.Open(FolderAccess.ReadWrite);

    var ids = inbox.Search(SearchQuery.All);
    foreach (var id in ids)
    {
        Console.WriteLine($"{id} {inbox.GetMessage(id).TextBody}");
    }

    //inbox.SetFlags([3, 5, 6, 7, 8, 9, 10, 11, 12], MessageFlags.Deleted, true);
    //inbox.Expunge();
    //inbox.Close();
}