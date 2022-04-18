using System.Data;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            buttons_Click(sender);
        }
        //buttons click
        public void buttons_Click(object sender)
        {
            Button button = (Button)sender;
            if (!(ekran.Text == button.Text && button.Text == "0"))
            {
                if (ekran.Text == "0" && button.Text != ".")
                {
                    ekran.Clear();
                }

                if (!(button.Text == "." && ekran.Text.EndsWith(".")) && EndChar(ekran.Text, button.Text))
                {
                     ekran.Text += button.Text;
                }
            }
        }
        //AC button click
        private void button18_Click(object sender, EventArgs e)
        {
            ekran.Text = "0";
        }

        //C button click
        private void button17_Click(object sender, EventArgs e)
        {
            if (ekran.Text.Length > 1)
            {
                ekran.Text = ekran.Text.Substring(0, ekran.Text.Length - 1);
            }
            else
            {
                ekran.Text = "0";
            }
        }

        //compute all
        DataTable data = new DataTable();
        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                ekran.Text = data.Compute(ekran.Text, null).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        private bool EndChar(string etext,string btext)
        {
            if (etext.Length > 1)
            {
                switch (etext[etext.Length - 1])
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '.': return IsChar(btext);
                }
            }

            return true;
        }

        private bool IsChar(string btext)
        {
            switch (btext)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case ".": return false;
                default: return true;
            }
        }
    }
}