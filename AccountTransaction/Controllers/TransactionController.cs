using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AccountTransaction.Models;
using AccountTransaction.DAL;
using AccountTransaction.Helper;

namespace AccountTransaction.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionDb _db = new TransactionContext();        

        // GET: /Transaction/
        public ActionResult Index()
        {
            var result = _db.Query<Transaction>();           
            
            if (result.Count() > 0)
            {
                ViewBag.ResultCount = result.Count();
                return View(result.ToList());
            }
            else
            {
                 ViewBag.ResultCount = 0;
                 return View();
            }
        }


        #region Not Supported Now
        //// GET: /Transaction/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: /Transaction/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include="Id,Account,Description,CurrencyCode,Amount")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        transaction.Id = Guid.NewGuid();
        //        _db.Transactions.Add(transaction);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(transaction);
        //}

        //// GET: /Transaction/Edit/5
        //public ActionResult Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = _db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: /Transaction/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include="Account,Description,CurrencyCode,Amount")] Transaction transaction)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        if (CurrencyHelper.CurrencyList.Contains(transaction.CurrencyCode))
        //        {
        //            _db.Entry(transaction).State = EntityState.Modified;
        //            _db.SaveChanges();
        //            return RedirectToAction("Index"); 
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("InValidCurrencyCode", "Currency Code is invalid");
        //            return View(transaction);        
        //        }
        //    }
        //    return View(transaction);
        //}

        //// GET: /Transaction/Delete/5
        //public ActionResult Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Transaction transaction = _db.Transactions.Find(id);
        //    if (transaction == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(transaction);
        //}

        //// POST: /Transaction/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(Guid id)
        //{
        //    Transaction transaction = _db.Transactions.Find(id);
        //    _db.Transactions.Remove(transaction);
        //    _db.SaveChanges();
        //    return RedirectToAction("Index");
        //} 
        #endregion

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
