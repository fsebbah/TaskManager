using AutoMapper;
using TaskManager.API.Dtos;
using TaskManager.API.Models;

namespace TaskManager.API.Profiles
{
    public class TasksProfile: Profile
    {

        public TasksProfile()
        {
            // Source : Model => Target : Dto
            CreateMap<TaskOne, TaskReadDto>();
            // Source : Dto => Target : Model
            CreateMap<TaskCreateDto, TaskOne>();
            CreateMap<TaskUpdateDto, TaskOne>();


        }


    }
}
