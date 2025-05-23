using BloodBank.Core.Entities;
using BloodBank.Core.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodBank.Infra.Persistence.Mappings
{
    public class DoadorMap : IEntityTypeConfiguration<Doador>
    {
        public void Configure(EntityTypeBuilder<Doador> builder)
        {
            builder.ToTable("Doadores");

            builder.HasKey(d => d.Id);

            builder.Property(d => d.NomeCompleto)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(d => d.Telefone)
                .HasConversion(
                    telefone => telefone.Numero,
                    numero => new Telefone(numero))
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(d => d.Email)
                .HasColumnType("varchar(200)")
                .IsRequired();

            builder.Property(d => d.DataNascimento)
                .HasColumnType("datetime2")
                .IsRequired();

            builder.Property(d => d.Sexo)
                .HasConversion<int>()
                .IsRequired();

            builder.Property(d => d.Peso)
                .HasColumnType("decimal(5,2)")
                .IsRequired();

            builder.Property(d => d.FatorRh)
                .HasConversion(
                    v => v.Simbolo, // grava como "+" ou "-"
                    v => FatorRh.APartir(v)!) // leitura (com ! assumindo valor válido)
                .HasColumnType("char(1)")
                .IsRequired();

            builder.Property(d => d.TipoSanguineo)
                .HasConversion(
                    v => v.Valor, // grava como "A+", "B-", etc.
                    v => TipoSanguineo.APartir(v)!)
                .HasColumnType("varchar(3)")
                .IsRequired();

            builder.OwnsOne(d => d.Endereco, endereco =>
            {
                endereco.Property(e => e.Logradouro)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Logradouro")
                    .IsRequired();

                endereco.Property(e => e.Cidade)
                    .HasColumnType("varchar(100)")
                    .HasColumnName("Cidade")
                    .IsRequired();

                endereco.Property(e => e.Estado)
                    .HasColumnType("char(2)")
                    .HasColumnName("Estado")
                    .IsRequired();

                endereco.Property(e => e.Cep)
                    .HasColumnType("varchar(9)") // considerando "00000-000"
                    .HasColumnName("Cep")
                    .IsRequired();
            });
        }
    }
}
