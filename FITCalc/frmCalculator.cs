namespace FITCalc
{
    /*
        Very scuffed and quickly put together calculator win forms app

        Todo:
            Scale the screen according to the number of digits for a better view
            Rewrite 'repeating code' in a more sensible manner
            Remake the UI into something more aesthetically pleasing
            Fix some minor bugs
    */

    public partial class frmCalculator : Form
    {
        public bool changed = false;
        public double memory = 0;
        public string operation;

        public frmCalculator()
        {
            InitializeComponent();
        }

        private void btnNum_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" && (sender as Button)?.Text == "0")
            {
                return;
            }

            //Causes bug with results that have a large number of digits
            //if (textBox1.Text.Length >= 16)
            //{
            //    return;
            //}

            if (!changed)
            {
                textBox1.Text = "";
                changed = true;
            }

            textBox1.Text += (sender as Button)?.Text;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            txtMemory.Text = "";
            memory = 0;
            changed = false;
        }

        private void btnDecimalPoint_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 16)
            {
                return;
            }
            if (textBox1.Text == "0")
            {
                changed = true;
            }
            if (!textBox1.Text.Contains("."))
                textBox1.Text += ".";
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double result))
            {
                if (result == 0)
                    return;
                textBox1.Text = (result * (-1)).ToString();
            }
            else
                return;
        }

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                if (textBox1.Text == "" || textBox1.Text == "-" || textBox1.Text == "-0")
                {
                    textBox1.Text = "0";
                    changed = false;
                }
            }
        }

        private void btnClearElement_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            changed = false;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double result))
            {
                if (result != 0)
                {
                    textBox1.Text = (result / 100).ToString();
                    changed = false;
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (operation != "/")
            {
                bool skip = true;
                double.TryParse(textBox1.Text, out double temp);
                switch (operation)
                {
                    case "-":
                        memory = memory - temp; break;
                    case "*":
                        memory = memory * temp; break;
                    case "+":
                        memory = memory + temp; break;
                    default:
                        skip = false; break;
                }
                txtMemory.Text = memory.ToString() + " ÷";
                operation = "/";
                changed = false;
                if (skip)
                    return;
            }
            if (memory == 0)
            {
                double.TryParse(textBox1.Text, out memory);
                txtMemory.Text = memory.ToString() + " ÷";
            }
            else
            {
                double.TryParse(textBox1.Text, out double temp);
                memory = memory / temp;
                txtMemory.Text = memory.ToString() + " ÷";
            }
            operation = "/";
            textBox1.Text = memory.ToString();
            changed = false;
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            if (operation != "*")
            {
                bool skip = true;
                double.TryParse(textBox1.Text, out double temp);
                switch (operation)
                {
                    case "-":
                        memory = memory - temp; break;
                    case "+":
                        memory = memory + temp; break;
                    case "/":
                        memory = memory / temp; break;
                    default:
                        skip = false; break;
                }
                txtMemory.Text = memory.ToString() + " *";
                operation = "*";
                changed = false;
                if (skip)
                    return;
            }
            if (memory == 0)
            {
                double.TryParse(textBox1.Text, out memory);
                txtMemory.Text = memory.ToString() + " *";
            }
            else
            {
                double.TryParse(textBox1.Text, out double temp);
                memory = memory * temp;
                txtMemory.Text = memory.ToString() + " *";
            }
            operation = "*";
            textBox1.Text = memory.ToString();
            changed = false;
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (operation != "-")
            {
                bool skip = true;
                double.TryParse(textBox1.Text, out double temp);
                switch (operation)
                {
                    case "+":
                        memory = memory + temp; break;
                    case "*":
                        memory = memory * temp; break;
                    case "/":
                        memory = memory / temp; break;
                    default:
                        skip = false; break;
                }
                txtMemory.Text = memory.ToString() + " -";
                operation = "-";
                changed = false;
                if (skip)
                    return;
            }
            if (memory == 0)
            {
                double.TryParse(textBox1.Text, out memory);
                txtMemory.Text = memory.ToString() + " -";
            }
            else
            {
                double.TryParse(textBox1.Text, out double temp);
                memory = memory - temp;
                txtMemory.Text = memory.ToString() + " -";
            }
            operation = "-";
            textBox1.Text = memory.ToString();
            changed = false;
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (operation != "+")
            {
                bool skip = true;
                double.TryParse(textBox1.Text, out double temp);
                switch (operation)
                {
                    case "-":
                        memory = memory - temp; break;
                    case "*":
                        memory = memory * temp; break;
                    case "/":
                        memory = memory / temp; break;
                    default:
                        skip = false; break;
                }
                txtMemory.Text = memory.ToString() + " +";
                operation = "+";
                changed = false;
                if (skip)
                    return;
            }
            if (memory == 0)
            {
                double.TryParse(textBox1.Text, out memory);
                txtMemory.Text = memory.ToString() + " +";
            }
            else
            {
                double.TryParse(textBox1.Text, out double temp);
                memory = memory + temp;
                txtMemory.Text = memory.ToString() + " +";
            }
            operation = "+";
            textBox1.Text = memory.ToString();
            changed = false;
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            double temp;
            switch (operation)
            {
                case "+":
                    double.TryParse(textBox1.Text, out temp);
                    txtMemory.Text = memory.ToString() + " + " + temp.ToString() + " =";
                    memory = memory + temp;
                    break;
                case "-":
                    double.TryParse(textBox1.Text, out temp);
                    txtMemory.Text = memory.ToString() + " - " + temp.ToString() + " =";
                    memory = memory - temp;
                    break;
                case "*":
                    double.TryParse(textBox1.Text, out temp);
                    txtMemory.Text = memory.ToString() + " * " + temp.ToString() + " =";
                    memory = memory * temp;
                    break;
                case "/":
                    double.TryParse(textBox1.Text, out temp);
                    txtMemory.Text = memory.ToString() + " ÷ " + temp.ToString() + " =";
                    memory = memory / temp;
                    break;
                default:
                    break;
            }
            textBox1.Text = memory.ToString();
            operation = "";
            memory = 0;
            changed = false;
        }
    }
}