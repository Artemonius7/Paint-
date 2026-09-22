using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paint
{
    internal class Gallery
    {
        Image picture;
        public Gallery()
        { }
        public Image Picture
        {
            get { return picture; }
            set { picture = value; }
        }
    }
}
