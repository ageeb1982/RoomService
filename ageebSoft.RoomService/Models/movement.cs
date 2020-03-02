using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ageebSoft.RoomService.Models
{
    public class RoomsMovement : MainClass
    {
        public Guid? CustId { set; get; }
        public Cust Cust { set; get; }

        public Guid? RoomId { set; get; }
        public Rooms Rooms {set;get;}
    }
}
