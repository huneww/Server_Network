
namespace WebApplication1.Models
{
    public class ReceivePacketBase
    {
        public string packetName;

        public ReceivePacketBase(string packetName)
        {
            this.packetName = packetName;
        }
    }

    public class SendPacketBase
    {
        public string packetName;
        public int returnCode;

        public SendPacketBase(string packetName, int returnCode)
        {
            this.packetName = packetName;
            this.returnCode = returnCode;
        }
    }
}