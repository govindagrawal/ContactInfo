using AutoMapper;
using ContactInfo.DataAccessLayer;
using ContactInfo.Models;
using ContactInfo.ViewModels;
using System.Web.Mvc;

namespace ContactInfo.Controllers
{
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
            var contact = _unitOfWork.Contacts.GetContact(id);

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
                _unitOfWork.Contacts.AddContact(contact);
            }
            else
            {
                _unitOfWork.Contacts.EditContact(contact);
            }
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Contacts");
        }
    }
}