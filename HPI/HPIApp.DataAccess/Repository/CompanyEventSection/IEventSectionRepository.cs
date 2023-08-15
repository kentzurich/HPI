using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyEventSection
{
    public interface IEventSectionRepository : IGenericRepository<EventsSection>
    {
        Task Update(EventsSection obj);
    }
}
