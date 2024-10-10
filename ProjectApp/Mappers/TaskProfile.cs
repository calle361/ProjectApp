using AutoMapper;
using ProjectApp.Core;
using ProjectApp.Persistence;

using Task = ProjectApp.Core.Task;

namespace ProjectApp.Mappers;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskDb, Task>().ReverseMap();
    }
}