using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;

namespace WebhookTester.Controllers
{
    public class WebhookController : ApiController
    {
        private static readonly List<object> _webhookRequests = new List<object>();

        [HttpPost]
        [Route("post")]
        public async Task<IHttpActionResult> ReceiveWebhook()
        {
            try
            {
                var requestBody = await Request.Content.ReadAsStringAsync();
                var jsonObject = JsonConvert.DeserializeObject<object>(requestBody);
                _webhookRequests.Add(jsonObject);
                return Ok(jsonObject);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetWebhookLogs()
        {
            var formattedLogs = JsonConvert.SerializeObject(_webhookRequests, Formatting.Indented);
            return Ok(formattedLogs);
        }
    }
}
