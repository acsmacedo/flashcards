namespace FlashCards.Api.Service.DTO.Accounts;

public class DeleteAccountDto
{
    [Key]
    public int ID { get; private set; }

    public DeleteAccountDto(int id)
    {
        ID = id;
    }
}
