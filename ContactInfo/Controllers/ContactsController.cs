﻿using AutoMapper;
using ContactInfo.DataAccessLayer.Repositories;
using ContactInfo.Models;
using ContactInfo.ViewModels;
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
            return View(User.IsInRole(RoleName.CanManageContacts) ? "ContactList" : "ReadOnlyContactList");
        }

        public ActionResult Details(int id)
        {
            var contactId = new ContactId
            {
                Id = id
            };

            return User.IsInRole(RoleName.CanManageContacts) ? View(contactId) : View("ReadOnlyDetails", contactId);
        }

        [Authorize(Roles = RoleName.CanManageContacts)]
        public ActionResult New()
        {
            var viewModel = new ContactFormViewModel();
            return View("ContactForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageContacts)]
        public ActionResult Edit(int id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return HttpNotFound();

            return View("ContactForm", Mapper.Map<ContactFormViewModel>(contact));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageContacts)]
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