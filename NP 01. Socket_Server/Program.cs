using System.Net;
using System.Net.Sockets;
using System.Text;

//var ipApdress = IPAddress.Parse("127.0.0.1");
var ipApdress = IPAddress.Parse("10.2.13.1");
var port = 27001;

Socket listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);

var endPoint = new IPEndPoint(ipApdress, port);
listener.Bind(endPoint);
var backlog = 1; // Budu sprashivat na sleduyushem uroke
listener.Listen(backlog);

Console.WriteLine("Listener listen...");

var length = 0;
var bytes = new byte[1024];
var message = string.Empty;

Socket client = null;
while (true)
{
    Console.WriteLine($"Listener listening on {listener.LocalEndPoint}");

    await Task.Run(() =>
    {
        do
        {
            client = listener.Accept();
            length = client.Receive(bytes);
            message = Encoding.Default.GetString(bytes, 0, length);
            Console.WriteLine($"{client.RemoteEndPoint}: {message}");
            if (message.ToLower() == "exit")
            {
                client.Shutdown(SocketShutdown.Both);
                client.Dispose();
                break;
            }

        } while (true);
    });
}
