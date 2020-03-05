using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    public class PieceService
    {
        //Create
        public async Task<bool> CreatePieceAsync(Piece model)
        {
            using (var con = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    con.Pieces.Add(model);
                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Read
        public async Task<Piece> GetPieceById(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = await con.Pieces.FindAsync(id);

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
            using (var con = new ApplicationDbContext())
            {
                return await con.Pieces.ToListAsync();
            }
        }
        //Update
        public async Task<bool> UpdatePieceAsync(Piece model)
        {
            using (var con = new ApplicationDbContext())
            {
                var currentModel = await con.Pieces.FindAsync(model.PieceId);

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

                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
        //Delete
        public async Task<bool> DeletePieceByIdAsync(int id)
        {
            using(var con = new ApplicationDbContext())
            {
                var entity = await con.Pieces.FindAsync();
                if (entity == null)
                    throw new InvalidOperationException();
                else
                {
                    con.Pieces.Remove(entity);
                    return await con.SaveChangesAsync() == 1;
                }
            }
        }
    }
}
