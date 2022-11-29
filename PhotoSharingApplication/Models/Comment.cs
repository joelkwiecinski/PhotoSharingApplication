using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class Comment
    {

        [Key]
        public int CommentID { get; set; }


        public int PhotoID { get; set; }


        public string UserName { get; set; }


        [Required]
        [StringLength(250)]
        public string Subject { get; set; }


        [DataType(DataType.MultilineText)]
        public string Body { get; set; }




        #region Navegacion

        public virtual Photo Photo { get; set; }


        #endregion


    }
}