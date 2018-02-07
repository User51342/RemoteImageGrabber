using System.Linq;
using RemoteImageGrabber.DataAccess;
using RemoteImageGrabber.DataAccess.Entities;
using RemoteImageGrabber.Common.Enums;

namespace RemoteImageGrabber.DataServices
{
    public class GrabberService : IGrabberService
    {
        #region Public Services
        public string GetCommand()
        {
            var uow = new UnitOfWork();
            var nextCommand = uow.Commands.GetAll().FirstOrDefault(c => c.CommandName == CommandType.NextCommand.ToString()) ?? new Command(CommandType.NextCommand.ToString(),RemoteCommand.None.ToString());
            var result = nextCommand.Value;
            nextCommand.Value = RemoteCommand.None.ToString();
            uow.Commands.Update(nextCommand);
            uow.Commit();
            return result;
        }

        public int SendImage(byte[] image)
        {
            var fileStorage = new FileStorage();
            return fileStorage.StoreImage(image);
        }
        #endregion
    }
}
