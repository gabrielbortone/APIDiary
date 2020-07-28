using APIDiary.Models;
using APIDiary.Repositories.Interfaces;

namespace APIDiary.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public EntradaRepository EntradaRepository { get; }
        public ImagemRepository ImagemRepository { get; }
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            EntradaRepository = new EntradaRepository(_context);
            ImagemRepository = new ImagemRepository(_context);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
