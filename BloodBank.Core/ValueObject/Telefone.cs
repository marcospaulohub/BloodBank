using System;
using System.Text.RegularExpressions;

namespace BloodBank.Core.ValueObject
{
    public class Telefone : IEquatable<Telefone>
    {
        public string Numero { get; }

        public Telefone() { }

        public Telefone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                throw new ArgumentException("Número de telefone não pode ser vazio.");

            // Validação simples para telefones brasileiros com ou sem máscara
            var formatoValido = Regex.IsMatch(numero, @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$");
            if (!formatoValido)
                throw new ArgumentException("Número de telefone inválido. Ex: (85) 91234-5678");

            Numero = numero;
        }

        public override string ToString() => Numero;

        public bool Equals(Telefone? outro) =>
            outro is not null && Numero == outro.Numero;

        public override bool Equals(object? obj) =>
            obj is Telefone outro && Equals(outro);

        public override int GetHashCode() => Numero.GetHashCode();

        public static bool operator ==(Telefone? a, Telefone? b) =>
            a is null ? b is null : a.Equals(b);

        public static bool operator !=(Telefone? a, Telefone? b) =>
            !(a == b);
    }
}
