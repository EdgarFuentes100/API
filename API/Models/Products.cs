using API.Models;
using System.Text.Json.Serialization;

namespace API.Models
{
    public class Products
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }

        public int TipoProductoId { get; set; }

        [JsonIgnore] // evita que Swagge usen esta propiedad
        public TipoProducto? TipoProducto { get; set; }
    }

}