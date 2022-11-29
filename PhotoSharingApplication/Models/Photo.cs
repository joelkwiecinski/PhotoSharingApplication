using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhotoSharingApplication.Models
{
    public class Photo
    {

        [Key]
        public int PhotoID { get; set; }


        [Required]
        public string Title { get; set; }


        [DisplayName("Picture")]
        [MaxLength]
        public byte[] PhotoFile { get; set; }


        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }


        [DataType(DataType.MultilineText)]
        public string Description { get; set; }


        [DataType(DataType.DateTime)]
        [DisplayName("Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


        public string UserName { get; set; }



        #region Navegacion

        public virtual ICollection<Comment> Comments { get; set; }

        #endregion


    }
}