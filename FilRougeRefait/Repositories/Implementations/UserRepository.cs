using CoVoyageur.Core.Models;
using System.Linq.Expressions;
using CoVoyageur.API.Data;
using Microsoft.EntityFrameworkCore;
using CoVoyageur.API.Repositories.Interfaces;

namespace CoVoyageur.API.Repositories.Implementations
{
    public class UserRepository : IRepository<User>
    {
        private ApplicationDbContext _db { get; }
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public Task<List<User>> GetAll()
        {
            return _db.Users.ToListAsync(); //fait

        }

        public async Task<List<User>> GetAll(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.Where(predicate).ToListAsync(); //fait
        }

        public async Task<User?> GetById(int id)
        {
            return await _db.Users.FindAsync(id); //fait
        }

        public async Task<User?> Get(Expression<Func<User, bool>> predicate)
        {
            return await _db.Users.FirstOrDefaultAsync(predicate); //fait
        }
        Task<int?> IRepository<User>.Add(User entity)
        {
            throw new NotImplementedException();
        }
        public async Task<User?> Add(User usr)
        {
            var added = await _db.Users.AddAsync(usr); //fait
            await _db.SaveChangesAsync();
            return added.Entity;
        }

        public async Task<User?> Update(User user)
        {
            var userDb = await GetById(user.ID);//fait
            if (userDb == null)
                return null;

            if (userDb.LastName != user.LastName)
                userDb.LastName = user.LastName;
            if (userDb.FirstName != user.FirstName)
                userDb.FirstName = user.FirstName;
            if (userDb.BirthDate != user.BirthDate)
                userDb.BirthDate = user.BirthDate;
            if (userDb.Email != user.Email)
                userDb.Email = user.Email;
            if (userDb.Password != user.Password)
                userDb.Password = user.Password;
            if (userDb.InscriptionDate != user.InscriptionDate)
                userDb.InscriptionDate = user.InscriptionDate;
            if (userDb.DrivingLicense != user.DrivingLicense)
                userDb.DrivingLicense = user.DrivingLicense;

            if (user.Rides != null)
            {
                foreach (Ride rideDb in userDb.Rides!)
                {
                    var presentRide = user.Rides.FirstOrDefault(r => r.ID == rideDb.ID);
                    if (presentRide != null)
                    {
                        user.Rides.Remove(presentRide);
                        continue;
                    }
                    _db.Rides.Remove(rideDb);
                }
                foreach (var newRide in user.Rides)
                {
                    await _db.Rides.AddAsync(newRide);
                }
            }
            else
            {
                foreach (var rideDb in userDb.Rides!)
                {
                    _db.Rides.Remove(rideDb);
                }
            }
            if (await _db.SaveChangesAsync() == 0)
                return null;

            return userDb;
        }

        public async Task<bool> Delete(int id)//fait
        {
            var user = await GetById(id);
            if (user == null)
                return false;
            _db.Users.Remove(user);
            return await _db.SaveChangesAsync() > 0;
        }

        
    }
}