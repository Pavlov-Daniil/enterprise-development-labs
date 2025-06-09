using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityDepartment.Domain.Model;

namespace UniversityDepartment.Domain.Model;

/// <summary>
/// Учебная дисциплина
/// </summary>
public class Discipline
{
    /// <summary>
    /// Идентификатор дисциплины
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// Название дисциплины
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Навигационное свойство для нагрузки
    /// </summary>
    public virtual List<Workload>? Workloads { get; set; }

    /// <summary>
    /// Количество преподавателей, ведущих дисциплину
    /// </summary>
    [NotMapped]
    public int TeachersCount => Workloads?.Select(w => w.TeacherId).Distinct().Count() ?? 0;

    /// <summary>
    /// Перегрузка метода ToString()
    /// </summary>
    public override string ToString() => Name ?? "<Без названия>";
}