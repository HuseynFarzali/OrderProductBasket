using DefaultWebApplication.Models.Command_Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DefaultWebApplication.Services.Repositories
{
    public interface IRepository<TMainModel, TCommandModel>
    {
        Task<TMainModel> CreateEntity(TCommandModel command);
        Task<IEnumerable<TMainModel>> GetEntityCollection(Func<TMainModel, bool> criteria);
        Task<TMainModel> UpdateEntity(Func<TMainModel, bool> criteriaUnique, TCommandModel command);
        Task DeleteEntityCollection(Func<TMainModel, bool> criteria);
    }
}
