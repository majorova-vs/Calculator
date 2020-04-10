using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum Operations
        {
            Sum,
            Sub,
            Mul,
            Div,
            None
        }

        Size originalFormSize;
        Dictionary<string, Size> originalElementsSize;
        Dictionary<string, Point> originalElementsLocations;

        double buffer;
        bool restart;
        Operations currentOp;

        public Form1()
        {
            InitializeComponent();

            buffer = 0;
            currentOp = Operations.None;
            restart = true;
            originalFormSize = this.Size;

            originalElementsSize = new Dictionary<string, Size>();
            originalElementsSize.Add("SmallButton", button1.Size);
            originalElementsSize.Add("LargeButton", button17.Size);
            originalElementsSize.Add("Label", label1.Size);

            originalElementsLocations = new Dictionary<string, Point>();
            originalElementsLocations.Add(button1.Name, button1.Location);
            originalElementsLocations.Add(button2.Name, button2.Location);
            originalElementsLocations.Add(button3.Name, button3.Location);
            originalElementsLocations.Add(button4.Name, button4.Location);
            originalElementsLocations.Add(button5.Name, button5.Location);
            originalElementsLocations.Add(button6.Name, button6.Location);
            originalElementsLocations.Add(button7.Name, button7.Location);
            originalElementsLocations.Add(button8.Name, button8.Location);
            originalElementsLocations.Add(button9.Name, button9.Location);
            originalElementsLocations.Add(button10.Name, button10.Location);
            originalElementsLocations.Add(button11.Name, button11.Location);
            originalElementsLocations.Add(button12.Name, button12.Location);
            originalElementsLocations.Add(button13.Name, button13.Location);
            originalElementsLocations.Add(button14.Name, button14.Location);
            originalElementsLocations.Add(button15.Name, button15.Location);
            originalElementsLocations.Add(button16.Name, button16.Location);
            originalElementsLocations.Add(button17.Name, button17.Location);
            originalElementsLocations.Add(label1.Name, label1.Location);
            originalElementsLocations.Add(label2.Name, label2.Location);

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Dictionary<string, Size> newElementsSize = new Dictionary<string, Size>();
            Dictionary<string, Point> newElementsLocations = new Dictionary<string, Point>();
    
            foreach(var loc in originalElementsLocations)
            {
                newElementsLocations.Add(loc.Key, new Point(Convert.ToInt32(Math.Round((float)(loc.Value.X * this.Size.Width / originalFormSize.Width))),
                    Convert.ToInt32(Math.Round((float)(loc.Value.Y * this.Size.Height / originalFormSize.Height)))));
            }

            button1.Location = newElementsLocations[button1.Name];
            button2.Location = newElementsLocations[button2.Name];
            button3.Location = newElementsLocations[button3.Name];
            button4.Location = newElementsLocations[button4.Name];
            button5.Location = newElementsLocations[button5.Name];
            button6.Location = newElementsLocations[button6.Name];
            button7.Location = newElementsLocations[button7.Name];
            button8.Location = newElementsLocations[button8.Name];
            button9.Location = newElementsLocations[button9.Name];
            button10.Location = newElementsLocations[button10.Name];
            button11.Location = newElementsLocations[button11.Name];
            button12.Location = newElementsLocations[button12.Name];
            button13.Location = newElementsLocations[button13.Name];
            button14.Location = newElementsLocations[button14.Name];
            button15.Location = newElementsLocations[button15.Name];
            button16.Location = newElementsLocations[button16.Name];
            button17.Location = newElementsLocations[button17.Name];
            label1.Location = newElementsLocations[label1.Name];
            label2.Location = newElementsLocations[label2.Name];

            foreach (var loc in originalElementsLocations)
            {
                if(loc.Key == button17.Name)
                {
                    newElementsSize.Add(loc.Key, new Size(Convert.ToInt32(Math.Round((float)(originalElementsSize["LargeButton"].Width * this.Size.Width / originalFormSize.Width))),
                       Convert.ToInt32(Math.Round((float)originalElementsSize["LargeButton"].Height * this.Size.Height / originalFormSize.Height))));

                }
                else if (loc.Key == label1.Name || loc.Key == label2.Name)
                {
                    newElementsSize.Add(loc.Key, new Size(Convert.ToInt32(Math.Round((float)(originalElementsSize["Label"].Width * this.Size.Width / originalFormSize.Width))),
                        Convert.ToInt32(Math.Round((float)originalElementsSize["Label"].Height * this.Size.Height / originalFormSize.Height))));
                }
                else
                {
                    newElementsSize.Add(loc.Key, new Size(Convert.ToInt32(Math.Round((float)(originalElementsSize["SmallButton"].Width * this.Size.Width / originalFormSize.Width))),
                        Convert.ToInt32(Math.Round((float)originalElementsSize["SmallButton"].Height * this.Size.Height / originalFormSize.Height))));
                }     
            }

            button1.Size = newElementsSize[button1.Name];
            button2.Size = newElementsSize[button2.Name];
            button3.Size = newElementsSize[button3.Name];
            button4.Size = newElementsSize[button4.Name];
            button5.Size = newElementsSize[button5.Name];
            button6.Size = newElementsSize[button6.Name];
            button7.Size = newElementsSize[button7.Name];
            button8.Size = newElementsSize[button8.Name];
            button9.Size = newElementsSize[button9.Name];
            button10.Size = newElementsSize[button10.Name];
            button11.Size = newElementsSize[button11.Name];
            button12.Size = newElementsSize[button12.Name];
            button13.Size = newElementsSize[button13.Name];
            button14.Size = newElementsSize[button14.Name];
            button15.Size = newElementsSize[button15.Name];
            button16.Size = newElementsSize[button16.Name];
            button17.Size = newElementsSize[button17.Name];
            label1.Size = newElementsSize[label1.Name];
            label2.Size = newElementsSize[label2.Name];
        }

        private void button_number_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (restart)
            {
                label1.Text = btn.Text.Substring(1);
                restart = false;
            }
            else
            {
                label1.Text = label1.Text + btn.Text.Substring(1);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            label1.Text = "0";
            buffer = 0;
            label2.Text = "";
            restart = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label1.Text.IndexOf('.') == -1)
            {
                label1.Text += ".";
                restart = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            currentOp = Operations.Sum;
            label2.Text += "+";

            if (buffer == 0)
            {
                buffer = Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }
            else
            {
                buffer += Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }

            label2.Text += " +";
            label1.Text = "0";
            restart = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(label1.Text != "-")
            {

                if (label1.Text == "0")
                {
                    label1.Text = "-";
                    restart = false;
                }
                else if (buffer == 0)
                {
                    currentOp = Operations.Sub;
                    buffer = Convert.ToDouble(label1.Text);
                    label2.Text = buffer.ToString() + " -";
                    Clipboard.SetText(buffer.ToString());
                    label1.Text = "0";
                    restart = true;
                }
                else
                {
                    buffer -= Convert.ToDouble(label1.Text);
                    label2.Text = buffer.ToString() + " -";
                    Clipboard.SetText(buffer.ToString());
                    label1.Text = "0";
                    restart = true;
                }   
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            currentOp = Operations.Mul;

            if (buffer == 0)
            {
                buffer = Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }
            else
            {
                buffer *= Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }

            label2.Text += " *";
            label1.Text = "0";
            restart = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            currentOp = Operations.Div;
            

            if (buffer == 0)
            {
                buffer = Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }
            else
            {
                buffer /= Convert.ToDouble(label1.Text);
                label2.Text = buffer.ToString();
                Clipboard.SetText(buffer.ToString());
            }

            label2.Text += " /";
            label1.Text = "0";
            restart = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            switch (currentOp)
            {
                case Operations.Sum:
                    buffer += Convert.ToDouble(label1.Text);
                    label1.Text = Math.Round(buffer, 5).ToString();
                    Clipboard.SetText(buffer.ToString());
                    buffer = 0;
                    label2.Text = "";
                    currentOp = Operations.None;
                    restart = true;
                    break;
                case Operations.Sub:
                    buffer -= Convert.ToDouble(label1.Text);
                    label1.Text = Math.Round(buffer, 5).ToString();
                    Clipboard.SetText(buffer.ToString());
                    buffer = 0;
                    label2.Text = "";
                    currentOp = Operations.None;
                    restart = true;
                    break;
                case Operations.Mul:
                    buffer *= Convert.ToDouble(label1.Text);
                    label1.Text = Math.Round(buffer, 5).ToString();
                    Clipboard.SetText(buffer.ToString());
                    buffer = 0;
                    label2.Text = "";
                    currentOp = Operations.None;
                    restart = true;
                    break;
                case Operations.Div:
                    if (Convert.ToDouble(label1.Text) == 0)
                    {
                        label1.Text = "На ноль делить нельзя";
                        label2.Text = "";
                        buffer = 0;
                        label2.Text = "";
                        currentOp = Operations.None;
                        restart = true;
                        break;

                    }
                    else
                    {
                        buffer /= Convert.ToDouble(label1.Text);
                        label1.Text = Math.Round(buffer, 5).ToString();
                        Clipboard.SetText(buffer.ToString());
                        buffer = 0;
                        label2.Text = "";
                        currentOp = Operations.None;
                        restart = true;
                        break;
                    }
            }
        }

        
    }
}
