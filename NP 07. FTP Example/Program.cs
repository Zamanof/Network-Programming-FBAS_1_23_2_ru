using System.Net;
getFtp();
void getFtp()
{
    var request = WebRequest.Create("ftp://13.88.206.233") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var sr = new StreamReader(stream);
    var data = sr.ReadToEnd();
    Console.WriteLine(data);
}
