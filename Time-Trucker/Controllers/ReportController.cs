using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Time_Trucker.Controllers
{
       [Route("api/[controller]")]
       [ApiController]
     public class ReportController : Controller
     {
      private readonly IUnitOfWork _unitOfWork;
      public ReportController(IUnitOfWork unitOfWork)
      {
         _unitOfWork = unitOfWork;
      }
    [HttpGet]
   public IActionResult Get()
     {
     var reportList = _unitOfWork.Report.GetAll(includeProperties: "Customer,Project");
     return Json(new { data = reportList });
     }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Report.GetFirstOrDefault(u => u.Id == id);
            _unitOfWork.Report.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful." });
        }

    }
}

