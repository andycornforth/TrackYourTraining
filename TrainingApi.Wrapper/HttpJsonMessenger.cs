using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Wrapper
{
    public class HttpJsonMessenger : IHttpMessenger
    {
        private string baseAddress;
        //private string authorizationKey;
        private string contentType = "application/json";

        public HttpJsonMessenger(string baseAddress)
        {
            this.baseAddress = baseAddress;
            //this.authorizationKey = authorizationKey;
        }

        public string Get(string relativeUrl)
        {
            using (var client = new HttpClient())
            {
                ConfigureHttpClient(client);

                HttpResponseMessage httpResponse = client.GetAsync(relativeUrl).Result;

                HandleResponseErrors(httpResponse);

                return httpResponse.Content.ReadAsStringAsync().Result;
            }
        }

        public T GetObjectFromString<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString); 
        }

        public T Post<T, TIn>(string relativeUrl, TIn postData)
        {
            var message = JsonConvert.SerializeObject(postData);

            return Post<T>(relativeUrl, message);
        }

        public T Post<T>(string relativeUrl, string message)
        {
            using (var client = new HttpClient())
            {
                ConfigureHttpClient(client);

                var httpContent = new StringContent(message);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue(contentType);
                HttpResponseMessage httpResponse = client.PostAsync(relativeUrl, httpContent).Result;

                HandleResponseErrors(httpResponse);

                var response = httpResponse.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(response);
            }
        }

        private void ConfigureHttpClient(HttpClient client)
        {
#if DEBUG
            // Allows any certificate, which is useful for debugging on a local machine with a developer certificate
            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
#endif

            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authorizationKey);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));
            client.BaseAddress = new Uri(baseAddress);
        }

        private static void HandleResponseErrors(HttpResponseMessage response)
        {
            //// TODO: This doesn't belong in a general HTTP messaging class
            //// as it is specific to our API.

            //if (!response.IsSuccessStatusCode)
            //{
            //    switch (response.StatusCode)
            //    {
            //        case HttpStatusCode.Redirect:
            //            // This is expected, so we allow this case
            //            break;
            //        case HttpStatusCode.Conflict:
            //            // Bad response that can be rectified by end user sending correct values next time
            //            throw new ValidationException(response.ReasonPhrase);
            //        case HttpStatusCode.BadRequest:
            //            // Api used incorrectly, e.g. methods not being called appropriately with correct parameters
            //            throw new BadRequestException(response.ReasonPhrase);
            //        case HttpStatusCode.NotImplemented:
            //            throw new ApiNotImplementedException(response.ReasonPhrase);
            //        case (HttpStatusCode)422:
            //            throw new BadContentException(response.ReasonPhrase);
            //        case HttpStatusCode.Unauthorized:
            //            throw new ApiUnauthorizedException(response.ReasonPhrase);
            //        default:
            //            throw new ApiException(string.Format("{0}: {1}", response.StatusCode, response.ReasonPhrase));
            //    }
            //}
        }

    }
}
