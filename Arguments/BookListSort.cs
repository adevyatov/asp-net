using System;

namespace WebApi.Arguments
{
    public class BookListSort
    {
        public string? OrderBy { get; set; }

        public string Direction { get; set; } = "desc";
    }
}
