using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Reports
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Report Report { get; set; }


        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
             Report = _unitOfWork.Report.GetFirstOrDefault(u => u.Id == id);

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                // _unitOfWork.Report.Update(Report);
                _unitOfWork.Save();
                TempData["success"] = "Report updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

