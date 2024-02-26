using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gerenciamento_de_Tarefas.Context;
using Gerenciamento_de_Tarefas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Gerenciamento_de_Tarefas.Controllers
{
    public class TarefasController : Controller
    {
        private readonly TarefasContext _context;
        

        public TarefasController(TarefasContext context)
        {
            _context = context;
        }

        public IActionResult Gerenciamento_De_Tarefas()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string nome) {

             if (string.IsNullOrEmpty(nome))
            {
                ViewBag.Mensagem = "Por favor, forneça um nome.";
                return View();
            }

            // Realize a consulta no banco de dados para verificar se o nome recebido no formulário existe
            var pessoa = _context.Usuarios.FirstOrDefault(p => p.Nome == nome);

            if (pessoa != null)
            {
                // Se encontrou uma pessoa com o nome fornecido, redirecione para outra página
                return RedirectToAction("Gerenciamento_De_Tarefas", "Tarefas");
            }
            else
            {
                // Se não encontrou uma pessoa com o nome fornecido, retorne para a mesma view com uma mensagem de erro
                ViewBag.Mensagem = "Nome não encontrado.";
                return View();
            }
        }

        public IActionResult Vertarefa()
        {
            var tarefas = _context.Tarefas.ToList();
            return View(tarefas);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            //if (ModelState.IsValid)
            //{
                // Verifica se o campo DataDeNascimento está preenchido
                if (usuario.DataDeNascimento == null)
                {
                    // Se não estiver preenchido, atribui a data atual como valor padrão
                    usuario.DataDeNascimento = "xxxxxxxxxxxxx";
                }

                // Adiciona o objeto Usuario ao contexto
                _context.Usuarios.Add(usuario);
                // Salva as mudanças no banco de dados
                _context.SaveChanges();
                //return RedirectToAction(nameof(Index));
            //}
            return View(usuario);
        }


        public IActionResult Criartarefa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criartarefa(Tarefa tarefa)
        {
            
           // if (ModelState.IsValid)
           // {
                // Adiciona a nova tarefa ao contexto
                _context.Tarefas.Add(tarefa);
                // Salva as mudanças no banco de dados
                _context.SaveChanges();
                // Redireciona para a página de gerenciamento de tarefas
                return RedirectToAction(nameof(Gerenciamento_De_Tarefas));
          //  }
            // Retorna a view com a tarefa em caso de falha na validação
           // return View(tarefa);
        }
    }
}
