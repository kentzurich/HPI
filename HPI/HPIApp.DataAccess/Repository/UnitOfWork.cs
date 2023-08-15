using HPIApp.DataAccess.Data;
using HPIApp.DataAccess.Repository.User;
using HPIApp.DataAccess.Repository.PaymentMethodUser;
using HPIApp.DataAccess.Repository.ReligionUser;
using HPIApp.DataAccess.Repository.UserTransaction;
using HPIApp.DataAccess.Repository.GenderUser;
using HPIApp.DataAccess.Repository.BranchUser;
using HPIApp.DataAccess.Repository.ClassUser;
using HPIApp.DataAccess.Repository.CompanyLogo;
using HPIApp.DataAccess.Repository.CompanyDetailsSection;
using HPIApp.DataAccess.Repository.CompanyHeroSection;
using HPIApp.DataAccess.Repository.CompanyWhyUsSection;
using HPIApp.DataAccess.Repository.CompanyAboutUsSection;
using HPIApp.DataAccess.Repository.CompanyEventSection;
using HPIApp.DataAccess.Repository.CompanyFAQSection;
using HPIApp.DataAccess.Repository.CompanyTestimonialSection;
using HPIApp.DataAccess.Repository.CompanyGallerySection;
using HPIApp.DataAccess.Repository.CompanyContactSection;

namespace HPIApp.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _db; 
        public UnitOfWork(ApplicationDBContext db)
        {
            _db = db;
        }
        public IApplicationUserRepository ApplicationUser => new ApplicationUserRepository(_db);
        public IGenderRepository Gender => new GenderRepository(_db);
        public IReligionRepository Religion  => new ReligionRepository(_db);
        public IBranchRepository Branch => new BranchRepository(_db);
        public IClassRepository Class => new ClassRepository(_db);
        public IPaymentMethodRepository PaymentMethod => new PaymentMethodRepository(_db);
        public ITransactionRepository Transaction => new TransactionRepository(_db);
        public ILogoRepository Logo => new LogoRepository(_db);
        public ICompanyDetailsRepository CompanyDetails => new CompanyDetailsRepository(_db);
        public IHeroSectionRepository HeroSection => new HeroSectionRepository(_db);
        public IWhyUsSectionRepository WhyUsSection => new WhyUsSectionRepository(_db);
        public IAboutUsSectionRepository AboutUsSection => new AboutUsSectionRepository(_db);
        public IEventSectionRepository EventSection => new EventSectionRepository(_db);
        public IFAQSectionRepository FAQSection => new FAQSectionRepository(_db);
        public ITestimonialSectionRepository TestimonialSection => new TestimonialSectionRepository(_db);
        public IGallerySectionRepository GallerySection => new GallerySectionRepository(_db);
        public IContactSectionRepository ContactSection => new ContactSectionRepository(_db);

        public Task SaveAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
