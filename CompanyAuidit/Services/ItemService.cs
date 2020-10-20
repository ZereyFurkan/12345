using CompanyAuidit.Data;
using CompanyAuidit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyAuidit.Services
{
    public class ItemService
    {
        private readonly CompanyAuiditContext companyAuiditContext;

        public ItemService(CompanyAuiditContext companyAuiditContext)
        {
            this.companyAuiditContext = companyAuiditContext;
        }

        public List<Item> GetAll()
        {
            return companyAuiditContext.Items.ToList();
        }

        public Item GetById(int itemId)
        {
            return companyAuiditContext.Items.FirstOrDefault(item => item.Id == itemId);
        }

        public void Add(Item item)
        {
            companyAuiditContext.Items.Add(item);
            companyAuiditContext.SaveChanges();
        }

        public void Update(Item item)
        {
            companyAuiditContext.Items.Update(item);
            companyAuiditContext.SaveChanges();
        }

        public void Delete(int itemId)
        {
            var item = GetById(itemId);
            companyAuiditContext.Items.Remove(item);
            companyAuiditContext.SaveChanges();
        }
    }
}
