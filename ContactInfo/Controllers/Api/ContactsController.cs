using AutoMapper;
using ContactInfo.DataAccessLayer;
using ContactInfo.Dtos;
using ContactInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ContactInfo.Controllers.Api
{
    public class ContactsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContactsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var contacts = _unitOfWork.Contacts.GetContacts();

            if (contacts == null || !contacts.Any())
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<ContactDto>>(contacts));
        }

        [HttpGet]
        public IHttpActionResult GetContact(int id)
        {
            var contact = _unitOfWork.Contacts.GetContact(id);

            if (contact == null)
                return NotFound();

            return Ok(Mapper.Map<ContactDto>(contact));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageContacts)]
        public IHttpActionResult CreateContact(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var contact = Mapper.Map<Contact>(contactDto);

            _unitOfWork.Contacts.AddContact(contact);
            _unitOfWork.Complete();

            contactDto.Id = contact.Id;

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contactDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageContacts)]
        public IHttpActionResult UpdateContact(int id, ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var contact = _unitOfWork.Contacts.GetContact(id);

            if (contact == null)
                return NotFound();

            _unitOfWork.Contacts.EditContact(Mapper.Map(contactDto, contact));

            _unitOfWork.Complete();

            return Ok(contactDto);
        }

        [HttpPut]
        [Route("api/contacts/activatedeactivatecontact/{id}")]
        [Authorize(Roles = RoleName.CanManageContacts)]
        public IHttpActionResult ActivateDeactivateContact(int id)
        {
            var contact = _unitOfWork.Contacts.ActivateDeactivateContact(id);

            if (contact == Constants.NotFound)
                return NotFound();

            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageContacts)]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _unitOfWork.Contacts.DeleteContact(id);

            if (contact == Constants.NotFound)
                return NotFound();

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
