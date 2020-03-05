using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    public class ComposerService
    {
        //Create
        public async Task<bool> CreateComposerAsync(Composer model)
        {
            using (var con = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    con.Composers.Add(model);
                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Read
        public async Task<Composer> GetComposerByIdAsync(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = await con.Composers.FindAsync(id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public async Task<IEnumerable<Composer>> GetComposersAsync()
        {
            using (var con = new ApplicationDbContext())
            {
                return await con.Composers.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdateComposerAsync(Composer model)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = await con.Composers.FindAsync(model.ComposerId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Gender = model.Gender;
                entity.DateOfBirth = model.DateOfBirth;
                entity.DateOfDeath = model.DateOfDeath;
                entity.IsAlive = model.IsAlive;

                return await con.SaveChangesAsync() == 1;
            }
        }
        //Delete
        public async Task<bool> DeleteComposerAsync(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = await con.Composers.FindAsync(id);

                con.Composers.Remove(entity);

                return await con.SaveChangesAsync() == 1;
            }
        }
    }
}
