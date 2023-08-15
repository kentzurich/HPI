using HPIApp.DataAccess.Repository;
using HPIApp.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace HPIApp.ViewComponents
{
    public class HeaderAdminViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;
        public HeaderAdminViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CustomerIndexVM customerIndexVM = new()
            {
                logo = await _unitOfWork.Logo.GetFirstOrDefaultAsync(x => x.Id == 1)
            };
            return View(customerIndexVM);
        }
    }
}
