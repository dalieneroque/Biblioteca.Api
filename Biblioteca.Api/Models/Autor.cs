namespace Biblioteca.Api.Models
{
    public class Autor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        //Um Autor pode ter vários Livros
        public ICollection<Livro> Livros { get; set; }
    }
}
