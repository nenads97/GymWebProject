using AutoMapper;
using Database.AdditionalRelations;
using Database.Dtos;
using Database.Dtos.Admin;
using Database.Dtos.Admin.Create;
using Database.Dtos.Admin.Get;
using Database.Dtos.Client.Create;
using Database.Dtos.Client.Get;
using Database.Dtos.Employee.Create;
using Database.Dtos.Employee.Get;
using Database.Entities;
using Database.JoinTables;

namespace Database.AutoMapperConfig
{
    public class AutoMapperConfigProfile : Profile
    {
        public AutoMapperConfigProfile()
        {
            var dateTime = DateTime.Now;

            //Admin create dtos
            CreateMap<ClientCreateDto, Client>();
            CreateMap<Person, PersonLoginDto>();
            CreateMap<PackagePriceCreateDto, PackagePrice>();
            CreateMap<PackageDiscountCreateDto, PackageDiscount>();
            CreateMap<PackageAdministratorCreateDto, PackageAdministrator>();
            CreateMap<PackageDiscountSetDto,  PackagePackageDiscount>();
            CreateMap<TokenPriceCreateDto, TokenPrice>();
            CreateMap<PackageCreateDto, Package>();
            CreateMap<TrainerCreateDto, Trainer>();
            CreateMap<EmployeeCreateDto, Employee>();

            //Admin get dtos
            CreateMap<Package, PackageGetDto>()
                .ForMember(dest => dest.PackageName, opt => opt.MapFrom(src => src.PackageName))
                .ForMember(dest => dest.PackagePriceValue, opt => opt.MapFrom(src =>
                src.PackagePrices
                    .OrderByDescending(pp => pp.Date)
                    .Select(pp => pp.Value)
                    .FirstOrDefault()))
                .ForMember(dest => dest.PackageDiscountValue, opt => opt.MapFrom(src =>
                src.PackagePackageDiscounts
                    .OrderByDescending(pd => pd.PackagePackageDiscountId)
                    .Select(pd => pd.PackageDiscount.Value)
                    .FirstOrDefault()));
            CreateMap<Employee, PersonGetDto>();
            CreateMap<Trainer, PersonGetDto>();
            CreateMap<Client, PersonGetDto>();
            CreateMap<Administrator, PersonGetDto>();
            CreateMap<PackagePrice, PackagePriceGetDto>()
                .ForMember(p => p.PackageName, opt => opt.MapFrom(src => src.Package.PackageName));
            CreateMap<PackageDiscount, PackageDiscountGetDto>()
                .ForMember(p => p.PackageId, opt => opt.MapFrom(src => src.PackagePackageDiscounts
                    .Select(pd => pd.PackageId)
                    .FirstOrDefault()))
                .ForMember(p => p.PackageName, opt => opt.MapFrom(src => src.PackagePackageDiscounts
                    .Select(pd => pd.Package.PackageName)
                    .FirstOrDefault()));

            CreateMap<PackagePackageDiscount, PackagePackageDiscountGetDto>()
                .ForMember(p => p.PackageName, opt => opt.MapFrom(src => src.Package.PackageName))
                .ForMember(p => p.BeginDate, opt => opt.MapFrom(src => src.PackageDiscount.BeginDate))
                .ForMember(p => p.EndDate, opt => opt.MapFrom(src => src.PackageDiscount.EndDate))
                .ForMember(p => p.Value, opt => opt.MapFrom(src => src.PackageDiscount.Value));

            //Employee Get Dtos
            CreateMap<Client, ClientsGetDto>();
            CreateMap<Payment, PaymentGetDto>()
                .ForMember(p => p.ClientName, opt => opt.MapFrom(src => src.Client.Firstname))
                .ForMember(p => p.ClientSurname, opt => opt.MapFrom(src => src.Client.Surname))
                .ForMember(p => p.ClientJmbg, opt => opt.MapFrom(src => src.Client.JMBG));

            //Employee Create Dtos
            CreateMap<PaymentCreateDto, Payment>();

            //Client Create Dtos
            CreateMap<MembershipCreateDto, Membership>();
            CreateMap<PurchaseCreateDto, Purchase>();
            CreateMap<TokenPurchaseCreateDto, TokenPurchase>();
            CreateMap<TokenCreateDto, Token>();
            CreateMap<TokenPackageCreateDto, TokenPackage>();

            //Client Get Dtos
            CreateMap<Client, ClientGetDto>();
            CreateMap<Membership, MembershipGetDto>()
                .ForMember(p => p.PackageName, opt => opt.MapFrom(src => src.Package.PackageName))
                .ForMember(p => p.ClientName, opt => opt.MapFrom(src => src.Client.Firstname))
                .ForMember(p => p.ClientSurname, opt => opt.MapFrom(src => src.Client.Surname));
        }

    }
}
