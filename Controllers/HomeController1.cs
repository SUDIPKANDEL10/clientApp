using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using clientApp.Models;
using CsvHelper;
using System.Text;


namespace clientApp.Controllers
{
    public class HomeController1 : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SubmitForm(ClientModel client)
        {
            if (ModelState.IsValid)
            {
                string dataDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
                string path = Path.Combine(dataDirectory, "clients.csv");

                try
                {
                    // Ensure the directory exists
                    if (!Directory.Exists(dataDirectory))
                    {
                        Directory.CreateDirectory(dataDirectory);
                    }

                    StringBuilder csvContent = new StringBuilder();

                    if (!System.IO.File.Exists(path))
                    {
                        csvContent.AppendLine("Name,Gender,Phone,Email,Address,Nationality,DateOfBirth,EducationBackground,PreferredContact");
                    }

                    csvContent.AppendLine($"{client.Name},{client.Gender},{client.Phone},{client.Email},{client.Address},{client.Nationality},{client.DOB},{client.Education},{client.PreferedContact}");

                    System.IO.File.AppendAllText(path, csvContent.ToString());
                    Console.WriteLine("Data written to CSV file successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing to CSV file: " + ex.Message);
                }

                return RedirectToAction("ClientList");
            }

            return View("Index", client);
        }


        [HttpGet]
        public IActionResult ClientList()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "clients.csv");
            List<ClientModel> clients = new List<ClientModel>();

            if (System.IO.File.Exists(path))
            {
                var csvLines = System.IO.File.ReadAllLines(path);
                foreach (var line in csvLines)
                {
                    var values = line.Split(',');

                    if (values[0] != "Name") // Skip header
                    {
                        clients.Add(new ClientModel
                        {
                            Name = values[0],
                            Gender = values[1],
                            Phone = values[2],
                            Email = values[3],
                            Address = values[4],
                            Nationality = values[5],
                            DOB = (values[6]),
                            Education = values[7],
                            PreferedContact = values[8]
                        });
                    }
                }
            }

            return View(clients);
        }
    }
}