using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class TimeSheet
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        public string EmployeeId { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Column(TypeName = "datetime")]

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "TimeIn is required")]
        public TimeSpan? TimeIn { get; set; }
        [Column(TypeName = "datetime")]

        [DataType(DataType.Time)]
        [Required(ErrorMessage = "TimeOut is required")]
        public TimeSpan? TimeOut { get; set; }

        [Key]
        [Column("ID")]
        public int? BreakId { get; set; }

        [Column("EntryID")]
        public int? EntryId { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? BreakIn { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan? BreakOut { get; set; }

        [ForeignKey(nameof(EntryId))]
        [InverseProperty("Breaks")]
        public virtual Entry? Entry { get; set; }

        public List<Break> BreakList { get; set; } = new List<Break>();
    }
}
