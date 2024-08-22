using Domain;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;


HttpClient httpClient = new HttpClient();


var bebe = new Humano(1, "Noah", 3, "meses");
Console.WriteLine(bebe.Nascer());
Console.WriteLine(bebe.Dormir());

Console.WriteLine("---------------------------------------");
var homem = new Humano(2, "Ricardão", 35, "anos");
Console.WriteLine(homem.Reproduzir());
Console.WriteLine(homem.Morrer());


Console.WriteLine("--------------------------------------");


RunAsync(httpClient).GetAwaiter().GetResult();


static void MostarHumano(Humano humano) => Console.WriteLine($"Nome: {humano.Nome}\tIdade:{humano.Idade}");

static async Task<Uri> CreateHumanoAsync(Humano humano, HttpClient client)
{
    HttpResponseMessage response = await client.PostAsJsonAsync("api/Human", humano);
    response.EnsureSuccessStatusCode();

    // return URI of the created resource.
    return response.Headers.Location ?? response.RequestMessage.RequestUri;
}

static async Task<Humano> GetHumanoAsync(string path, HttpClient client)
{
    Humano humano = null;
    HttpResponseMessage response = await client.GetAsync(path);
    if (response.IsSuccessStatusCode)
    {
        var responseJson = response.Content.ReadAsStringAsync().Result;

        var humanolist = JsonConvert.DeserializeObject<List<Humano>>(responseJson);

        humano = humanolist[1];

        Console.WriteLine($"Json:  {responseJson}");
    }
    return humano;
}

static async Task<Humano> UpdateHumanoAsync(Humano humano, HttpClient client)
{
    HttpResponseMessage response = await client.PutAsJsonAsync(
        $"api/Human/{humano.ID}", humano);
    response.EnsureSuccessStatusCode();

    var responseJson = response.Content.ReadAsStringAsync().Result;

    var lstHumanos = JsonConvert.DeserializeObject<List<Humano>>(responseJson);

    Console.WriteLine($"Json:  {lstHumanos[0]}");

    return humano;
}

static async Task<HttpStatusCode> DeleteHumanoAsync(int id, HttpClient client)
{
    HttpResponseMessage response = await client.DeleteAsync($"api/Human/{id}");
    return response.StatusCode;
}

static async Task RunAsync(HttpClient client)
{
    client.BaseAddress = new Uri("https://localhost:7076/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

    try
    {
        Humano humano = new Humano(30, "Enzo", 3, "meses");

        var url = await CreateHumanoAsync(humano, client);
        Console.WriteLine($"Created at {url}");

        humano = await GetHumanoAsync(url.PathAndQuery.Trim('/'), client);
        MostarHumano(humano);

        Console.WriteLine("atualizando idade...");
        humano.Idade = 4;
        await UpdateHumanoAsync(humano, client);

        humano = await GetHumanoAsync(url.PathAndQuery, client);
        MostarHumano(humano);

        var statusCode = await DeleteHumanoAsync(humano.ID, client);
        Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

    Console.ReadLine();
}