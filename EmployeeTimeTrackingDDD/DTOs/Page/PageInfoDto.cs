using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Page
{
    public class PageInfoDto
    {
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int CountItems { get; set; }
        public int PageSize { get; set; }
        public PageInfoDto(int pageNumber, int countItems, int pageSize)
        {
            CurrentPage = pageNumber;
            CountItems = countItems;
            PageSize = pageSize;
        }
        public bool PrevPageExist
        {
            get { return CurrentPage > 1 && CurrentPage <= TotalPages + 1; }
        }

        public bool NextPageExist
        {
            get { return CurrentPage < TotalPages; }
        }

        public void CalculateTotalPage()
        {
            TotalPages = (int)Math.Ceiling(CountItems / (double)PageSize);
        }
    }
}
