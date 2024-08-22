using Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Services
{
    public class HumansServices
    {
        public async Task<string?> GetCyclopMorty()
        {
            var url = "https://rickandmortyapi.com/api/character/85";
            var parameters = "";

            string? retorno = null;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(parameters).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
                retorno = await response.Content.ReadAsStringAsync();

            return retorno;
        }
    }
}