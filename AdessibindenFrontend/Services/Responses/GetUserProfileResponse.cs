﻿using AdessibindenFrontend.Shared;

namespace AdessibindenFrontend.Services.Responses;

public class GetUserProfileResponse : IResponse
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
}
