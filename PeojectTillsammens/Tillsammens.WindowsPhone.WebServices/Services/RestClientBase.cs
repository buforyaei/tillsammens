using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Web;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Tillsammens.WindowsPhone.WebServices.Exceptions;

namespace Tillsammens.WindowsPhone.WebServices.Services
{
    public abstract class RestClientBase
    {
        protected RestClient RestClient;

        protected RestClientBase(string baseAddress)
        {
            RestClient = new RestClient(baseAddress);
        }

        protected async Task<TResponse> CallAsync<TResponse>(IRestRequest request)
        {
            IRestResponse response;
            try
            {
                response = await RestClient.Execute(request);
            }
            catch (Exception ex)
            {
                throw new WebServiceException(ex, WebErrorStatus.HostNameNotResolved);
            }
            if (!response.IsSuccess &&
                Enum.IsDefined(typeof(WebErrorStatus), (int)response.StatusCode))
            {
                throw new WebServiceException((WebErrorStatus)response.StatusCode);
            }

            var resultString = Encoding.UTF8.GetString(response.RawBytes, 0,
                response.RawBytes.Length);
            try
            {
                var result = JsonConvert.DeserializeObject<TResponse>(resultString);
                return result;
            }
            catch (Exception)
            {
                throw new WebServiceException(WebErrorStatus.Unknown);
            }
        }
    }
}