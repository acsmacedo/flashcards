namespace FlashCards.Api.Service.DTO.Users;

public class EditUserDto
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public string? Instagram { get; private set; }
    public string? Interests { get; private set; }

    public EditUserDto(
        int id, 
        string name, 
        string? instagram,
        string? interests)
    {
        ID = id;
        Name = name;
        Instagram = instagram;
        Interests = interests;
    }
}
