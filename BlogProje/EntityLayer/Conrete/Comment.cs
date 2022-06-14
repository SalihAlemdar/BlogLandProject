using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    public class Comment //YORUM
    {
        [Key]
        public int CommentID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public bool CommentStatus { get; set; }
        public int BlogRating { get; set; }

        //Comment Blog İlişkileri oluşturdum
        //virtual anahtarını kullanarag blogu overrirde edebileceğiz. yani değişiklik yapabileceğiz
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }
    }
}
