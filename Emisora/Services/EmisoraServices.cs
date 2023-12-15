using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Emisora.Services
{
    internal class EmisoraServices : IEmisoraServices
    {
        // URL de la API
        private string apiUrl = "https://tuneinradio.azurewebsites.net/api/movil/emisorasGet";
        public async Task<List<Emisora>> Obtener()
        {


            // Realizar solicitud HTTP
            var client = new HttpClient();
            var response = await client.GetAsync(apiUrl);
            var responseBody = await response.Content.ReadAsStringAsync();
            // Deserializar la respuesta JSON
            //JsonNode nodos = JsonNode.Parse(responseBody); 
            //JsonNode result = nodos["results"].ToJsonString();
            var emisoras = JsonSerializer.Deserialize<List<Emisora>>(responseBody);
            // Asignar datos a la propiedad Emisoras
            return emisoras!;
        }
    }
}
