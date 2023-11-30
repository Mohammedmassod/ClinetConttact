using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClinetEmployee
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            //start-show

            /*   HttpClient client = new HttpClient();
               var responseTask = client.GetAsync("https://localhost:7101/api/Contact");
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
            //حذف عنصر بارقم
            /* int idToDelete = 1004; // تعيين قيمة الـ ID التي ترغب في حذفها

             HttpClient client = new HttpClient();
             var responseTask = client.DeleteAsync($"https://localhost:7101/api/Contact?id={idToDelete}");
             responseTask.Wait();

             if (responseTask.IsCompleted)
             {
                 var result = responseTask.Result;
                 if (result.IsSuccessStatusCode)
                 {
                     Console.WriteLine($"Data with ID {idToDelete} deleted successfully");
                     // أي تعليمات أو شيء آخر بعد حذف البيانات
                 }
                 else
                 {
                     Console.WriteLine($"Failed to delete data with ID {idToDelete}. Status code: {result.StatusCode}");
                     // إذا كان هناك أي سبب لفشل الحذف يمكنك إضافة تعليمات هنا
                 }
             }
             Console.ReadLine(); // هذا السطر يجبر البرنامج على الانتظار قبل الإغلاق
 */
            //نهاية كود الحذف بالرقم


            //بداية كود انشاء <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // البيانات الجديدة التي تريد إدخالها
            /*  var newContact = new
              {
                  contactId = 1,
                  firstName = "ali",
                  lastName = "ali",
                  email = "ali@ali.com",
                  phoneNumber = "123456789"
              };

              string url = "https://localhost:7101/api/Contact"; // عنوان الخدمة

              // يحول الكائن إلى JSON ويقوم بإرساله إلى الخدمة
              var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(newContact), System.Text.Encoding.UTF8, "application/json");

              using (var client = new HttpClient())
              {
                  var response = await client.PostAsync(url, content);

                  if (response.IsSuccessStatusCode)
                  {
                      Console.WriteLine("Data added successfully");
                  }
                  else
                  {
                      Console.WriteLine("Add operation failed");
                  }
              }

              Console.ReadLine(); // هذا السطر يجبر البرنامج على الانتظار قبل الإغلاق
  */
            //نهاية كود انشا>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>


            //بداية كود التعديل 

          /*  var client = new HttpClient();
            var contact = new Contact
            {
                // قم بتحديث البيانات التي ترغب في تعديلها في كائن Contact هنا
                ContactId = 3, // تحديد رقم الاتصال الذي تريد تعديله
                FirstName = "ali",
                LastName = "nasser",
                Email = "ali@ali.com",
                PhoneNumber = "774785445"
                // يمكنك تحديث الحقول الأخرى إذا كانت بياناتك تتضمن ذلك
            };

            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync("https://localhost:7101/api/Contact", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data edit successfully");

                Console.ReadLine(); // هذا السطر يجبر البرنامج على الانتظار قبل الإغلاق

            }
            else
            {
                // فشل في التحديث
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Edit operation failed");

                Console.ReadLine(); // هذا السطر يجبر البرنامج على الانتظار قبل الإغلاق

                // إجراءات للتعامل مع الخطأ
            }
*/

            //نهاية كود التعديل

            //بداية كود الجلب بالرقم

            // رقم جهة الاتصال التي تريد جلب بياناتها
            int contactId = 1007; // يمكنك تغييرها إلى الرقم المطلوب

            // رابط الطلب لجلب بيانات جهة الاتصال
            string apiUrl = $"https://localhost:7101/api/Contact/{contactId}";

            // إعداد طلب HTTP GET
            using (var httpClient = new HttpClient())
            {
                // إرسال طلب HTTP GET
                var getResponse = await httpClient.GetAsync(apiUrl);

                if (getResponse.IsSuccessStatusCode)
                {
                    // قراءة البيانات المسترجعة
                    var responseBody = await getResponse.Content.ReadAsStringAsync();
                    Console.WriteLine($"بيانات جهة الاتصال: {responseBody}");
                    // يمكنك تحويل البيانات النصية إلى كائن Contact هنا إذا كنت ترغب
                }
                else
                {
                    Console.WriteLine($"فشل في جلب بيانات جهة الاتصال. الرمز الناتج: {getResponse.StatusCode}");
                    // يمكنك إضافة تعليمات في حالة حدوث أي خطأ أثناء جلب البيانات هنا
                }
            }

            Console.ReadLine(); // هذا السطر يجبر البرنامج على الانتظار قبل الإغلاق

            //نهاية كود الجلب بالرقم



        }
    }

}
/*create database db;


use db;
CREATE TABLE [dbo].[Employees](
	[EmployeesId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](200) NOT NULL,
	[LastName] [varchar](200)NOT NULL,
	[Email] [varchar](200) NOT NULL,
	[PhoneNumber] [varchar](200) NOT NULL,
	)
drop table Employees;
INSERT INTO Employees ( FirstName, LastName, Email, PhoneNumber)
VALUES ( 'mohammed', 'massowd', 'mohammed@massowd.com', '774785445');

INSERT INTO Employees ( FirstName, LastName, Email, PhoneNumber)
VALUES ('taha', 'massowd', 'taha@massowd.com', '774785446');
*/