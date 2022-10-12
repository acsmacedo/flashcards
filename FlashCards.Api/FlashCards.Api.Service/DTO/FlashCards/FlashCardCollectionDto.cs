﻿using FlashCards.Api.Core.FlashCards;

namespace FlashCards.Api.Service.DTO.FlashCards;

public class FlashCardCollectionDto
{
    public int ID { get; private set; }
    public int CategoryID { get; private set; }
    public int UserDirectoryID { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int Stars { get; private set; }
    public int Available { get; private set; }
    public string UserInstagram { get; private set; }

    public FlashCardCollectionDto(FlashCardCollection data)
    {
        ID = data.ID;
        CategoryID = data.CategoryID;
        UserDirectoryID = data.UserDirectoryID;
        Name = data.Name;
        Description = data.Description;
        Stars = 4;
        Available = 10;
        UserInstagram = "@deconhecido";
    }
}
