using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DataAccessLayer.Models
{
    [Table("Entry")]
    public partial class Entry
    {
        public Entry()
        {
            Breaks = new HashSet<Break>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [StringLength(450)]
        public string EmployeeId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }
        public TimeSpan? InTime { get; set; }
        public TimeSpan? OutTime { get; set; }
        [Column(TypeName = "decimal(5, 1)")]
        public decimal? TotalWorkingTime { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        [InverseProperty(nameof(AspNetUser.Entries))]
        public virtual AspNetUser Employee { get; set; }
        [InverseProperty(nameof(Break.Entry))]
        public virtual ICollection<Break> Breaks { get; set; }
    }
}
