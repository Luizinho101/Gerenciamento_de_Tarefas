using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento_de_Tarefas.Context
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas{get; set;}
        public DbSet<Usuario> Usuarios{get; set;}
    }
}