using AutoMapper;
using Humanizer;
using Traversal.DtoLayer.DTOS.AboutDtos;
using Traversal.DtoLayer.DTOS.AppRoleDtos;
using Traversal.DtoLayer.DTOS.AppUserDtos;
using Traversal.DtoLayer.DTOS.CommentDtos;
using Traversal.DtoLayer.DTOS.ContactDtos;
using Traversal.DtoLayer.DTOS.DestinationDtos;
using Traversal.DtoLayer.DTOS.FavoriteDtos;
using Traversal.DtoLayer.DTOS.FeatureGridDtos;
using Traversal.DtoLayer.DTOS.FeatureMainDtos;
using Traversal.DtoLayer.DTOS.GuideDtos;
using Traversal.DtoLayer.DTOS.InfoCardDtos;
using Traversal.DtoLayer.DTOS.MessageDtos;
using Traversal.DtoLayer.DTOS.NewsletterDtos;
using Traversal.DtoLayer.DTOS.ReservationDtos;
using Traversal.DtoLayer.DTOS.RoleDtos;
using Traversal.DtoLayer.DTOS.SubAboutDtos;
using Traversal.DtoLayer.DTOS.TestimonialDtos;
using Traversal.DtoLayer.DTOS.WhyChooseDtos;
using Traversal.DtoLayer.DTOS.WhyChooseUsDtos;
using Traversal.EntityLayer.Entities;
using Traversal.WebUI.CQRS.Command;
using Traversal.WebUI.CQRS.Result;

namespace Traversal.WebUI.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            // Destination
            CreateMap<Destination, GetDestinationQueryResult>().ReverseMap();
            CreateMap<Destination, CreateDestinationCommand>().ReverseMap();
            CreateMap<Destination, UpdateDestinationCommand>().ReverseMap();
            CreateMap<CreateDestinationDto, CreateDestinationCommand>().ReverseMap();
            CreateMap<UpdateDestinationDto, UpdateDestinationCommand>().ReverseMap();

            // Info Card
            CreateMap<InfoCard, ResultInfoCardDto>().ReverseMap();
            CreateMap<InfoCard, CreateInfoCardDto>().ReverseMap();
            CreateMap<InfoCard, UpdateInfoCardDto>().ReverseMap();

            //AppUser Dto
            CreateMap<AppUser, ResultAppUserDto>()
                  .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                      .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                        .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                          .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                           .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
            CreateMap<AppUser, GetAppUserByIdDto>()
                 .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                   .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                    .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl))
                     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                      .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));


            // AppRole Dto
            CreateMap<AppRole, ResultAppRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateAppRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateAppRoleDto>()
                    .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Name));
            //Destination Dto
            CreateMap<Destination, ResultDestinationDto>().ReverseMap();
            CreateMap<Destination, CreateDestinationDto>().ReverseMap();
            CreateMap<Destination, UpdateDestinationDto>().ReverseMap();
            CreateMap<Destination, GetDestinationByIdDto>().ReverseMap();

            //SubAbout Dto
            CreateMap<SubAbout, ResultSubAboutDto>().ReverseMap();

            //Testimonial Dto
            CreateMap<Testimonial, ResultTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDto>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdDto>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDto>().ReverseMap();

            //Feature Grid Dto
            CreateMap<FeatureGrid, ResultFeatureGridDto>().ReverseMap();
            CreateMap<FeatureGrid, CreateFeatureGridDto>().ReverseMap();
            CreateMap<FeatureGrid, UpdateFeatureGridDto>().ReverseMap();

            //Feature Main Dto
            CreateMap<FeatureMain, ResultFeatureMainDto>().ReverseMap();
            CreateMap<FeatureMain, GetFeatureMainDto>().ReverseMap();
            CreateMap<FeatureMain, CreateFeatureMainDto>().ReverseMap();
            CreateMap<FeatureMain, UpdateFeatureMainDto>().ReverseMap();

            //Guide  Dto
            CreateMap<Guide, ResultGuideDto>().ReverseMap();
            CreateMap<Guide, UpdateGuideDto>().ReverseMap();
            CreateMap<Guide, CreateGuideDto>().ReverseMap();

            //About  Dto
            CreateMap<About, ResultAboutDto>().ReverseMap();
            CreateMap<About, CreateAboutDto>().ReverseMap();
            CreateMap<About, GetAboutDto>().ReverseMap();
            CreateMap<About, UpdateAboutDto>().ReverseMap();

            //Why Choose Us  Dto
            CreateMap<WhyChooseUs, GetWhyChooseUsDto>().ReverseMap();
            CreateMap<WhyChooseUs, ResultWhyChooseUsDto>().ReverseMap();
            CreateMap<WhyChooseUs, UpdateWhyChooseUsDto>().ReverseMap();
            CreateMap<WhyChooseUs, CreateWhyChooseUsDto>().ReverseMap();


            //Comment Dto
            CreateMap<Comment, GetCommentByIdDto>()
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId))
                     .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City));
            CreateMap<Comment,CreateCommentDto>().ReverseMap();
            CreateMap<Comment,ResultCommentDto>().ReverseMap()
                  .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.AppUserId));


            //Reservation Dto
            CreateMap<Reservation, ResultReservationDto>()
                .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City));

            CreateMap<Reservation, CreateReservationDto>()
                .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City));

            CreateMap<CreateReservationDto, Reservation>()
          .ForMember(dest => dest.Destination, opt => opt.Ignore());

            //Favorite Dto
            CreateMap<Favorite, ResultFavoriteDto>()
                .ForMember(dest => dest.DestinationCity, opt => opt.MapFrom(src => src.Destination.City))
                 .ForMember(dest => dest.DestinationImage, opt => opt.MapFrom(src => src.Destination.Image))
                  .ForMember(dest => dest.DestinationPrice, opt => opt.MapFrom(src => src.Destination.Price));


            // Contact Dto
            CreateMap<Contact, ResultContactDto>().ReverseMap();
            CreateMap<Contact, GetContactDto>().ReverseMap();
            CreateMap<Contact, GetContactByIdDto>().ReverseMap();
            CreateMap<Contact, UpdateContactDto>().ReverseMap();

            // Message Dto
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, ResultMessageDto>().ReverseMap();


            //Newsletter Dto
            CreateMap<Newsletter, CreateNewsletterDto>().ReverseMap();
            CreateMap<Newsletter, ResultNewsletterDto>().ReverseMap();


        }
    }
}
