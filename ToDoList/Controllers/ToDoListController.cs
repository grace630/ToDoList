using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ToDoListController : Controller
    {
        private ToDoListDBContext db = new ToDoListDBContext();

        // GET: ToDoList
        public ActionResult Index(string keyWord)
        {
            var todoList = from m in db.toDoList select m;

            if (!String.IsNullOrEmpty(keyWord))
            {
                todoList = todoList.Where(o => o.Title.Contains(keyWord));
            }
            return View(todoList);
        }

        // GET: ToDoList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListViewModels toDoListViewModels = db.toDoList.Find(id);
            if (toDoListViewModels == null)
            {
                return HttpNotFound();
            }
            return View(toDoListViewModels);
        }

        // GET: ToDoList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ToDoList/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Date,Description")] ToDoListViewModels toDoListViewModels)
        {
            if (ModelState.IsValid)
            {
                db.toDoList.Add(toDoListViewModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(toDoListViewModels);
        }

        // GET: ToDoList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListViewModels toDoListViewModels = db.toDoList.Find(id);
            if (toDoListViewModels == null)
            {
                return HttpNotFound();
            }
            return View(toDoListViewModels);
        }

        // POST: ToDoList/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Date,Description")] ToDoListViewModels toDoListViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(toDoListViewModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(toDoListViewModels);
        }

        // GET: ToDoList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoListViewModels toDoListViewModels = db.toDoList.Find(id);
            if (toDoListViewModels == null)
            {
                return HttpNotFound();
            }
            return View(toDoListViewModels);
        }

        // POST: ToDoList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ToDoListViewModels toDoListViewModels = db.toDoList.Find(id);
            db.toDoList.Remove(toDoListViewModels);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
