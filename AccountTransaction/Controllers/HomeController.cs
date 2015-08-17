using AccountTransaction.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountTransaction.Helper;


namespace AccountTransaction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public JsonResult FileUpload()
        //{
        //    //var check = ModelState.IsValid;
        //    string fileName = String.Empty;
        //    try
        //    {
        //        HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;

        //        //Check for extension at serveeside too
        //        //var supportedTypes = new[] { "jpg", "jpeg", "png" };

        //        //var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

        //        //if (!supportedTypes.Contains(fileExt))
        //        //{
        //        //    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
        //        //    return View();
        //        //}

        //        if (file.ContentLength > 0)
        //        {
        //            fileName = file.FileName;
        //            string mimeType = file.ContentType;
        //            using (System.IO.Stream fileContent = file.InputStream)
        //            {
        //                //UploadCsvFile(fileContent);

        //                // Add the file to server for future purpose and catching
        //                var path = Path.Combine(Server.MapPath("~/Folder_Drop/"), fileName);
        //                file.SaveAs(path);

        //                ViewBag.FileUploadStatus = "Success";
        //                return Json(String.Format("Succefull Uploaded and saved the file {0}", fileName));
        //            }
        //        }
        //        else
        //        {
        //            throw new Exception("The File format is not correect");
        //        }
        //    }

        //    catch (Exception)
        //    {
        //        Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //        ViewBag.FileUploadStatus = "Failed";
        //        return Json("Upload failed");
        //    }

        //}


        [HttpPost]
        public JsonResult FileUpload(UploadFileModel input)
        {
           // string directory = @"D:\Temp\";

            if (ModelState.IsValid)
            {
                //if (input != null && input.File != null && input.File.ContentLength > 0)
                //{
                //    var fileName = Path.GetFileName(input.File.FileName);
                //    input.File.SaveAs(directory+  fileName);
                //}

                //ConsoleApplication1.Program.CsvParse(input.File.InputStream);


                
               var transactionList= new MyCsvHelper().ReadFile(input.File.InputStream);
               TransactionHelper.Validation(transactionList);

               
                return Json(String.Format("Succefull Uploaded and saved the file {0}", input.File.FileName));
            }

            var errors = ModelState.Select(x => x.Value.Errors)
                          .Where(y => y.Count > 0)
                          .ToList();
            return Json("Model State is invalid");

        }


      

    }
}