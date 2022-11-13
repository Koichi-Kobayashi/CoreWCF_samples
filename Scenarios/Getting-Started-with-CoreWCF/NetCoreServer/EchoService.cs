using System.Threading.Tasks;
using CoreWCF;
using Shared;
using SharedExtra;

namespace NetCoreServer
{
    public class EchoService : IEchoService
    {
        public Task<string> Echo(ServiceID id, string text)
        {
            System.Console.WriteLine($"Received {text} from client! & ServiceID = {id}");
            return Task.FromResult(text);
        }

        public Task<string> ComplexEcho(EchoMessage text)
        {
            System.Console.WriteLine($"Received {text.Text} from client!");
            return Task.FromResult(text.Text);
        }

        public Task<string> FailEcho(string text)
            => throw new FaultException<EchoFault>(new EchoFault() { Text = "WCF Fault OK" }, new FaultReason("FailReason"));

        [AuthorizeRole("CoreWCFGroupAdmin")]
        public Task<string> EchoForPermission(Task<string> echo)
        {
            return echo;
        }
    }
}
