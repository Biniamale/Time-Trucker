using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.MasterPage.UI
{[Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Report> ReportList { get; set; }
        public IEnumerable<Customer> CustomerList { get; set; }

        public void OnGet()
        {
            ReportList = _unitOfWork.Report.GetAll(includeProperties: "Customer,Project");
            //CustomerList = _unitOfWork.Customer.GetAll(orderby: u => u.OrderBy(c => c.DisplayOrder));
        }
    }
}
