using PockOData.Api.Domain.Entities.Base;

namespace PockOData.Api.Domain.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task Create(T model);
    Task Update(T model);
    Task Delete(Guid id);
}