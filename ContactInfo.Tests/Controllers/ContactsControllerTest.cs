using AutoMapper;
using ContactInfo.Controllers;
using ContactInfo.DataAccessLayer;
using ContactInfo.Dtos;
using ContactInfo.Models;
using ContactInfo.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace ContactInfo.Tests.Controllers
{
    [TestClass]
    public class ContactsControllerTest
    {
        private Mock<ControllerContext> _controllerContext;
        private Mock<HttpContextBase> _httpContext;
        private Mock<IPrincipal> _principal;
        private Mock<IUnitOfWork> _mockUnitOfWork;

        private ContactsController _contactsController;

        private const int Id = 1;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Contact, ContactFormViewModel>().ReverseMap();
                cfg.CreateMap<Contact, ContactDto>().ReverseMap();
            });
        }

        [TestInitialize]
        public void BeforeEach()
        {
            _controllerContext = new Mock<ControllerContext>();
            _httpContext = new Mock<HttpContextBase>();
            _principal = new Mock<IPrincipal>();

            _mockUnitOfWork = new Mock<IUnitOfWork>();

            _contactsController = new ContactsController(_mockUnitOfWork.Object);
        }

        [TestMethod]
        public void ContactsController_Index_ShouldReturn_ContactListView_WhenUserIsAdmin()
        {
            // Arrange
            SetUserAuthorizationRoles(true);

            // Act
            var result = _contactsController.Index();

            // Assert
            Assert.AreEqual("ContactList", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Index_ShouldReturn_ReadOnlyContactListView_WhenUserIsNotAdmin()
        {
            // Arrange
            SetUserAuthorizationRoles(false);

            // Act
            var result = _contactsController.Index();

            // Assert
            Assert.AreEqual("ReadOnlyContactList", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Details_ShouldReturn_DetailsView_WhenUserIsAdmin()
        {
            // Arrange
            SetUserAuthorizationRoles(true);

            // Act
            var result = _contactsController.Details(Id);

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Details_ShouldReturn_ReadOnlyDetailsView_WhenUserIsNotAdmin()
        {
            // Arrange
            SetUserAuthorizationRoles(false);

            // Act
            var result = _contactsController.Details(Id);

            // Assert
            Assert.AreEqual("ReadOnlyDetails", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_New_ShouldReturn_ContactFormView()
        {
            // Act
            var result = _contactsController.New();

            // Assert
            Assert.AreEqual("ContactForm", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Edit_ShouldReturn_ContactFormView()
        {
            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.GetContact(It.IsAny<int>())).Returns(new Contact());

            // Act
            var result = _contactsController.Edit(Id) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ContactForm", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Save_ShouldReturn_ContactFormView_WhenModelStateIsInvalid()
        {
            var viewModel = new ContactFormViewModel();

            // Arrange
            _contactsController.ModelState.AddModelError("FirstName", @"The First Name field is required."); 

            // Act
            var result = _contactsController.Save(viewModel) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ContactForm", result.ViewName);
        }

        [TestMethod]
        public void ContactsController_Save_Should_AddContact_WhenIdIsEqualToZero()
        {
            var viewModel = new ContactFormViewModel { Id = 0 };

            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.AddContact(It.IsAny<Contact>()));
            _mockUnitOfWork.Setup(u => u.Complete());

            // Act
            var result = _contactsController.Save(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Contacts", result.RouteValues["Controller"]);
        }

        [TestMethod]
        public void ContactsController_Save_Should_EditContact_WhenIdIsNotEqualToZero()
        {
            var viewModel = new ContactFormViewModel { Id = Id };

            // Arrange
            _mockUnitOfWork.Setup(u => u.Contacts.EditContact(It.IsAny<Contact>()));
            _mockUnitOfWork.Setup(u => u.Complete());

            // Act
            var result = _contactsController.Save(viewModel) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", result.RouteValues["Action"]);
            Assert.AreEqual("Contacts", result.RouteValues["Controller"]);
        }

        private void SetUserAuthorizationRoles(bool isAdmin)
        {
            _principal.Setup(p => p.IsInRole(RoleName.CanManageContacts)).Returns(isAdmin);
            _httpContext.SetupGet(ctx => ctx.User).Returns(_principal.Object);
            _controllerContext.SetupGet(con => con.HttpContext).Returns(_httpContext.Object);

            _contactsController.ControllerContext = _controllerContext.Object;
        }
    }
}
