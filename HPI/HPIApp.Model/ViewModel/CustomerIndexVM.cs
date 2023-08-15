namespace HPIApp.Models.ViewModel
{
    public class CustomerIndexVM
    {
        public CompanyDetails companyDetails { get; set; }
        public ContactSection contactSection { get; set; }
        public Logo logo { get; set; }
        public HeroSection heroSection { get; set; }
        public WhyUsSection whyUsSection { get; set; }  
        public AboutUsSection aboutUsSection { get; set; }
        public EventsSection eventsSection { get; set; }
        public IEnumerable<FAQSection> faqSection { get; set; }
        public IEnumerable<TestimonialSection> testimonialSection { get; set; }
        public IEnumerable<GallerySection> gallerySection { get; set; }
    }
}
