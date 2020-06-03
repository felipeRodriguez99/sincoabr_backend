using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Service;
using SINCOABR_INFRASTRUCTURE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Service
{
    public class UsersService : IUsersService
    {
        private readonly UsersRepository _UsersRepository;

        public UsersService()
        {
            _UsersRepository = new UsersRepository();
        }

        public async Task<Users> createUser(Users model) => await _UsersRepository.createUser(model);

        public async Task<UsersDOT> getUser(string email)
        {
            return await _UsersRepository.getUser(email);
        }

        public async Task<UsersDOT> updateUser(UsersDOT model)
        {
            return await _UsersRepository.updateUser(model);
        }
    }
}
