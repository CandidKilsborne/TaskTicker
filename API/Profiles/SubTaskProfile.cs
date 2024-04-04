using API.Entities;
using API.Models;
using AutoMapper;

namespace API.Profiles;

public class SubTaskProfile : Profile
{
    public SubTaskProfile()
    {
        CreateMap<SubTask, SubTaskDto>();
        CreateMap<SubTaskCreationDto, SubTask>();
        CreateMap<SubTaskUpdateDto, SubTask>();
    }
}