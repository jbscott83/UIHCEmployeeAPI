using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UIHCEmployeeAPI.Models
{
    public class EmployeeReceipt
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public DateOnly Date { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [StringLength(100)]
        public string Description { get; set; } = string.Empty;
        
        [NotMapped]
        public IFormFile ReceiptFile { get; set; }

        [StringLength(100)]
        public string ReceiptFileName { get; set; } = string.Empty;

        public byte[] Receipt { get; set; } = new byte[0];
    }

//    public class BufferedSingleFileUploadDbModel
//    {
//        public BufferedSingleFileUploadDb ReceiptFileUpload { get; set; }
//}

//    public class BufferedSingleFileUploadDb
//    {
//        public IFormFile FormFile { get; set; }
//    }
}
