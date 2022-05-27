using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Projects
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Project Project { get; set; }


        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Project = _unitOfWork.Project.GetFirstOrDefault(u => u.ProjectId == id);

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {

                _unitOfWork.Project.Update(Project);
                _unitOfWork.Save();
                TempData["success"] = "Project updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
