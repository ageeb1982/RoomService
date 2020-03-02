using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ageebSoft.RoomService.Models
{
    public class Rooms:MainClass
    {
        [Display(Name ="رقم المفتاح - الباب")]
        public string DoorKey { set; get; }
        
        [Display(Name ="رقم الغرفة")]
        public string RoomNo { set; get; }
        
        [Display(Name ="الطابق")]
        public string Level { set; get; }

        [Display(Name ="المستلم")]
        public Guid? CustId { set; get; }
        public Cust Cust { set; get; }
    }
}
