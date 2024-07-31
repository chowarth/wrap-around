using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class Student : AggregateRoot<StudentId>
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public string FullName
        => $"{FirstName} {LastName}";

    // TODO: Guardians property

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
