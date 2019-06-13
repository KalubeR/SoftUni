using FastFood.Web.ViewModels.Categories;
using FastFood.Web.ViewModels.Employees;
using FastFood.Web.ViewModels.Items;
using FastFood.Web.ViewModels.Orders;

namespace FastFood.Web.MappingConfiguration
{
    using AutoMapper;
    using Models;

    using ViewModels.Positions;

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(dest => dest.PositionName, src => src.MapFrom(x => x.Name));

            this.CreateMap<RegisterEmployeeInputModel, Employee>();

            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(dest => dest.Position, src => src.MapFrom(x => x.Position.Name));

            //Categories
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(dest => dest.Name, src => src.MapFrom(x => x.CategoryName));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(dest => dest.CategoryId, src => src.MapFrom(x => x.Id));

            this.CreateMap<CreateItemInputModel, Item>();

            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(dest => dest.Category, src => src.MapFrom(x => x.Category.Name));

            //Orders
            this.CreateMap<CreateOrderInputModel, Order>();

            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(dest => dest.OrderId, src => src.MapFrom(x => x.Id))
                .ForMember(dest => dest.Employee, src => src.MapFrom(y => y.Employee.Name))
                .ForMember(dest => dest.DateTime, src => src.MapFrom(x => x.DateTime.ToString("g")));
        }
    }
}
