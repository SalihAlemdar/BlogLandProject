using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Conrete
{
    public class Author //YAZAR
    {
        [Key]
        public int AuthorID { get; set; }

        [StringLength(30)]
        public string AuthorName { get; set; }

        
        public string AuthorImage { get; set; }

         // configure ederken veritabanı tarafında kolon olarak oluşturma.
        public IFormFile ImagePath { get; set; }

        [StringLength(300)]
        public string AuthorAbout { get; set; }

        [StringLength(50)]
        public string AuthorTitle { get; set; }
         
        [StringLength(100)]
        public string AboutShort { get; set; }

        [StringLength(50)]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        public bool AuthorStatus { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
