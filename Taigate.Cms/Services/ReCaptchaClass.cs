using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;


namespace Taigate.Cms.Services
{
    public class ReCaptchaClass
    {
        public static string Validate(string encodedResponse)
        {
            var client = new WebClient();
            var secretKey = "6Ld9x1wiAAAAALAqAUkitJ0UuTeVSMLbFHy2pUi4";
           
            var googleReply = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, encodedResponse));
            var captchaResponse = JsonConvert.DeserializeObject<ReCaptchaClass>(googleReply);
            
            return captchaResponse.Success.ToLower();
        }

        [JsonProperty("success")]
        public string Success
        {
            get { return m_Success; }
            set { m_Success = value; }
        }

        private string m_Success;
        [JsonProperty("error-codes")]
        public List<string> ErrorCodes
        {
            get { return m_ErrorCodes; }
            set { m_ErrorCodes = value; }
        }


        private List<string> m_ErrorCodes;
    }


}