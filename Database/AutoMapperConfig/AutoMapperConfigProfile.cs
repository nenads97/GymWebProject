using AutoMapper;
using Database.AdditionalRelations;
using Database.Dtos;
using Database.Dtos.Admin;
using Database.Dtos.Admin.Create;
using Database.Dtos.Admin.Get;
using Database.Dtos.Client;
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
                    .Where(pd => pd.PackageDiscount.BeginDate <= dateTime && pd.PackageDiscount.EndDate >= dateTime)
                    .Select(pd => pd.PackageDiscount.Value)
                    .FirstOrDefault()));
            CreateMap<Employee, PersonGetDto>();
            CreateMap<Trainer, PersonGetDto>();
            CreateMap<Client, PersonGetDto>();
            CreateMap<Administrator, PersonGetDto>();
            CreateMap<PackagePrice, PackagePriceGetDto>();
            CreateMap<PackageDiscount, PackageDiscountGetDto>()
                .ForMember(p => p.PackageId, opt => opt.MapFrom(src => src.PackagePackageDiscounts
                    .Select(pd => pd.PackageId)
                    .FirstOrDefault()))
                .ForMember(p => p.PackageName, opt => opt.MapFrom(src => src.PackagePackageDiscounts
                    .Select(pd => pd.Package.PackageName)
                    .FirstOrDefault()))
                .ForMember(p => p.PackageDiscountId, opt => opt.MapFrom(src => src.PackagePackageDiscounts
                    .Select(pd => pd.PackageDiscountId)
                    .FirstOrDefault()));


        }

    }
}
