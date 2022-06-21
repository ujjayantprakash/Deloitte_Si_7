﻿using Microsoft.AspNetCore.Authorization;
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
    public class TestController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public IActionResult Index()
        {
            List<string> content = Directory.GetFiles(wwwrootDirectory, "*.jpg").Select(Path.GetFileName).ToList();

            return View(content);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myFile)
        {
            if(myFile != null)
            {
                //preparing the path
                var path = Path.Combine(wwwrootDirectory, DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName));

                //saving the file
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DownloadFile(string filePath)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", filePath);

            var memory = new MemoryStream();

            using (var stream = new FileStream(path,FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }

            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);

        }

    }
}