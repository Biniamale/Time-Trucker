using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Customers
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Customer Customer { get; set; }


        public DeleteModel(IUnitOfWork unitOfWork)
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
                var customerFromDb = _unitOfWork.Customer.GetFirstOrDefault(u => u.CustomerId == Customer.CustomerId);
                if (customerFromDb != null)
                {
                    _unitOfWork.Customer.Remove(customerFromDb);
                    _unitOfWork.Save();
                    TempData["success"] = "Customer deleted successfully";

                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}


