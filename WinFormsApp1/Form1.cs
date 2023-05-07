using ShapeDLL;
using System.Windows.Forms;
using System.Drawing;
using System.Security.Policy;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }

        string laturi = "laturi.txt";
        string arii = "arii.txt";
        private void Cerc_Click(object sender, EventArgs e)
        {
            double radius = double.Parse(razaTextBox.Text);
            
            Circle circle = new Circle(radius);
            double area = circle.CalculateArea();
            MessageBox.Show($"Aria cercului este: {area}");

            using (StreamWriter writer = new StreamWriter(laturi, true)) 
            {
                writer.WriteLine($"Raza cercului este: {radius}");
            }

            using (StreamWriter writer = new StreamWriter(arii, true)) 
            {
                writer.WriteLine($"Aria cercului este: {area}");
            }


            // Desenarea cercului în panoul de desenare
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            g.DrawEllipse(p, 10, 10, (float)radius * 2, (float)radius * 2);

        }

        

        private void Dreptunghi_Click(object sender, EventArgs e)
        {
            double width = double.Parse(latimeTextBox.Text);
            double height = double.Parse(lungimeTextBox.Text);
            ShapeDLL.Rectangle rectangle = new ShapeDLL.Rectangle(width, height);
            double area = rectangle.CalculateArea();
            MessageBox.Show($"Aria dreptunghiului este: {area}");

            using (StreamWriter writer = new StreamWriter(laturi, true))
            {
                writer.WriteLine($"Laturile dreptunghiului sunt: {width}, {height}");
            }

            using (StreamWriter writer = new StreamWriter(arii, true))
            {
                writer.WriteLine($"Aria dreptunghiului este: {area}");
            }

            // Desenarea dreptunghiului în panoul de desenare
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, 10, 10, (float)width, (float)height);

        }

      
        private void Patrat_Click(object sender, EventArgs e)
        {
            double side = double.Parse(laturaTextBox.Text);
            Square square = new Square(side);
            double area = square.CalculateArea();
            MessageBox.Show($"Aria patratului este: {area}");

            using (StreamWriter writer = new StreamWriter(laturi, true))
            {
                writer.WriteLine($"Latura patratului este: {side}");
            }

            using (StreamWriter writer = new StreamWriter(arii, true))
            {
                writer.WriteLine($"Aria patratului este: {area}");
            }

            //  Desenarea patratului în panoul de desenare
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Red, 2);
            g.DrawRectangle(p, 10, 10, (float)side, (float)side);

        }

        private void Triunghi_Click(object sender, EventArgs e)
        {
           
            double sideA = double.Parse(latura1TextBox.Text);
            double sideB = double.Parse(latura2TextBox.Text);
            double sideC = double.Parse(latura3TextBox.Text);

           
            if (sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA)
            {
                // Determinam tipu triunghiului
                if (sideA == sideB && sideB == sideC)
                {
                    // Triunghiul este echilateral
                    double area = Math.Sqrt(3) / 4 * sideA * sideA;
                    MessageBox.Show($"Aria triunghiului echilateral este: {area}");

                    using (StreamWriter writer = new StreamWriter(laturi, true))
                    {
                        writer.WriteLine($"Laturie triunghiului echilateral este: {sideA}, {sideB}, {sideC}");
                    }

                    using (StreamWriter writer = new StreamWriter(arii, true))
                    {
                        writer.WriteLine($"Aria triunghiului echilateral este: {area}");
                    }

                    // Adaugă cod pentru desenarea triunghiului în panoul de desenare
                    Graphics g = panel1.CreateGraphics();
                    Pen p = new Pen(Color.Blue, 2);

                    // Calculează coordonatele punctelor triunghiului
                    PointF pointA = new PointF(10, 10);
                    PointF pointB = new PointF(10 + (float)sideB, 10);
                    float angleC = (float)Math.Acos((sideA * sideA + sideB * sideB - sideC * sideC) / (2 * sideA * sideB));
                    PointF pointC = new PointF(10 + (float)(sideA * Math.Cos(angleC)), 10 + (float)(sideA * Math.Sin(angleC)));

                    // Desenează triunghiul
                    g.DrawLine(p, pointA, pointB);
                    g.DrawLine(p, pointB, pointC);
                    g.DrawLine(p, pointC, pointA);
                }
                else if (sideA == sideB || sideA == sideC || sideB == sideC)
                {
                    // Triunghiul este isoscel
                    double baseSide = sideA == sideB ? sideC : (sideA == sideC ? sideB : sideA);
                    double height = Math.Sqrt(sideA * sideA - baseSide * baseSide / 4);
                    double area = baseSide * height / 2;
                    MessageBox.Show($"Aria triunghiului isoscel este: {area}");

                    using (StreamWriter writer = new StreamWriter(laturi, true))
                    {
                        writer.WriteLine($"Laturie triunghiului isoscel este: {sideA}, {sideB}, {sideC}");
                    }

                    using (StreamWriter writer = new StreamWriter(arii, true))
                    {
                        writer.WriteLine($"Aria triunghiului isoscel este: {area}");
                    }

                    // Adaugă cod pentru desenarea triunghiului în panoul de desenare
                    Graphics g = panel1.CreateGraphics();
                    Pen p = new Pen(Color.Blue, 2);

                    // Calculează coordonatele punctelor triunghiului
                    PointF pointA = new PointF(10, 10);
                    PointF pointB = new PointF(10 + (float)sideB, 10);
                    float angleC = (float)Math.Acos((sideA * sideA + sideB * sideB - sideC * sideC) / (2 * sideA * sideB));
                    PointF pointC = new PointF(10 + (float)(sideA * Math.Cos(angleC)), 10 + (float)(sideA * Math.Sin(angleC)));

                    // Desenează triunghiul
                    g.DrawLine(p, pointA, pointB);
                    g.DrawLine(p, pointB, pointC);
                    g.DrawLine(p, pointC, pointA);
                }
                else
                {
                    // Triunghiul este oarecare
                    double s = (sideA + sideB + sideC) / 2;
                    double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
                    MessageBox.Show($"Aria triunghiului oarecare este: {area}");

                    using (StreamWriter writer = new StreamWriter(laturi, true))
                    {
                        writer.WriteLine($"Laturie triunghiului oarecare este: {sideA}, {sideB}, {sideC}");
                    }

                    using (StreamWriter writer = new StreamWriter(arii, true))
                    {
                        writer.WriteLine($"Aria triunghiului oarecare este: {area}");
                    }

                    // Adaugă cod pentru desenarea triunghiului în panoul de desenare
                    Graphics g = panel1.CreateGraphics();
                    Pen p = new Pen(Color.Blue, 2);

                    // Calculează coordonatele punctelor triunghiului
                    PointF pointA = new PointF(10, 10);
                    PointF pointB = new PointF(10 + (float)sideB, 10);
                    float angleC = (float)Math.Acos((sideA * sideA + sideB * sideB - sideC * sideC) / (2 * sideA * sideB));
                    PointF pointC = new PointF(10 + (float)(sideA * Math.Cos(angleC)), 10 + (float)(sideA * Math.Sin(angleC)));

                    // Desenează triunghiul
                    g.DrawLine(p, pointA, pointB);
                    g.DrawLine(p, pointB, pointC);
                    g.DrawLine(p, pointC, pointA);
                }
            }
            else
            {
                MessageBox.Show("Input invalid.");
            }
        }

        private void ResetarePanel_Click(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }
    }
}