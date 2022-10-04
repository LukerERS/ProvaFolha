
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ProvaFolha.Models;

namespace ProvaFolha.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {
         private readonly DataContext _context;
        public FolhaController(DataContext context) =>
            _context = context;
        // POST: /api/funcionario/cadastrar
        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folha)
        {
            Funcionario funcionario = _context.Funcionarios.Find(folha.FuncinarioId);
            if(funcionario != null)
            {
                double bruto = folha.Valorhora * folha.Quantidadedehoras;
                double impostodeRenda = ImpostoRenda(bruto);
                double impostodeInss = CalcInss(bruto);
                double  impostodeFgts = CalcFGTS(bruto);  
                double salarioLiquido =   bruto - impostodeRenda - impostodeInss;
                folha.Salariobruto = bruto;
                folha.Impostorenda = impostodeRenda;
                folha.Impostinss = impostodeInss;
                folha.Impostofgts = impostodeFgts;
                folha.SalarioLiquido = salarioLiquido;
                folha.Funcinario = funcionario;
                folha.mes = 10;
                folha.ano = 2022;
 
                _context.Folhas.Add(folha);
                _context.SaveChanges();
                return Created("", folha);
            }
            else
            {
                return NotFound();
            }
        }
        // GET: /api/folha/listar
        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            return _context.Folhas.ToList() != null ? Ok(_context.Folhas.ToList()) : NotFound();
        }
        // GET: /api/folha/buscar/{cpf}/{mes}/{ano}
        [HttpGet]
        [Route("buscar/{cpf}/{mes}/{ano}")]
        public IActionResult Buscar([FromRoute] string cpf, [FromRoute] int mes, [FromRoute] int ano)
        {
            Folha folha = _context.Folhas.FirstOrDefault(f => f.Funcinario.Cpf.Equals(cpf));
            return folha != null ? Ok(folha) : NotFound();
            
        }
        
        private double ImpostoRenda(double bruto)
        {
           if(bruto <= 1903.98)
                {
                    return 0;
            }else if(bruto <= 2826.65)
                {
                    return (bruto * 0.075) - 142.8;
            }else if (bruto <= 3751.05)
                {
                    return (bruto * 0.15) - 354.8;
            }else if (bruto <= 4664.68)
                {
                    return (bruto * 0.225) - 636.13;
            }return (bruto * 0.275) - 869.39;
        }
        private double CalcInss(double bruto)
        {
            if (bruto <= 1693.72) {
            return bruto * 0.08;
        } else if (bruto <= 2822.9) {
            return bruto * 0.09;
        } else if (bruto <= 5645.8) {
            return bruto * 0.11;
        }
        return 621.03;
        }
        private double CalcFGTS(double bruto)
        {
            return bruto * 0.08;
        }
    }
}