using System;
using System.Collections.Generic;
using System.Linq;

namespace BloodBank.Core.ValueObject
{
    public class TipoSanguineo : IEquatable<TipoSanguineo>
    {
        public string Valor { get; }

        private TipoSanguineo(string valor)
        {
            Valor = valor;
        }

        public static readonly TipoSanguineo APositivo = new("A+");
        public static readonly TipoSanguineo ANegativo = new("A-");
        public static readonly TipoSanguineo BPositivo = new("B+");
        public static readonly TipoSanguineo BNegativo = new("B-");
        public static readonly TipoSanguineo ABPositivo = new("AB+");
        public static readonly TipoSanguineo ABNegativo = new("AB-");
        public static readonly TipoSanguineo OPositivo = new("O+");
        public static readonly TipoSanguineo ONegativo = new("O-");

        public static IEnumerable<TipoSanguineo> ListarTodos()
        {
            return new[]
            {
            APositivo, ANegativo, BPositivo, BNegativo,
            ABPositivo, ABNegativo, OPositivo, ONegativo
        };
        }

        public static TipoSanguineo? APartir(string valor)
        {
            return ListarTodos().FirstOrDefault(ts => ts.Valor == valor);
        }

        public override string ToString() => Valor;

        public bool Equals(TipoSanguineo? other)
        {
            if (other is null) return false;
            return Valor == other.Valor;
        }

        public override bool Equals(object? obj) =>
            obj is TipoSanguineo other && Equals(other);

        public override int GetHashCode() => Valor.GetHashCode();

        public static bool operator ==(TipoSanguineo? a, TipoSanguineo? b) =>
            a is null ? b is null : a.Equals(b);

        public static bool operator !=(TipoSanguineo? a, TipoSanguineo? b) =>
            !(a == b);
    }

}
