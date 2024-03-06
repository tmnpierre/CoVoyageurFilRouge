using CoVoyageur.Core.Models;
using System.Linq.Expressions;
using CoVoyageur.API.Data;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.Repositories.Interfaces;

namespace CoVoyageur.API.Repositories.Implementations
{
    public class RideRepository : IRepository<Ride>
    {
        private ApplicationDbContext _db { get; }
        public RideRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<Ride>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Ride>> GetAll(Expression<Func<Ride, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Ride?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Ride?> Get(Expression<Func<Ride, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<int?> IRepository<Ride>.Add(Ride entity)
        {
            throw new NotImplementedException();
        }

        public Task<Ride?> Update(Ride entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
