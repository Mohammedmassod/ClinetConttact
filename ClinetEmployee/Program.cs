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

            /*HttpClient client = new HttpClient();
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

            }*/

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

            /* string url = "https://localhost:44372/api/Employees?id=6";
             using (HttpClient client = new HttpClient())
             {
                 HttpResponseMessage response = await client.DeleteAsync(url);
                 Console.WriteLine(response.StatusCode.ToString());
             }*/
            //

            //
            var pepoleurl = "https://localhost:44372/api/Employees";
            using (var httpClient = new HttpClient())
            {
                var Employees = new Employees() { EmployeesId = 7, FirstName = "mohsin", LastName = "saleh", Email = "mohsin@saleh.com", PhoneNumber = "774786554" };
                //create the employees
                var responseMessage = await httpClient.PostAsJsonAsync(pepoleurl, Employees);
                responseMessage.EnsureSuccessStatusCode();
                var contect = await responseMessage.Content.ReadAsStringAsync();
                var EmployeesId = int.Parse(contect);

                // Http PUT
                Employees.EmployeesId = EmployeesId;
                Employees.FirstName = "UpDate";
                await httpClient.PutAsJsonAsync($"(pepoleurl)/(Employees)", Employees);

                var people = await httpClient.GetFromJsonAsync<List<Employees>>(pepoleurl);

                await httpClient.DeleteAsync($"(pepoleurl)/(Employees)", EmployeesId);
                var people2 = await httpClient.GetFromJsonAsync<List<Employees>>(pepoleurl);
            }
                //
        }
    }

}
