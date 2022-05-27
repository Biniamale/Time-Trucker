using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Customers
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Customer Customer { get; set; }


        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void OnGet(int id)
        {
            Customer = _unitOfWork.Customer.GetFirstOrDefault(u => u.CustomerId == id);

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Customer.Update(Customer);
                _unitOfWork.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}

