using System.Xml.Linq;
using UniversityDepartment.Domain.Model;
using UniversityDepartment.Domain.Data;

namespace UniversityDepartment.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для дисциплин, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class DisciplineInMemoryRepository : IRepository<Discipline, int>
{
    private List<Discipline> _disciplines;

    public DisciplineInMemoryRepository()
    {
        _disciplines = DataSeeder.Disciplines;
    }

    public Task<Discipline?> Get(int key)
        => Task.FromResult(_disciplines.FirstOrDefault(d => d.Id == key));

    public Task<Discipline> Add(Discipline entity)
    {
        try
        {
            _disciplines.Add(entity);
        }
        catch
        {
            return null!;
        }
        return Task.FromResult(entity);
    }

    public async Task<bool> Delete(int key)
    {
        try
        {
            var discipline = await Get(key);
            if (discipline != null)
                _disciplines.Remove(discipline);
        }
        catch
        {
            return false;
        }
        return true;
    }

    public Task<IList<Discipline>> GetAll()
        => Task.FromResult((IList<Discipline>)_disciplines);

    public async Task<Discipline> Update(Discipline entity)
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