using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Movie_Mania_2.Data;
using Movie_Mania_2.Models;

namespace Movie_Mania_2.Controllers
{
    public class UsersController : Controller
    {
        
        private Movie_Mania_2Context db = new Movie_Mania_2Context();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);  
        }

        // GET: Users/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nombre,Apellido,Usuario,Mail,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Usuario.Equals(user.Usuario)))
                {
                    ViewBag.NotificationUser = "Este usuario ya esta en uso";

                    if (db.Users.Any(x => x.Mail.Equals(user.Mail)))
                    {
                        ViewBag.NotificationMail = "Este mail ya esta en uso";
                        return View();
                    }
                    return View();

                }
                else if (db.Users.Any(x => x.Mail.Equals(user.Mail)))
                {
                    ViewBag.NotificationMail = "Este mail ya esta en uso";
                    return View();
                }
                else
                {
                    user.tipo_Usuario = 0;
                    db.Users.Add(user);
                    db.SaveChanges();

                    Session["Id"] = user.Id.ToString();
                    Session["Username"] = user.Usuario.ToString();

                    return RedirectToAction("Details", new { id = user.Id });
                }
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Apellido,Usuario,tipo_Usuario,Mail")] User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.Usuario == user.Usuario))
                {
                    ViewBag.Notification = "Este usuario ya esta en uso";
                    return View();
                }
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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

        // GET: Users/Login
        public ActionResult Login()
        {
            if(Session["Id"] != null)
            {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        //POST: Users/Login/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var checkLogin = db.Users.Where(x => x.Usuario.Equals(user.Usuario) && x.Password.Equals(user.Password));


            foreach(var item in db.Users)
            {
                if (item.Usuario.Equals(user.Usuario) && item.Password.Equals(user.Password))
                {
                    Session["Id"] = item.Id.ToString();
                    Session["Username"] = item.Usuario.ToString();
                    if(item.tipo_Usuario.Equals(User_Type.Client))
                    {
                        Session["User_Type"] = item.tipo_Usuario.ToString();
                    }
                    else
                    {
                        
                        Session["User_Type"] = item.tipo_Usuario.ToString();
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Notification = "El usuario o la contraseña no son correctos";

            return View(user);
        }

    }
}
