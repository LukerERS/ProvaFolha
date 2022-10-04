
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProvaFolha.Models
{
    public class Folha
    {  
        public int Id {get; set;}
        [ForeignKey("Funcionario")]
        public int FuncinarioId {get; set;}
        public double Valorhora {get; set;}
        public int Quantidadedehoras {get;set;}
        public double Salariobruto {get;set;}
        public double Impostorenda {get;set;}
        public double Impostinss {get; set;}
        public double Impostofgts {get;set;}
        public double SalarioLiquido {get;set;}
        public int mes{get;set;}
        public int ano{get; set;}
        public virtual Funcionario Funcinario {get;set;}

        public static implicit operator Folha(double v)
        {
            throw new NotImplementedException();
        }
    }
}