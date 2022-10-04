
using System;
using System.ComponentModel.DataAnnotations;

namespace ProvaFolha.Models
{
    public class Funcionario
    {
        public Funcionario () => CriadoEm = DateTime.Now;
        [Key()]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        public double Salario { get; set; }
        public string Email { get; set; }
        [Required]
        public DateTime Nascimento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}