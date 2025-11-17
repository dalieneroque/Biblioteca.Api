using Biblioteca_Api.Data;
using Biblioteca_Api.Dto.Livro;
using Biblioteca_Api.Models;

namespace Biblioteca_Api.Services.Livro
{
    public class LivroService : ILivroInterface
    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<LivroModel>> BuscarLivroPorIdAutor(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> DeletarLivro(int idLivro)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto livroEdicaoDto)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            throw new NotImplementedException();
        }
    }
}
