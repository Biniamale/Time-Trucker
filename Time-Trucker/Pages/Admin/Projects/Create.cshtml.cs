using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Projects
{
   
        [BindProperties]
        public class CreateModel : PageModel
        {
        private readonly IUnitOfWork _unitOfWork;

        public Project Project { get; set; }


        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
            {
                if (ModelState.IsValid)
                {
                _unitOfWork.Project.Add(Project);
                _unitOfWork.Save();
                 TempData["success"] = "Project created successfully";
                 return RedirectToPage("Index");
                }
                return Page();
            }
        }
    }
