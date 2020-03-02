using IssmaRequiredList.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssmaRequiredList.Services
{
    public class MovementService
    {
        //Create
        public bool CreateMovement(Movement model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                if (model == null)
                    return false;
                else
                {
                    ctx.Movements.Add(model);
                    return ctx.SaveChanges() == 1;
                }
            }
        }
        //Read
        public Movement GetMovementById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movements.FirstOrDefault(m => m.MovementId == id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                    return entity;
            }
        }
        public IEnumerable<Movement> GetAllMovements()
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                return ctx.Movements.ToArray();
            }
        }
        //Update
        public bool UpdateMovement(Movement model)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var currentModel = ctx.Movements.FirstOrDefault(m => model.MovementId == m.MovementId);

                if (currentModel == null)
                    return false;
                else
                {
                    currentModel.MovementNumber = model.MovementNumber;
                    currentModel.PieceId = model.PieceId;

                    return ctx.SaveChanges() == 1;
                }
            }
        }
        //Delete
        public bool DeleteMovementById(int id)
        {
            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                var entity = ctx.Movements.FirstOrDefault(m => m.MovementId == id);
                if (entity == null)
                    throw new InvalidOperationException();
                else
                {
                    ctx.Movements.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

            }
        }
    }
}
