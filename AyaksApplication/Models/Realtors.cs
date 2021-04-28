using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AyaksApplication.Models
{
    public class Realtors
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public long DivisionId { get; set; }
        public Divisions Division { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
