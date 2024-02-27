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
        private int idDoUsuario ;
        

        public TarefasController(TarefasContext context)
        {
            _context = context;
        }
      
        public IActionResult Gerenciamento_De_Tarefas(int id)
        {
            var tarefas = _context.Tarefas.Where(t => t.UsuarioId == id).ToList();

            return View(tarefas); 
        }
       
        
       
        
       

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string Senha, string Email) {


            


             if (string.IsNullOrEmpty(Senha))
            {
                ViewBag.Mensagem = "Por favor, forneça um nome.";
                return View();
            }
            if (string.IsNullOrEmpty(Email))
            {
                ViewBag.Mensagem = "Por favor, forneça um nome.";
                return View();
            }
            
            var senha = _context.Usuarios.FirstOrDefault(p => p.Senha == Senha);
            var email = _context.Usuarios.FirstOrDefault(p => p.Email == Email);
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == Email && u.Senha == Senha);
            if (usuario != null)
            {
               
                return RedirectToAction("Gerenciamento_De_Tarefas", "Tarefas", new { id = usuario.Id });
            }
            else
            {
                ViewBag.Mensagem = "E-mail ou senha incorretos.";
                return View();
            }

            
        }

        public IActionResult Vertarefa(int id)
        {
        
            var tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);

            if (tarefa == null)
            {
                
                return RedirectToAction("vertarefa", "Tarefas"); 
            }

            return View(tarefa);
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
          
                if (usuario.DataDeNascimento == null)
                {
                    
                    usuario.DataDeNascimento = "xxxxxxxxxxxxx";
                }

        
                _context.Usuarios.Add(usuario);
           
                _context.SaveChanges();
              
            return View(usuario);
        }


        public IActionResult Criartarefa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criartarefa(Tarefa tarefa)
        {
            
                _context.Tarefas.Add(tarefa);
                _context.SaveChanges();
              
                return RedirectToAction("Criartarefa", "Tarefas");
           
        }
    }
}
