﻿using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class DeletedUserFavouriteProductResponse : IResponse
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
}
