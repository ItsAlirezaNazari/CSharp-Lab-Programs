namespace tictactoe
{
    public partial class Form1 : Form
    {
        Button[,] Buttons;
        int ply;

        public Form1()
        {
            InitializeComponent();

            Buttons = new Button[3, 3];

            biuld();

            new_game();
        }

        private void biuld()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Buttons[i, j] = new Button();
                    Buttons[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    Buttons[i, j].Font = new Font("Microsoft Sans Serif", 20);
                    Buttons[i, j].Click += new EventHandler(button_Click);
                    tableLayoutPanel1.Controls.Add(Buttons[i, j], i, j);
                }
            }
        }

        private void button_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                Button btn = (Button)sender;

                if (btn.Text == "")
                {
                    if (ply == 1)
                    {
                        btn.Text = "X";
                        btn.ForeColor = Color.DarkGreen;
                        btn.BackColor = Color.LightGreen;
                        ply = 2;
                    }
                    else
                    {
                        btn.Text = "O";
                        btn.ForeColor = Color.Red;
                        btn.BackColor = Color.Pink;
                        ply = 1;
                    }

                    check_game();
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            new_game();
        }

        private void new_game()
        {
            ply = 1;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Buttons[i, j].Text = "";
                    Buttons[i, j].BackColor = Color.White;
                }
            }
        }
        private void check_game()
        {
            string symbol = "";
            int full_btns_count = 0;

            if (Buttons[0, 0].Text == Buttons[1, 1].Text && Buttons[1, 1].Text == Buttons[2, 2].Text)
            {
                symbol = Buttons[0, 0].Text;
            }
            else if (Buttons[0, 2].Text == Buttons[1, 1].Text && Buttons[1, 1].Text == Buttons[2, 0].Text)
            {
                symbol = Buttons[0, 2].Text;
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (Buttons[i, 0].Text == Buttons[i, 1].Text && 
                        Buttons[i, 1].Text == Buttons[i, 2].Text &&
                        Buttons[i, 0].Text != "" && 
                        Buttons[i, 1].Text != "" && 
                        Buttons[i, 2].Text != "")
                    {
                        symbol = Buttons[i, 0].Text;
                        break;
                    }
                    else if (Buttons[0, i].Text == Buttons[1, i].Text && 
                             Buttons[1, i].Text == Buttons[2, i].Text &&
                             Buttons[0, i].Text != "" &&
                             Buttons[1, i].Text != "" &&
                             Buttons[2, i].Text != "")
                    {
                        symbol = Buttons[0, i].Text;
                        break;
                    }
                }
            }
            
            if (symbol == "")
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Buttons[i, j].Text != "")
                        {
                            full_btns_count++;
                        }
                    }
                }

                if (full_btns_count == 9)
                {
                    MessageBox.Show("Player 1 == Player 2");
                    new_game();
                }
            }
            else if (symbol == "X")
            {
                MessageBox.Show("Player 1 Wins");
                new_game();
            }
            else if (symbol == "O")
            {
                MessageBox.Show("Player 2 Wins");
                new_game();
            }
        }

        /*
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.AliceBlue;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.White;
        }
        */
    }
}