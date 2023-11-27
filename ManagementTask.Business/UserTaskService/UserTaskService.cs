using AutoMapper;
using ManagementTask.DataAccess.Models;
using ManagementTask.Domain.ModelsDTO.UserTaskDTO;
using ManagementTask.Domain.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementTask.Business.UserTaskService
{
    public class UserTaskService : IUserTaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserTaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<UserTaskDTO>> GetAll() => _mapper.Map<List<UserTaskDTO>>((await _unitOfWork.Repository<UserTask>().GetAllAsync()).ToList());

        public async Task<UserTaskDTO> Update(UserTaskDTO userTask)
        {
            var response = await _unitOfWork.Repository<UserTask>().GetAllAsync(x => x.UserTaskId.Equals(userTask.UserTaskId) && x.UserId.Equals(userTask.UserId));

            if (response == null) throw new Exception("La tarea no a sido asignada a un usuario.");

            var responseTask = await _unitOfWork.Repository<TblTask>().GetByIdAsync((Guid)userTask.TaskId);

            responseTask.IsComplete = true;

            await _unitOfWork.Repository<TblTask>().UpdateAsync(responseTask);

            await _unitOfWork.Repository<UserTask>().UpdateAsync((UserTask)response);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserTaskDTO>(response);
        }

        public async Task<UserTaskDTO> Delete(UserTaskDelete delete)
        {
            var response = await _unitOfWork.Repository<UserTask>().GetAllAsync(x => x.UserTaskId.Equals(delete.UserTaskId));

            if (response == null) throw new Exception("La tarea no existe");

            await _unitOfWork.Repository<UserTask>().DeleteAsync((UserTask)response);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserTaskDTO>(response);
        }

        public async Task<UserTaskDTO> Create(UserTaskCreate userTaskCreate)
        {
            var response = (await _unitOfWork.Repository<UserTask>().GetAllAsync(x => x.TaskId == userTaskCreate.TaskId && x.UserId == userTaskCreate.UserId)).FirstOrDefault();

            if (response != null) throw new Exception("La tarea ya tiene asignado un usuario.");

            var Create = _mapper.Map<UserTask>(userTaskCreate);

            await _unitOfWork.Repository<UserTask>().AddAsync(Create);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<UserTaskDTO>(Create);
        }
    }
}
