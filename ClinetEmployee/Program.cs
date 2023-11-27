using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClinetEmployee
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //start-show

            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://localhost:44372/api/Employees");
            responseTask.Wait();
            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var massegeTask = result.Content.ReadAsStringAsync();
                    massegeTask.Wait();
                    Console.WriteLine("massege for WebApi" + massegeTask.Result);
                    Console.ReadLine();

                }

            }

            //end-show

            //start-Create
            /* string url = "https://localhost:44372/api/Employees";
             var client = new RestClient(url);
             var request = new RestRequest();
             var body = new Employees { EmployeeId = 5, FirstName = "hosin", LastName = "ali", Email = "hosin@ali.com", PhoneNumber = "774653224" };
             request.AddJsonBody(body); // استخدم AddJsonBody بدلاً من AddBody لتعيين الجسم باستخدام تنسيق JSON
             var response = await client.PostAsync(request); // استخدم await للانتظار على الاستجابة
             Console.WriteLine(response.StatusCode.ToString() + "  " + response.Content.ToString());
             Console.Read();*/
            //End-Create


            //

            //

            //
           
            //
        }
    }

}
