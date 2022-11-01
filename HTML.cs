using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersDefterim
{
    public partial class HTML : Form
    {
        public HTML(string file)
        {
            InitializeComponent();
            webBrowser1.DocumentText = file;
            webBrowser2.DocumentText = file;
        }
    }
}
