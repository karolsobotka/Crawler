using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {
            var websiteURL = args[0];
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(websiteURL);

           // Console.WriteLine(response);

            var content = await response.Content.ReadAsStringAsync();

            //Console.WriteLine(content);

            var regex = new Regex(@"\b[\w-\.]+@([\w-]+\.)+[\w-]{2,4}\b");

            var a = $"Conetent: {content}";
            var b = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

            var matchCollection = regex.Matches(content);

            

           foreach(Match line in regex.Matches(content))
            {
                Console.WriteLine($"{line.Index} : {line.Value}");
            }
        }   
    }
}
