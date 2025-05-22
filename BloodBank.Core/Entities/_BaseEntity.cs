using System;

namespace BloodBank.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CriadoEm = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public DateTime? ExcluidoEm { get; set; }

        public void DefinirComoAtualizado()
        {
            AtualizadoEm = DateTime.Now;
        }

        public void DefinirComoExcluido()
        {
            ExcluidoEm = DateTime.Now;
        }
    }

}
