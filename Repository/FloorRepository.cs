using BNTU_fond.Models;
using BNTU_fond.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BNTU_fond.Repository
{
    public class FloorRepository : IRepository<Floor>
    {
        private readonly AppDbContext context;

        public FloorRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Floor GetById(int id)
        {
            return context.Floors.Find(id);
        }

        public void Create(Floor floor)
        {
            context.Floors.Add(floor);
            context.SaveChanges();
        }

        public void Update(Floor floor)
        {
            context.Entry(floor).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Floor floor)
        {
            context.Floors.Remove(floor);
            context.SaveChanges();
        }

        public IQueryable<Floor> GetAll()
        {
            return context.Floors;
        }
    }
}
