using System;

namespace BloodBank.Core.ValueObject
{
    public class FatorRh : IEquatable<FatorRh>
    {
        public static readonly FatorRh Positivo = new("+");
        public static readonly FatorRh Negativo = new("-");

        public string Simbolo { get; }

        private FatorRh(string simbolo)
        {
            Simbolo = simbolo;
        }

        public static FatorRh? APartir(string valor)
        {
            return valor switch
            {
                "+" => Positivo,
                "-" => Negativo,
                _ => null
            };
        }

        public override string ToString() => Simbolo;

        public bool Equals(FatorRh? outro) =>
            outro is not null && Simbolo == outro.Simbolo;

        public override bool Equals(object? obj) =>
            obj is FatorRh outro && Equals(outro);

        public override int GetHashCode() => Simbolo.GetHashCode();

        public static bool operator ==(FatorRh? a, FatorRh? b) =>
            a is null ? b is null : a.Equals(b);

        public static bool operator !=(FatorRh? a, FatorRh? b) =>
            !(a == b);
    }

}
