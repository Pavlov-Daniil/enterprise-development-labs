using UniversityDepartment.Domain.Model;
using UniversityDepartment.Domain.Data;

namespace UniversityDepartment.Domain.Services.InMemory;

/// <summary>
/// Имплементация репозитория для преподавателей, которая хранит коллекцию в оперативной памяти 
/// </summary>
public class TeacherInMemoryRepository : ITeacherRepository
{
    private List<Teacher> _teachers;
    private List<Discipline> _disciplines;
    private List<Workload> _workloads;

    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    public TeacherInMemoryRepository()
    {
        _teachers = DataSeeder.Teachers;
        _disciplines = DataSeeder.Disciplines;
        _workloads = DataSeeder.Workloads;

        // Устанавливаем связи между сущностями
        foreach (var w in _workloads)
        {
            w.Teacher = _teachers.FirstOrDefault(t => t.Id == w.TeacherId);
            w.Discipline = _disciplines.FirstOrDefault(d => d.Id == w.DisciplineId);
        }

        foreach (var t in _teachers)
        {
            t.Workloads = [];
            t.Workloads?.AddRange(_workloads.Where(w => w.TeacherId == t.Id));
        }

        foreach (var d in _disciplines)
        {
            d.Workloads = [];
            d.Workloads?.AddRange(_workloads.Where(w => w.DisciplineId == d.Id));
        }
    }

    /// <inheritdoc/>
    public Task<Teacher> Add(Teacher entity)
    {
        try
        {
            _teachers.Add(entity);
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
            var teacher = await Get(key);
            if (teacher != null)
                _teachers.Remove(teacher);
        }
        catch
        {
            return false;
        }
        return true;
    }

    /// <inheritdoc/>
    public async Task<Teacher> Update(Teacher entity)
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

    /// <inheritdoc/>
    public Task<Teacher?> Get(int key) =>
        Task.FromResult(_teachers.FirstOrDefault(t => t.Id == key));

    /// <inheritdoc/>
    public Task<IList<Teacher>> GetAll() =>
        Task.FromResult((IList<Teacher>)_teachers);

    /// <inheritdoc/>
    public Task<IList<Tuple<string, int>>> GetTop5TeachersByHours()
    {
        return Task.FromResult((IList<Tuple<string, int>>)_teachers
            .OrderByDescending(t => t.TotalHours)
            .Take(5)
            .Select(t => new Tuple<string, int>(t.ToString(), t.TotalHours))
            .ToList());
    }

    /// <inheritdoc/>
    public async Task<IList<Tuple<string, int>>> GetLast5WorkloadsBySemester(int key)
    {
        var teacher = await Get(key);
        var workloads = new List<Workload>();
        
        if (teacher != null && teacher.Workloads?.Count > 0)
        {
            workloads.AddRange(teacher.Workloads);
        }
        
        return workloads
            .OrderByDescending(w => w.SemesterNumber)
            .Take(5)
            .Select(w => new Tuple<string, int>(
                w.Discipline?.ToString() ?? "Неизвестная дисциплина", 
                w.SemesterNumber))
            .ToList();
    }
}