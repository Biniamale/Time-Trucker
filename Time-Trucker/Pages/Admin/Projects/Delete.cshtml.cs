using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Projects
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Project Project { get; set; }


        public DeleteModel(IUnitOfWork unitOfWork)
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
                var projectFromDb = _unitOfWork.Project.GetFirstOrDefault(u => u.ProjectId == Project.ProjectId);
                if (projectFromDb != null)
                {
                    _unitOfWork.Project.Remove(projectFromDb);
                    _unitOfWork.Save();
                    TempData["success"] = "Project deleted successfully";

                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
