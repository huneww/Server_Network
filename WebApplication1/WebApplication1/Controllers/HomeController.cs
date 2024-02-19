using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // 클라이언트에서 Post를 이용해서 데이터를 넘겨줌
        // 서버에서도 Post로 데이터를 받기위해 HttpPost 에트리뷰트 사용
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            // 클라이언트에서 보낼 데이터를 저장할 변수
            string json = string.Empty;

            // 클라이언트에서 uploadHandler로 전송한 데이터를 StreamReader로 reader변수에 저장
            // 데이터 누수 방지를 위해 using 사용
            using (var reader = new StreamReader(Request.Body))
            {
                // 비동기적으로 요청 바디의 내용을 전부 읽어 옴
                json = await reader.ReadToEndAsync();
            }

            // 읽어넨 데이터를 직렬화를 해제하여 데이터를 저장
            ApplicationConfigReceivePacket? applicationConfigReceivePacket
               = JsonConvert.DeserializeObject<ApplicationConfigReceivePacket>(json);

            //
            // 읽어넨 데이터를 확인하여 오류가 없는지 확인 혹은 가공
            //

            // 가공한 데이터에 따라 클라이언트에게 보낼 데이터를 생성
            ApplicationConfigSendPacket applicationConfigSendPacket
                = new ApplicationConfigSendPacket(applicationConfigReceivePacket.packetName,
                200,
                "https://localhost:7278/");

            // 데이터를 Json으로 직렬화하여 문자열로 저장
            string sendPacket = JsonConvert.SerializeObject(applicationConfigSendPacket);

            // 클라이언트에게 데이터를 전송
            // 데이터 전송되면 클라이언트에서 yield return 부분으로 가짐
            return Content(sendPacket);
        }
    }
}