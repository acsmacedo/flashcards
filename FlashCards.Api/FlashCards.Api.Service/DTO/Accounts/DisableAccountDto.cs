namespace FlashCards.Api.Service.DTO.Accounts;

public class DisableAccountDto
{
    [Key]
    public int ID { get; private set; }

    public DisableAccountDto(int id)
    {
        ID = id;
    }
}
