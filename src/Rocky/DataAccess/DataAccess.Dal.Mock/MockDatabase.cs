namespace DataAccess.Dal.Mock;

public static class MockDatabase
{
    public static List<PersonEntity> People { get; } =
    [
        new() {
            Id = 1,
            Name = "John Doe",
            Address = "123 Main",
            City = "Springfield",
            State = "IL",
            Zip = "62701"
            },
        new() {
            Id = 2,
            Name = "Jane Doe",
            Address = "456 Elm",
            City = "Springfield",
            State = "IL",
            Zip = "62701"
        },
        new() {
            Id = 3,
            Name = "Jim Doe",
            Address = "789 Oak",
            City = "Springfield",
            State = "IL",
            Zip = "62701"
        }
    ];
}
