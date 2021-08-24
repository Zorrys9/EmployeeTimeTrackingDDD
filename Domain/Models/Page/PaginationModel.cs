using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Page
{
   public  class PaginationModel<T> where T : class
    {
        public PaginationModel()
        {
            List = new List<T>();
        }
        public ICollection<T> List { get; set; }
        public PageInfoModel PageInfo { get; set; }

        public IEnumerable<T> Calculate(IEnumerable<T> list, int pageNumber, int pageSize)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
