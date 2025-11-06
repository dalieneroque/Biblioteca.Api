using System.Text.Json.Serialization;

namespace Biblioteca.Api.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [JsonIgnore] 
        //Um Livro tem um Autor
        public Autor Autor { get; set; }
    }
}
