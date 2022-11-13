using Shared;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace SharedExtra
{
    [ServiceContract]
    public interface IEchoService
    {
        [OperationContract]
        Task<string> Echo(ServiceID id, string text);

        [OperationContract]
        Task<string> ComplexEcho(EchoMessage text);

        [OperationContract]
        [FaultContract(typeof(EchoFault))]
        Task<string> FailEcho(string text);

        [OperationContract]
        Task<string> EchoForPermission(Task<string> text);
    }

    [Serializable]
    public enum ServiceID : uint
    {
        None,
        Login
    }
}