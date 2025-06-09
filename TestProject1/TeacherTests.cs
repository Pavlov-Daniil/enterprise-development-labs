using UniversityDepartment.Domain.Services.InMemory;

namespace UniversityDepartment.Domain.Tests;

/// <summary>
/// ����� � ����-������� ����������� ��������������
/// </summary>
public class TeacherRepositoryTests
{
    /// <summary>
    /// ����������������� ���� ������, ������������� ��������� 5 �������� �� ���������
    /// </summary>
    [Theory]
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(3, 1)]
    public async Task GetLast5WorkloadsBySemester_Success(int teacherId, int expectedCount)
    {
        var repo = new TeacherInMemoryRepository();
        var workloads = await repo.GetLast5WorkloadsBySemester(teacherId);
        Assert.Equal(expectedCount, workloads.Count);
    }

    /// <summary>
    /// ���� ������, ���������� ��� 5 �������������� �� �����
    /// </summary>
    [Fact]
    public async Task GetTop5TeachersByHours_Success()
    {
        var repo = new TeacherInMemoryRepository();
        var teachers = await repo.GetTop5TeachersByHours();
        Assert.Equal(3, teachers.Count);
    }
}