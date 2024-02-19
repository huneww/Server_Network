
// �����͸� ������ ������ ���� Ŭ����
public class ApplicationConfigSendPacket : SendPacketBase
{
    // �������� ȯ�濡 ���� ������ �ּҸ� ����ϱ� ���ؼ�
    // ����ȯ�� : Dev, Stage, Live
    // �ü�� : Andriod, IOS;
    // �� ���� : 1.0.0

    public int environment_Type;
    public int os_Type;
    public string appVersion;

    public ApplicationConfigSendPacket(PACKET_NAME_TYPE packetName, ENVIRONMENT_TYPE environment_Type,
                                       OS_TYPE os_Type, string appVersion) : base(packetName: packetName)
    {
        this.environment_Type = (int)environment_Type;
        this.os_Type = (int)os_Type;
        this.appVersion = appVersion;
    }
}


// �������� ���� �����͸� �����ҋ� ���� Ŭ����
public class ApplicationConfigReceivePacket : ReceivePacketBase
{
    public string apiURL;

    public ApplicationConfigReceivePacket(int returnCode, string apiURL) : base(returnCode)
    {
        this.apiURL = apiURL;
    }
}
