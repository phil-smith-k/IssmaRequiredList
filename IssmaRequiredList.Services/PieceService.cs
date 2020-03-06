using IssmaRequiredList.Data;
using IssmaRequiredList.Models.PieceModels;
using IssmaRequiredList.Models.MovementModels;
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
        public async Task<PieceDetail> GetPieceById(int id)
        {
            using (var con = new ApplicationDbContext())
            {
                var entity = await con.Pieces.FindAsync(id);

                var movements = entity
                    .Movements
                    .Select(
                        mov =>
                            new MovementConcise
                            {
                                MovementNumber = mov.MovementNumber,
                                MovementName = mov.MovementName
                            })
                    .ToList();

                return new PieceDetail
                {
                    PieceId = entity.PieceId,
                    Title = entity.Title,
                    ComposerId = entity.ComposerId,
                    ComposerName = entity.Composer.FullName,
                    ArrangerId = entity.ArrangerId,
                    ArrangerName = entity.Arranger.FullName,
                    PublisherId = entity.PublisherId,
                    PublisherName = entity.Publisher.Name,
                    Requirement = entity.Requirement,
                    Duration = entity.Duration,
                    YearPublished = entity.YearPublished,
                    IsOutOfPrint = entity.IsOutOfPrint,
                    ListOfMovements = movements
                };
                
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
