using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyTestimonialSection
{
    public class TestimonialSectionRepository : GenericRepository<TestimonialSection>, ITestimonialSectionRepository
    {
        private readonly ApplicationDBContext _db;
        public TestimonialSectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }

        public async Task Update(TestimonialSection obj)
        {
            _db.Update(obj);
        }
    }
}
