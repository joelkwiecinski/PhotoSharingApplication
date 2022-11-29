using PhotoSharingApplication.Data;
using PhotoSharingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Controllers
{
    public class PhotoController: Controller
    {

        private PhotoDBContext context = new PhotoDBContext();

        public ActionResult Index()
        {
            return View("Index");
        }


        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos;
            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos
                          orderby p.CreatedDate descending
                          select p).Take(number).ToList();
            }
            return PartialView("_PhotoGallery", photos);

        }


        // GET: photo/display
        public ActionResult Display(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Display", photo);
        }


        // GET: photo/create
        public ActionResult Create()
        {
            Photo photo = new Photo();
            photo.CreatedDate = DateTime.Today;
            return View("Create", photo);
        }


        // POST: photo/create
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;

            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }
            }

            context.Photos.Add(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: photo/delete/id
        public ActionResult Delete(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo == null)
            {
                return HttpNotFound();
            }

            return View("Delete", photo);
        }



        // POST: photo/delete/id
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Photo photo = context.Photos.Find(id);
            context.Photos.Remove(photo);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: photo/getimage/id
        public FileContentResult GetImage(int id)
        {
            Photo photo = context.Photos.Find(id);
            if (photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}