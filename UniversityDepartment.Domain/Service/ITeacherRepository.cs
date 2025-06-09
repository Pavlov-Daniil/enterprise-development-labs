using UniversityDepartment.Domain.Model;

namespace UniversityDepartment.Domain.Services;

/// <summary>
/// Наследник обобщенного интерфейса для преподавателей с дополнительной функциональностью 
/// </summary>
public interface ITeacherRepository : IRepository<Teacher, int>
{
    /// <summary>
    /// Метод для вывода 5 наиболее загруженных преподавателей по общему количеству часов
    /// </summary>
    /// <returns>Список кортежей с ФИО преподавателя и общим количеством часов</returns>
    Task<IList<Tuple<string, int>>> GetTop5TeachersByHours();

    /// <summary>
    /// Метод для вывода последних 5 нагрузок преподавателя по семестрам
    /// </summary>
    /// <param name="key">Идентификатор преподавателя</param>
    /// <returns>Список кортежей с названием дисциплины и номером семестра</returns>
    Task<IList<Tuple<string, int>>> GetLast5WorkloadsBySemester(int key);
}