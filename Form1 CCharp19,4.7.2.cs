using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Windows.Documents;
using System.Collections.Generic;




// Initionalisation and declaration
        #region

namespace DrawWithMousePB19
{
    public partial class Form1 : Form
    {


        private static readonly Random Random = new Random();



        private Bitmap ContrastBtmp;



        private readonly Pen pen1 = new Pen(Color.Black);

        private readonly Pen pen2 = new Pen(Color.Black);

        private readonly Pen pen3 = new Pen(Color.Black);



        // The Graphics object on which we are drawing.
        private Graphics graphics;

        private string fullPath;


        // True when we are drawing.
        private bool isDrawing = false;

        // The last point we drew.
        private Point lastPoint;
        // for draw items





        public int x_MD_1, y_MD_1;


        PointF MD_1_, MD_2_, MD_3_, MD_4_, MD_5_, MD_6_, MD_7_, MD_8_, MD_9_, MD_10_;

        private readonly PointF[] m_Points3 = new PointF[10];




        PointF MD_1, MD_2, MD_3, MD_4, MD_5, MD_6, MD_7;

        private readonly PointF[] m_Points1 = new PointF[7];


        PointF _MD_1_, _MD_2_, _MD_3_;

        private readonly PointF[] m_Points4 = new PointF[3];



        PointF _MD_1, _MD_2, _MD_3, _MD_4;

        private readonly PointF[] m_Points = new PointF[4];





        private int NextPoint = 0;



        // private int NextPoint1 = 0;

        private int n1;

        private int i;

        //DashCap lines
        public LineCap StartCap { get; private set; }
        public LineCap EndCap { get; private set; }

        public DashCap DashCap { get; private set; }
        public DashStyle DashStyle { get; private set; }

        // for system of coordinates


        public float a, b, x_min, x_max;

        //eversome function for graph
        float Function_of_graph(float x)
        {
            float Function;

            Function = a * x + b;
            return Function;
        }



        //Step of graph:
        public int Npoints = 100;



        //x,y places of system
        public float O_x_pix;
        public float O_y_pix;


        // variables for scale of the system: width, height of squares
        public float M_x;

        public float M_y;

        //   public LineCap EndCap { get; private set; }






        public Form1()




        {
            InitializeComponent();

            pen1.Alignment = PenAlignment.Inset;


        }

        private void Form1_Load(object sender, EventArgs e)
        {



            pictureBox1.BackColor = Color.White;


            radioButton3.Checked = true;

            radioButton2.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            radioButton15.Checked = false;
            radioButton16.Checked = false;
            radioButton17.Checked = false;
            radioButton18.Checked = false;
            radioButton19.Checked = false;
            radioButton20.Checked = false;
            radioButton21.Checked = false;
            radioButton22.Checked = false;

            radioButton23.Checked = true;

            radioButton24.Checked = false;
            radioButton25.Checked = false;
            radioButton26.Checked = true;
            radioButton27.Checked = false;

            radioButton28.Checked = true;

            radioButton29.Checked = false;
            radioButton30.Checked = false;
            radioButton31.Checked = false;
            radioButton32.Checked = false;
            radioButton33.Checked = false;
            radioButton34.Checked = false;

            radioButton35.Checked = true;

            radioButton36.Checked = false;
            radioButton37.Checked = false;
            radioButton38.Checked = false;
            radioButton39.Checked = false;

            radioButton41.Checked = true;

            radioButton42.Checked = false;

            radioButton43.Checked = true;

            radioButton44.Checked = false;

            radioButton45.Checked = true;

            radioButton46.Checked = false;
            radioButton47.Checked = false;

            radioButton49.Checked = true;

            pen1.Width = 1;


            StartNewDrawing();



            for (i = 0; i < 705; i++)
            {

                toolStripComboBox1.Items.Add(i);
            }

            toolStripComboBox1.SelectedItem = 1;


            for (i = 1; i <= 1400; i++)

            {

                toolStripComboBox3.Items.Add(i);
            }

            toolStripComboBox3.SelectedItem = 10;


            for (i = 1; i <= 800; i++)

            {

                toolStripComboBox4.Items.Add(i);
            }

            toolStripComboBox4.SelectedItem = 10;



            for (i = 1; i <= 700; i++)

            {

                toolStripComboBox5.Items.Add(i);
            }

            toolStripComboBox5.SelectedItem = 30;


            for (i = 1; i <= 700; i++)

            {

                toolStripComboBox6.Items.Add(i);
            }

            toolStripComboBox6.SelectedItem = 30;



            for (i = 1; i <= 360; i++)

            {

                toolStripComboBox9.Items.Add(i);
            }

            toolStripComboBox9.SelectedItem = 90;


            for (i = 1; i <= 500; i++)

            {

                toolStripComboBox10.Items.Add(i);
            }

            toolStripComboBox10.SelectedItem = 1;


            n1 = 0;

            do
            {

                toolStripComboBox7.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            toolStripComboBox7.SelectedItem = Color.LimeGreen;



            n1 = 0;

            do
            {

                toolStripComboBox8.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            toolStripComboBox8.SelectedItem = Color.Gold;


            n1 = 0;

            do
            {

                toolStripComboBox2.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            toolStripComboBox2.SelectedItem = Color.Navy;


            //88888888888888888888888888888888888888888

            n1 = 0;

            do
            {

                comboBox10.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox10.SelectedItem = Color.Fuchsia;

            n1 = 0;

            do
            {

                comboBox12.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox12.SelectedItem = Color.Navy;


            n1 = 0;

            do
            {

                comboBox13.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox13.SelectedItem = Color.Green;


            n1 = 0;

            do
            {

                comboBox14.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox14.SelectedItem = Color.Red;


            n1 = 0;

            do
            {

                comboBox15.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox15.SelectedItem = Color.HotPink;


            n1 = 0;

            do
            {

                comboBox16.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox16.SelectedItem = Color.Crimson;

            n1 = 0;

            do
            {

                comboBox17.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox17.SelectedItem = Color.Lime;


            n1 = 0;

            do
            {

                comboBox18.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox18.SelectedItem = Color.DarkGreen;


            n1 = 0;

            do
            {

                comboBox19.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox19.SelectedItem = Color.Coral;


            n1 = 0;

            do
            {

                comboBox1.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox1.SelectedItem = Color.Blue;


            n1 = 0;

            do
            {

                comboBox2.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox2.SelectedItem = Color.Green;


            n1 = 0;

            do
            {

                comboBox3.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox3.SelectedItem = Color.Pink;


            n1 = 0;

            do
            {

                comboBox4.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox4.SelectedItem = Color.Cyan;

            n1 = 0;

            do
            {

                comboBox4.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);




            comboBox4.SelectedItem = Color.Cyan;



            //*******************************************************************************
            n1 = 0;

            do
            {

                comboBox5.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox5.SelectedItem = Color.Fuchsia;
            n1 = 0;

            do
            {

                comboBox6.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox6.SelectedItem = Color.Navy;


            n1 = 0;

            do
            {

                comboBox7.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox7.SelectedItem = Color.Green;


            n1 = 0;

            do
            {

                comboBox8.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox8.SelectedItem = Color.Red;

            n1 = 0;

            do
            {

                comboBox9.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox9.SelectedItem = Color.HotPink;

            n1 = 0;

            do
            {

                comboBox11.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox11.SelectedItem = Color.Crimson;


            n1 = 0;

            do
            {

                comboBox20.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox20.SelectedItem = Color.Lime;


            n1 = 0;

            do
            {

                comboBox21.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox21.SelectedItem = Color.DarkGreen;

            n1 = 0;

            do
            {

                comboBox22.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox22.SelectedItem = Color.Cyan;

            n1 = 0;

            do
            {

                comboBox23.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox23.SelectedItem = Color.Coral;


            n1 = 0;


            do
            {

                comboBox24.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox24.SelectedItem = Color.Blue;
            //***************************************************************************************************

            comboBox25.SelectedItem = "Times New Roman";


            for (i = 0; i < 100; i++)
            {

                comboBox26.Items.Add(i);
            }

            comboBox26.SelectedItem = 20;


            n1 = 0;

            do
            {

                comboBox27.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox27.SelectedItem = Color.Black;

            //*****************************************************************

            //color and width of pen
            n1 = 0;

            do
            {

                comboBox32.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox32.SelectedItem = Color.Black;


            for (i = 0; i < 100; i++)
            {

                comboBox33.Items.Add(i);
            }

            comboBox33.SelectedItem = 20;


            //888888888888888888888888888888888888888888888888
            //populate the comboBoxs by Lists of style





            var LineCapItems = new List<LineCap> { LineCap.Flat, LineCap.Square, LineCap.Round, LineCap.Triangle, LineCap.NoAnchor, LineCap.NoAnchor, LineCap.RoundAnchor, LineCap.DiamondAnchor, LineCap.ArrowAnchor, LineCap.AnchorMask, LineCap.Custom };

            foreach (LineCap element in LineCapItems)
            {

                comboBox28.Items.Add(element);

            }

            comboBox28.SelectedItem = LineCap.Flat;

            var LineCapItems1 = new List<LineCap> { LineCap.Flat, LineCap.Square, LineCap.Round, LineCap.Triangle, LineCap.NoAnchor, LineCap.NoAnchor, LineCap.RoundAnchor, LineCap.DiamondAnchor, LineCap.ArrowAnchor, LineCap.AnchorMask, LineCap.Custom };


            foreach (LineCap element in LineCapItems1)
            {

                comboBox29.Items.Add(element);

            }

            comboBox29.SelectedItem = LineCap.Flat;


            var LineCapItems2 = new List<DashCap> { DashCap.Flat, DashCap.Round, DashCap.Triangle };

            foreach (DashCap element in LineCapItems2)
            {

                comboBox30.Items.Add(element);

            }

            comboBox30.SelectedItem = DashCap.Flat;


            var LineCapItems3 = new List<DashStyle> { DashStyle.Solid, DashStyle.Dash, DashStyle.Dot, DashStyle.DashDot, DashStyle.DashDotDot, DashStyle.Custom };

            foreach (DashStyle element in LineCapItems3)
            {

                comboBox31.Items.Add(element);

            }

            comboBox31.SelectedItem = DashStyle.Dash;
            //88888888888888888888888888888888888888888888888888888888888888



            n1 = 0;

            do
            {

                comboBox35.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox35.SelectedItem = Color.Black;


            n1 = 0;

            do
            {

                comboBox36.Items.Add(Color.FromKnownColor((KnownColor)n1));

                n1++;


            } while (n1 <= 167);


            comboBox36.SelectedItem = Color.Teal;


        }

        #endregion



        //Option of drawing
        #region

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewDrawing();
        }

        private void StartNewDrawing()
        {
            // Make a new Bitmap;
            Bitmap bm = new Bitmap(pictureBox1.ClientRectangle.Width, pictureBox1.ClientRectangle.Height);

            // Make an associated Graphics object.
            graphics = Graphics.FromImage(bm);

            // Clear the new Bitmap.
            graphics.Clear(BackColor);

            // Display the new bitmap in the PictureBox.
            pictureBox1.Image = bm;

            // Refresh.
            pictureBox1.Refresh();
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (radioButton1.Checked)
                {

                    // Remember we are drawing.
                    isDrawing = true;

                    // Save the current point.
                    lastPoint = e.Location;

                }

                if (radioButton2.Checked)
                {


                    // Remember we are drawing.
                    isDrawing = true;



                }

                if (radioButton4.Checked)
                {


                    // Remember we are drawing.
                    isDrawing = true;

                }

                if (radioButton5.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;


                }

                if (radioButton6.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }

                if (radioButton7.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;
                }

                if (radioButton8.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }

                if (radioButton9.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;


                }

                if (radioButton10.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }

                if (radioButton11.Checked)
                {
                    isDrawing = true;

                }

                if (radioButton12.Checked)
                {
                    isDrawing = true;


                }

                if (radioButton13.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;


                }

                if (radioButton14.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;


                }
                if (radioButton15.Checked)
                {


                    isDrawing = true;
                    if (isDrawing == true)
                    {
                        if (NextPoint > 3) NextPoint = 0;
                        {

                            // Let's save this point 
                            m_Points[NextPoint].X = e.X;
                            m_Points[NextPoint].Y = e.Y;

                            //Let's move to the next point. 
                            NextPoint++;




                            _MD_1 = m_Points[0];

                            _MD_2 = m_Points[1];

                            _MD_3 = m_Points[2];

                            _MD_4 = m_Points[3];


                            pictureBox1.Invalidate();

                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen1,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);

                                    }

                                }
                            }




                        }


                    }


                }



                if (radioButton16.Checked)
                {


                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        if (NextPoint > 6) NextPoint = 0;

                        // Сохраним эту точку.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Переместимся к следующей точке.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }

                        }


                    }

                    // ReDraw.
                    pictureBox1.Refresh();

                }


                if (radioButton17.Checked)
                {

                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        if (NextPoint > 6) NextPoint = 0;

                        // Сохраним эту точку.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Переместимся к следующей точке.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }

                        }
                        //ReDraw
                        pictureBox1.Refresh();


                    }

                }


                if (radioButton18.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        if (NextPoint > 6) NextPoint = 0;

                        // Сохраним эту точку.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Переместимся к следующей точке.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }

                        }
                        // ReDraw
                        pictureBox1.Refresh();


                    }

                }

                if (radioButton19.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {


                        if (NextPoint > 6) NextPoint = 0;

                        // Let's save this point.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Let's move to other points.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];





                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }
                        }

                        // ReDraw.
                        pictureBox1.Refresh();


                    }


                }


                if (radioButton20.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {


                        if (NextPoint > 6) NextPoint = 0;

                        // Let's save this point.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Let's move to other points.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];





                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }
                        }

                        // ReDraw.
                        pictureBox1.Refresh();


                    }

                }

                if (radioButton21.Checked)

                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {


                        if (NextPoint > 3) NextPoint = 0; //6

                        // Let's save this point.
                        m_Points[NextPoint].X = e.X;
                        m_Points[NextPoint].Y = e.Y;

                        // Let's move to other points.
                        NextPoint++;

                        _MD_1 = m_Points[0];
                        _MD_2 = m_Points[1];
                        _MD_3 = m_Points[2];
                        _MD_4 = m_Points[3];






                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                }

                            }
                        }

                        // ReDraw.
                        pictureBox1.Refresh();

                    }

                }


                if (radioButton22.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (NextPoint > 3) NextPoint = 0; //6

                        // Let's save this point.
                        m_Points[NextPoint].X = e.X;
                        m_Points[NextPoint].Y = e.Y;

                        // Let's move to other points.
                        NextPoint++;

                        _MD_1 = m_Points[0];
                        _MD_2 = m_Points[1];
                        _MD_3 = m_Points[2];
                        _MD_4 = m_Points[3];






                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                }

                            }
                        }

                        // ReDraw.
                        pictureBox1.Refresh();

                    }

                }

                if (radioButton24.Checked)
                {

                    isDrawing = true;





                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;




                }


                if (radioButton25.Checked)
                {

                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        if (NextPoint > 9) NextPoint = 0;

                        // Сохраним эту точку.
                        m_Points3[NextPoint].X = e.X;
                        m_Points3[NextPoint].Y = e.Y;

                        // Переместимся к следующей точке.
                        NextPoint++;

                        MD_1_ = m_Points3[0];
                        MD_2_ = m_Points3[1];
                        MD_3_ = m_Points3[2];
                        MD_4_ = m_Points3[3];
                        MD_5_ = m_Points3[4];
                        MD_6_ = m_Points3[5];
                        MD_7_ = m_Points3[6];
                        MD_8_ = m_Points3[7];
                        MD_9_ = m_Points3[8];
                        MD_10_ = m_Points3[9];





                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points3[i].X - 1, m_Points3[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points3[i].X - 1, m_Points3[i].Y - 1, 1, 1);


                                }

                            }

                        }

                        pictureBox1.Refresh();

                    }



                }

                if (radioButton27.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        x_MD_1 = e.X;

                        y_MD_1 = e.Y;
                    }

                    //  if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                    //{

                    //  graphics.DrawRectangle(pen3, e.X, e.Y, 1, 1);
                    // }
                }



                if (radioButton29.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;



                }

                if (radioButton30.Checked)
                {
                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;



                }


                if (radioButton31.Checked)
                {
                    isDrawing = true;
                    if (isDrawing == true)
                    {
                        if (NextPoint > 2) NextPoint = 0;
                        {

                            // Let's save this point 
                            m_Points4[NextPoint].X = e.X;
                            m_Points4[NextPoint].Y = e.Y;

                            //Let's move to the next point. 
                            NextPoint++;




                            _MD_1_ = m_Points4[0];

                            _MD_2_ = m_Points4[1];

                            _MD_3_ = m_Points4[2];



                            pictureBox1.Invalidate();




                            //     pictureBox1.Invalidate();

                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);

                                    }
                                }

                            }




                        }

                        pictureBox1.Refresh();


                    }

                }


                if (radioButton32.Checked)
                {
                    isDrawing = true;
                    if (isDrawing == true)
                    {
                        if (NextPoint > 2) NextPoint = 0;
                        {

                            // Let's save this point 
                            m_Points4[NextPoint].X = e.X;
                            m_Points4[NextPoint].Y = e.Y;

                            //Let's move to the next point. 
                            NextPoint++;




                            _MD_1_ = m_Points4[0];

                            _MD_2_ = m_Points4[1];

                            _MD_3_ = m_Points4[2];



                            pictureBox1.Invalidate();




                            //     pictureBox1.Invalidate();

                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {
                                // Let's draw some control points. 
                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(Pens.Black,
                                             m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                    }

                                }

                            }




                        }

                        pictureBox1.Refresh();


                    }


                }


                if (radioButton33.Checked)
                {

                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (NextPoint > 3) NextPoint = 0;

                        // Let's save this point.
                        m_Points[NextPoint].X = e.X;
                        m_Points[NextPoint].Y = e.Y;

                        // Let's move to other points.
                        NextPoint++;

                        _MD_1 = m_Points[0];
                        _MD_2 = m_Points[1];
                        _MD_3 = m_Points[2];
                        _MD_4 = m_Points[3];






                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                }

                            }
                        }

                        // ReDraw.
                        pictureBox1.Refresh();

                    }


                }


                if (radioButton34.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {

                        if (NextPoint > 6) NextPoint = 0;

                        // Сохраним эту точку.
                        m_Points1[NextPoint].X = e.X;
                        m_Points1[NextPoint].Y = e.Y;

                        // Переместимся к следующей точке.
                        NextPoint++;

                        MD_1 = m_Points1[0];
                        MD_2 = m_Points1[1];
                        MD_3 = m_Points1[2];
                        MD_4 = m_Points1[3];
                        MD_5 = m_Points1[4];
                        MD_6 = m_Points1[5];
                        MD_7 = m_Points1[6];


                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(pen3,
                                         m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                }

                            }

                        }
                        // ReDraw
                        pictureBox1.Refresh();


                    }



                }




                if (radioButton36.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }


                if (radioButton37.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }


                if (radioButton38.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }

                if (radioButton39.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }

                if (radioButton40.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                }



                if (radioButton44.Checked)
                {

                    isDrawing = true;

                    x_MD_1 = e.X;

                    y_MD_1 = e.Y;

                    pictureBox1.Refresh();

                }

                if (radioButton46.Checked)
                {

                    isDrawing = true;

                    //  x_MD_1 = e.X;

                    //  y_MD_1 = e.Y;

                    //     pictureBox1.Refresh();

                }

                if (radioButton47.Checked)
                {

                    isDrawing = true;

                    //  x_MD_1 = e.X;

                    //  y_MD_1 = e.Y;

                    //     pictureBox1.Refresh();

                }

            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                toolStripTextBox1.Text = string.Format("X = {0} или {1}",
                                     MousePosition.X, e.X);
                toolStripTextBox2.Text = string.Format("Y = {0} или {1}",
                                               MousePosition.Y, e.Y);

                if (e.Button == MouseButtons.Left)
                {
                    if (radioButton1.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.
                            graphics.DrawLine(pen1, lastPoint, e.Location);

                        }
                        // Refresh.
                        pictureBox1.Refresh();

                        // Save the current point.
                        lastPoint = e.Location;


                    }

                    if (radioButton2.Checked)
                    {

                        // Make sure we are drawing.
                        isDrawing = true;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {


                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.


                            graphics.FillEllipse(
                                 new SolidBrush((Color)toolStripComboBox2.SelectedItem), e.X, e.Y, (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem);

                        }
                        // Refresh.
                        pictureBox1.Refresh();


                    }

                    if (radioButton4.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.FillRectangle(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), e.X, e.Y, (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem);
                        }

                        // Refresh.
                        pictureBox1.Refresh();



                    }

                    if (radioButton5.Checked)
                    {

                        isDrawing = true;
                    }

                    if (radioButton6.Checked)
                    {
                        isDrawing = true;
                    }

                    if (radioButton7.Checked)
                    {
                        isDrawing = true;
                    }

                    if (radioButton8.Checked)
                    {
                        isDrawing = true;
                    }

                    if (radioButton9.Checked)
                    {


                        if (!isDrawing) return;

                    }

                    if (radioButton10.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;
                    }

                    if (radioButton11.Checked)
                    {

                        if (e.Button == MouseButtons.Left)
                        {


                            // Make sure we are drawing.
                            if (!isDrawing) return;
                            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                            {


                                graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                Rectangle Rect = new Rectangle(e.X, e.Y, (int)toolStripComboBox5.SelectedItem, (int)toolStripComboBox6.SelectedItem);
                                LinearGradientBrush GrBrush;

                                GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem);


                                graphics.FillRectangle(GrBrush, Rect);


                            }
                            pictureBox1.Refresh();

                        }

                    }

                    if (radioButton12.Checked)
                    {
                        if (e.Button == MouseButtons.Left)
                        {


                            // Make sure we are drawing.
                            if (!isDrawing) return;

                            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                            {

                                graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                Rectangle Rect = new Rectangle(e.X, e.Y, (int)toolStripComboBox5.SelectedItem, (int)toolStripComboBox6.SelectedItem);


                                LinearGradientBrush GrBrush;

                                GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem);


                                graphics.FillEllipse(GrBrush, Rect);


                            }
                            pictureBox1.Refresh();

                        }

                    }

                    if (radioButton13.Checked)
                    {
                        if (!isDrawing) return;

                    }

                    if (radioButton14.Checked)

                    {
                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            graphics.DrawLine(pen1, x_MD_1, y_MD_1,
                            e.X, e.Y);

                        }

                        pictureBox1.Refresh();



                    }

                    if (radioButton15.Checked)
                    {
                        if (!isDrawing) return;


                    }


                    if (radioButton16.Checked)
                    {

                        if (!isDrawing) return;


                    }


                    if (radioButton17.Checked)
                    {

                        if (!isDrawing) return;


                    }



                    if (radioButton18.Checked)
                    {


                        if (!isDrawing) return;


                    }


                    if (radioButton19.Checked)
                    {

                        if (!isDrawing) return;

                    }


                    if (radioButton20.Checked)
                    {


                        if (!isDrawing) return;


                    }


                    if (radioButton21.Checked)

                    {

                        if (!isDrawing) return;

                    }


                    if (radioButton22.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {


                            if (!isDrawing) return;



                        }

                    }

                    if (radioButton24.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }

                    if (radioButton25.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }



                    if (radioButton27.Checked)
                    {


                        // Make sure we are drawing.
                        if (!isDrawing) return;
                    }


                    if (radioButton29.Checked)
                    {


                        // Make sure we are drawing.
                        if (!isDrawing) return;
                    }

                    if (radioButton30.Checked)
                    {


                        // Make sure we are drawing.
                        if (!isDrawing) return;
                    }

                    if (radioButton31.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;

                    }


                    if (radioButton32.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;



                    }

                    if (radioButton33.Checked)
                    {
                        // Make sure we are drawing.
                        if (!isDrawing) return;



                    }


                    if (radioButton34.Checked)
                    {


                        if (!isDrawing) return;


                    }


                    if (radioButton36.Checked)
                    {
                        isDrawing = true;



                    }


                    if (radioButton37.Checked)
                    {
                        isDrawing = true;



                    }

                    if (radioButton38.Checked)
                    {
                        isDrawing = true;



                    }

                    if (radioButton39.Checked)
                    {
                        isDrawing = true;

                        try
                        {
                            using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                            {
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                Bitmap image1 = (Bitmap)Image.FromFile(fullPath, true);

                                TextureBrush texture = new TextureBrush(image1)
                                {
                                    WrapMode = WrapMode.Clamp
                                };

                                graphics.FillEllipse(texture,
                                    new RectangleF(e.X, e.Y, (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem));

                                pictureBox1.Refresh();
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("There was an error opening the bitmap." +
                                "Please check the path.");
                        }

                    }

                    if (radioButton40.Checked)
                    {
                        isDrawing = true;

                        try
                        {
                            using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                            {
                                graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                Rectangle Rect = new Rectangle(e.X, e.Y, (int)toolStripComboBox5.SelectedItem, (int)toolStripComboBox6.SelectedItem);
                                LinearGradientBrush GrBrush;

                                GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem);


                                graphics.FillRectangle(GrBrush, Rect);

                                Bitmap image1 = (Bitmap)Image.FromFile(fullPath, true);

                                TextureBrush texture = new TextureBrush(image1)
                                {
                                    WrapMode = WrapMode.Clamp
                                };

                                graphics.FillRectangle(GrBrush, Rect);

                                graphics.FillEllipse(texture,
                                    new RectangleF(e.X, e.Y, (int)toolStripComboBox5.SelectedItem, (int)toolStripComboBox6.SelectedItem));


                                pictureBox1.Refresh();
                            }
                        }
                        catch (FileNotFoundException)
                        {
                            MessageBox.Show("There was an error opening the bitmap." +
                                "Please check the path.");
                        }

                    }

                    if (radioButton44.Checked)
                    {

                        isDrawing = true;

                    }

                    if (radioButton46.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            graphics.DrawRectangle(pen1, e.X, e.Y,
                       (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem);



                        }

                        // Refresh.
                        pictureBox1.Refresh();



                    }


                    if (radioButton47.Checked)
                    {

                        // Make sure we are drawing.
                        if (!isDrawing) return;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            graphics.DrawEllipse(pen1, e.X, e.Y,
                       (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem);



                        }

                        // Refresh.
                        pictureBox1.Refresh();



                    }

                }
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            try
            {


                if (e.Button == MouseButtons.Left)
                {



                    if (radioButton1.Checked)
                    {
                        Clipboard.SetImage(pictureBox1.Image);

                        isDrawing = false;
                    }

                    if (radioButton2.Checked)
                    {

                        Clipboard.SetImage(pictureBox1.Image);

                        isDrawing = false;

                    }

                    if (radioButton4.Checked)

                    {

                        Clipboard.SetImage(pictureBox1.Image);

                        isDrawing = false;

                    }

                    if (radioButton5.Checked)
                    {


                        // Make sure we are drawing.
                        isDrawing = true;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            // Create rectangle.
                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            graphics.FillRectangle(new SolidBrush((Color)toolStripComboBox2.SelectedItem), Rect);
                        }
                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }

                    if (radioButton6.Checked)
                    {
                        // Make sure we are drawing.
                        isDrawing = true;

                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                            // Draw to the new point.

                            // Create rectangle.
                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            graphics.FillEllipse(
                                     new SolidBrush((Color)toolStripComboBox2.SelectedItem), Rect);
                        }

                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);


                    }

                    if (radioButton7.Checked)
                    {
                        isDrawing = true;

                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.DrawRectangle(pen1, x_MD_1, y_MD_1,
                              e.X - x_MD_1, e.Y - y_MD_1);
                        }
                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }


                    if (radioButton8.Checked)
                    {
                        isDrawing = true;
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;

                            graphics.DrawEllipse(pen1, x_MD_1, y_MD_1,
                          e.X - x_MD_1, e.Y - y_MD_1);

                        }
                        pictureBox1.Refresh();
                        Clipboard.SetImage(pictureBox1.Image);
                    }

                    if (radioButton9.Checked)
                    {
                        isDrawing = true;

                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            LinearGradientBrush GrBrush;

                            using (GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem))
                            {

                                graphics.FillRectangle(GrBrush, Rect);

                            }
                        }
                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);

                    }

                    if (radioButton10.Checked)
                    {
                        isDrawing = true;

                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            LinearGradientBrush GrBrush;

                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem);


                            graphics.FillEllipse(GrBrush, Rect);


                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);

                    }

                    if (radioButton11.Checked)
                    {
                        Clipboard.SetImage(pictureBox1.Image);
                        isDrawing = false;


                    }

                    if (radioButton12.Checked)

                    {
                        Clipboard.SetImage(pictureBox1.Image);
                        isDrawing = false;

                    }

                    if (radioButton13.Checked)
                    {


                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {
                            graphics.SmoothingMode = SmoothingMode.AntiAlias;



                            graphics.DrawLine(pen1, x_MD_1, y_MD_1, e.X, e.Y);

                        }

                        // Refresh.
                        pictureBox1.Refresh();
                        Clipboard.SetImage(pictureBox1.Image);


                    }
                    if (radioButton14.Checked)
                    {
                        Clipboard.SetImage(pictureBox1.Image);
                        isDrawing = false;

                    }

                    if (radioButton15.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 4)
                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    Pen DrawBZPen = new Pen((Color)toolStripComboBox2.SelectedItem, (int)toolStripComboBox1.SelectedItem);

                                    graphics.DrawBezier(DrawBZPen, _MD_1, _MD_2, _MD_3, _MD_4);

                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {

                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Transparent,
                                            m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        }

                                    }
                                }

                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }

                    }

                    if (radioButton16.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    Pen DrawPolygon = new Pen((Color)toolStripComboBox2.SelectedItem, (int)toolStripComboBox1.SelectedItem);



                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                    graphics.DrawPolygon(DrawPolygon, curvePoints);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                        }

                                    }
                                }



                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }


                    }


                    if (radioButton17.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    SolidBrush BrushP = new SolidBrush((Color)toolStripComboBox2.SelectedItem);


                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                    graphics.FillPolygon(BrushP, curvePoints);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                        }

                                    }
                                }



                                pictureBox1.Refresh();
                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }


                    }
                    if (radioButton18.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {



                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    SolidBrush BrushP = new SolidBrush((Color)toolStripComboBox2.SelectedItem);


                                    PointF[] curvePoints =
                                    {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };

                                    LinearGradientBrush GrBrush;



                                    GrBrush = new LinearGradientBrush(MD_1, MD_5, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem);



                                    graphics.FillPolygon(GrBrush, curvePoints);




                                    //  graphics.FillPolygon(BrushP, curvePoints);



                                }

                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Transparent,
                                            m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                        }

                                    }
                                }



                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);

                            }


                        }

                    }

                    if (radioButton19.Checked)
                    {


                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    PointF[] curvePoints =
                                    {
                                          MD_1,
                                          MD_2,
                                          MD_3,
                                          MD_4,
                                          MD_5,
                                          MD_6,
                                          MD_7,
                                                  };





                                    Pen Pen1 = new Pen((Color)toolStripComboBox7.SelectedItem, (int)toolStripComboBox1.SelectedItem);

                                    Pen Pen2 = new Pen((Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox10.SelectedItem);




                                    graphics.DrawLines(Pen1, curvePoints);


                                    graphics.DrawCurve(Pen2, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                        }

                                    }
                                }

                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);

                            }

                        }

                    }


                    if (radioButton20.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 7)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {

                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                    PointF[] curvePoints =
                                    {
                                          MD_1,
                                          MD_2,
                                          MD_3,
                                          MD_4,
                                          MD_5,
                                          MD_6,
                                          MD_7,
                                                  };





                                    Pen Pen1 = new Pen((Color)toolStripComboBox7.SelectedItem, (int)toolStripComboBox1.SelectedItem);

                                    Pen Pen2 = new Pen((Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox10.SelectedItem);




                                    graphics.DrawLines(Pen1, curvePoints);


                                    graphics.DrawClosedCurve(Pen2, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                        }

                                    }
                                }

                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);
                            }

                        }



                    }

                    if (radioButton21.Checked)

                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {


                            if (NextPoint >= 4)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                    PointF[] curvePoints =
                                    {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };

                                    SolidBrush BrushClCu = new SolidBrush((Color)toolStripComboBox2.SelectedItem);



                                    graphics.FillClosedCurve(BrushClCu, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                        }

                                    }
                                }

                                pictureBox1.Refresh();

                                Clipboard.SetImage(pictureBox1.Image);
                            }

                        }

                    }

                    if (radioButton22.Checked)
                    {
                        isDrawing = true;

                        if (isDrawing == true)
                        {
                            if (NextPoint >= 4)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                    PointF[] curvePoints =
                                    {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };


                                    LinearGradientBrush GrBrush;






                                    GrBrush = new LinearGradientBrush(_MD_1, _MD_3, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem);



                                    graphics.FillClosedCurve(GrBrush, curvePoints);


                                }


                                if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                                {

                                    for (int i = 0; i < NextPoint; i++)
                                    {
                                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                        {
                                            graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                            graphics.FillRectangle(Brushes.Red,
                                            m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                            graphics.DrawRectangle(pen3,
                                                 m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                        }

                                    }
                                }

                                pictureBox1.Refresh();


                                Clipboard.SetImage(pictureBox1.Image);


                            }

                        }

                    }

                    if (radioButton24.Checked)
                    {
                        isDrawing = true;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            // graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                            // Create a path that consists of a single ellipse.
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(Rect);


                            // path.AddRectangle(Rect);
                            // Use the path to construct a brush.

                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                            {




                                // Set the color at the center of the path to blue.
                                CenterColor = (Color)toolStripComboBox7.SelectedItem
                            };

                            // Set the color along the entire boundary 
                            // of the path to aqua.
                            Color[] colors = { (Color)toolStripComboBox8.SelectedItem };
                            pthGrBrush.SurroundColors = colors;

                            //e.Graphics.FillRectangle(pthGrBrush, 35, 35, 140, 140);

                            graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                        }

                        pictureBox1.Refresh();

                        Clipboard.SetImage(pictureBox1.Image);


                    }
                    if (radioButton25.Checked)
                    {

                        isDrawing = true;



                        if (isDrawing == true)
                        {

                            if (NextPoint >= 10)

                            {

                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {


                                    // Put the points of a polygon in an array.
                                    PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                                    // Use the array of points to construct a path.
                                    GraphicsPath path = new GraphicsPath();
                                    path.AddLines(points);

                                    // Use the path to construct a path gradient brush.
                                    PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                                    {

                                        // Set the color at the center of the path to red.
                                        CenterColor = (Color)toolStripComboBox7.SelectedItem
                                    };


                                    // Set the colors of the points in the array.
                                    Color[] colors = {
                                    (Color)comboBox10.SelectedItem,
                                    (Color)comboBox12.SelectedItem,
                                    (Color)comboBox13.SelectedItem,
                                    (Color)comboBox14.SelectedItem,
                                    (Color)comboBox15.SelectedItem,
                                    (Color)comboBox16.SelectedItem,
                                    (Color)comboBox17.SelectedItem,
                                    (Color)comboBox18.SelectedItem,
                                    (Color)comboBox19.SelectedItem,
                                    (Color)toolStripComboBox8.SelectedItem};


                                    pthGrBrush.SurroundColors = colors;

                                    // Fill the path with the path gradient brush.
                                    graphics.FillPath(pthGrBrush, path);

                                    // Refresh.
                                    pictureBox1.Refresh();
                                }

                                Clipboard.SetImage(pictureBox1.Image);

                            }


                        }

                    }

                    if (radioButton27.Checked)
                    {
                        isDrawing = true;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            // graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                            // Create a path that consists of a single ellipse.
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(Rect);


                            // path.AddRectangle(Rect);
                            // Use the path to construct a brush.

                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                            {
                                CenterPoint = new PointF((int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem),

                                // Set the color at the center of the path to blue.
                                CenterColor = (Color)toolStripComboBox7.SelectedItem
                            };

                            // Set the color along the entire boundary 
                            // of the path to aqua.
                            Color[] colors = { (Color)toolStripComboBox8.SelectedItem };
                            pthGrBrush.SurroundColors = colors;

                            //e.Graphics.FillRectangle(pthGrBrush, 35, 35, 140, 140);

                            graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {

                                graphics.DrawRectangle(pen3, (int)toolStripComboBox3.SelectedItem, (int)toolStripComboBox4.SelectedItem - 1, 1, 1);
                            }

                            pictureBox1.Refresh();

                            Clipboard.SetImage(pictureBox1.Image);

                        }

                    }

                    if (radioButton29.Checked)
                    {
                        isDrawing = true;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            // graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                            // Create a path that consists of a single ellipse.
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(Rect);


                            // path.AddRectangle(Rect);
                            // Use the path to construct a brush.

                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                            {
                                CenterPoint = new PointF(e.X, e.Y),

                                // Set the color at the center of the path to blue.
                                CenterColor = (Color)toolStripComboBox7.SelectedItem
                            };

                            // Set the color along the entire boundary 
                            // of the path to aqua.
                            Color[] colors = { (Color)toolStripComboBox8.SelectedItem };
                            pthGrBrush.SurroundColors = colors;

                            //e.Graphics.FillRectangle(pthGrBrush, 35, 35, 140, 140);

                            graphics.FillEllipse(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {

                                graphics.DrawRectangle(pen3, e.X, e.Y, 1, 1);
                            }

                            pictureBox1.Refresh();

                            Clipboard.SetImage(pictureBox1.Image);

                        }
                    }




                    if (radioButton30.Checked)
                    {
                        isDrawing = true;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            // graphics.SmoothingMode = SmoothingMode.AntiAlias;


                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));




                            // Create a path that consists of a single ellipse.
                            GraphicsPath path = new GraphicsPath();
                            path.AddEllipse(Rect);


                            // path.AddRectangle(Rect);
                            // Use the path to construct a brush.

                            PathGradientBrush pthGrBrush = new PathGradientBrush(path)

                            {
                                CenterPoint = new PointF(e.X, e.Y),

                                // Set the color at the center of the path to blue.
                                CenterColor = (Color)toolStripComboBox7.SelectedItem
                            };

                            // Set the color along the entire boundary 
                            // of the path to aqua.
                            Color[] colors = { (Color)toolStripComboBox8.SelectedItem };
                            pthGrBrush.SurroundColors = colors;



                            graphics.FillRectangle(pthGrBrush, Rect);// строку можно оставить при прямоугольнике сходящиеся к центру оси градиентов.


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {

                                graphics.DrawRectangle(pen3, e.X, e.Y, 1, 1);
                            }

                            pictureBox1.Refresh();

                            Clipboard.SetImage(pictureBox1.Image);

                        }


                    }



                    if (radioButton31.Checked)
                    {

                        //  if (NextPoint >= 3) Especially for this 
                        //  {

                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            PointF[] points =
                                    {
                                          _MD_1_,
                                          _MD_2_,
                                          _MD_3_,


                                                  };

                            GraphicsPath path = new GraphicsPath();
                            path.AddLines(points);


                            // No GraphicsPath object is created. The PathGradientBrush
                            // object is constructed directly from the array of points.
                            PathGradientBrush pthGrBrush = new PathGradientBrush(points);

                            Color[] colors = {
      (Color)toolStripComboBox7.SelectedItem,
       (Color)toolStripComboBox8.SelectedItem,
       (Color)comboBox1.SelectedItem};




                            float[] relativePositions = {
       (float)numericUpDown1.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown2.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown3.Value};    // Blue is at the center point.

                            ColorBlend colorBlend = new ColorBlend
                            {
                                Colors = colors,
                                Positions = relativePositions
                            };
                            pthGrBrush.InterpolationColors = colorBlend;

                            // Fill a rectangle that is larger than the triangle
                            // specified in the Point array. The portion of the
                            // rectangle outside the triangle will not be painted.
                            g.FillPath(pthGrBrush, path);

                        }

                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(Pens.Black,
                                         m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                }

                            }

                        }

                        // }

                        // Refresh.
                        pictureBox1.Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }


                }



                if (radioButton32.Checked)
                {
                    if (NextPoint >= 3)

                    {
                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {

                            PointF[] points =
                                    {
                                          _MD_1_,
                                          _MD_2_,
                                          _MD_3_,


                                                  };

                            GraphicsPath path = new GraphicsPath();
                            path.AddLines(points);


                            // No GraphicsPath object is created. The PathGradientBrush
                            // object is constructed directly from the array of points.
                            PathGradientBrush pthGrBrush = new PathGradientBrush(points);

                            Color[] colors = {
      (Color)toolStripComboBox7.SelectedItem,
      (Color)toolStripComboBox8.SelectedItem,
      (Color)comboBox1.SelectedItem};




                            float[] relativePositions = {
       (float)numericUpDown1.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown2.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown3.Value};    // Blue is at the center point.

                            ColorBlend colorBlend = new ColorBlend
                            {
                                Colors = colors,
                                Positions = relativePositions
                            };
                            pthGrBrush.InterpolationColors = colorBlend;

                            // Fill a rectangle that is larger than the triangle
                            // specified in the Point array. The portion of the
                            // rectangle outside the triangle will not be painted.
                            g.FillPath(pthGrBrush, path);

                        }

                        if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                        {
                            // Let's draw some control points. 
                            for (int i = 0; i < NextPoint; i++)
                            {
                                using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                {
                                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                    graphics.FillRectangle(Brushes.Transparent,
                                    m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);
                                    graphics.DrawRectangle(Pens.Black,
                                         m_Points4[i].X - 1, m_Points4[i].Y - 1, 1, 1);

                                }
                            }

                        }




                        // Refresh.
                        pictureBox1.Refresh();



                        Clipboard.SetImage(pictureBox1.Image);
                    }

                }

                if (radioButton33.Checked)
                {
                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (NextPoint >= 4)

                        {

                            using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                            {


                                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                                PointF[] curvePoints =
                                {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };



                                GraphicsPath path = new GraphicsPath();
                                path.AddLines(curvePoints);


                                // No GraphicsPath object is created. The PathGradientBrush
                                // object is constructed directly from the array of points.
                                PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                                Color[] colors = {
      (Color)toolStripComboBox7.SelectedItem,
      (Color)toolStripComboBox8.SelectedItem,
      (Color)comboBox1.SelectedItem};




                                float[] relativePositions = {
       (float)numericUpDown1.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown2.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown3.Value};    // Blue is at the center point.

                                ColorBlend colorBlend = new ColorBlend
                                {
                                    Colors = colors,
                                    Positions = relativePositions
                                };
                                pthGrBrush.InterpolationColors = colorBlend;

                                // Fill a rectangle that is larger than the triangle
                                // specified in the Point array. The portion of the
                                // rectangle outside the triangle will not be painted.
                                graphics.FillPath(pthGrBrush, path);



                            }


                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {

                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Red,
                                        m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points[i].X - 1, m_Points[i].Y - 1, 1, 1);


                                    }

                                }
                            }

                            pictureBox1.Refresh();


                            Clipboard.SetImage(pictureBox1.Image);


                        }



                    }

                }


                if (radioButton34.Checked)
                {

                    isDrawing = true;



                    if (isDrawing == true)
                    {



                        if (NextPoint >= 7)

                        {

                            using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                            {

                                graphics.SmoothingMode = SmoothingMode.AntiAlias;


                                SolidBrush BrushP = new SolidBrush((Color)toolStripComboBox2.SelectedItem);


                                PointF[] curvePoints =
                                {

                                        MD_1,
                                        MD_2,
                                        MD_3,
                                        MD_4,
                                        MD_5,
                                        MD_6,
                                        MD_7,

                                     };


                                GraphicsPath path = new GraphicsPath();


                                path.AddLines(curvePoints);


                                //   path.AddClosedCurve(curvePoints);


                                // No GraphicsPath object is created. The PathGradientBrush
                                // object is constructed directly from the array of points.
                                PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                                Color[] colors = {
      (Color)toolStripComboBox7.SelectedItem,
      (Color)toolStripComboBox8.SelectedItem,
      (Color)comboBox1.SelectedItem};




                                float[] relativePositions = {
       (float)numericUpDown1.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown2.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown3.Value};    // Blue is at the center point.

                                ColorBlend colorBlend = new ColorBlend
                                {
                                    Colors = colors,
                                    Positions = relativePositions
                                };
                                pthGrBrush.InterpolationColors = colorBlend;

                                // Fill a rectangle that is larger than the triangle
                                // specified in the Point array. The portion of the
                                // rectangle outside the triangle will not be painted.
                                graphics.FillPath(pthGrBrush, path);



                            }

                            if (controlPointsToolStripMenuItem.BackColor == Color.Green)
                            {

                                for (int i = 0; i < NextPoint; i++)
                                {
                                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                                    {
                                        graphics.SmoothingMode = SmoothingMode.AntiAlias;
                                        graphics.FillRectangle(Brushes.Transparent,
                                        m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);
                                        graphics.DrawRectangle(pen3,
                                             m_Points1[i].X - 1, m_Points1[i].Y - 1, 1, 1);


                                    }

                                }
                            }



                            pictureBox1.Refresh();

                            Clipboard.SetImage(pictureBox1.Image);

                        }


                    }



                }

                if (radioButton36.Checked)
                {


                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (x_MD_1 >= (e.X - x_MD_1)) return;

                        if (y_MD_1 >= (e.Y - y_MD_1)) return;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;




                            //   Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));


                            int x = x_MD_1;
                            int y = y_MD_1;
                            int width = e.X - x_MD_1;
                            int height = e.Y - y_MD_1;







                            int startAngle = (int)numericUpDown4.Value; // float
                            int sweepAngle = (int)numericUpDown5.Value; // float

                            // Draw arc to screen.
                            //    graphics.DrawArc(pen1, Rect, startAngle, sweepAngle);





                            // Draw arc to screen.
                            g.DrawPie(pen1, x, y, width, height, startAngle, sweepAngle);
                        }
                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }
                }

                if (radioButton37.Checked)
                {


                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (x_MD_1 >= (e.X - x_MD_1)) return;

                        if (y_MD_1 >= (e.Y - y_MD_1)) return;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;




                            //   Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));


                            int x = x_MD_1;
                            int y = y_MD_1;
                            int width = e.X - x_MD_1;
                            int height = e.Y - y_MD_1;







                            int startAngle = (int)numericUpDown4.Value; // float
                            int sweepAngle = (int)numericUpDown5.Value; // float

                            // Draw arc to screen.
                            //    graphics.DrawArc(pen1, Rect, startAngle, sweepAngle);





                            // Draw arc to screen.
                            g.FillPie(new SolidBrush((Color)toolStripComboBox2.SelectedItem), x, y, width, height, startAngle, sweepAngle);
                        }
                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }
                }

                if (radioButton38.Checked)
                {


                    isDrawing = true;

                    if (isDrawing == true)
                    {
                        if (x_MD_1 >= (e.X - x_MD_1)) return;

                        if (y_MD_1 >= (e.Y - y_MD_1)) return;


                        using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                        {
                            g.SmoothingMode = SmoothingMode.AntiAlias;




                            Rectangle Rect = new Rectangle(new Point(x_MD_1, y_MD_1), new Size(e.X - x_MD_1, e.Y - y_MD_1));

                            // Create start and sweep angles.
                            float startAngle = (float)numericUpDown4.Value;
                            float sweepAngle = (float)numericUpDown5.Value;

                            LinearGradientBrush GrBrush;


                            GrBrush = new LinearGradientBrush(Rect, (Color)toolStripComboBox7.SelectedItem, (Color)toolStripComboBox8.SelectedItem, (int)toolStripComboBox9.SelectedItem);



                            // Fill pie to screen.
                            graphics.FillPie(GrBrush, Rect, startAngle, sweepAngle);
                        }
                        Refresh();
                        Clipboard.SetImage(pictureBox1.Image);

                    }
                }


                if (radioButton39.Checked)

                {

                    Clipboard.SetImage(pictureBox1.Image);

                    isDrawing = false;

                }

                if (radioButton40.Checked)

                {
                    Clipboard.SetImage(pictureBox1.Image);

                    isDrawing = false;


                }
                if (radioButton44.Checked)
                {


                    isDrawing = true;


                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;





                        Pen ArrowPen = new Pen((Color)comboBox32.SelectedItem, (int)comboBox33.SelectedItem)
                        {

                            StartCap = (LineCap)comboBox28.SelectedItem,
                            EndCap = (LineCap)comboBox29.SelectedItem,
                            DashCap = (DashCap)comboBox30.SelectedItem,
                            DashStyle = (DashStyle)comboBox31.SelectedItem

                        };



                        graphics.DrawLine(ArrowPen, x_MD_1, y_MD_1, e.X, e.Y);

                    }

                    // Refresh.
                    pictureBox1.Refresh();

                    Clipboard.SetImage(pictureBox1.Image);

                }

                if (radioButton46.Checked)

                {

                    Clipboard.SetImage(pictureBox1.Image);

                    isDrawing = false;

                }


                if (radioButton47.Checked)

                {

                    Clipboard.SetImage(pictureBox1.Image);

                    isDrawing = false;

                }


            }

            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }







        #endregion
        // Option of menu and some +
        #region

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                ContrastBtmp = new Bitmap(pictureBox1.Image);



                if (saveFileDialog1.FileName.Contains(".jpeg")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                else
                      if (saveFileDialog1.FileName.Contains(".bmp")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                else
                       if (saveFileDialog1.FileName.Contains(".gif")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                else
                 if (saveFileDialog1.FileName.Contains(".tiff")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
                else
                   if (saveFileDialog1.FileName.Contains(".png")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Png);
                else
                {
                    MessageBox.Show("The file " + saveFileDialog1.FileName + " has an inappropriate extension. Returning.");
                    return;
                }
            }
            MessageBox.Show("The result image saved under " + saveFileDialog1.FileName);

        }

        private void PenColorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            try
            {
                ToolStripMenuItem PCL = sender as ToolStripMenuItem;
                colorDialog1.Color = PCL.BackColor;
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    PCL.BackColor = colorDialog1.Color;

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void PenColorToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {

            try
            {
                pen1.Color = penColorToolStripMenuItem.BackColor;
                penColorToolStripMenuItem.Invalidate();

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }




        private void ToolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                pen1.Width = toolStripComboBox1.SelectedIndex;



            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }


        private void ToolStripComboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                pen2.Width = toolStripComboBox1.SelectedIndex;
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void BackColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (colorDialog1.ShowDialog() == DialogResult.OK)
                    BackColor = colorDialog1.Color;
                pictureBox1.BackColor = BackColor;

                newToolStripMenuItem.PerformClick(); //because of new
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }




        private void InformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Inf = new Form2();
            Inf.Show();
        }

        private void AboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var AB = new AboutBox1();
            AB.Show();
        }




        private void AllScrineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {




                toolStrip1.Visible = false;
                menuStrip1.Visible = false;
                tabControl1.Visible = false;
                FormBorderStyle = FormBorderStyle.None;

                pictureBox1.Dock = DockStyle.Fill;


                // Form Form3 = new Form3();

                //  Form3.FormBorderStyle = FormBorderStyle.None;


            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AllScreenForMultGRToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                toolStrip1.Visible = false;
                menuStrip1.Visible = false;
                tabControl1.Visible = false;
                FormBorderStyle = FormBorderStyle.None;

                pictureBox1.Dock = DockStyle.Fill;

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        //save image to the graphic file, twoo click PictureBox, right button of the mouse 
        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (radioButton42.BackColor == Color.Green) return;

            try
            {

                if (e.Button == MouseButtons.Right)
                {

                    ContrastBtmp = new Bitmap(pictureBox1.Image);


                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {


                        if (saveFileDialog1.FileName.Contains(".jpeg")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                        else
                                 if (saveFileDialog1.FileName.Contains(".bmp")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Bmp);
                        else
                                  if (saveFileDialog1.FileName.Contains(".gif")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Gif);
                        else
                                 if (saveFileDialog1.FileName.Contains(".tiff")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Tiff);
                        else
                                  if (saveFileDialog1.FileName.Contains(".png")) ContrastBtmp.Save(saveFileDialog1.FileName, ImageFormat.Png);
                        else

                            MessageBox.Show("The result image saved under " + saveFileDialog1.FileName);

                        toolStrip1.Visible = true;
                        menuStrip1.Visible = true;
                        tabControl1.Visible = true;
                        FormBorderStyle = FormBorderStyle.Fixed3D;


                        //  Form3 Fr = new Form3();

                        //   Fr.FormBorderStyle = FormBorderStyle.Fixed3D;



                    }


                    toolStrip1.Visible = true;
                    menuStrip1.Visible = true;
                    tabControl1.Visible = true;
                    FormBorderStyle = FormBorderStyle.Fixed3D;





                    //    Form Form3 = new Form3();

                    //    Form3.FormBorderStyle = FormBorderStyle.Fixed3D;

                }

            }
            catch (Exception)
            {


                MessageBox.Show("The file " + saveFileDialog1.FileName + " has an inappropriate extension. Returning.");
                return;

            }


        }


        private void ToolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {

                tabControl1.Visible = false;
                toolStrip1.Visible = false;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void BackColorManyGrToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {

                isDrawing = true;



                if (isDrawing == true)
                {





                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {



                        MD_1_ = new Point(0, 0);
                        MD_2_ = new Point(pictureBox1.ClientSize.Width / 6, 0);
                        MD_3_ = new Point(pictureBox1.ClientSize.Width / 3, 0);


                        MD_4_ = new Point(pictureBox1.ClientSize.Width, 0);

                        MD_5_ = new Point(pictureBox1.ClientSize.Width, 388);



                        MD_6_ = new Point(pictureBox1.ClientSize.Width, 776);


                        MD_7_ = new Point(pictureBox1.ClientSize.Width / 6, 776);


                        MD_8_ = new Point(pictureBox1.ClientSize.Width / 3, 776);


                        MD_9_ = new Point(0, pictureBox1.ClientSize.Height);


                        MD_10_ = new Point(0, 338);


                        // Put the points of a polygon in an array.
                        PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                        // Use the array of points to construct a path.
                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(points);

                        // Use the path to construct a path gradient brush.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                        {

                            // Set the color at the center of the path to red.
                            CenterColor = (Color)comboBox5.SelectedItem
                        };


                        // Set the colors of the points in the array.
                        Color[] colors = {
                                    (Color)comboBox6.SelectedItem,
                                    (Color)comboBox7.SelectedItem,
                                    (Color)comboBox8.SelectedItem,
                                    (Color)comboBox9.SelectedItem,
                                    (Color)comboBox11.SelectedItem,
                                    (Color)comboBox20.SelectedItem,
                                    (Color)comboBox21.SelectedItem,
                                    (Color)comboBox22.SelectedItem,
                                    (Color)comboBox23.SelectedItem,
                                    (Color)comboBox24.SelectedItem};


                        pthGrBrush.SurroundColors = colors;

                        // Fill the path with the path gradient brush.
                        graphics.FillPath(pthGrBrush, path);

                        // Refresh.
                        pictureBox1.Refresh();
                    }

                    Clipboard.SetImage(pictureBox1.Image);

                }





            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void ImageForTextureBrushToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {



                    fullPath = Path.GetFullPath(openFileDialog1.FileName);


                }
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox1.Text.Length == 0) return;



            if (radioButton42.Checked)

            {

                if (e.Button == MouseButtons.Right)
                {
                    if (radioButton42.BackColor == Color.Green)
                    {

                        using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                        {


                            // Create font and brush.
                            Font drawFont = new Font((string)comboBox25.SelectedItem, (int)comboBox26.SelectedItem);


                            SolidBrush drawBrush = new SolidBrush((Color)comboBox27.SelectedItem);



                            // Set format of string.
                            StringFormat drawFormat = new StringFormat
                            {
                                FormatFlags = StringFormatFlags.DisplayFormatControl
                            };

                            // Draw string to screen.
                            graphics.DrawString(textBox1.Text, drawFont, drawBrush, e.X, e.Y, drawFormat);


                        }

                        pictureBox1.Refresh();

                    }

                }

            }

        }

        private void FuzzyBackColorMultGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fuzzyBackColorMultGrToolStripMenuItem.Text == "Fuzzy Mult Color Gr Start")
                {
                    fuzzyBackColorMultGrToolStripMenuItem.Text = "Fuzzy Mult Color Gr Stop";
                    timer2.Enabled = true;
                }
                else
                {
                    fuzzyBackColorMultGrToolStripMenuItem.Text = "Fuzzy Mult Color Gr Start";
                    timer2.Enabled = false;
                }
            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Timer2_Tick(object sender, EventArgs e)
        {

            try
            {

                isDrawing = true;



                if (isDrawing == true)
                {





                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {



                        MD_1_ = new Point(0, 0);
                        MD_2_ = new Point(pictureBox1.ClientSize.Width / 6, 0);
                        MD_3_ = new Point(pictureBox1.ClientSize.Width / 3, 0);


                        MD_4_ = new Point(pictureBox1.ClientSize.Width, 0);

                        MD_5_ = new Point(pictureBox1.ClientSize.Width, 388);



                        MD_6_ = new Point(pictureBox1.ClientSize.Width, 776);


                        MD_7_ = new Point(pictureBox1.ClientSize.Width / 6, 776);


                        MD_8_ = new Point(pictureBox1.ClientSize.Width / 3, 776);


                        MD_9_ = new Point(0, pictureBox1.ClientSize.Height);


                        MD_10_ = new Point(0, 338);


                        // Put the points of a polygon in an array.
                        PointF[] points = {
                                        MD_1_,
                                        MD_2_,
                                        MD_3_,
                                        MD_4_,
                                        MD_5_,
                                        MD_6_,
                                        MD_7_,
                                        MD_8_,
                                        MD_9_,
                                        MD_10_,};

                        // Use the array of points to construct a path.
                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(points);

                        // Use the path to construct a path gradient brush.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(path)
                        {

                            // Set the color at the center of the path to red.
                            CenterColor = Color.FromArgb(Random.Next(256), Random.Next(256), Random.Next(256))
                        };


                        // Set the colors of the points in the array.
                        Color[] colors = {
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256)),
                                    Color.FromArgb (Random.Next(256), Random.Next(256), Random.Next(256))};


                        pthGrBrush.SurroundColors = colors;

                        // Fill the path with the path gradient brush.
                        graphics.FillPath(pthGrBrush, path);

                        // Refresh.
                        pictureBox1.Refresh();
                    }

                    Clipboard.SetImage(pictureBox1.Image);

                }





            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }




        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                InputLanguage myCurrentLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));

                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));



            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                // Display numeric values.
                label7.Text = hScrollBar1.Value.ToString();
                label8.Text = hScrollBar2.Value.ToString();
                label9.Text = hScrollBar3.Value.ToString();

                // Display a sample.
                label10.BackColor = Color.FromArgb(
                    255,
                    hScrollBar1.Value,
                    hScrollBar2.Value,
                    hScrollBar3.Value);

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton48.Checked)
                {



                    using (graphics = Graphics.FromImage(pictureBox1.Image))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;


                        // X,Y of system, grid

                        O_x_pix = (float)numericUpDown11.Value;

                        O_y_pix = (float)numericUpDown12.Value;

                        //Width.Hieght of squares

                        M_x = (float)numericUpDown13.Value;

                        M_y = (float)numericUpDown14.Value;





                        float step_x = (x_max - x_min) / Npoints;

                        float y_min, y_max;

                        float x_max_abs = Math.Abs(x_max);
                        if (x_max_abs < Math.Abs(x_min)) x_max_abs = Math.Abs(x_min);
                        //Промежуточные локальные переменные:
                        float x_0, y_0, x_1, y_1;// x_0_pix, y_0_pix, x_1_pix, y_1_pix;
                                                 //Расчет минимального y_min и максимального y_max
                                                 //действительных значений функции:


                        //Присваиваем y_min, y_max значение y_0
                        //для нулевой точки (i=0):
                        x_0 = x_min; y_0 = Function_of_graph(x_0);
                        y_min = y_0; y_max = y_0; int i;


                        //Организовываем цикл по всем точкам, начиная с i=1:
                        for (i = 1; i <= (Npoints - 1); i++)
                        {
                            x_1 = x_min + i * step_x;
                            y_1 = Function_of_graph(x_1);
                            //Расчет минимального и максимального значений функции:
                            if (y_min > y_1) y_min = y_1;
                            if (y_max < y_1) y_max = y_1;
                        }
                        //Т.к. в последней точке i = Npoints
                        //значение x_1 = x_min + Npoints * step_x
                        //может отличаться от заданного значения x_max

                        //(из-за накапливания погрешности в цикле), то проверяем,
                        //может быть y_min или y_max находится в последней
                        //точке при точном задании нами значения x_max:
                        x_1 = x_max; y_1 = Function_of_graph(x_1);
                        //Проверка минимального и максимального
                        //значений функции в последней точке:
                        if (y_min > y_1) y_min = y_1;
                        if (y_max < y_1) y_max = y_1;
                        //Наибольшее абсолютное значение функции y_max_abs
                        //из двух значений y_min и y_max:
                        float y_max_abs = Math.Abs(y_max);
                        if (y_max_abs < Math.Abs(y_min)) y_max_abs = Math.Abs(y_min);




                        //Строим сетку координат:
                        //Сначала строим ось абсцисс "x" от x = -1 до x = 1:
                        //Задаем абсциссу последней точки оси абсцисс "x"
                        //при x = 1:
                        float x_point_end, x_point_end_pix; x_point_end = 1;
                        x_point_end_pix = x_point_end * M_x + O_x_pix;
                        //Выбираем зеленое перо толщиной 2:



                        Pen greenPen_x = new Pen((Color)comboBox35.SelectedItem, (float)numericUpDown15.Value);





                        //Задаем координаты двух граничных точек оси:
                        PointF point1 = new PointF(-1 * M_x + O_x_pix, O_y_pix);
                        PointF point2 = new PointF(x_point_end_pix, O_y_pix);
                        //Строим линию через две заданные граничные точки:


                        graphics.DrawLine(greenPen_x, point1, point2);
                        //Строим горизонтальные линии сетки координат
                        //(кроме оси "x"):
                        //Ширина (размах) графика по оси ординат "y":
                        float span_y = y_max - y_min;
                        //Число шагов по всей высоте сетки (по оси "y"):


                        int N_step_grid_y = (int)numericUpDown10.Value;



                        //Шаг сетки в направлении оси "y"
                        //(высота всей сетки равна 2 единицам):
                        float step_grid_y, step_grid_y_pix;
                        //Преобразование типов переменных:
                        step_grid_y = (float)2 / N_step_grid_y;
                        step_grid_y_pix = step_grid_y * M_y;
                        //Выбираем красное перо толщиной 1:


                        Pen redPen = new Pen((Color)comboBox36.SelectedItem, (float)numericUpDown16.Value);




                        //Строим сетку от нулевой линии в одну сторону (вниз):
                        int j_y; float y1, y1_pix;
                        for (j_y = 1; j_y <= (N_step_grid_y / 2); j_y++)
                        {
                            y1 = j_y * step_grid_y;
                            y1_pix = O_y_pix + j_y * step_grid_y_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point3 = new PointF(-1 * M_x + O_x_pix, y1_pix);
                            PointF point4 = new PointF(x_point_end_pix, y1_pix);
                            //Строим линию через две заданные граничные точки:

                            graphics.DrawLine(redPen, point3, point4);
                        }
                        //Строим сетку от нулевой линии в другую сторону (вверх):
                        for (j_y = 1; j_y <= (N_step_grid_y / 2); j_y++)
                        {
                            y1_pix = O_y_pix - j_y * step_grid_y * M_y;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point5 = new PointF(-1 * M_x + O_x_pix, y1_pix);
                            PointF point6 = new PointF(x_point_end_pix, y1_pix);
                            //Строим прямую линию через две заданные точки:
                            graphics.DrawLine(redPen, point5, point6);
                        }
                        //Строим ось ординат "y" от y= -1 до y = 1:
                        //Задаем ординату последней точки оси ординат "y" при y = 1:
                        float y_point_end, y_point_end_pix; y_point_end = 1;
                        y_point_end_pix = y_point_end * M_y + O_y_pix;
                        //Выбираем зеленое перо толщиной 2:


                        Pen greenPen_y = new Pen((Color)comboBox35.SelectedItem, (float)numericUpDown15.Value);




                        //Задаем координаты двух граничных точек оси:
                        PointF point7 = new PointF(O_x_pix, -1 * M_y + O_y_pix);
                        PointF point8 = new PointF(O_x_pix, y_point_end_pix);
                        //Строим линию через две заданные граничные точки:
                        graphics.DrawLine(greenPen_y, point7, point8);
                        //Строим вертикальные линии сетки координат (кроме оси "y"):

                        //Ширина (размах) графика по оси абсцисс "x":
                        float span_x = x_max - x_min;
                        //Число шагов по всей ширине сетки по обе стороны от оси y:


                        int N_step_grid_x = (int)numericUpDown10.Value;


                        //Шаг сетки в направлении оси "y"
                        //(высота всей сетки равна 2 единицам):
                        float step_grid_x, step_grid_x_pix;
                        //Преобразование типов переменных:
                        step_grid_x = (float)2 / N_step_grid_x;
                        step_grid_x_pix = step_grid_y * M_x;
                        //Выбираем красное перо толщиной 1:



                        //Шаг сетки в направлении оси "x"
                        //(ширина всей сетки равна 2 единицам):
                        //   float step_grid_x = 0.1F, step_grid_x_pix;
                        // step_grid_x_pix = step_grid_x * M_x;
                        //Выбираем красное перо толщиной 1:
                        Pen redPen_y = new Pen((Color)comboBox36.SelectedItem, (float)numericUpDown16.Value);
                        //Строим сетку от нулевой линии в одну сторону (вправо):
                        int j_x; float x1, x1_pix;
                        for (j_x = 1; j_x <= (N_step_grid_x / 2); j_x++)
                        {
                            x1 = j_x * step_grid_x;
                            x1_pix = O_x_pix + j_x * step_grid_x_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point9 = new PointF(x1_pix, -1 * M_y + O_y_pix);
                            PointF point10 = new PointF(x1_pix, y_point_end_pix);
                            //Строим линию через две заданные граничные точки:
                            graphics.DrawLine(greenPen_y, point9, point10);
                        }
                        //Строим сетку от нулевой линии в другую сторону (влево):
                        for (j_x = 1; j_x <= (N_step_grid_x / 2); j_x++)
                        {
                            x1 = j_x * step_grid_x;
                            x1_pix = O_x_pix - j_x * step_grid_x_pix;
                            //Задаем координаты двух граничных точек линии сетки:
                            PointF point11 = new PointF(x1_pix, -1 * M_y +
                            O_y_pix);
                            PointF point12 = new PointF(x1_pix, y_point_end_pix);
                            //Строим прямую линию через две заданные точки:
                            graphics.DrawLine(greenPen_y, point11, point12);
                        }

                    }

                    pictureBox1.Refresh();
                }

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }


        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // InputLanguage myDefaultLanguage = InputLanguage.DefaultInputLanguage;
                // InputLanguage.CurrentInputLanguage = myDefaultLanguage;

                InputLanguage myCurrentLanguage = InputLanguage.FromCulture(new CultureInfo("en-US"));

                InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ru-RU"));


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

    
        private void RadioButton42_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                radioButton42.BackColor = Color.Green;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void RadioButton41_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                radioButton42.BackColor = Color.White;

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void BackColorGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {

                    graphics.SmoothingMode = SmoothingMode.AntiAlias;


                    Rectangle Rect = new Rectangle(0, 0, pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);

                    LinearGradientBrush GrBrush;

                    using (GrBrush = new LinearGradientBrush(Rect, (Color)comboBox2.SelectedItem, (Color)comboBox3.SelectedItem, (int)numericUpDown6.Value))
                    {

                        graphics.FillRectangle(GrBrush, Rect);

                    }
                }
                pictureBox1.Refresh();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void BackColorManyGrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                isDrawing = true;

                if (isDrawing == true)
                {
                    using (Graphics graphics = Graphics.FromImage(pictureBox1.Image))
                    {


                        graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        _MD_1 = new Point(0, 53);
                        _MD_2 = new Point(pictureBox1.ClientSize.Width, 53);
                        _MD_3 = new Point(pictureBox1.ClientSize.Width, 776);
                        _MD_4 = new Point(0, pictureBox1.ClientSize.Height);

                        PointF[] curvePoints =
                            {
                                          _MD_1,
                                          _MD_2,
                                          _MD_3,
                                          _MD_4,

                                                  };



                        GraphicsPath path = new GraphicsPath();
                        path.AddLines(curvePoints);


                        // No GraphicsPath object is created. The PathGradientBrush
                        // object is constructed directly from the array of points.
                        PathGradientBrush pthGrBrush = new PathGradientBrush(curvePoints);

                        Color[] colors = {
      (Color)comboBox2.SelectedItem,
      (Color)comboBox3.SelectedItem,
      (Color)comboBox4.SelectedItem};




                        float[] relativePositions = {
       (float)numericUpDown9.Value,       // Dark green is at the boundary of the triangle.
       (float)numericUpDown8.Value,     // Aqua is 40 percent of the way from the boundary
                 // to the center point.
      (float)numericUpDown7.Value};    // Blue is at the center point.

                        ColorBlend colorBlend = new ColorBlend
                        {
                            Colors = colors,
                            Positions = relativePositions
                        };
                        pthGrBrush.InterpolationColors = colorBlend;

                        // Fill a rectangle that is larger than the triangle
                        // specified in the Point array. The portion of the
                        // rectangle outside the triangle will not be painted.
                        graphics.FillPath(pthGrBrush, path);



                    }




                    pictureBox1.Refresh();


                    Clipboard.SetImage(pictureBox1.Image);


                }






            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        private void ItemsControlVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                tabControl1.Visible = true;

                toolStrip1.Visible = true;
            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ColorControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                ToolStripMenuItem PCL = sender as ToolStripMenuItem;

                //  colorDialog1.Color = PCL.BackColor;
                //  if (colorDialog1.ShowDialog() == DialogResult.OK)
                //      PCL.BackColor = colorDialog1.Color;

                PCL.BackColor = (Color)toolStripComboBox8.SelectedItem;


            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        private void ColorControlToolStripMenuItem_BackColorChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem PCL = sender as ToolStripMenuItem;

                pen3.Color = PCL.BackColor;

                PCL.BackColor = (Color)toolStripComboBox8.SelectedItem;




            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }



        private void FileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                if (fileToolStripMenuItem.ForeColor == Color.Black)
                {
                    fileToolStripMenuItem.ForeColor = Color.White;
                }
                else
                {
                    fileToolStripMenuItem.ForeColor = Color.Black;
                }

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }





        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                if (editToolStripMenuItem.ForeColor == Color.Black)
                {
                    editToolStripMenuItem.ForeColor = Color.White;
                }
                else
                {
                    editToolStripMenuItem.ForeColor = Color.Black;
                }

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }




        }

        private void DecorToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                if (decorToolStripMenuItem.ForeColor == Color.Black)
                {
                    decorToolStripMenuItem.ForeColor = Color.White;
                }
                else
                {
                    decorToolStripMenuItem.ForeColor = Color.Black;
                }

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void FormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (formatToolStripMenuItem.ForeColor == Color.Black)
                {
                    formatToolStripMenuItem.ForeColor = Color.White;
                }
                else
                {
                    formatToolStripMenuItem.ForeColor = Color.Black;
                }

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void ServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (serviceToolStripMenuItem.ForeColor == Color.Black)
                {
                    serviceToolStripMenuItem.ForeColor = Color.White;
                }
                else
                {
                    serviceToolStripMenuItem.ForeColor = Color.Black;
                }


            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }










        //Past image from the ClipBoard
        private void PastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //startPt = nullPt;

                if (Clipboard.ContainsImage())

                {

                    if (pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();

                    Image bm1 = Clipboard.GetImage();
                    // Make an associated Graphics object.


                    graphics = Graphics.FromImage(bm1);


                    // Display the new bitmap in the PictureBox.
                    pictureBox1.Image = bm1;


                }

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                throw;
            }

        }
        //Copy image to the ClipBoard
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // if (Clipboard.ContainsImage())
                // {
                //   Clipboard.Clear();

                Clipboard.SetImage(pictureBox1.Image);
                // }
            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        //Save Screenshot to ClipBoard, two click PictureBox, left button of the mouse
        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("%{PRTSC}");

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }



        private void CopyScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SendKeys.Send("%{PRTSC}");

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }





        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //startPt = nullPt;

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string s = openFileDialog1.FileName;
                    try
                    {
                        Image bm1 = new Bitmap(s);
                        // Make an associated Graphics object.
                        graphics = Graphics.FromImage(bm1);


                        // Display the new bitmap in the PictureBox.
                        pictureBox1.Image = bm1;

                    }
                    catch
                    {
                        MessageBox.Show("File " + s + " has a wrong format.", "Error");
                        return;
                    }
                    Text = "DrawWithMousePB19 - " + s;

                    openFileDialog1.FileName = "";
                }

            }
            catch (Exception Исключение)
            {
                // Отчет о других ошибках:
                MessageBox.Show(Исключение.Message, "ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void ControlPointsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            controlPointsToolStripMenuItem.BackColor = Color.Green;
        }

        private void ControlPointsRelaxToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            controlPointsToolStripMenuItem.BackColor = Color.Red;
        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                Close();

            }
            catch (Exception Exclamation)
            {
                // Report about auther mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


            if (graphics != null)
            {
                ((IDisposable)graphics).Dispose();
            }

        }

        #endregion

   

        private void CopyFromScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    graphics.CopyFromScreen(new Point((int)numericUpDown17.Value, (int)numericUpDown18.Value),
                    new Point((int)numericUpDown19.Value, (int)numericUpDown20.Value), new Size((int)numericUpDown21.Value, (int)numericUpDown22.Value));
                }

                pictureBox1.Refresh();

            }
            catch (Exception Exclamation)
            {
                // Report about others mistakes:
                MessageBox.Show(Exclamation.Message, "Mistake",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



        }

        private void CopyFromScreenMixColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {

                if (radioButton50.Checked == true)
                {
                    using (Graphics g = Graphics.FromImage(pictureBox1.Image))
                    {
                        graphics.SmoothingMode = SmoothingMode.AntiAlias;

                        graphics.CopyFromScreen(new Point((int)numericUpDown17.Value, (int)numericUpDown18.Value), new Point((int)numericUpDown19.Value, (int)numericUpDown20.Value),
                         new Size((int)numericUpDown21.Value, (int)numericUpDown22.Value), CopyPixelOperation.MergePaint);
                    }

                    pictureBox1.Refresh();
                }
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
