using UniversityDepartment.Domain.Model;

namespace UniversityDepartment.Domain.Data;

public static class DataSeeder
{
    public static readonly List<Teacher> Teachers =
        [
            new()
            {
                Id = 1,
                FullName = "Иванов Алексей Петрович",
                Position = Position.AssociateProfessor
            },
            new()
            {
                Id = 2,
                FullName = "Смирнова Екатерина Владимировна",
                Position = Position.Professor
            },
            new()
            {
                Id = 3,
                FullName = "Петров Дмитрий Сергеевич",
                Position = Position.Assistant
            }
        ];

    public static readonly List<Discipline> Disciplines =
        [
            new()
            {
                Id = 1,
                Name = "Высшая математика"
            },
            new()
            {
                Id = 2,
                Name = "Физика"
            },
            new()
            {
                Id = 3,
                Name = "Программирование на C#"
            },
            new()
            {
                Id = 4,
                Name = "Базы данных"
            }
        ];

    public static readonly List<Workload> Workloads =
        [
            new()
            {
                Id = 1,
                TeacherId = 1,
                DisciplineId = 1,
                SemesterNumber = 1,
                Groups = ["МАТ-101", "МАТ-102"],
                StudentCount = 45,
                ActivityType = ActivityType.Lecture,
                EducationType = EducationType.FullTime,
                Hours = 90
            },
            new()
            {
                Id = 2,
                TeacherId = 1,
                DisciplineId = 1,
                SemesterNumber = 1,
                Groups = ["МАТ-101"],
                StudentCount = 25,
                ActivityType = ActivityType.Practical,
                EducationType = EducationType.FullTime,
                Hours = 60
            },
            new()
            {
                Id = 3,
                TeacherId = 2,
                DisciplineId = 3,
                SemesterNumber = 2,
                Groups = ["ИТ-201", "ИТ-202"],
                StudentCount = 30,
                ActivityType = ActivityType.Lab,
                EducationType = EducationType.Evening,
                Hours = 120
            },
            new()
            {
                Id = 4,
                TeacherId = 3,
                DisciplineId = 4,
                SemesterNumber = 3,
                Groups = ["БД-301"],
                StudentCount = 20,
                ActivityType = ActivityType.CourseProject,
                EducationType = EducationType.FullTime,
                Hours = 80
            },
            new()
            {
                Id = 5,
                TeacherId = 2,
                DisciplineId = 2,
                SemesterNumber = 1,
                Groups = ["ФИЗ-101"],
                StudentCount = 35,
                ActivityType = ActivityType.GEK,
                EducationType = EducationType.FullTime,
                Hours = 50
            }
        ];
}

public enum Position
{
    Assistant,
    AssociateProfessor,
    Professor
}

public enum ActivityType
{
    Lecture,
    Practical,
    Lab,
    KSR,
    CourseProject,
    GEK
}

public enum EducationType
{
    FullTime,
    Evening
}

