using AutoMapper;
using record_backend.Models;

public class Mapper : Profile {
    public Mapper()
    {
        CreateMap<Record, RecordViewModel>();
        CreateMap<RecordViewModel, Record>();
        CreateMap<ProductsInGenre, ProductsInGenreViewModel>();
        CreateMap<ProductsInGenreViewModel, ProductsInGenre>();
        CreateMap<Genre, GenreViewModel>();
        CreateMap<GenreViewModel, Genre>();
        CreateMap<Order, OrderViewModel>();
        CreateMap<OrderViewModel, Order>();
        CreateMap<Cart, CartViewModel>();
        CreateMap<CartViewModel, Cart>();
        CreateMap<User, UserViewModel>();
        CreateMap<UserViewModel, User>();
    }
}