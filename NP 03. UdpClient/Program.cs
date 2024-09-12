using System.Net;
using System.Net.Sockets;
using System.Text;

var client = new UdpClient();

var connectEP = new IPEndPoint(IPAddress.Loopback, 27001);

List<string> messages = [
    @"/\_______",
    @"_/\______",
    @"__/\_____",
    @"___/\____",
    @"____/\___",
    @"_____/\__",
    @"______/\_",
    @"_______/\",
    @"________/",
    @"_________",
    @"\________"
];
var i = 0;
byte[] bytes = null;
while (true)
{
    bytes = Encoding.Default.GetBytes(messages[i++ % messages.Count]);
    client.Send(bytes, bytes.Length, connectEP);
    Thread.Sleep(100);
}
