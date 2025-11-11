using Biblioteca_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca_Api.Data
{
    public class AppDbContext : DbContext //Classe que representa o contexto do banco de dados
    {
        //Construtor que recebe as opções de configuração do DbContext
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        //Definindo as entidades do banco de dados
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<LivroModel> Livros { get; set; }
    }
}
