namespace Biblioteca_Api.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Sobrenome { get; set; }

        //Um Autor pode ter vários Livros
        public ICollection<LivroModel> Livros { get; set; }
    }
}
