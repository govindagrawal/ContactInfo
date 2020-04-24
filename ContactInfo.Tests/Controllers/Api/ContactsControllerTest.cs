using ContactInfo.Controllers.Api;
using ContactInfo.DataAccessLayer;
using ContactInfo.Dtos;
using ContactInfo.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Results;

namespace ContactInfo.Tests.Controllers.Api
{
    [TestClass]
    public class ContactsControllerTest
    {
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private ContactsController _contactsController;

        private const int Id = 1;

        [TestInitialize]
        public void BeforeEach()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _contactsController = new ContactsController(_mockUnitOfWork.Object);
        }

        [TestMethod]
        public void ContactsController_GetContacts_ShouldReturn_NotFound_WhenDataIsNotAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContacts()).Returns(new List<Contact>());

            // Act
            var result = _contactsController.GetContacts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ContactsController_GetContacts_ShouldReturn_Ok_WhenDataIsAvailable()
        {
            var contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "Test"
                }
            };

            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContacts()).Returns(contacts);

            // Act
            var result = _contactsController.GetContacts();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<ContactDto>>));
        }

        [TestMethod]
        public void ContactsController_GetContact_ShouldReturn_NotFound_WhenDataIsNotAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContact(It.IsAny<int>())).Returns((Contact)null);

            // Act
            var result = _contactsController.GetContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ContactsController_GetContact_ShouldReturn_Ok_WhenDataIsAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContact(It.IsAny<int>())).Returns(new Contact());

            // Act
            var result = _contactsController.GetContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactDto>));
        }

        [TestMethod]
        public void ContactsController_CreateContact_ShouldReturn_BadRequest_WhenFailure()
        {
            // Arrange
            _contactsController.ModelState.AddModelError("FirstName", @"The First Name field is required.");

            // Act
            var result = _contactsController.CreateContact(new ContactDto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void ContactsController_CreateContact_ShouldReturn_Created_WhenSuccess()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.AddContact(It.IsAny<Contact>()));
            _mockUnitOfWork.Setup(u => u.Complete());

            _contactsController.Request = new HttpRequestMessage(HttpMethod.Get, "http://testlocation");

            // Act
            var result = _contactsController.CreateContact(new ContactDto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedNegotiatedContentResult<ContactDto>));
        }

        [TestMethod]
        public void ContactsController_UpdateContact_ShouldReturn_BadRequest_WhenFailure()
        {
            // Arrange
            _contactsController.ModelState.AddModelError("FirstName", @"The First Name field is required.");

            // Act
            var result = _contactsController.UpdateContact(Id, new ContactDto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void ContactsController_UpdateContact_ShouldReturn_NotFound_WhenDataIsNotAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContact(It.IsAny<int>())).Returns((Contact)null);

            // Act
            var result = _contactsController.UpdateContact(Id, new ContactDto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ContactsController_UpdateContact_ShouldReturn_Created_WhenSuccess()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContact(It.IsAny<int>())).Returns(new Contact());
            _mockUnitOfWork.Setup(u => u.Contacts.EditContact(It.IsAny<Contact>()));
            _mockUnitOfWork.Setup(u => u.Complete());

            // Act
            var result = _contactsController.UpdateContact(Id, new ContactDto());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContactDto>));
        }

        [TestMethod]
        public void ContactsController_ActivateDeactivateContact_ShouldReturn_NotFound_WhenDataIsNotAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.ActivateDeactivateContact(It.IsAny<int>())).Returns(Constants.NotFound);

            // Act
            var result = _contactsController.ActivateDeactivateContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ContactsController_ActivateDeactivateContact_ShouldReturn_Ok_WhenDataIsAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.ActivateDeactivateContact(It.IsAny<int>())).Returns(1);
            _mockUnitOfWork.Setup(u => u.Complete());

            // Act
            var result = _contactsController.ActivateDeactivateContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ContactsController_DeleteContact_ShouldReturn_NotFound_WhenDataIsNotAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.DeleteContact(It.IsAny<int>())).Returns(Constants.NotFound);

            // Act
            var result = _contactsController.DeleteContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void ContactsController_DeleteContact_ShouldReturn_Ok_WhenDataIsAvailable()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.DeleteContact(It.IsAny<int>())).Returns(1);
            _mockUnitOfWork.Setup(u => u.Complete());

            // Act
            var result = _contactsController.DeleteContact(Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }
    }
}
