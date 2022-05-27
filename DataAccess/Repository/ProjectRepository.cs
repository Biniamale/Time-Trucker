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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private readonly ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Project obj)
        {
            var objFromDb = _db.Project.FirstOrDefault(u => u.ProjectId == obj.ProjectId);
            objFromDb.ProjectName = obj.ProjectName;
        }
    }
}
