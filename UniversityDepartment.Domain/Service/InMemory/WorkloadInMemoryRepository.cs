using UniversityDepartment.Domain.Model;
using UniversityDepartment.Domain.Data;

namespace UniversityDepartment.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для учебной нагрузки, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class WorkloadInMemoryRepository : IRepository<Workload, int>
{
    private List<Workload> _workloads;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public WorkloadInMemoryRepository()
    {
        _workloads = DataSeeder.Workloads;
    }

    /// <inheritdoc/>
    public Task<Workload> Add(Workload entity)
    {
        try
        {
            _workloads.Add(entity);
        }
        catch
        {
            return null!;
        }
        return Task.FromResult(entity);
    }

    /// <inheritdoc/>
    public async Task<bool> Delete(int key)
    {
        try
        {
            var workload = await Get(key);
            if (workload != null)
                _workloads.Remove(workload);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public Task<Workload?> Get(int key) =>
        Task.FromResult(_workloads.FirstOrDefault(w => w.Id == key));

    /// <inheritdoc/>
    public Task<IList<Workload>> GetAll() =>
        Task.FromResult((IList<Workload>)_workloads);

    /// <inheritdoc/>
    public async Task<Workload> Update(Workload entity)
    {
        try
        {
            await Delete(entity.Id);
            await Add(entity);
        }
        catch
        {
            return null!;
        }
        return entity;
    }
}