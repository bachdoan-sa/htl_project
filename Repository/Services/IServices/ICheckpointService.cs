using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services.IServices
{
    public interface ICheckpointService
    {
        Task<CheckpointModel> GetById(string id);
        Task<List<CheckpointModel>> GetAll();
        Task<CheckpointModel> Add(CheckpointModel model);
        Task<CheckpointModel> Update(CheckpointModel model);
        Task<string> Delete(string id);
    }
}
