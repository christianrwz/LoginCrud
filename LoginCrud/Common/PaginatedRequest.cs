﻿using Microsoft.AspNetCore.Mvc;

namespace LoginCrud.Common
{
    public class PaginatedRequest
    {
        public const int ITEMS_PER_PAGE = 5;
        [FromQuery(Name = "p")]
        public int PageNumber { get; set; } = 1;
        [FromQuery(Name = "s")]
        public string? SearchKeyword { get; set; }
    }
}
