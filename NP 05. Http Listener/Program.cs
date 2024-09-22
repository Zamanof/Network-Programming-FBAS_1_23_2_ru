﻿using System.Net;

var listener = new HttpListener();
listener.Prefixes.Add(@"http://localhost:27001/");
listener.Start();

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;
    response.AddHeader("Content-Type", "text/plain");
    //var rawUrl = request.RawUrl; 
    //Console.WriteLine(rawUrl);
    //foreach(string key in request.QueryString.Keys)
    //{
    //    Console.WriteLine($"key: {key} - {request.QueryString[key]}");
    //}
    StreamWriter writer = new StreamWriter(response.OutputStream);
    //writer.WriteLine($"Salam {request.QueryString["name"]}");

    writer.WriteLine(@$"<h1 style='color:Aqua'>Salam {request.QueryString["name"]}</h1>");
    writer.WriteLine($@"<a href='https://google.az/search?q={request.QueryString["name"]}'>Search</a>");
    writer.WriteLine($@"<img src='data:image/jpeg;base64,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'/>");
    writer.Close();
}