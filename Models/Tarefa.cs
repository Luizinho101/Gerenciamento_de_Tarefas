using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_de_Tarefas.Models
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string StatusDaTarefa { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataDeInicioDaTarefa { get; set; }
        public DateTime DataFimDaTarefa { get; set; }

         public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}