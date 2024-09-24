using System.Net;
//getFtp();

//DownloadFtp();

UploadFtp();
void getFtp()
{
    var request = WebRequest.Create("ftp://localhost:21") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
    var response = request.GetResponse() as FtpWebResponse;
    var stream = response.GetResponseStream();
    var sr = new StreamReader(stream);
    var data = sr.ReadToEnd();
    Console.WriteLine(data);
}

void DownloadFtp()
{
    var request = WebRequest.Create("ftp://localhost:21/It Step Baku.mp4") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.DownloadFile;

    var responce = request.GetResponse() as FtpWebResponse;
    var stream = responce.GetResponseStream();
    var fs = new FileStream("video.mp4", FileMode.Create);
    stream.CopyTo(fs);
    fs.Close();
    stream.Close();
}

void UploadFtp()
{
    var request = WebRequest.Create("ftp://localhost:21/for attilla.txt") as FtpWebRequest;
    request.Method = WebRequestMethods.Ftp.UploadFile;

    using var fs = new FileStream("Atilla.txt", FileMode.Open);
    using var stream = request.GetRequestStream();
    fs.CopyTo(stream);
}
