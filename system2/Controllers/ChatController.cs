using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using system2.Data;
using system2.Models;
using system2.ViewModels;

namespace system2.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ChatController(ApplicationDbContext db)
        {
            _db = db;
        }

        private string[] tagsAllowed = new string[] { "<h2>", "</h2>", "<h3>", "</h3>" };

        public IActionResult Index()
        {
            IEnumerable<Comments> objList = _db.Comment.ToList();
            return View(objList);

        }

        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Comments comment)
        {
            if (ModelState.IsValid)
            {
                string encodedContent = HttpUtility.HtmlEncode(comment.Message);

                foreach (var tag in tagsAllowed)
                {
                    var encodedTag = HttpUtility.HtmlEncode(tag);
                    encodedContent = encodedContent.Replace(encodedTag, tag);
                }

                comment.Message = encodedContent;

                _db.Add(comment);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comment);
        }

        [Authorize(Roles = "Manager")]
        public IActionResult Delete(int? id)
        {
            var obj = _db.Comment.FirstOrDefault(u => u.Id == id);
            _db.Comment.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index", "Chat");

        }

    }


}
