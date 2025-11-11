using System.Text.Json.Serialization;

namespace Biblioteca_Api.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        [JsonIgnore] 
        //Um Livro tem um Autor
        public AutorModel Autor { get; set; }
    }
}
