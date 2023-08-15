using HPIApp.DataAccess.Data;
using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyGallerySection
{
    public class GallerySectionRepository : GenericRepository<GallerySection>, IGallerySectionRepository
    {
        private readonly ApplicationDBContext _db;
        public GallerySectionRepository(ApplicationDBContext db) : base(db)
        {
            _db = db;
        }
        public async Task Update(GallerySection obj)
        {
            _db.Update(obj);
        }
    }
}
