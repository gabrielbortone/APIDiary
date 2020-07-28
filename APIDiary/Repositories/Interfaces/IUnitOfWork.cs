namespace APIDiary.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        EntradaRepository EntradaRepository { get;  }
        ImagemRepository ImagemRepository { get; }
        public void Commit();

    }
}
