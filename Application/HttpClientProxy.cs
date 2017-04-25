using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FaceDetectorApi.Application
{
    public class HttpClientProxy : IClientProxy
    {
        public async Task<string> PostAsync(string imageUrl,string cognitiveApi)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "e7a59a104fa148a3a741879a69c1d4ff");
                var httpBody = "{\"url\":\"" + imageUrl + "\"}";
                var httpContent = new StringContent(httpBody, Encoding.UTF8, "application/json");
                var httpResponse = await httpClient.PostAsync(cognitiveApi, httpContent);
             
                return await httpResponse.Content.ReadAsStringAsync();
            }
        }
    }
}

