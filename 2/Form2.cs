using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static _2.Form1;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO;

namespace _2
{
    public partial class Form2 : Form 
    {

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public Form2(Flat[] list)
        {
            InitializeComponent();
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
      
        private void Form2_Load(object sender, EventArgs e)
        {
            //ResultList.Items.AddRange(Form1.list);
        }
        List<Flat> collA = new List<Flat>();
       
    }
}
