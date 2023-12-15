using System;
using System.Text.Json.Serialization;

namespace Emisora
{
    public class Emisora
    {
        public int EmisoraID { get; set; }
        public DateTime Fecha { get; set; }
        [JsonPropertyName("Emisora")]
        public string? Nombre { get; set; }
        public string? Foto { get; set; }
        public string? Url { get; set; }
        public string? Provincia { get; set; }
        public string? Pais { get; set; }
        public string? Icon { get; set; }
    }
}
