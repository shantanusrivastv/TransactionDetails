using AccountTransaction.Models;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace AccountTransaction.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FileUpload()
        {
            //var check = ModelState.IsValid;
            string fileName = String.Empty;
            try
            {
                HttpPostedFileBase file = Request.Files[0] as HttpPostedFileBase;

                //Check for extension at serveeside too
                //var supportedTypes = new[] { "jpg", "jpeg", "png" };

                //var fileExt = System.IO.Path.GetExtension(photo.FileName).Substring(1);

                //if (!supportedTypes.Contains(fileExt))
                //{
                //    ModelState.AddModelError("photo", "Invalid type. Only the following types (jpg, jpeg, png) are supported.");
                //    return View();
                //}

                if (file.ContentLength > 0)
                {
                    fileName = file.FileName;
                    string mimeType = file.ContentType;
                    using (System.IO.Stream fileContent = file.InputStream)
                    {
                        //UploadCsvFile(fileContent);

                        // Add the file to server for future purpose and catching
                        var path = Path.Combine(Server.MapPath("~/Folder_Drop/"), fileName);
                        file.SaveAs(path);

                        ViewBag.FileUploadStatus = "Success";
                        return Json(String.Format("Succefull Uploaded and saved the file {0}", fileName));
                    }
                }
                else
                {
                    throw new Exception("The File format is not correect");
                }
            }

            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                ViewBag.FileUploadStatus = "Failed";
                return Json("Upload failed");
            }

        }

        static int count = 0;
        protected void ClearOutput()
        {
            DTE2 ide = (DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject("VisualStudio.DTE.12.0");
            ide.ToolWindows.OutputWindow.OutputWindowPanes.Item("Debug").Clear();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ide);
        }
        public void UploadCsvFile(Stream stm)
        {
            try
            {
                using (var csvReader = new StreamReader(stm))
                {
                    var uploadModelList = new List<Transaction>();
                    List<string[]> Transactions = new List<string[]>();
                    while (!csvReader.EndOfStream)
                    {
                        Transactions.Add(csvReader.ReadLine().Split(','));
                    }


                    //ViewBag.CEO = Employees[0][0] != "" ? Employees[0][0] : "CEO Name is absent";
                    //Employees.Remove(Employees[0]);

                    Transactions.Remove(Transactions[0]);
                    ClearOutput();
                  
                    
                    foreach (var transaction in Transactions)
                    {
                        var uploadModelRecord = new Transaction();
                        uploadModelRecord.Account = transaction[0] != "" ? transaction[0] : string.Empty;
                        uploadModelRecord.Description = transaction[1] != "" ? transaction[1] : string.Empty;                        
                        uploadModelRecord.CurrencyCode = transaction[2] != "" ? transaction[2] : string.Empty;
                        //to do Deimal.TryParse();
                        uploadModelRecord.Amount = decimal.Parse(transaction[3], CultureInfo.InvariantCulture) != 0.00m ? decimal.Parse(transaction[3], CultureInfo.InvariantCulture) : 0.00m;
                        uploadModelList.Add(uploadModelRecord);
                        count++;
                        
                        System.Diagnostics.Debug.WriteLine(count);
                    }

                    //InsertToDatabase(uploadModelList);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error while Reading the File Content");
            }
        }

    }
}