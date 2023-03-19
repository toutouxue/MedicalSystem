using MedicalSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MedicalSystem.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContext _dbContext;
        public UserRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(IUserBase user)
        {
            _dbContext.Set<DoctorEntity>().Add(user);
        }

        public void Delete(IUserBase user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUserBase> GetAll()
        {
            throw new NotImplementedException();
        }

        public IUserBase GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IUserBase user)
        {
            throw new NotImplementedException();
        }
    }
}
