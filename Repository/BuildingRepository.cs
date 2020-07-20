using BNTU_fond.Models;
using BNTU_fond.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BNTU_fond.Repository
{
    public class BuildingRepository : IRepository<Building>
    {
        private readonly AppDbContext context;

        public BuildingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Building GetById(int id)
        {
            return context.Buildings.Find(id);
        }

        public void Create(Building building)
        {
            context.Buildings.Add(building);
            context.SaveChanges();
        }

        public void Update(Building building)
        {
            context.Entry(building).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Building building)
        {
            context.Buildings.Remove(building);
            context.SaveChanges();
        }

        public IQueryable<Building> GetAll()
        {
            return context.Buildings;
        }
    }
}
