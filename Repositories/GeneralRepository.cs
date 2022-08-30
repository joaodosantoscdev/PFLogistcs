using System.Threading.Tasks;
using PFLogistcs.Context;
using PFLogistcs.Repositories.Interfaces;

namespace PFLogistcs.Repositories
{
  public class GenericRepository : IGenericRepository
  {
    private readonly PFLogisticsDbContext  _context;
    public GenericRepository(PFLogisticsDbContext context)
    {
        _context = context;
    }

    public void Add<T>(T entity) where T : class
    {
      _context.Add(entity);
    }
    public void Update<T>(T entity) where T : class
    {
      _context.Update(entity);
    }

    public void Delete<T>(T entity) where T : class
    {
      _context.Remove(entity);
    }
    public void DeleteRange<T>(T[] entities) where T : class
    {
      _context.RemoveRange(entities);
    }

    public async Task<bool> SaveChangesAsync()
    {
      return (await _context.SaveChangesAsync()) > 0;
    }

  }
}