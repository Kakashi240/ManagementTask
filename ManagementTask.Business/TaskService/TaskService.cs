using AutoMapper;
using ManagementTask.DataAccess.Models;
using ManagementTask.Domain.ModelsDTO.TaskDTO;
using ManagementTask.Domain.UnitOfWork;

namespace ManagementTask.Business.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TaskService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<TaskDTO>> GetAll() => _mapper.Map<List<TaskDTO>>((await _unitOfWork.Repository<TblTask>().GetAllAsync()).ToList());

        public async Task<List<TaskDTO>> GetIsActived() => _mapper.Map<List<TaskDTO>>((await _unitOfWork.Repository<TblTask>().GetAllAsync(x => x.IsComplete)).ToList());
        public async Task<TaskDTO> Update(TaskDTO task)
        {
            var response = await _unitOfWork.Repository<TblTask>().GetByIdAsync(task.TaskId);

            if (response == null) throw new Exception("la tarea no existe");

            _mapper.Map(task, response);

            await _unitOfWork.Repository<TblTask>().UpdateAsync(response);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TaskDTO>(response);
        }

        public async Task<TaskDTO> Delete(TaskDelete delete)
        {
            var response = await _unitOfWork.Repository<TblTask>().GetByIdAsync(delete.TaskId);

            if (response == null) throw new Exception("la tarea no existe");

            response.IsComplete = false;

            await _unitOfWork.Repository<TblTask>().UpdateAsync(response);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TaskDTO>(response);
        }

        public async Task<TaskDTO> Create(TaskCreate taskCreate)
        {
            var response = (await _unitOfWork.Repository<TblTask>().GetAllAsync(x => x.TaskName == taskCreate.TaskName)).FirstOrDefault();

            if (response != null) throw new Exception("La tarea ya existe.");

            var Create = _mapper.Map<TblTask>(taskCreate);

            Create.IsComplete = false;

            await _unitOfWork.Repository<TblTask>().AddAsync(Create);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<TaskDTO>(Create);
        }

    }
}
