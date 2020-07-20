using BNTU_fond.Models;
using BNTU_fond.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BNTU_fond.Repository
{
    public class AuditoryRepository : IRepository<Auditory>
    {
        private readonly AppDbContext context;

        public AuditoryRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Auditory GetById(int id)
        {
            return context.Auditories.Find(id);
        }

        public void Create(Auditory auditory)
        {
            context.Auditories.Add(auditory);
            context.SaveChanges();
        }

        public void Update(Auditory auditory)
        {
            context.Entry(auditory).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Auditory auditory)
        {
            context.Auditories.Remove(auditory);
            context.SaveChanges();
        }

        public IQueryable<Auditory> GetAll()
        {
            return context.Auditories;
        }
    }
}
