using Microsoft.AspNetCore.Mvc;
using clientApp.Models;
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
        public IActionResult wwwroot(ClientViewModel clients)
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

                    csvContent.AppendLine($"{clients.Name},{clients.Gender},{clients.Phone},{clients.Email},{clients.Address},{clients.Nationality},{clients.DateOfBirth},{clients.EducationBackground},{clients.PreferredContact}");

                    System.IO.File.AppendAllText(path, csvContent.ToString());
                    Console.WriteLine("Data written to CSV file successfully.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error writing to CSV file: " + ex.Message);
                }

                return RedirectToAction("ClientList");
            }

            return View("Index", clients);
        }


        [HttpGet]
        public IActionResult ClientList()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "clients.csv");
            List<ClientViewModel> clients = new List<ClientViewModel>();

            if (System.IO.File.Exists(path))
            {
                var csvLines = System.IO.File.ReadAllLines(path);
                foreach (var line in csvLines)
                {
                    var values = line.Split(',');

                    if (values[0] != "Name") // Skip header
                    {
                        clients.Add(new ClientViewModel
                        {
                            Name = values[0],
                            Gender = values[1],
                            Phone = values[2],
                            Email = values[3],
                            Address = values[4],
                            Nationality = values[5],
                            DateOfBirth = (values[6]),
                            EducationBackground = values[7],
                            PreferredContact = values[8]
                        });
                    }
                }
            }

            return View(clients);
        }
    }
}