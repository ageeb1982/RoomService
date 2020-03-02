using System.ComponentModel.DataAnnotations;

namespace ageebSoft.RoomService.Models
{
    public class NameTel:MainClass
    {
        [Display(Name="الاسم")]
        public string Name { set; get; }
        [Display(Name="رقم الجوال")]
        public string Tel { set; get; }
        [Display(Name ="العنوان")]
        public string Address { set; get; }
    }
}