using DataAccess.Data;
using DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace Time_Trucker.Pages.Admin.Customers
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Customer> Customers { get; set; }

            public IndexModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public void OnGet()
            {
                Customers = _unitOfWork.Customer.GetAll();
        }
        }
    }

