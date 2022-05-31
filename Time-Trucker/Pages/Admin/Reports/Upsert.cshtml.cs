using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;

namespace Time_Trucker.Pages.Admin.Reports
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<SelectListItem> CustomerList { get; set; }
        public IEnumerable<SelectListItem> ProjectList { get; set; }
        public Report Report { get; set; }
        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Report = new();
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                //Edit
                Report = _unitOfWork.Report.GetFirstOrDefault(u => u.Id == id);
            }

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

            var files = HttpContext.Request.Form.Files;
            if (Report.Id == 0)
            {
                //create
                string fileName_new = Guid.NewGuid().ToString();
               _unitOfWork.Report.Add(Report);
                _unitOfWork.Save();
            }
            else
            {
                //edit
                var objFromDb = _unitOfWork.Report.GetFirstOrDefault(u => u.Id == Report.Id);
                if (files.Count > 0)
                {
                    string fileName_new = Guid.NewGuid().ToString();
                    var extension = Path.GetExtension(files[0].FileName);

                    //new upload
                    using (var fileStream = new FileStream(Path.Combine(fileName_new + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                }
                _unitOfWork.Report.Update(Report);
                _unitOfWork.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}


