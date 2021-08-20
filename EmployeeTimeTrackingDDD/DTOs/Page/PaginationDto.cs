using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Page
{
    public class PaginationDto<T> where T:class
    {
        public PaginationDto()
        {
            List = new List<T>();
        }
        public ICollection<T> List { get; set; }
        public PageInfoDto PageInfo { get; set; }

        public IEnumerable<T> Pagination(IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
