using NP_05._HttpClient_example;
using System.Text.Json;

var postClient = new HttpClient();
var message = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri(@"https://jsonplaceholder.typicode.com/posts")
};
// .GetAsync(), .PostAsync(), .DeleteAsync() ...
var responce = await postClient.SendAsync(message);
var json = await responce.Content.ReadAsStringAsync();
//Console.WriteLine(json);
var posts = JsonSerializer.Deserialize<List<Post>>(json);

foreach(var post in posts!)
{
    Console.WriteLine(post);
}