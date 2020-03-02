using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ageebSoft.RoomService.Models
{
    public class Movement:MainClass
    {
        [Display(Name ="مسؤول الغرفة")]
        public string CustName { set; get; }


        public Guid? RoomId { set; get; }
        [ForeignKey(nameof(RoomId))]
        public Rooms Rooms { set; get; }
    }
}
