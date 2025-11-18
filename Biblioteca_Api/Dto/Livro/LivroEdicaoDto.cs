using Biblioteca_Api.Models;

namespace Biblioteca_Api.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public AutorModel Autor { get; set; } // Adiciona a propriedade Autor
    }
}
