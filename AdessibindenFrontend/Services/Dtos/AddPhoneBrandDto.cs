﻿using Core.Application.Dtos;

namespace AdessibindenFrontend.Services.Dtos
{
    public class AddPhoneBrandDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}