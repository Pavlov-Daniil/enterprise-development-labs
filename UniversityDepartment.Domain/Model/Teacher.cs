using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityDepartment.Domain.Data;

namespace UniversityDepartment.Domain.Model;

/// <summary>
/// Преподаватель
/// </summary>
public class Teacher
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Полное имя преподавателя
    /// </summary>
    public string? FullName { get; set; }

    /// <summary>
    /// Должность преподавателя
    /// </summary>
    public Position Position { get; set; }

    /// <summary>
    /// Навигационное свойство для нагрузки
    /// </summary>
    public virtual List<Workload>? Workloads { get; set; }

    /// <summary>
    /// Общее количество учебных часов
    /// </summary>
    [NotMapped]
    public int TotalHours => Workloads?.Sum(w => w.Hours) ?? 0;

    /// <summary>
    /// Перегрузка метода ToString()
    /// </summary>
    public override string ToString() => $"{FullName} ({Position})";
}

