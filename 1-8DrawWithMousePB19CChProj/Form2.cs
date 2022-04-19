using DrawWithMousePB19.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawWithMousePB19
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Resources.TextFile1;
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                fontDialog1.Font = richTextBox1.SelectionFont;
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                    if (!richTextBox1.SelectionFont.Equals(fontDialog1.Font))
                    {
                        richTextBox1.SelectAll();
                        Font f = richTextBox1.SelectionFont;
                        richTextBox1.SelectionFont = fontDialog1.Font;
                        f.Dispose();
                    }
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

       
    }
}
