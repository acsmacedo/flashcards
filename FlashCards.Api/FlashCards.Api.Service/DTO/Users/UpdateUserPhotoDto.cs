using Microsoft.AspNetCore.Http;

namespace FlashCards.Api.Service.DTO.Users;

public class UpdateUserPhotoDto
{
    public int UserID { get; private set; }
    public IFormFileCollection File { get; private set; }
    public string BaseUrl { get; private set; }

    public UpdateUserPhotoDto(int userID, IFormFileCollection file, string baseUrl)
    {
        UserID = userID;
        File = file;
        BaseUrl = baseUrl;
    }
}
