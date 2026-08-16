using FluentValidation;
using Traversal.BusinessLayer.Abstract;
using Traversal.BusinessLayer.Concrete;
using Traversal.BusinessLayer.ValidationRules.AboutValidators;
using Traversal.BusinessLayer.ValidationRules.DestinationValidators;
using Traversal.BusinessLayer.ValidationRules.FeatureGridValidators;
using Traversal.BusinessLayer.ValidationRules.FeatureMainValidators;
using Traversal.BusinessLayer.ValidationRules.GuideValidators;
using Traversal.BusinessLayer.ValidationRules.InfoCardValidators;
using Traversal.BusinessLayer.ValidationRules.TestimonialValidators;
using Traversal.BusinessLayer.ValidationRules.WhyChooseUsValidators;
using Traversal.DataAccessLayer.Abstract;
using Traversal.DataAccessLayer.EntityFramework;
using Traversal.DataAccessLayer.Repository;

namespace Traversal.WebUI.Extensions
{
    public static class ServiceExtension
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
            services.AddScoped<IDestinationDal, EfDestinationDal>();
            services.AddScoped<IAboutDal, EfAboutDal>();
            services.AddScoped<IContactDal, EfContactDal>();
            services.AddScoped<IFeatureGridDal, EfFeatureGridDal>();
            services.AddScoped<IFeatureMainDal, EfFeatureMainDal>();
            services.AddScoped<IGuideDal, EfGuideDal>();
            services.AddScoped<IInfoCardDal, EfInfoCardDal>();
            services.AddScoped<INewsletterDal, EfNewsletterDal>();
            services.AddScoped<ISubAboutDal, EfSubAboutDal>();
            services.AddScoped<ITestimonialDal, EfTestimonialDal>();
            services.AddScoped<IWhyChooseUsDal, EfWhyChooseUsDal>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IReservationDal, EfReservationDal>();
            services.AddScoped<IFavoriteDal, EfFavoriteDal>();
            services.AddScoped<IMessageDal, EfMessageDal>();

            services.AddScoped<IDestinationService, DestinationManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<IFeatureGridService, FeatureGridManager>();
            services.AddScoped<IFeatureMainService, FeatureMainManager>();
            services.AddScoped<IGuideService, GuideManager>();
            services.AddScoped<IInfoCardService, InfoCardManager>();
            services.AddScoped<INewsletterService, NewsletterManager>();
            services.AddScoped<ISubAboutService, SubAboutManager>();
            services.AddScoped<ITestimonialService, TestimonialManager>();
            services.AddScoped<IWhyChooseUsService, WhyChooseUsManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IReservationService, ReservationManager>();
            services.AddScoped<IFavoriteService, FavoriteManager>();
            services.AddScoped<IMessageService, MessageManager>();

            // Validators
            services.AddValidatorsFromAssemblyContaining<DestinationValidator>();
            services.AddValidatorsFromAssemblyContaining<AboutValidator>();
            services.AddValidatorsFromAssemblyContaining<WhyChooseUsValidator>();
            services.AddValidatorsFromAssemblyContaining<TestimonialValidator>();
            services.AddValidatorsFromAssemblyContaining<GuideValidator>();
            services.AddValidatorsFromAssemblyContaining<FeatureMainValidator>();
            services.AddValidatorsFromAssemblyContaining<FeatureGridValidator>();
            services.AddValidatorsFromAssemblyContaining<InfoCardValidator>();
        }
    }
}
