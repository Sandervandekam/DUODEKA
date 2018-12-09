using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using domain.objects;

namespace dal.repositories
{
    public class UserRepository : domain.interfaces.IUserRepository
    {
        domain.interfaces.IUserRepository ctx = new contexts.UserContext();

        public void create(User entity)
        {
            ctx.create(entity);
        }

        public void delete(User enity)
        {
            ctx.delete(enity);
        }

        public void deleteById(int id)
        {
            ctx.deleteById(id);
        }

        public User read(int id)
        {
            return ctx.read(id);
        }

        public User read(User entity)
        {
            return ctx.read(entity);
        }

        public IEnumerable<User> readAll()
        {
            return ctx.readAll();
        }

        public void update(User entity)
        {
            ctx.update(entity);
        }
    }
}
