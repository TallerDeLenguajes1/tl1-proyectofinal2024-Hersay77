using System.Text.Json;
using EspacioClaseListaEpisdios;

namespace EspacioAPI
{
    public class Api
    {
        public static async Task<List<Episodio>> GetEpisodiosAsync(string url) 
        {
            try //para manejo de posibles excepciones
            {
                HttpClient client = new HttpClient(); 
                HttpResponseMessage response = await client.GetAsync(url); 
                response.EnsureSuccessStatusCode(); 
                string responseBody = await response.Content.ReadAsStringAsync(); 
                List<Episodio> ListaEpisodios = JsonSerializer.Deserialize<List<Episodio>>(responseBody);
                return ListaEpisodios;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Problemas de acceso a la API");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }    
    }
}