using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class EmpInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "This is requird field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This is requird field")]
        public string JobTitle { get; set; }
        [Required(ErrorMessage = "This is requird field")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "This is requird field")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This is requird field")]
        public int Ext { get; set; }
        public int Direct { get; set; }
        public int Mobile { get; set; }



    }
}
