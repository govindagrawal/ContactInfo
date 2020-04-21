using AutoMapper;
using ContactInfo.DataAccessLayer.Repositories;
using ContactInfo.Models;
using ContactInfo.ViewModels;
using System;
using System.Web.Mvc;

namespace ContactInfo.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public ViewResult Index()
        {
            var contacts = _contactRepository.GetContacts();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return HttpNotFound();

            return View(contact);
        }

        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel();
            return View("ContactForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return HttpNotFound();

            return View("ContactForm", Mapper.Map<ContactFormViewModel>(contact));
        }

        public ActionResult ActivateDeactivate(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ContactFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View("ContactForm", viewModel);

            var contact = Mapper.Map<Contact>(viewModel);

            if (viewModel.Id == 0)
            {
                contact.Status = Constants.Active;
                _contactRepository.AddContact(contact);
            }
            else
            {
                _contactRepository.EditContact(contact);
            }
            _contactRepository.Complete();

            return RedirectToAction("Index", "Contacts");
        }
    }
}