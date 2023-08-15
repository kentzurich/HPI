using HPIApp.Models;

namespace HPIApp.DataAccess.Repository.CompanyGallerySection
{
    public interface IGallerySectionRepository : IGenericRepository<GallerySection>
    {
        Task Update(GallerySection obj);
    }
}
