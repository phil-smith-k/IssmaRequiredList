using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    //TODO - Crud
    public class PieceService
    {
        //Create
        public async Task<bool> CreatePieceAsync(Piece model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    ctx.Pieces.Add(model);
                    return await ctx.SaveChangesAsync() == 1;
                }
            }
        }
        //Read
        public async Task<Piece> GetPieceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = await ctx.Pieces.FindAsync(id);

                if (entity == null)
                    throw new InvalidOperationException();
                else
                {
                    return entity;
                }
            }
        }
        public async Task<IEnumerable<Piece>> GetPiecesAsync()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return await ctx.Pieces.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdatePieceAsync(Piece model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var currentModel = await ctx.Pieces.FindAsync(model.PieceId);

                if (currentModel == null)
                    return false;
                else
                {
                    currentModel.Title = model.Title;
                    currentModel.Requirement = model.Requirement;
                    currentModel.Duration = model.Duration;
                    currentModel.YearPublished = model.YearPublished;
                    currentModel.IsMultiMovement = model.IsMultiMovement;
                    currentModel.IsOutOfPrint = model.IsOutOfPrint;
                    currentModel.ComposerId = model.ComposerId;
                    currentModel.ArrangerId = model.ArrangerId;
                    currentModel.PublisherId = model.PublisherId;

                    return await ctx.SaveChangesAsync() == 1;
                }
            }
        }
        //Delete
        public async Task<bool> DeletePieceByIdAsync(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                throw new NotImplementedException();
            }
        }
    }
}
