using HPIApp.DataAccess.Repository.User;
using HPIApp.DataAccess.Repository.UserTransaction;
using HPIApp.DataAccess.Repository.PaymentMethodUser;
using HPIApp.DataAccess.Repository.GenderUser;
using HPIApp.DataAccess.Repository.ReligionUser;
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
    public interface IUnitOfWork
    {
        IApplicationUserRepository ApplicationUser { get; }
        IGenderRepository Gender { get; }
        IReligionRepository Religion { get; }
        IBranchRepository Branch { get; }
        IClassRepository Class { get; }
        IPaymentMethodRepository PaymentMethod { get; }
        ITransactionRepository Transaction { get; }
        ILogoRepository Logo { get; }
        ICompanyDetailsRepository CompanyDetails { get; }
        IHeroSectionRepository HeroSection { get; }
        IWhyUsSectionRepository WhyUsSection { get; }
        IAboutUsSectionRepository AboutUsSection { get; }
        IEventSectionRepository EventSection { get; }
        IFAQSectionRepository FAQSection { get; }
        ITestimonialSectionRepository TestimonialSection { get; }
        IGallerySectionRepository GallerySection { get; }
        IContactSectionRepository ContactSection { get; }
        Task SaveAsync();
    }
}
