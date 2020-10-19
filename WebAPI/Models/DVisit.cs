using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DVisit
    {
        [Key]
        public int Id { get; }
        public DateTime Date { get; set; }

        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
    }
}
