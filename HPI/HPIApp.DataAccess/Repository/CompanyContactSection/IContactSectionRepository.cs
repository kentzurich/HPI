using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyContactSection
{
    public interface IContactSectionRepository : IGenericRepository<ContactSection>
    {
        Task Update(ContactSection obj);
    }
}
