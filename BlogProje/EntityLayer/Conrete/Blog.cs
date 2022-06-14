using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        [StringLength(100)]
        public string BlogTitle { get; set; }

        public string BlogImage { get; set; }


        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }

        public int BlogRating { get; set; }


        //Category Blog İlişkileri oluşturdum
        //virtual ederek category override edebileceğiz yani değişiklik yapabileceğiz
        //Bir kategory birden fazla blog olabilir.

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        //Author Blog ilişkileri oluşturdum
        //Her blogun bir yazarı olmalı
        public int AuthorID { get; set; }
        public virtual Author Author { get; set; }

        //Blog ile Comment ilişikisi
        //Bir blogun birden fazla yorumu olabilir.
        public ICollection<Comment> Comments { get; set; }

    }
}
