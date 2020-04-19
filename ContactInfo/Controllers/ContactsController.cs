using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContactInfo.Models;

namespace ContactInfo.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        public ViewResult Index()
        {
            var contacts = GetContacts();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = GetContacts().SingleOrDefault(c => c.Id == id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        private IEnumerable<Contact> GetContacts()
        {
            return new List<Contact>();
        }
    }
}