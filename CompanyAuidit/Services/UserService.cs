using CompanyAuidit.Contexts;
using CompanyAuidit.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.UserSecrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class UserService
    {
        private readonly CompanyAuiditContext companyAuiditContext;

        public UserService(CompanyAuiditContext companyAuiditContext)
        {
            this.companyAuiditContext = companyAuiditContext;
        }

        public List<User> GetAll()
        {
            return companyAuiditContext.Users.ToList();
        }

        public User GetById(int userId)
        {
            return companyAuiditContext.Users.FirstOrDefault(user => user.Id == userId);
        }

        public void Add(User user)
        {
            companyAuiditContext.Users.Add(user);
            companyAuiditContext.SaveChanges();
        }

        public void Update(User user)
        {
            companyAuiditContext.Users.Update(user);
            companyAuiditContext.SaveChanges();
        }

        public void Delete(int userId)
        {
            var user = new User { Id = userId };
            companyAuiditContext.Users.Remove(user);
            companyAuiditContext.SaveChanges();
        }

        public User GetUserWithItems(int userId)
        {
            return companyAuiditContext.Users
                .Include(user => user.UserItems)
                .ThenInclude(userItem => userItem.Item)
                .First(user => user.Id == userId);
        }

        public void Deleteİtem(int userId, int itemId)
        {
            var result = new UserItem { UserId = userId, ItemId = itemId};
            companyAuiditContext.UserItems.Remove(result);
            companyAuiditContext.SaveChanges();
        }
    }
}
