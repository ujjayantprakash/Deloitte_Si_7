using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CS_project.Models;
using System.Security.Claims;
using CS_project.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CS_project.Areas.Identity.Data;

namespace CS_project.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly string wwwrootDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
        public string str;
        public IActionResult Index()
        {
            List<string> content = Directory.GetFiles(wwwrootDirectory, "*.pbix").Select(Path.GetFileName).ToList();

            return View(content);
        }
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var UserName = HttpContext.User.Identity.Name;
            str = UserName;
            return Ok(UserName);
        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormFile myFile)
        {
            var userName = User.FindFirstValue(ClaimTypes.Name);
            //var context = new CS_project_authContext();
            //var username = User.Identity.Name;

            //if (!string.IsNullOrEmpty(username))
            //{
            //    var user = context.Users.SingleOrDefault(u => u.UserName == username);
            //    string fullName = string.Concat(new string[] { user.firstName, " ", user.lastName });
            //}
                //var userName = User.FindFirst("firstName").Value;
                /*var userName = User.FindFirstValue(ClaimTypes.NameIdentifier);*///gives userid
                                                                                  // var userName = User.FindFirstValue(ClaimTypes.GivenName);
                if (myFile != null)
            {
                //preparing the path
                //var user = User.Identity.GetUserId();
                //System.Security.Claims.ClaimsPrincipal currentUser = this.User;
                //bool isAdmin = currentUser.IsInRole("Admin");
                //var id = _userManager.GetUserId(User);
                var ext = Path.GetExtension(myFile.FileName);
                if (ext.Equals(".pbix"))
                {
                    var path = Path.Combine(wwwrootDirectory, DateTime.Now.ToString("dd - MM - yyyy") + "____" + myFile.FileName + "____" + userName + "____"+DateTime.Now.Ticks.ToString()+Path.GetExtension(myFile.FileName));

                    //saving the file
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await myFile.CopyToAsync(stream);
                    }

                    //return RedirectToAction("Index");
                }
                //else
                //{
                //    TempData["Message"] = "This is my Error";
                //}
                return RedirectToAction("Index");
            }

            ViewData["error"] = "this is my error";
            return RedirectToAction("Index");
            //return View();
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

            return File(memory,contentType,fileName);

        }

    }
}
