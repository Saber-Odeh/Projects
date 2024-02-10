using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using Task1.Models;
using Task1.Models.Repository;
using Microsoft.AspNetCore.Hosting;
using Task1.ViewsModel;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using System.Globalization;
using System.Linq;

namespace Task1.Controllers
{
    public class CallsLogSummaryController : Controller
    {
        public IRepository<CallsLogSummary> CallsLogSummary { get; }
        public IRepository<CallsLogDetails> CallsLogDetails { get; }
        public IHostingEnvironment Host { get; }
        public CallsLogSummaryController(IRepository<CallsLogSummary> _CallsLogSummary, IRepository<CallsLogDetails> _CallsLogDetails
            , IHostingEnvironment _Host)
        {
            CallsLogSummary = _CallsLogSummary;
            CallsLogDetails = _CallsLogDetails;
            Host = _Host;
        }

       

        // GET: CallsLogSummaryController/Edit/5
        public ActionResult Convert()
        {
            return View();
        } 
        
        // POST: CallsLogSummaryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Convert(CallsLogSummaryModel collection)
        {
            try
            {
                string ImageName = "";
                string FullPath="";
                string extension="";
                if (collection.File != null)
                {
                    string Imagepath = Path.Combine(Host.WebRootPath, "Logs");
                    FileInfo fn = new FileInfo(collection.File.FileName);
                    ImageName = "Image" + Guid.NewGuid() + fn.Extension;
                    extension = fn.Extension;
                    FullPath = Path.Combine(Imagepath, ImageName);
                    collection.File.CopyTo(new FileStream(FullPath, FileMode.Create));
                }
                var obj = new CallsLogSummary();
                obj.ToDate = collection.ToDate;
                obj.FromDate = collection.FromDate;
                obj.Path = FullPath;
                obj.Upload = DateTime.UtcNow;
                CallsLogSummary.Add(obj);
                List<CallsLogDetails> Callslist = ConvertExcelToList(FullPath);
                foreach (var item in Callslist)
                {
                    item.Answered = (item.CallDuration == 0) ? false : true;
                    item.CallsLogSummaryId = obj.CallsLogSummaryId;
                    item.Extension = extension;
                    item.Type = "";
                    CallsLogDetails.Add(item);
                }


                return RedirectToAction("CallsLogView", obj );
            }
            catch
            {
                return View();
            }
        }
        public List<CallsLogDetails> ConvertExcelToList(string filePath)
        {
            List<CallsLogDetails> objectsList = new List<CallsLogDetails>();
            FileInfo fileInfo = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                if (worksheet.Cells[1, 1].Value.ToString() is null)
                    return objectsList;
               
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Value is null )
                        break;
                    
                    CallsLogDetails obj = new CallsLogDetails();
                    obj.PhoneNumber = worksheet.Cells[row, 1].Value.ToString();
                    obj.CallDateTime = DateTime.ParseExact(worksheet.Cells[row, 2].Value.ToString(), "d/M/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                    obj.AgentID = worksheet.Cells[row, 3].Value.ToString();
                    obj.CallDuration = (double)worksheet.Cells[row, 4].Value;
                        
                    

                    objectsList.Add(obj);
                }
            }

            return objectsList;
        }

            // GET: CallsLogSummaryController/Edit/5
     public ActionResult CallsLogView(CallsLogSummary obj)
     {
            var data = CallsLogDetails.Get().Where(x=>x.CallsLogSummaryId==obj.CallsLogSummaryId && x.CallDateTime>=obj.FromDate && x.CallDateTime <= obj.ToDate).ToList();
         return View(data);
     }
            
    }
}
