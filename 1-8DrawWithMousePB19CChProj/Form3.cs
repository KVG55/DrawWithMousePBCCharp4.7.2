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
    public partial class Form3 : Form
    {

        double s; //step of changing of the opacity


        private int childCount;// number of forms


        // Create a new form.
        Form mdiChildForm = new Form();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            s = 0.1;
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a new form to represent the child form.
            Form Form1 = new Form1();
            // Increment the private child count.
            childCount++;
            // Set the text of the child form using the count of child forms.
            String formText = "Child " + childCount;
            Form1.Text = formText;

            // Make the new form a child form.
            Form1.MdiParent = this;
            // Display the child form.
            Form1.Show();
        }
             
        private void ToolStripButton7_Click(object sender, EventArgs e)
        {
            try
            {



                menuStrip1.Visible = true;

                FormBorderStyle = FormBorderStyle.Fixed3D;
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void MainMenuInvToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (hideToolStripMenuItem.BackColor == Color.Red)
                    {
                    return;
                }

                // toolStrip1.Visible = false;
                menuStrip1.Visible = false;

                FormBorderStyle = FormBorderStyle.None;


                // FormBorderStyle = FormBorderStyle.None;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                toolStrip1.Visible = false;

                hideToolStripMenuItem.BackColor = Color.Red;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ShowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                hideToolStripMenuItem.BackColor = Color.White;
                toolStrip1.Visible = true;
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                // If the opacity strp over the limit of interval then
                // 0 < Opacity < 1, some change the sign of the interval to the inverse:
                if (Opacity <= 0 || Opacity >= 1) s = -s;
                // Every 0.1 second change the norm of opacity of
                // form for s = 0.1:
                Opacity += s;

            }
            
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ToolStripButton8_Click(object sender, EventArgs e)
        {
            try
            {
                //turn off or swich of the timer

                timer1.Enabled = !timer1.Enabled;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

   
        private void ToolStripButton9_Click(object sender, EventArgs e)
        {
           

            try
            {
                timer1.Enabled = false;
                Opacity = 1;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

      

     

        private void InformationToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                // Create a new form to represent the child form.
                Form Form2 = new Form2
                {
                    // Increment the private child count.

                    // Make the new form a child form.
                    MdiParent = this
                };
                // Display the child form.
                Form2.Show();
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AboutProgramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                // Create a new form to represent the child form.
                AboutBox1 Ab = new AboutBox1
                {
                    //Make the child form
                    MdiParent = this
                };
                // Display the child form.
                Ab.Show();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

    
        private void CascadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                // Cascade all MDI child windows.
                LayoutMdi(MdiLayout.Cascade);
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

      


    

     
       

        }
}
         
    

