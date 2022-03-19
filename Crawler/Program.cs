using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        public async static Task Main(string[] args)
        {

            
            if (args.Length == 0)
            {
                throw new ArgumentNullException("Podaj adres URL");
            }

            var websiteURL = args[0];

            if (!(Uri.IsWellFormedUriString(websiteURL, UriKind.Absolute)))
            {
                throw new ArgumentException("Podaj poprawny adres URL");
            }

            var httpClient = new HttpClient();

            try
            {
                var response = await httpClient.GetAsync(websiteURL);


                var content = await response.Content.ReadAsStringAsync();


                var regex = new Regex(@"\b[\w-\.]+@([\w-]+\.)+[\w-]{2,4}\b");

                var a = $"Conetent: {content}";
                var b = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

                var matchCollection = regex.Matches(content);

                HashSet<string> hashSet = new HashSet<string>();


                foreach (Match line in matchCollection) 
                {
                    hashSet.Add(line.Value); 
                }

                if (hashSet.Count >= 1)
                        foreach (string str in hashSet)
                            Console.WriteLine(str);
                    else
                        Console.WriteLine("Haven't found e-mail addresses");
                

                
            }catch(Exception e)
            {
                Console.WriteLine("Błąd podczas pobierania strony: " + e.Message);
            }
            

            finally
            {
                httpClient.Dispose();
            }

        }   
    }
}
