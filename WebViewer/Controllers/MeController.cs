using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using RemoteImageGrabber.Common.Enums;
using RemoteImageGrabber.DataAccess;
using RemoteImageGrabber.DataAccess.Entities;
using WebViewer.Models;

namespace WebViewer.Controllers
{
    [Authorize]
    public class MeController : ApiController
    {
        private ApplicationUserManager _userManager;

        public MeController()
        {
        }

        public MeController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET api/Me
        public GetViewModel Get()
        {
            var uof = new UnitOfWork();
            var lastImage = uof.Pictures.GetAll().OrderByDescending(c => c.CreationDate).FirstOrDefault();
            if (lastImage == null)
            {
                lastImage = new Picture() { PictureUrl = "untitled.png", CreationDate = DateTime.MinValue };
            }
            return new GetViewModel() { ImageUrl = "/images/" + lastImage.PictureUrl };
        }

        [HttpPut]
        public GetViewModel Put()
        {
            var uow = new UnitOfWork();
            var command = uow.Commands.GetAll().FirstOrDefault(c => c.CommandName == CommandType.NextCommand.ToString());
            if (command == null)
            {
                command = new Command(CommandType.NextCommand.ToString(), RemoteCommand.Grab.ToString());
                uow.Commands.Add(command);
            }
            else
            {
                command.Value = RemoteCommand.Grab.ToString();
            }
            uow.Commit();
            return Get();
        }
    }
}