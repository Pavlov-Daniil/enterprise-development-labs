using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UniversityDepartment.Domain.Data;

namespace UniversityDepartment.Domain.Model;

/// <summary>
/// Учебная нагрузка
/// </summary>
public class Workload
{
    /// <summary>
    /// Идентификатор нагрузки
    /// </summary>
    [Key]
    public required int Id { get; set; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public required int TeacherId { get; set; }

    /// <summary>
    /// Навигационное свойство преподавателя
    /// </summary>
    [ForeignKey("TeacherId")]
    public virtual Teacher? Teacher { get; set; }

    /// <summary>
    /// Идентификатор дисциплины
    /// </summary>
    public required int DisciplineId { get; set; }

    /// <summary>
    /// Навигационное свойство дисциплины
    /// </summary>
    [ForeignKey("DisciplineId")]
    public virtual Discipline? Discipline { get; set; }

    /// <summary>
    /// Номер семестра
    /// </summary>
    public int SemesterNumber { get; set; }

    /// <summary>
    /// Группы для занятий
    /// </summary>
    public List<string> Groups { get; set; } = new();

    /// <summary>
    /// Количество студентов
    /// </summary>
    public int StudentCount { get; set; }

    /// <summary>
    /// Тип занятия
    /// </summary>
    public ActivityType ActivityType { get; set; }

    /// <summary>
    /// Форма обучения
    /// </summary>
    public EducationType EducationType { get; set; }

    /// <summary>
    /// Количество часов
    /// </summary>
    public int Hours { get; set; }

    /// <summary>
    /// Перегрузка метода ToString()
    /// </summary>
    public override string ToString() => 
        $"{Discipline?.ToString() ?? "Дисциплина"} - {ActivityType} ({Hours} часов)";
}
