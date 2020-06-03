using SINCOABR_CONTEXT.Context;
using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Repository
{
    public class UsersRepository : IUsersRepository
    {
        public async Task<Users> createUser(Users model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    model.userId = Guid.NewGuid();
                    model.createDate = DateTime.Now;
                    model.state = true;
                    context.Users.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<UsersDOT> getUser(string email)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var user = await context.Users.Where(c => c.email == email).FirstOrDefaultAsync();

                    UsersDOT usersDOT = new UsersDOT();

                    usersDOT.userId = user.userId;
                    usersDOT.email = user.email;
                    usersDOT.password = user.password;
                    usersDOT.name = user.name;
                    usersDOT.latName = user.latName;
                    usersDOT.createDate = user.createDate;
                    usersDOT.state = user.state;
                    usersDOT.rolId = user.rolId;

                    return usersDOT;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<UsersDOT> updateUser(UsersDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    Users users = new Users();

                    users.userId = model.userId;
                    users.email = model.email;
                    users.password = model.password;
                    users.name = model.name;
                    users.latName = model.latName;
                    users.createDate = model.createDate;
                    users.state = model.state;
                    users.rolId = model.rolId;
                    context.Entry(users).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
