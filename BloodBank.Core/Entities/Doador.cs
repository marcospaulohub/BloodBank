using System;
using BloodBank.Core.Enums;
using BloodBank.Core.ValueObject;

namespace BloodBank.Core.Entities
{
    public class Doador : BaseEntity
    {
        public Doador() : base() { }

        public string NomeCompleto { get; set; }
        public Telefone Telefone { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public double Peso { get; set; }
        public TipoSanguineo TipoSanguineo { get; set; }
        public FatorRh FatorRh { get; set; }
        public Endereco Endereco { get; set; }
    }
}
