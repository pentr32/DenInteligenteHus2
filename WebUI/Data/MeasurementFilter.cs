using System.ComponentModel.DataAnnotations;

namespace WebUI.Data
{
    public enum MeasurementFilterBy
    {
        [Display(Name = "Newest Time")]
        ByNewestTime,
        [Display(Name = "Newest Day")]
        ByNewestDay,
        [Display(Name = "Newest Week")]
        ByNewestWeek
    }
}
