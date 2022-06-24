using CS_project.Models;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CS_project.Controllers
{
    [Authorize]
    public class DatasetsController : Controller
    {
        [HttpGet]
        public IActionResult Index(List<Dataset> datasets = null)
        {
            datasets = datasets == null ? new List<Dataset>() : datasets;
            return View(datasets);
        }
        [HttpPost]
        [Obsolete]
        public IActionResult Index(IFormFile file,[FromServices] IHostingEnvironment hostingEnvironment)
        {
            string filename = $"{hostingEnvironment.WebRootPath}\\files\\{file.FileName}";
            using (FileStream filestream = System.IO.File.Create(filename))
            {
                file.CopyTo(filestream);
                filestream.Flush();
            }

            var datasets = this.GetDatasetList(file.FileName);
            return Index(datasets);
        }

        private List<Dataset> GetDatasetList(string fName)
        {
            List<Dataset> datasets = new List<Dataset>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        datasets.Add(new Dataset()
                        {
                            Name = reader.GetValue(0).ToString(),
                            Email = reader.GetValue(1).ToString(),
                            Amount = reader.GetValue(2).ToString(),
                            PhoneNo = reader.GetValue(3).ToString(),
                            Location = reader.GetValue(4).ToString()
                        }); 
                    }
                }
            }
            return datasets;
        }
    }
}
