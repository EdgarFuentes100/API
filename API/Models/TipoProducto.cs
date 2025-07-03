using System.Text.Json.Serialization;

namespace API.Models
{
    public class TipoProducto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore] // evita que Swagge usen esta propiedad
        public List<Products> Productos { get; set; } 

    }
}
