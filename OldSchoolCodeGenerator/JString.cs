using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OldSchoolCodeGenerator
{
    public partial class JString : Form
    {
        public JString()
        {
            InitializeComponent();
        }

        private void btnToJSString_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            string input = this.txtInput.Text.Trim();
            if (String.IsNullOrEmpty(input) == false)
            {
                string[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                foreach (string s in lines)
                {
                    sb.AppendLine("dhtml = dhtml + \"" + s.Replace("\"", "\\\"") + "\";");
                }
            }

            this.txtOutput.Text = sb.ToString();
        }
    }
}
