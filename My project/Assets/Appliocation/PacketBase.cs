public class SendPacketBase
{
    public string packetName;

    public SendPacketBase(PACKET_NAME_TYPE packetName)
    {
        this.packetName = packetName.ToString();
    }
}

public class ReceivePacketBase
{
    public int returnCode;

    public ReceivePacketBase(int returnCode)
    {
        this.returnCode = returnCode;
    }
}
