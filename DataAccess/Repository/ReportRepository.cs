using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
     private readonly ApplicationDbContext _db;

     public ReportRepository(ApplicationDbContext db) : base(db)
     {
         _db = db;
     }



    public void Update(Report obj)
    {
     var objFromDb = _db.Report.FirstOrDefault(u => u.Id == obj.Id);
     objFromDb.StartingDate = obj.StartingDate;
     objFromDb.EndingDate = obj.EndingDate;
     objFromDb.ProjectId = obj.ProjectId;
     objFromDb.CustomerId = obj.CustomerId;
     objFromDb.Description = obj.Description;          

    }
  }
}

