using Microsoft.AspNetCore.Mvc;
using LibraryApp.Models;
using LibraryApp.Utils;
using LibraryApp.Models;

namespace Library.Areas.Management.Controllers;

[Area("Management")]
public class ContactController : Controller
{
    LibraryDbContext db = new LibraryDbContext();
    private readonly IWebHostEnvironment _hostEnvironment;
    public ContactController(IWebHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }
    public IActionResult Index()
    {
        var model = db.Contacts.FirstOrDefault();
        return View(model);
    }


    public IActionResult Edit(int id)
    {
        var model = db.Contacts.Find(id);
        if (model == null)
        {
            return Redirect("/Management/Contact/Index");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Contact model)
    {
        if (ModelState.IsValid)
        {
            var editModel = db.Contacts.Find(model.Id);
            if (editModel == null)
            {
                return Redirect("/Management/Contact/Index");
            }

            //if (img != null)
            //{
            //    await Utils.ImageUploader.DeleteImageAsync(_hostEnvironment, editModel.ImageUrl);
            //    editModel.ImageUrl = await Utils.ImageUploader.UploadImageAsync(_hostEnvironment, img);
            //}

            editModel.Title = model.Title;
            editModel.ImageUrl = model.ImageUrl;
            editModel.Description = model.Description;
            editModel.Status = model.Status;
            db.SaveChanges();
            return Redirect("/Management/Contact/Index");
        }
        return View(model);
    }

}