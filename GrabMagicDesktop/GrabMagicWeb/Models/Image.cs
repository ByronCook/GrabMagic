using System;

namespace GrabMagicWeb.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string FileName { get; set; }
        public DateTime Date { get; set; }
        public Image Screenshot { get; set; }

        public ApplicationUser User { get; set; }
    }
}