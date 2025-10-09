using DTO.TreeDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Abstractions.Works
{
    public interface IProjectTreeService
    {
        Task<ProjectTreeDTO> GetProjectTreeAsync(int projectID);
    }
}
