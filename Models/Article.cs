using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_RAZORWEB.models
{
    // [Table("posts")]
    public class Article
    {
        [Key]
        public int Id { set; get; }
        [StringLength(255, MinimumLength = 10, ErrorMessage = "{0} phải từ {2} đến {1} ký tự")]
        [Required(ErrorMessage = "{0} phải nhập")]
        [Column(TypeName = "nvarchar")]
        [DisplayName("Tiêu đề")]
        public string Title { set; get; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "{0} phải nhập")]
        [DisplayName("Ngày tạo")]
        public DateTime? Created { set; get; }
        [Column(TypeName = "ntext")]
        [DisplayName("Nội dung")]
        public string Content { set; get; }
    }
}