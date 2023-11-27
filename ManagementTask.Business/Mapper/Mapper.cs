using AutoMapper;
using ManagementTask.DataAccess.Models;
using ManagementTask.Domain.ModelsDTO.TaskDTO;
using ManagementTask.Domain.ModelsDTO.UserDTO;
using ManagementTask.Domain.ModelsDTO.UserTaskDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Business.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<TblUser, UserDTO>();
            CreateMap<UserDTO, TblUser>();
            CreateMap<UserCreate, TblUser>();
            CreateMap<TblUser, UserCreate>();

            CreateMap<TblTask, TaskDTO>();
            CreateMap<TaskDTO, TblTask>();
            CreateMap<TaskCreate, TblTask>();
            CreateMap<TblTask, TaskCreate>();

            CreateMap<UserTask, UserTaskDTO>();
            CreateMap<UserTaskDTO, UserTask>();
            CreateMap<UserTaskCreate, UserTask>();
            CreateMap<UserTask, UserTaskCreate>();
        }
    }
}
