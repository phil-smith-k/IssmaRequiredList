using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    //TODO - Crud
    public class ComposerService
    {
        //Create
        public async Task<bool> CreateComposerAsync(Composer model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    ctx.Composers.Add(model);
                    return await ctx.SaveChangesAsync() == 1;
                }
            }
        }
        //Read
        public async Task<Composer> GetComposerByIdAsync(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Composers.FindAsync(id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public async Task<IEnumerable<Composer>> GetComposersAsync()
        {
            throw new NotImplementedException();
        }
        //Update

        //Delete
    }
}
