using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

// TODO: Session should reference StudentId instead of Student
// TODO: Create Guardian entity
// TODO: Create Address entity
public sealed class Student : AggregateRoot<StudentId>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string FullName
        => $"{FirstName} {LastName}";

    private Student(StudentId id, string firstName, string lastName)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public static Student Create(string firstName, string lastName)
    {
        return new Student(StudentId.CreateUnique(), firstName, lastName);
    }
}
