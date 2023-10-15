using System;
using System.Collections.Generic;
using System.Text;

namespace SportEvent.BLL.DTO
{
    public class ResultDTO<T> where T : class
    {
        public List<T> Data { get; set; }
        public MetaResultDTO Meta { get; set; }
    }

    public class MetaResultDTO
    {
        public PaginationResultDTO Pagination { get; set; }
    }

    public class PaginationResultDTO
    {
        public int Total { get; set; }
        public int Count { get; set; }
        public int Per_Page { get; set; }
        public int Current_Page { get; set; }
        public int Total_Pages { get; set; }
        public PaginationLinkDTO Links { get; set; }
    }

    public class PaginationLinkDTO
    {
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}
