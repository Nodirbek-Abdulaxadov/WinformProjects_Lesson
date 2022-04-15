namespace TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Turn turn = Turn.Player1;
        byte turnCounter = 0;
        bool GameOver = false;

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick(sender);
            CheckWinner();
            if (turnCounter == 9 && !GameOver)
            {
                MessageBox.Show("Draw 😐!");
            }
        }

        private void CheckWinner()
        {
            turnCounter++;
            if ( button1.Text == button2.Text && button2.Text == button3.Text && button1.Text != "" ||
                 button4.Text == button5.Text && button5.Text == button6.Text && button4.Text != "" ||
                 button7.Text == button8.Text && button8.Text == button9.Text && button7.Text != "" ||
                 button1.Text == button4.Text && button4.Text == button7.Text && button7.Text != "" ||
                 button2.Text == button5.Text && button5.Text == button8.Text && button8.Text != "" ||
                 button3.Text == button6.Text && button6.Text == button9.Text && button9.Text != "" ||
                 button1.Text == button5.Text && button5.Text == button9.Text && button9.Text != "" ||
                 button3.Text == button5.Text && button5.Text == button7.Text && button7.Text != "")
            {
                if (turn == Turn.Player1)
                {
                    MessageBox.Show(Turn.Player2.ToString() + " win 🥳!");
                }
                else
                {
                    MessageBox.Show(Turn.Player1.ToString() + " win 🥳!");
                }
                GameOver = true;
            }
        }

        private void ButtonClick(object sender)
        {
            Button button = (Button)sender;

            if (turn == Turn.Player1)
            {
                button.Text = "X";
                button.Enabled = false;
                xod.Text = "O";
                turn = Turn.Player2;
            }
            else
            {
                button.Text = "O";
                button.Enabled = false;
                xod.Text = "X";
                turn = Turn.Player1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            button1.Text = button2.Text = button3.Text = button4.Text = "";
            button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = "";

            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = true;
            button5.Enabled = button6.Enabled = button7.Enabled = button8.Enabled = button9.Enabled = true;

            xod.Text = "X";
            turn = Turn.Player1;
            turnCounter = 0;
            GameOver = false;
        }
    }

    enum Turn
    {
        Player1,
        Player2
    }
}