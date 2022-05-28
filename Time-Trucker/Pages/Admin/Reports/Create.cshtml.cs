using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Time_Trucker.Pages.Admin.Reports
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public Report Report { get; set; }
        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Report = new();
        }
        public void OnGet()
        {

            CustomerList = _unitOfWork.Customer.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FullName,
                Value = i.CustomerId.ToString()
            });
            ProjectList = _unitOfWork.Project.GetAll().Select(i => new SelectListItem()
            {
                Text = i.ProjectName,
                Value = i.ProjectId.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                // _unitOfWork.Report.Add(Report);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}


