﻿using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace HonzaCalc
{
    public partial class Form1 : Form
    {
        float FirstNumber;
        string Operation;
        float Result;

        public Form1()
        {
            InitializeComponent(); // Action after code start
            richTextBox1.Text = "0"; // Set up default value on calc display
            /*richTextBox1.Enabled = false;*/// Turn off typing to calc display
            textBox1.Enabled = false;

            richTextBox1.Select(); // Select calc display to typing after start
            richTextBox1.SelectAll();
        }
        void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("-"))
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1); // Remove minus [ - ] from display to easy convert
                textBox1.Text = richTextBox1.Text + " -";// Display 
                minus_Click(sender, e); // Simulate click minus button
            }

            if (richTextBox1.Text.Contains("+"))
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1); // Remove plus [ + ] from display to easy convert 
                textBox1.Text = richTextBox1.Text + " +";// Display 
                plus_Click(sender, e); // Simulate click plus button
            }

            if (richTextBox1.Text.Contains("/"))
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1); // Remove divided [ / ] from display to easy convert 
                textBox1.Text = richTextBox1.Text + " /";// Display
                divided_Click(sender, e);  // Simulate click divided button
            }

            if (richTextBox1.Text.Contains("*"))
            {
                richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1); // Remove multiply [ * ] from display to easy convert 
                textBox1.Text = richTextBox1.Text + " *";
                multiply_Click(sender, e);
            }
        }

        void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13) // If press enter
            {
                equals_Click(sender, e); // Simulate equals [ = ] button 
            }
            /*
            for (int i = 64; i < 91; i++)
            {
                if (Convert.ToInt32(e.KeyChar) == i)
                {
                    richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1);
                }
            }
            */
        }


        //int[] allowedKeys =
        // {
        //           13,
        //           96,
        //           97,
        //           98,
        //           99,
        //           100,
        //           101,
        //           102,
        //           103,
        //           104,
        //           105,
        //           106,
        //           107,
        //           109,
        //           110,
        //           111,
        //           144,
        //       };
        Keys[] allowedKeys =
       {
        Keys.Return,
        Keys.D0,
        Keys.NumPad1,
        Keys.NumPad2,
        Keys.NumPad3,
        Keys.NumPad4,
        Keys.NumPad5,
        Keys.NumPad6,
        Keys.NumPad7,
        Keys.NumPad8,
        Keys.NumPad9,
        Keys.Multiply,
        Keys.Add,
        Keys.Subtract,
        Keys.Decimal,
        Keys.Divide,
        Keys.NumLock,
        Keys.Back,
        Keys.Return,
        Keys.ShiftKey,
        Keys.ControlKey,
        Keys.ShiftKey,
         };

        void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // --------NUMERIC-KEYBOARD--------
            // KeyValue 13 ... Enter
            // KeyValue 96 ... 0
            // KeyValue 97 ... 1
            // KeyValue 98 ... 2
            // KeyValue 99 ... 3
            // KeyValue 100 ... 4
            // KeyValue 101 ... 5
            // KeyValue 102 ... 6
            // KeyValue 103 ... 7
            // KeyValue 104 ... 8
            // KeyValue 105 ... 9
            // KeyValue 106 ... Multiply [ * ]
            // KeyValue 107 ... Add [ + ]
            // KeyValue 109 ... Subtract [ - ]
            // KeyValue 110 ... Decimal [ , ]
            // KeyValue 111 ... Divide [ / ]
            // KeyValue 144 ... NumLock

            // ------------KEYBOARD------------
            // KeyValue 8 ... Backspace
            // KeyValue 13 ... Enter
            // KeyValue 16 ... Shift
            // KeyValue 17 ... Control
            // KeyValue 48 ... D0
            // KeyValue 49 ... D1
            // KeyValue 50 ... D2
            // KeyValue 51 ... D3
            // KeyValue 52 ... D4
            // KeyValue 53 ... D5
            // KeyValue 54 ... D6
            // KeyValue 55 ... D7
            // KeyValue 56 ... D8
            // KeyValue 57 ... D9
            // KeyValue 65 ... A
            // KeyValue 67 ... C
            // KeyValue 86 ... V
            // KeyValue 88 ... X
            // KeyValue 188 ... Oemcomma [ , ]
            // KeyValue 189 ... OemMinus [ - ]

            /*
            if (!(e.KeyValue >= 96 && e.KeyValue <= 111 || e.KeyValue == 13 || e.KeyValue == 144 || e.KeyValue == 189 || e.KeyValue == 188 || e.KeyValue == 8 || e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers == Keys.Shift || e.KeyValue == 65 && e.Modifiers == Keys.Control || e.KeyValue == 88 && e.Modifiers == Keys.Control || e.KeyValue == 67 && e.Modifiers == Keys.Control || e.KeyValue == 86 && e.Modifiers == Keys.Control))
            {
                e.SuppressKeyPress = true; // Supress NON numeric and others keys
            }*/

            //int pos = Array.IndexOf(allowedKeys, e.KeyCode);
            if (allowedKeys.Contains(e.KeyCode) == false)
                e.SuppressKeyPress = true;
            else if (!(
                e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9 && e.Modifiers == Keys.Shift ||
                e.KeyCode == Keys.A && e.Modifiers == Keys.Control ||
                e.KeyCode == Keys.C && e.Modifiers == Keys.Control ||
                e.KeyCode == Keys.V && e.Modifiers == Keys.Control ||
                e.KeyCode == Keys.X && e.Modifiers == Keys.Control))
                e.SuppressKeyPress = true;
        }

        // ------------NUMBERS------------
        // button10_Click ... 0
        // button1_Click ... 1
        // button2_Click ... 2
        // button3_Click ... 3
        // button4_Click ... 4
        // button5_Click ... 5
        // button6_Click ... 6
        // button7_Click ... 7
        // button8_Click ... 8
        // button9_Click ... 9

        void button10_Click(object sender, EventArgs e)
        {
            button10.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "0"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "0"; // Add to value number 0
            }
        }

        void button1_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "1"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "1"; // Add to value number 1
            }
        }

        void button2_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "2"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "2"; // Add to value number 2
            }
        }

        void button3_Click(object sender, EventArgs e)
        {
            button3.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "3"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "3"; // Add to value number 3
            }
        }

        void button4_Click(object sender, EventArgs e)
        {
            button4.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "4"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "4"; // Add to value number 4
            }
        }

        void button5_Click(object sender, EventArgs e)
        {
            button5.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "5"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "5"; // Add to value number 5
            }
        }

        void button6_Click(object sender, EventArgs e)
        {
            button6.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "6"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "6"; // Add to value number 6
            }
        }

        void button7_Click(object sender, EventArgs e)
        {
            button7.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "7"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "7"; // Add to value number 7
            }
        }

        void button8_Click(object sender, EventArgs e)
        {
            button8.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "8"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "8"; // Add to value number 8
            }
        }

        void button9_Click(object sender, EventArgs e)
        {
            button9.ForeColor = Color.DarkRed;

            if (richTextBox1.Text == "0")
            {
                richTextBox1.Text = "9"; // Replace default value
            }
            else
            {
                richTextBox1.Text += "9"; // Add to value number 9
            }
        }

        // ------------OPERATION------------
        // plus_Click ... plus [ + ]
        // minus_Click ... minus [ - ]
        // divided_Click ... divided [ + ]
        // multiply_Click ... multiply [ * ]
        // button12_Click ... pow [ x² ]
        // button14_Click ... [ 1/x ]
        // button16_Click ... sqrt [ √x ]
        //

        void plus_Click(object sender, EventArgs e)
        {
            plus.ForeColor = Color.DarkRed;
            FirstNumber = float.Parse(richTextBox1.Text); // Save value from display
            textBox1.Text = richTextBox1.Text + " +"; // Display operation in second display
            richTextBox1.Text = "0"; // Set up default value
            richTextBox1.SelectAll();
            Operation = "+"; // Save operation [ + ]
        }

        void minus_Click(object sender, EventArgs e)
        {
            if (!(richTextBox1.Text.StartsWith("-")))
            {
                plus.ForeColor = Color.DarkRed;
                FirstNumber = float.Parse(richTextBox1.Text); // Save value from display
                textBox1.Text = richTextBox1.Text + " -"; // Display operation in second display
                richTextBox1.Text = "0"; // Set up default value
                richTextBox1.SelectAll();
                Operation = "-"; // Save operation [ - ]
            }
        }

        void divided_Click(object sender, EventArgs e)
        {
            divided.ForeColor = Color.DarkRed;
            FirstNumber = float.Parse(richTextBox1.Text); // Save value from display
            textBox1.Text = richTextBox1.Text + " /"; // Display operation in second display
            richTextBox1.Text = "0"; // Set up default value
            richTextBox1.SelectAll();
            Operation = "/"; // Save operation [ / ]
        }

        void multiply_Click(object sender, EventArgs e)
        {
            multiply.ForeColor = Color.DarkRed;
            FirstNumber = float.Parse(richTextBox1.Text); // Save value from display
            textBox1.Text = richTextBox1.Text + " *"; // Display operation in second display
            richTextBox1.Text = "0"; // Set up default value
            richTextBox1.SelectAll();
            Operation = "*"; // Save operation [ * ]
        }

        void button12_Click(object sender, EventArgs e)
        {
            var pow = double.Parse(richTextBox1.Text); // Save value from display
            var powResult = Math.Pow(pow, 2); // Math operation 
            textBox1.Text = pow.ToString() + "²" + " = "; // Display operation in second display
            richTextBox1.Text = powResult.ToString(); // Display result
        }

        void button14_Click(object sender, EventArgs e)
        {
            var idk = double.Parse(richTextBox1.Text); // Save value from display

            if (idk == 0)
            {
                richTextBox1.Text = "Nulou nelze dělit"; // Can't divide zero
                richTextBox1.Select();
                richTextBox1.SelectAll();
            }
            else
            {
                var idkResult = 1 / (idk);
                textBox1.Text = "1/" + idk.ToString() + " = "; // Display operation in second display
                richTextBox1.Text = idkResult.ToString(); // Display result
            }
        }

        void button16_Click(object sender, EventArgs e)
        {
            var sqrt = double.Parse(richTextBox1.Text); // Save value from display
            var sqrtResult = Math.Sqrt(sqrt); // Math operation
            textBox1.Text = "√" + sqrt.ToString() + " = "; // Display operation in second display
            richTextBox1.Text = sqrtResult.ToString(); // Display result
        }

        // ------------EQUALS------------

        void equals_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text.Contains("-"))
            {
                richTextBox1.Text = richTextBox1.Text.Replace("-", ""); // Replace minus to easy convert
            }

            float secondNumber = 0;

            if (secondNumber > 0 || secondNumber < 0)
            {
                Operation = "";
                richTextBox1.Clear(); // Clear display
                richTextBox1.Text = "0"; // Set up default value
                textBox1.Clear(); // Clear secondary display
                richTextBox1.Select();
                richTextBox1.SelectAll();
            }
            else
            {
                secondNumber = float.Parse(richTextBox1.Text);  // Save value from display

                if (Operation == "+")
                {
                    Result = (FirstNumber + secondNumber); // Math operation
                    richTextBox1.Text = Result.ToString(); // Display result
                }

                if (Operation == "-")
                {
                    Result = (FirstNumber - secondNumber); // Math operation
                    richTextBox1.Text = Result.ToString(); // Display result
                }

                if (Operation == "/")
                {
                    if (secondNumber == 0)
                    {
                        richTextBox1.Text = "Nulou nelze dělit"; // Can't divide zero
                        richTextBox1.Select();
                        richTextBox1.SelectAll();
                    }
                    else
                    {
                        Result = (FirstNumber / secondNumber); // Math operation
                        richTextBox1.Text = Result.ToString(); // Display result
                    }
                }

                if (Operation == "*")
                {
                    Result = (FirstNumber * secondNumber); // Math operation
                    richTextBox1.Text = Result.ToString(); // Display result
                }

                textBox1.Text += " " + secondNumber + " = "; // Display operation in second display
            }
        }

        // ------------REMOVE------------
        // ce_Click ... All
        // backspace_Click ... One char
        void ce_Click(object sender, EventArgs e)
        {
            Operation = "";
            richTextBox1.Clear(); // Clear display
            richTextBox1.Text = "0"; // Set up default value
            textBox1.Clear(); // Clear secondary display
            richTextBox1.Select();
            richTextBox1.SelectAll();
        }

        void backspace_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = richTextBox1.Text.Remove(richTextBox1.Text.Length - 1); // Remove last char
        }

        // ------------LINK------------
        // http://www.itzhonzah.social/

        void ItzHonzaH_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.itzhonzah.social/"); // Open link in primary web browser
        }

        // ------------OTHERS------------
        // button11_Click ... [ , ]
        // button13_Click ... momentarily without function
        void button11_Click(object sender, EventArgs e) => richTextBox1.Text += ",";

        void button13_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            /*
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            f2 = null;
            this.Show();
            */

        }
    }
}
// ------------TO-DO-LIST------------
// Počítání během zadávání čísel
// Užití metod
// Historie počítání
// Oprava výběru při startu ... line 24
// Funkce double clicku 