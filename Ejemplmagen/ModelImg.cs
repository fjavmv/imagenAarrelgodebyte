using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplmagen
{
    internal class ModelImg
    {
        public Byte[] img { get; set; }
        public Image imagenModel { get; set; }
        public string nombreImg { get; set; }

        public ModelImg()
        {
            
        }

        public ModelImg(Byte[] img)
        {
            this.img = img;
        }
    }
}
