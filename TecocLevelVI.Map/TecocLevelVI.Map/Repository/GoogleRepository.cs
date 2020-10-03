using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TecocLevelVI.Map.Models;

namespace TecocLevelVI.Map.Repository
{
    public static class GoogleRepository
    {
        public async static Task<GeocodeModel> GetLocation(string address)
        {
            var dataResponse = new GeocodeModel();
            try
            {
                var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=";
                var http = new HttpClient();
                HttpResponseMessage response = await http.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    if (Convert.ToInt32(response.StatusCode) == 200)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        dataResponse = JsonConvert.DeserializeObject<GeocodeModel>(data);
                    }
                }
            }
            catch (Exception e)
            {
            }
            return dataResponse;
        }
    }
}
