using System.Collections.Generic;
using System.Linq;

namespace BNTU_fond.Models.ViewModel
{
    public class AuditoryViewModel
    {
        public int FloorNum { get; set; }
        public int FloorId { get; set; }
        public int BuildingId { get; set; }
        public IQueryable<Auditory> Auditories { get; set; }
    }
}
