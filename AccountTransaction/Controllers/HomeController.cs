using AccountTransaction.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AccountTransaction.Helper;
using AccountTransaction.DAL;


namespace AccountTransaction.Controllers
{
    public class HomeController : Controller
    {
        private ITransactionDb _db = new TransactionContext();

        public ActionResult Index()
        {
            return View();
        }


        //File Uploader
        [HttpPost]
        public JsonResult FileUpload(UploadFileModel input)
        {
            try
            {
                if (ModelState.IsValid && input.File.ContentLength > 0)
                {
                    var path = Path.Combine(Server.MapPath("~/File_Drop/"), input.File.FileName);

                    if (!System.IO.File.Exists(path))
                    {
                        var transactionList = MyCsvHelper.ReadFile(input.File.InputStream);
                        var result = TransactionHelper.ValidateFile(ref transactionList);

                        //Inserting the record to DB using Bulk Insert
                        _db.Add(transactionList);

                        ViewBag.FileUploadStatus = "Success";

                        //Saving the file after the Insertion is successful.
                        input.File.SaveAs(path);

                        return Json(new
                        {
                            RecordsUploaded = result.Item1,
                            RecordsSkipped = result.Item2
                        }, JsonRequestBehavior.AllowGet);
                    }

                    else
                    {
                        Response.StatusCode = (int)HttpStatusCode.Conflict;
                        ViewBag.FileUploadStatus = "Failed";
                        return Json("This File is already uploaded. Please select a new file", JsonRequestBehavior.AllowGet);
                    }

                }

                else
                {
                    var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json(allErrors);
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.FileUploadStatus = "Failed";
                return Json("Please check the file and try again");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}