using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.DTOs.Report
{
    public class ReportDto
    {        
        [Required(ErrorMessage = "Не указан идентификатор сотрудника")]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Не указан идентификатор отчета")]
        public Guid ReportId { get; set; }

        [Required(ErrorMessage = "Не указана дата создания отчета")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Количество отработанных часов не указано")]
        public int NumberOfHour { get; set; }

        public int Recycling { get; set; }

        [MaxLength(50, ErrorMessage = "Причина переработки не должна превышать 50 символов")]
        public string ReasonForRecycling { get; set; }

        [Required(ErrorMessage = "Подробное описание работы не указано")]
        [MaxLength(100, ErrorMessage = "Подробное описание работы не должно превышать 100 символов")]
        public string DescriptionWork { get; set; }
    }
}
