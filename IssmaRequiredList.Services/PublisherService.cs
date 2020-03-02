using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    // TODO - Crud
    public class PublisherService
    {
        //Create
        public async Task<bool> CreatePublisherAsync(Publisher model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    ctx.Publishers.Add(model);
                    return await ctx.SaveChangesAsync() == 1;
                } 
            }
        }
        //Read
        public async Task<Publisher> GetPublisherByIdAsync(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Publishers.FindAsync(id);

                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                return await ctx.Publishers.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdatePublisherAsync(Publisher model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var currentModel = await ctx.Publishers.FindAsync(model.PublisherId);

                if (currentModel == null)
                    return false;
                else
                {
                    currentModel.Name = model.Name;
                    currentModel.Url = model.Url;

                    return await ctx.SaveChangesAsync() == 1;
                }
            }
        }
        //Delete
    }
}
