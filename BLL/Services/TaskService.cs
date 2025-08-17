using BLL.Interfaces;
using System.CodeDom;
using System;
using DAL.Interfaces;

namespace BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
