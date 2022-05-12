namespace _2048
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        public Form1()
        {
            InitializeComponent();

            game_board = new Label[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    game_board[i, j] = new Label();
                    // game_board[i, j].Text = "2";
                    game_board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    game_board[i, j].Font = new Font("verdana", 24, FontStyle.Bold);
                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 180);
                    game_board[i, j].ForeColor = Color.FromArgb(119, 110, 101);
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin = margin;
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    
                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                }
            }

            Random r = new Random();
            int r1, r2, r1_x, r1_y, r2_x, r2_y, random_index;
            int[] int_numbers = { 2, 2, 2, 2, 4 };

            random_index = r.Next(0, int_numbers.Length);
            r1 = int_numbers[random_index];

            random_index = r.Next(0, int_numbers.Length);
            r2 = int_numbers[random_index];

            r1_x = r.Next(0, 3);
            r1_y = r.Next(0, 3);

            do
            {
                r2_x = r.Next(0, 3);
                r2_y = r.Next(0, 3);
            } while(r1_x == r2_x && r1_y == r2_y);

            // Write Text to Labels
            game_board[r1_x, r1_y].Text = Convert.ToString(r1);
            game_board[r1_x, r1_y].BackColor = Color.FromArgb(238, 228, 218);

            game_board[r2_x, r2_y].Text = Convert.ToString(r2);
            game_board[r2_x, r2_y].BackColor = Color.FromArgb(238, 228, 218);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (j > 0 && game_board[i, j - 1].Text == "")
                                {
                                    game_board[i, j - 1].Text = game_board[i, j].Text;
                                    game_board[i, j - 1].BackColor = game_board[i, j].BackColor;

                                    game_board[i, j].Text = "";
                                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 180);
                                }
                            }
                        }
                    }
                    break;

                case Keys.Down:
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (j < 3 && game_board[i, j + 1].Text == "")
                                {
                                    game_board[i, j + 1].Text = game_board[i, j].Text;
                                    game_board[i, j + 1].BackColor = game_board[i, j].BackColor;

                                    game_board[i, j].Text = "";
                                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 180);
                                }
                            }
                        }
                    }
                    break;

                case Keys.Left:
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (i > 0 && game_board[i - 1, j].Text == "")
                                {
                                    game_board[i - 1, j].Text = game_board[i, j].Text;
                                    game_board[i - 1, j].BackColor = game_board[i, j].BackColor;

                                    game_board[i, j].Text = "";
                                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 180);
                                }
                            }
                        }
                    }
                    break;

                case Keys.Right:
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                if (i < 3 && game_board[i + 1, j].Text == "")
                                {
                                    game_board[i + 1, j].Text = game_board[i, j].Text;
                                    game_board[i + 1, j].BackColor = game_board[i, j].BackColor;

                                    game_board[i, j].Text = "";
                                    game_board[i, j].BackColor = Color.FromArgb(205, 193, 180);
                                }
                            }
                        }
                    }
                    break;


            }




        }
    }
}