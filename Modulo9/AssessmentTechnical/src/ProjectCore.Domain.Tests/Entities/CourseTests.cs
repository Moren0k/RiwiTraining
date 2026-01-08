using FluentAssertions;
using ProjectCore.Domain.Entities;
using ProjectCore.Domain.Enums;
using Xunit;

namespace ProjectCore.Domain.Tests.Entities;

public class CourseTests
{
    [Fact]
    public void PublishCourse_WithLessons_ShouldSucceed()
    {
        // Arrange
        var course = new Course("DDD 101");
        course.AddLesson("Intro", 1);

        // Act
        course.Publish();

        // Assert
        course.Status.Should().Be(CourseStatus.Published);
    }

    [Fact]
    public void PublishCourse_WithoutLessons_ShouldFail()
    {
        // Arrange
        var course = new Course("DDD 101");

        // Act
        var act = () => course.Publish();

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void CreateLesson_WithUniqueOrder_ShouldSucceed()
    {
        // Arrange
        var course = new Course("DDD 101");

        // Act
        course.AddLesson("Intro", 1);
        course.AddLesson("Advanced", 2);

        // Assert
        course.Lessons.Should().HaveCount(2);
    }

    [Fact]
    public void CreateLesson_WithDuplicateOrder_ShouldFail()
    {
        // Arrange
        var course = new Course("DDD 101");
        course.AddLesson("Intro", 1);

        // Act
        var act = () => course.AddLesson("Advanced", 1);

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void DeleteCourse_ShouldBeSoftDelete()
    {
        // Arrange
        var course = new Course("DDD 101");

        // Act
        course.SoftDelete();

        // Assert
        course.IsDeleted.Should().BeTrue();
    }
}