using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using InventoryAPI.Controllers;
using InventoryAPI.Data.Entities;
using static InventoryAPI.Data.Entities.UpsResponseObj;

namespace InventoryAPI.Data.ExternalDataAccess
{
    public static class UPS
    {


        public static async Task<UpsResponse> GetUPSTimeInTransit(string request)
        {
         
            

            var stringContent = new StringContent(request);

            var url = "https://wwwcie.ups.com/rest/TimeInTransit";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.PostAsync(url, stringContent))
            {
                if (response.IsSuccessStatusCode)
                {
                    UpsResponse resp = await response.Content.ReadAsAsync<UpsResponse>();
                    HttpStatusCode StatusCode = response.StatusCode;
                    return resp;

                }

                else
                {
                    throw new System.Exception(response.ReasonPhrase);
                }

            }

            
        }
        
        
    }
}