using WrapAround.Domain.Common.Models;

namespace WrapAround.Domain.Students;

public sealed class Student : AggregateRoot<StudentId>
{
    public string FirstName { get; }
    public string LastName { get; }

    public string FullName
        => $"{FirstName} {LastName}";

    public Guardian? Guardian { get; private set; }

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
