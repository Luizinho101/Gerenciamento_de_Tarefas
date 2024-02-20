using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gerenciamento_de_Tarefas.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome {get; set;}
        public string Email { get; set; }
        public string Senha { get; set; }
        public string DataDeNascimento { get; set; }
        public string Telefone {get; set;}
        public string Endereco { get; set; }
        public string EstadoCivil { get; set; }

        public ICollection<Tarefa> Tarefas { get; }
    }
}