using System;
using System.Text.RegularExpressions;

namespace BloodBank.Core.ValueObject
{
    public class Endereco : IEquatable<Endereco>
    {
        public int Id { get; }                 // Usado apenas se necessário para persistência
        public string Logradouro { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public string Cep { get; }

        public Endereco(string logradouro, string cidade, string estado, string cep, int id = 0)
        {
            if (string.IsNullOrWhiteSpace(logradouro))
                throw new ArgumentException("Logradouro não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(cidade))
                throw new ArgumentException("Cidade não pode ser vazia.");

            if (string.IsNullOrWhiteSpace(estado) || estado.Length != 2)
                throw new ArgumentException("Estado deve conter exatamente 2 letras (ex: 'CE').");

            if (!Regex.IsMatch(cep, @"^\d{5}-\d{3}$"))
                throw new ArgumentException("CEP inválido. Use o formato 00000-000.");

            Id = id;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado.ToUpper();
            Cep = cep;
        }

        public override string ToString() =>
            $"{Logradouro}, {Cidade} - {Estado}, {Cep}";

        public bool Equals(Endereco? outro)
        {
            if (outro is null) return false;

            return Logradouro == outro.Logradouro &&
                   Cidade == outro.Cidade &&
                   Estado == outro.Estado &&
                   Cep == outro.Cep;
        }

        public override bool Equals(object? obj) =>
            obj is Endereco outro && Equals(outro);

        public override int GetHashCode() =>
            HashCode.Combine(Logradouro, Cidade, Estado, Cep);

        public static bool operator ==(Endereco? a, Endereco? b) =>
            a is null ? b is null : a.Equals(b);

        public static bool operator !=(Endereco? a, Endereco? b) =>
            !(a == b);
    }

}
