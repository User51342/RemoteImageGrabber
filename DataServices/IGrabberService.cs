using System.ServiceModel;

namespace RemoteImageGrabber.DataServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IGrabberService
    {
        [OperationContract]
        string GetCommand();

        [OperationContract]
        int SendImage(byte[] image);
    }

}
