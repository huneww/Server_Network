namespace WebApplication1.Models
{
    // 클라이언트와는 반대로 받는 클래스로 이름 변경
    public class ApplicationConfigReceivePacket : ReceivePacketBase
    {
        // 서버에서 환경에 따라 내려준 주소를 사용하기 위해서
        // 개발환경 : Dev, Stage, Live
        // 운영체제 : Andriod, IOS;
        // 앱 버전 : 1.0.0

        public int environment_Type;
        public int os_Type;
        public string appVersion;

        public ApplicationConfigReceivePacket(string packetName, int environment_Type,
                                           int os_Type, string appVersion) : base(packetName: packetName)
        {
            this.environment_Type = environment_Type;
            this.os_Type = os_Type;
            this.appVersion = appVersion;
        }
    }

    public class ApplicationConfigSendPacket : SendPacketBase
    {
        public string apiURL;

        public ApplicationConfigSendPacket(string packetName, int returnCode, string apiURL) : base(packetName, returnCode)
        {
            this.apiURL = apiURL;
        }
    }
}
