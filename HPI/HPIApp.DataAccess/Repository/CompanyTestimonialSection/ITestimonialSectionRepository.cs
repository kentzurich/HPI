using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyTestimonialSection
{
    public interface ITestimonialSectionRepository : IGenericRepository<TestimonialSection>
    {
        Task Update(TestimonialSection obj);
    }
}
