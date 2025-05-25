using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;

namespace BloodBank.Infra.Persistence.Repositories
{
    public  class DoadorRepository : IDoadorRepository
    {
        private readonly BloodBankDbContext _context;

        public DoadorRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public int Insert(Doador doador)
        {
            _context.Doadores.Add(doador);
            _context.SaveChanges();

            return doador.Id;
        }

        public void Update(Doador doador)
        {
            doador.DefinirComoAtualizado();

            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }

        public void Delete(Doador doador)
        {
            doador.DefinirComoExcluido();

            _context.Doadores.Update(doador);
            _context.SaveChanges();
        }

        public Doador GetById(int id)
        {
            var doador =
                _context
                .Doadores
                .SingleOrDefault(d => d.Id == id && d.ExcluidoEm == null);

            return doador;
        }

        public IEnumerable<Doador> GetAll()
        {
            var listaDoadores = 
                _context
                .Doadores
                .Where(d => d.ExcluidoEm == null)
                .ToList();

            return listaDoadores;
        }

    }
}
