using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class StudentSubjectAttendancesController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: StudentSubjectAttendances
        public ActionResult Index()
        {
            var attendances = db.Attendances.Include(s => s.Student).Include(s => s.Subject);
            return View(attendances.ToList());
        }

        // GET: StudentSubjectAttendances/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubjectAttendance studentSubjectAttendance = db.Attendances.Find(id);
            if (studentSubjectAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentSubjectAttendance);
        }

        // GET: StudentSubjectAttendances/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name");
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name");
            return View();
        }

        // POST: StudentSubjectAttendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SubjectId,StudentId,CountMissed")] StudentSubjectAttendance studentSubjectAttendance)
        {
            if (ModelState.IsValid)
            {
                studentSubjectAttendance.Id = Guid.NewGuid();
                db.Attendances.Add(studentSubjectAttendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentSubjectAttendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", studentSubjectAttendance.SubjectId);
            return View(studentSubjectAttendance);
        }

        // GET: StudentSubjectAttendances/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubjectAttendance studentSubjectAttendance = db.Attendances.Find(id);
            if (studentSubjectAttendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentSubjectAttendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", studentSubjectAttendance.SubjectId);
            return View(studentSubjectAttendance);
        }

        // POST: StudentSubjectAttendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SubjectId,StudentId,CountMissed")] StudentSubjectAttendance studentSubjectAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentSubjectAttendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "Id", "Name", studentSubjectAttendance.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "Id", "Name", studentSubjectAttendance.SubjectId);
            return View(studentSubjectAttendance);
        }

        // GET: StudentSubjectAttendances/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentSubjectAttendance studentSubjectAttendance = db.Attendances.Find(id);
            if (studentSubjectAttendance == null)
            {
                return HttpNotFound();
            }
            return View(studentSubjectAttendance);
        }

        // POST: StudentSubjectAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            StudentSubjectAttendance studentSubjectAttendance = db.Attendances.Find(id);
            db.Attendances.Remove(studentSubjectAttendance);
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

        public async Task<ActionResult> Filter(string text)
        {
            if (text == null)
            {
                return RedirectToAction("Index");
            }
            var result =
                db.Attendances
                    .Include(s => s.Student)
                    .Include(s => s.Subject)
                    .Where(x => x.Student.Name.Contains(text) || x.Subject.Name.Contains(text));

            return View("Index", await result.ToListAsync());
        }
    }
}
