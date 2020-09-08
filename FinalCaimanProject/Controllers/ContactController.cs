using FinalCaimanProject.DAL;
using FinalCaimanProject.Models;
using FinalCaimanProject.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinalCaimanProject.Controllers
{
  [Authorize]
    public class ContactController : Controller
    {
        // GET: Contact
        DbCaimanContext db = new DbCaimanContext();
        // GET: Contact
        //Pagination 
        public ActionResult Contact(int page = 0)
        {

            var bedroom = from s in db.Contacts select s;
            const int PageSize = 6; // you can always do something more elegant to set this

            var count = bedroom.Count();

            var data = bedroom.Skip(page * PageSize).Take(PageSize).ToList();

            ViewBag.MaxPage = (count / PageSize) - (count % PageSize == 0 ? 1 : 0);

            ViewBag.Page = page;
            ViewBag.Contact = data;
            return View();
        }

        // recherche par nom , prenom , specialite
        [HttpPost]
        public ActionResult Contact(string Searching)
        {
            var bg = from s in db.Contacts select s;
            if (Searching != null)
            {
                bg = bg.Where(s => s.ContactName.Contains(Searching) || s.ContactPname.Contains(Searching) || s.ContactFonction.Contains(Searching) || s.ContactSite.Contains(Searching));
                ViewBag.Contact = bg.ToList();
            }
            return View();
        }

        public ActionResult ModifContact(int id)
        {
            var contact = db.Contacts.Find(id);
            return View(contact);
        }


        // Modification des contacts
        [HttpPost]
        public ActionResult ModifContact(ContactViewModel contact, int id)
        {
           
            var bd2 = new Contact();
            bd2 = db.Contacts.Find(id);
            if (contact != null)
            {
                bd2.ContactEmail= contact.ContactEmail;
                bd2.ContactFonction = contact.ContactFonction;
                bd2.ContactName = contact.ContactName;
                bd2.ContactNumber = contact.ContactNumber;
                bd2.ContactPname = contact.ContactPname;
                bd2.ContactSite = contact.ContactSite;

                db.Contacts.Update(bd2);
                db.SaveChanges();

                ViewBag.Message = "Contact Modifié avec succès";
            }
            return View();
        }

        private List<Contact> GetContact()
        {
            var contact = db.Contacts.ToList();
            return contact;
        }

        // vue des contacts
        public ActionResult NewContact()
        {
            return View();
        }
        //Ajout de contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewContact(ContactViewModel contact)
        {

            if (ModelState.IsValid)
            {
                Contact c = new Contact();
                c.ContactName = contact.ContactName;
                c.ContactPname = contact.ContactPname;
                c.ContactEmail = contact.ContactEmail;
                c.ContactNumber = contact.ContactNumber;
                c.ContactSite = contact.ContactSite;
                c.ContactFonction = contact.ContactFonction;

                db.Contacts.Add(c);
                db.SaveChanges();

                ViewBag.Message = "Contact enregistré avec succès";

                ModelState.Clear();

                return View();
            }
            else
            {
                return View("NewContact", contact);
            }
        }
    }
}