
// 데이터를 서버로 보낼때 사용될 클래스
public class ApplicationConfigSendPacket : SendPacketBase
{
    // 서버에서 환경에 따라 내려준 주소를 사용하기 위해서
    // 개발환경 : Dev, Stage, Live
    // 운영체제 : Andriod, IOS;
    // 앱 버전 : 1.0.0

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


// 서버에서 보낸 데이터를 저장할떄 사용될 클래스
public class ApplicationConfigReceivePacket : ReceivePacketBase
{
    public string apiURL;

    public ApplicationConfigReceivePacket(int returnCode, string apiURL) : base(returnCode)
    {
        this.apiURL = apiURL;
    }
}
