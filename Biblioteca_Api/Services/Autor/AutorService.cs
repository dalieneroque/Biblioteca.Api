using Biblioteca_Api.Data;
using Biblioteca_Api.Dto.Autor;
using Biblioteca_Api.Models;
using Biblioteca_Api.Services.Autor;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Api.Services.Autor
{
    public class AutorService : IAutorInterface
    {
        //Injeção de dependência do contexto do banco de dados
        //O .NET entrega automaticamente o AppDbContext configurado para essa classe,
        //permitindo acessar o banco de dados sem precisar instanciar manualmente.

        private readonly AppDbContext _context; //Cria uma variável apenas de leitura para armazenar o contexto do banco de dados
        public AutorService(AppDbContext context) //Recebe esse contexto e o armazena em _context
        {
            _context = context;
        }

        //Implementação dos métodos da interface IAutorInterface
        //Esse método busca um autor pelo seu ID
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if(autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    resposta.Status = false;
                    return resposta;
                }
                resposta.Dados = autor;
                resposta.Mensagem = "Autor encontrado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //Esse método busca um autor pelo ID de um livro associado a ele
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var livro = await _context.Livros.
                    Include(a => a.Autor).
                    FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if (livro == null)
                { 
                    resposta.Mensagem = "Livro não encontrado.";
                    return resposta;
                }
                resposta.Dados = livro.Autor;
                resposta.Mensagem = "Autor encontrado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel
                {
                    Nome = autorCriacaoDto.Nome,
                    Sobrenome = autorCriacaoDto.Sobrenome
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Autores.ToListAsync();               
                resposta.Mensagem = "Autor criado com sucesso.";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        //Esse método lista todos os autores cadastrados no banco de dados
        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autores = await _context.Autores.ToListAsync();
                resposta.Dados = autores;
                resposta.Mensagem = "Autores listados com sucesso.";
                resposta.Status = true;
            }
            catch (Exception ex)
            {
               resposta.Mensagem = ex.Message;
               resposta.Status = false;               
            }
            return resposta;
        }

        //Esse método edita os dados de um autor existente
        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == autorEdicaoDto.Id);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    return resposta;
                }
                autor.Nome = autorEdicaoDto.Nome;
                autor.Sobrenome = autorEdicaoDto.Sobrenome;
                _context.Update(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor editado com sucesso.";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

            return resposta;
        }

        //Esse método deleta um autor pelo seu ID
        public async Task<ResponseModel<List<AutorModel>>> DeletarAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado.";
                    return resposta;
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Autores.ToListAsync();
                resposta.Mensagem = "Autor deletado com sucesso.";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
       
    }
}
