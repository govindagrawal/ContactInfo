using AutoMapper;
using ContactInfo.DataAccessLayer.Repositories;
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
        private readonly IContactRepository _contactRepository;

        public ContactsController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet]
        public IHttpActionResult GetContacts()
        {
            var contacts = _contactRepository.GetContacts();

            if (contacts == null || !contacts.Any())
                return NotFound();

            return Ok(Mapper.Map<IEnumerable<ContactDto>>(contacts));
        }

        [HttpGet]
        public IHttpActionResult GetContact(int id)
        {
            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return NotFound();

            return Ok(Mapper.Map<ContactDto>(contact));
        }

        [HttpPost]
        public IHttpActionResult CreateContact(ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var contact = Mapper.Map<Contact>(contactDto);

            _contactRepository.AddContact(contact);
            _contactRepository.Complete();

            contactDto.Id = contact.Id;

            return Created(new Uri(Request.RequestUri + "/" + contact.Id), contactDto);
        }

        [HttpPut]
        public IHttpActionResult UpdateContact(int id,ContactDto contactDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            var contact = _contactRepository.GetContact(id);

            if (contact == null)
                return NotFound();

            _contactRepository.EditContact(Mapper.Map(contactDto, contact));

            _contactRepository.Complete();

            return Ok(contactDto);
        }

        [HttpPut]
        [Route("api/contacts/activatedeactivatecontact/{id}")]
        public IHttpActionResult ActivateDeactivateContact(int id)
        {
            var contact = _contactRepository.ActivateDeactivateContact(id);

            if (contact == Constants.NotFound)
                return NotFound();

            _contactRepository.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteContact(int id)
        {
            var contact = _contactRepository.DeleteContact(id);

            if (contact == Constants.NotFound)
                return NotFound();

            _contactRepository.Complete();

            return Ok();
        }
    }
}
