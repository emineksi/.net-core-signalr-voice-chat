using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        // Kullanıcıdan gelen mesajı loglayabilirsiniz
        Console.WriteLine($"says: {message}");

        // Kullanıcıya mesajı geri gönder (echo)
        //await Clients.Caller.SendAsync("ReceiveMessage", message);

        // Basit bir chatbot mantığı
        await RespondToMessage(message);
    }

    private async Task RespondToMessage(string message)
    {
        var response = "";

        // Mesaj içeriğine göre basit cevaplar hazırla
        if (message.ToLower().Contains("merhaba"))
        {
            response = "Merhaba! Sana nasıl yardımcı olabilirim?";
        }
        else if (message.ToLower().Contains("nasılsın"))
        {
            response = "Ben bir botum, teşekkürler! Sen nasılsın?";
        }
        else if (message.ToLower().Contains("en büyük"))
        {
            response = "Fenerbahçe";
        }
        else
        {
            response = "Anlamadım, lütfen başka bir şey sor.";
        }

        // Cevabı kullanıcıya gönder
        await Clients.Caller.SendAsync("ReceiveMessage", response);
    }
}
