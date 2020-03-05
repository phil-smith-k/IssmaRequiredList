using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    public class PublisherService
    {
        //Create
        public async Task<bool> CreatePublisherAsync(Publisher model)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    con.Publishers.Add(model);
                    return await con.SaveChangesAsync() == 1;
                } 
            }
        }
        //Read
        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var entity = await con.Publishers.FindAsync(id);

                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                return await con.Publishers.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdatePublisherAsync(Publisher model)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var currentModel = await con.Publishers.FindAsync(model.PublisherId);

                if (currentModel == null)
                    return false;
                else
                {
                    currentModel.Name = model.Name;
                    currentModel.Url = model.Url;

                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Delete
        public async Task<bool> DeletePublisherByIdAsync(int id)
        {
            using (ApplicationDbContext con = new ApplicationDbContext())
            {
                var entity = await con.Publishers.FindAsync(id);

                if (entity == null)
                    return false;
                else
                {
                    con.Publishers.Remove(entity);
                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
    }
}
