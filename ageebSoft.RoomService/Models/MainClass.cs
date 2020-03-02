using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ageebSoft.RoomService.Models
{
    /// <summary>
    /// الجدول العام لكل الجداول
    /// </summary>

    public class MainClass

    {

        /// <summary>
        /// دالة الإنشاء
        /// </summary>
        public MainClass()
        {
            var now= DateTime.Now;
            Date1 = now;
            Date_Add = now;
            Date_Edit = now;
          

        }

        #region GenaralSection


        /// <summary>
        /// تسلسلي الملف
        /// </summary>
        
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "تسلسلي")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
         public Guid Id { get; set; }

        /// <summary>
        /// تاريخ الإدخال
        /// </summary>
        //      [Required(ErrorMessage = "ادخل التاريخ")]
        [ScaffoldColumn(false)]
        [DataType(DataType.Date)]
        [Display(Name = "التاريخ")]
        [JsonIgnore]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy}")]
        public DateTime? Date1 { get; set; }

        /// <summary>
        /// ملاحظات لكل ملف مدخل - ملاحظات عامة
        /// </summary>
         [Display(Name = "ملاحظات")]
        public string Note { get; set; }


        #endregion

        //============================
        #region تفاصيل الإدخال


        /// <summary>
        /// المدخل
        /// </summary>
         [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "المدخل")]
        [JsonIgnore]
        public string User_Add { get; set; }

        /// <summary>
        /// تاريخ التعديل
        /// </summary>
         [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "تاريخ الإدخال")]
        [JsonIgnore]

        public DateTime? Date_Add { get; set; }

        /// <summary>
        /// المعّدل
        /// </summary>
         [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "المعّدل")]
        [JsonIgnore]

        public string User_Edit { get; set; }



        /// <summary>
        /// تاريخ التعديل
        /// </summary>
         [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "تاريخ التعديل")]
        [JsonIgnore]
        public DateTime? Date_Edit { get; set; }
        #endregion
        //============================
        #region MethodSection

        /// <summary>
        /// احضر تاريخ الإدخال مختصراً
        /// </summary>
        /// <returns></returns>
        public string GetDate1()
        {
            try
            {
                return Date1.Value.ToShortDateString();
            }
            catch { return ""; }
        }


        /// <summary>
        /// احضر تاريخ الإضافة مختصراً
        /// </summary>
        /// <returns></returns>
        public string GetDate_Add()
        {
            try
            {
                return Date_Add.Value.ToShortDateString();
            }
            catch { return ""; }
        }
        /// <summary>
        /// احضر تاريخ التعديل مختصراً
        /// </summary>
        /// <returns></returns>
        public string GetDate_Edit()
        {
            try
            {
                return Date_Edit.Value.ToShortDateString();
            }
            catch { return ""; }
        }

        #endregion

    }

}
