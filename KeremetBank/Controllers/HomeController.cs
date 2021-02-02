using KeremetBank.Data;
using KeremetBank.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KeremetBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BankClientsContext _context;
        private readonly IWebHostEnvironment _appEnvironment;
        public HomeController(ILogger<HomeController> logger, BankClientsContext context, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult ExportToExcel(string SocialNumber)
        {            
            string filePath = Path.Combine(_appEnvironment.ContentRootPath, "Template/example.xlsx");
            string filePathRes = Path.Combine(_appEnvironment.ContentRootPath, "Result/result.xlsx");
            FileInfo filetemplate = new FileInfo(filePath);
            FileInfo fileresult = new FileInfo(filePathRes);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Client client = _context.Clients.FirstOrDefault(s => s.SocialNumber == SocialNumber);

            using (var excelPackage = new ExcelPackage(filetemplate))
            {                
               ExcelWorksheet sheet = excelPackage.Workbook.Worksheets["Лист1"];
               var range = sheet.SelectedRange[3, 2, 10, 9];
                
                for (int i = 3; i< 9; i++)
                {
                    for (int j = 1; j< 10; j++)
                    {
                        if(range[i, j].Value != null)
                        {
                            string value = range[i, j].Value.ToString();
                            if (value == "[ID]")
                            {
                                sheet.SetValue(i, j, client.Id);
                            }
                            else if (value == "[Name]")
                            {
                                sheet.SetValue(i, j, client.Name);
                            }
                            else if (value == "[BirthDate]")
                            {
                                sheet.SetValue(i, j, client.BirthDate.ToString());
                            }
                            else if (value == "[PhoneNumber]")
                            {
                                sheet.SetValue(i, j, client.PhoneNumber);
                            }
                            else if (value == "[Address]")
                            {
                                sheet.SetValue(i, j, client.Address);
                            }
                            else if (value == "[SocialNumber]")
                            {
                                sheet.SetValue(i, j, client.SocialNumber);
                            }
                        }

                    }
                }
                excelPackage.SaveAs(fileresult);
            }
            return View("Privacy");
        }
        public IActionResult Privacy()
        {
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
