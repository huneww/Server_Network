using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CertHandler : CertificateHandler
{
    protected override bool ValidateCertificate(byte[] certificateData)
    {
        return true;
    }
}

public class NetworkManager : MonoBehaviour
{
    private readonly string apiURL = Config.SERVER_API_URL;

    public void SendPacket()
    {
        // 서버에 전송할 데이터
        ApplicationConfigSendPacket sendPacket
            = new ApplicationConfigSendPacket(PACKET_NAME_TYPE.ApplicationConfig,
            Config.environment_Type, Config.os_Type, Config.app_Version);

        StartCoroutine(C_SendPacket(sendPacket));
    }

    private IEnumerator C_SendPacket(SendPacketBase sendPacket)
    {
        // 데이터를 Json형태로 변환
        string packet = JsonUtility.ToJson(sendPacket);
        // 변환 데이터 확인
        Debug.Log("[NetworkManager Send Packet] : " + packet);

        // apiURL의 서버 주소로 전송 데이터 전송 요청
        // request가 사용이 끝나면 자동적으로 데이터를 정리 해줌, 데이터 누수를 예방할수 있음
        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(apiURL, packet))
        {
            // packet을 UTF-8로 인코딩
            byte[] bytes = new System.Text.UTF8Encoding().GetBytes(packet);

            // bytes를 요청 바디에 데이터를 전송
            // 데이터를 따로 저장하지 않고 전송을 하는 용도
            request.uploadHandler = new UploadHandlerRaw(bytes);

            // 응답 데이터를 버퍼에 저장
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            // SSL/TLS 인증서 유효성 검사
            request.certificateHandler = new CertHandler();

            // 서버에 데이터 전송 후 다시 받을때 까지 대기
            yield return request.SendWebRequest();

            // 오류 발생시 로그 출력
            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error : " + request.error);
            }
            else
            {
                // 서버에서 넘겨준 데이터 획득
                string jsonData = request.downloadHandler.text;
                // 데이터 로그 출력
                Debug.Log("Recevied Data : " + jsonData);
                // 데이터를 Json에서 클래스로 변환
                ApplicationConfigReceivePacket applicationConfigReceivePacket
                    = JsonUtility.FromJson<ApplicationConfigReceivePacket>(jsonData);

            }
        }

    }
}
