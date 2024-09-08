using System.Net.Sockets;
using System.Net;
using System.Text;

var ipAddress = IPAddress.Loopback;
var port = 27001;

Socket client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Dgram,
    ProtocolType.Udp);

var connEP = new IPEndPoint(ipAddress, port);

var message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam accumsan massa lorem, at condimentum felis condimentum at. Ut sagittis neque sed sapien feugiat posuere. Morbi congue ex id gravida ullamcorper. Praesent ullamcorper enim non dui lacinia feugiat. Pellentesque aliquam quam lorem, vestibulum aliquam lectus sagittis sollicitudin. Sed odio orci, euismod eu lobortis sed, tristique sit amet velit. Curabitur quis ligula nec lacus auctor ultricies. Donec ultricies semper eleifend.
Morbi semper, lacus sit amet varius sodales, odio erat lobortis sem, sit amet ullamcorper ex justo nec ante. Integer aliquam nulla volutpat magna semper porta. Donec eu augue scelerisque, dignissim ligula faucibus, aliquet sem. Nunc vulputate pharetra est, quis vehicula nunc hendrerit et. Fusce sollicitudin justo tellus, eu ornare sem aliquam et. Suspendisse purus purus, ullamcorper vel suscipit vel, condimentum vel quam. Mauris mattis iaculis nulla ac semper. Duis egestas dolor vel dignissim rutrum. Mauris in quam ultricies risus consectetur finibus id eget justo. Nam porttitor mauris non lectus semper cursus. Etiam faucibus sit amet velit in rutrum.
Proin egestas turpis sit amet dolor viverra ullamcorper. Mauris et vehicula nibh. Nunc semper, enim id dapibus feugiat, neque diam aliquam urna, eu placerat libero dolor id quam. Phasellus tortor sapien, pellentesque vel tincidunt a, aliquet ut ipsum. Integer fringilla ex a nulla pretium, eu egestas mauris laoreet. Aenean tempor non dui a euismod. Pellentesque volutpat tristique mi interdum commodo.
In hac habitasse platea dictumst. Pellentesque quis lacus quis dui hendrerit vulputate non ac mauris. Maecenas porta enim et nunc elementum hendrerit. Nulla imperdiet vestibulum felis eget pulvinar. Suspendisse cursus velit id diam euismod ullamcorper. Vestibulum condimentum rhoncus efficitur. Sed rutrum sollicitudin lacus, sit amet dictum nibh vestibulum non. Suspendisse malesuada ut dui vitae rutrum. Aliquam ornare a augue vitae congue. Nunc varius, urna dictum laoreet semper, metus mi elementum ipsum, nec vehicula mi lorem sed erat. Quisque vel dolor est. Vestibulum ut dictum nunc.
Praesent aliquet vitae augue eget interdum. Vivamus efficitur tempus mauris sit amet dictum. Cras consequat, libero eu varius dapibus, magna velit tristique odio, a faucibus diam lacus nec ligula. Morbi non urna mattis, pharetra odio sed, pretium nulla. Aenean id sapien nec ex scelerisque accumsan at eget nisi. Praesent ligula leo, bibendum at dictum vel, porttitor vitae dui. Ut ac elementum sapien. Suspendisse laoreet sed leo eget lobortis. Sed aliquet ac enim nec tempor. Sed sapien turpis, elementum feugiat tempor eu, ornare ut lacus.";

int count = 0;
while (true)
{
    var bytes = Encoding
        .Default
        .GetBytes(message[count++ % message.Length].ToString());
    Thread.Sleep (100);
    client.SendTo(bytes, connEP);
}
