using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        [StringLength(30)]
        public string CategoryName { get; set; }

        [StringLength(500)]
        public string CategoryDescreption { get; set; }

        public bool CategoryStatus { get; set; }

        //İlişkiler oluşturdum
        //Category ile Blog ilişkisi
        //Bir category birden fazla blog olabilir.
        public ICollection<Blog> Blogs { get; set; }
        

    }
}
