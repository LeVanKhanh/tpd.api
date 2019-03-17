using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System.Text;

namespace Tpd.Api.Utility.Serializer
{
    public static class JsonHelper
    {
        public static void WriteJson<T>(this HttpResponse response, T obj, string contentType = null)
        {
            response.ContentType = contentType ?? "application/json";
            using (var writer = new HttpResponseStreamWriter(response.Body, Encoding.UTF8))
            {
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    jsonWriter.CloseOutput = false;
                    jsonWriter.AutoCompleteOnClose = false;

                    Serializer.Serialize(jsonWriter, obj);
                }
            }
        }

        private static readonly JsonSerializer Serializer = new JsonSerializer
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
