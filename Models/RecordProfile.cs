using AutoMapper;
using record_backend.Models;

public class Mapper : Profile {
    public Mapper()
    {
        CreateMap<Record, RecordViewModel>();
        CreateMap<ProductsInGenre, ProductsInGenreViewModel>();
        CreateMap<Genre, GenreViewModel>();
    }
}