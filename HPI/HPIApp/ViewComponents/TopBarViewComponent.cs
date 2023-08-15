using HPIApp.DataAccess.Repository;
using HPIApp.Models;
using HPIApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.ViewComponents
{
    public class TopBarViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public TopBarViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CustomerIndexVM customerIndexVM = new()
            {
                companyDetails = await _unitOfWork.CompanyDetails.GetFirstOrDefaultAsync(x => x.Id == 1),
            };
            return View(customerIndexVM);
        }
    }
}
