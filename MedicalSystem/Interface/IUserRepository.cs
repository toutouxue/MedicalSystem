
// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


// Configure the HTTP request pipeline.
public interface IUserRepository
{
    IEnumerable<IUserBase> GetAll();
    IUserBase GetById(int id);
    void Add(IUserBase user);
    void Update(IUserBase user);
    void Delete(IUserBase user);
}
