using AutoMapper;
using System.ComponentModel.DataAnnotations;
using ToDo.BLL.Extensions;
using ToDo.BusinessObjects;
using ToDo.Core.Enums;
using TODO.Models;

namespace TODO.Mappers
{
    public class ToDoMapper : Profile
    {
        public ToDoMapper()
        {
            CreateMap<Task, TaskViewModel>()
            .ForMember(x => x.StatusId, opt => opt.MapFrom(src => (int)src.Status))
            .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.GetEnumDescription<DisplayAttribute>().Name));


            CreateMap<TaskViewModel, Task>()
                .ForMember(x => x.Status, opt => opt.MapFrom(src => (Status)src.StatusId));
        }
    }
}
