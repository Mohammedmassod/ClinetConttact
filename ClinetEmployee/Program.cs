using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClinetEmployee
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            bool continueExecution = true;

            while (continueExecution)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Update");
                Console.WriteLine("4. Retrieve");
                Console.WriteLine("5. RetrieveAllContacts");
                Console.WriteLine("6. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        await AddContact();
                        break;
                    case 2:
                        await DeleteContact();
                        break;
                    case 3:
                        await UpdateContact();
                        break;
                    case 4:
                        await RetrieveContact();
                        break;
                    case 5:
                        await RetrieveAllContacts();
                        break;
                    case 6:
                        continueExecution = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }

        // الدالة لإضافة جهة اتصال جديدة
        static async Task AddContact()
        {
            Console.WriteLine("Enter first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter phone number:");
            string phoneNumber = Console.ReadLine();

            var newContact = new
            {
                contactId = 1,
                firstName,
                lastName,
                email,
                phoneNumber
            };

            string url = "https://localhost:7101/api/Contact";
            var content = new StringContent(JsonConvert.SerializeObject(newContact), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data added successfully");
            }
            else
            {
                Console.WriteLine("Add operation failed");
            }
            Console.ReadLine();
        }
        static async Task DeleteContact()
        {
            Console.WriteLine("Enter contact ID to delete:");
            int idToDelete = int.Parse(Console.ReadLine());

            var response = await client.DeleteAsync($"https://localhost:7101/api/Contact/{idToDelete}");

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine($"Data with ID {idToDelete} deleted successfully");
            }
            else
            {
                Console.WriteLine($"Failed to delete data with ID {idToDelete}. Status code: {response.StatusCode}");
            }
            Console.ReadLine();

        }

        static async Task UpdateContact()
        {
            Console.WriteLine("Enter contact ID to update:");
            int contactId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter new first name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter new last name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter new email:");
            string email = Console.ReadLine();

            Console.WriteLine("Enter new phone number:");
            string phoneNumber = Console.ReadLine();

            var contact = new
            {
                ContactId = contactId,
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            var json = JsonConvert.SerializeObject(contact);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"https://localhost:7101/api/Contact/{contactId}", content);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data edited successfully");
            }
            else
            {
                Console.WriteLine("Edit operation failed");
            }
            Console.ReadLine();

        }

        static async Task RetrieveContact()
        {
            Console.WriteLine("Enter contact ID to retrieve:");
            int contactId = int.Parse(Console.ReadLine());

            string apiUrl = $"https://localhost:7101/api/Contact/{contactId}";

            var getResponse = await client.GetAsync(apiUrl);

            if (getResponse.IsSuccessStatusCode)
            {
                var responseBody = await getResponse.Content.ReadAsStringAsync();
                Console.WriteLine($"Contact data: {responseBody}");
            }
            else
            {
                Console.WriteLine($"Failed to retrieve contact data. Status code: {getResponse.StatusCode}");
            }
            Console.ReadLine();
        }
       static async Task RetrieveAllContacts()
{
    var response = await client.GetAsync("https://localhost:7101/api/Contact");

    if (response.IsSuccessStatusCode)
    {
        var responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine($"All Contacts data: {responseBody}");
    }
    else
    {
        Console.WriteLine($"Failed to retrieve all contacts. Status code: {response.StatusCode}");
    }
    Console.ReadLine();
}



    }
}
