using IngameDemo.Core.Context;
using IngameDemo.Core.DTOs;
using IngameDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IngameDemo.Core.Repositories
{
    public class UserRepository : BasicCrudRepo<User>
    {
        private readonly ApiContext _context;
        public UserRepository(ApiContext context) : base(context)
        {
            _context = context;
        }

        public User Login(LoginInput  loginInput)
        {
            return _context.User.Where(x => x.Email == loginInput.Email && x.Password == loginInput.Password).FirstOrDefault();
        }
    }
}
