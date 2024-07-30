using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Sessions;

public sealed class Student : Entity<StudentId>
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
