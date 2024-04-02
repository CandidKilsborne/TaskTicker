using AutoMapper;
using API.Models;
using API.Entities;

namespace API.Profiles;

public class TodoProfile : Profile
{
    public TodoProfile()
    {
        CreateMap<Todo, TodoDto>();
        CreateMap<TodoCreationDto, Todo>();
    }
}