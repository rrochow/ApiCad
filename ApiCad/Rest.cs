using ApiCad.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ApiCad
{
    public class RestClient
    {
        public async Task<List<Plano_>> Get_plano<Plano_>(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<Plano_>>(jsonstring);
                }


            }
            catch (Exception ex)
            {
                return null;
            }

            return default(List<Plano_>);
        }

    }

    public class RestUser
    {
        public async Task<List<User>> Get_user<User>(string url)
        {
            try
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var jsonstring = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<User>>(jsonstring);
                }
               
            }
            catch (Exception ex)
            {
                return default(List<User>);

            }

            return default(List<User>);
        }

    }

}

