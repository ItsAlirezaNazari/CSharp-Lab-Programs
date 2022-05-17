namespace _2048
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        bool move;
        Color defaultBackColor = Color.FromArgb(205, 193, 180);

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
                    game_board[i, j].BackColor = defaultBackColor;
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

            r1_x = r.Next(0, 4);
            r1_y = r.Next(0, 4);

            do
            {
                r2_x = r.Next(0, 4);
                r2_y = r.Next(0, 4);
            } while(r1_x == r2_x && r1_y == r2_y);

            // Write Text to Labels
            game_board[r1_x, r1_y].Text = Convert.ToString(r1);
            game_board[r1_x, r1_y].BackColor = Color.FromArgb(238, 228, 218);

            game_board[r2_x, r2_y].Text = Convert.ToString(r2);
            game_board[r2_x, r2_y].BackColor = Color.FromArgb(238, 228, 218);


        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            move = false;
            Func<int, int, bool> AGreaterThanB = (a, b) => a > b;
            Func<int, int, bool> BGreaterThanA = (a, b) => a < b;

            switch (e.KeyCode)
            {
                case Keys.Up:
                    move_labels("up", 0, 0, -1, AGreaterThanB);
                    break;

                case Keys.Down:
                    move_labels("down", 3, 0, 1, BGreaterThanA);
                    break;

                case Keys.Left:
                    move_labels("left", 0, -1, 0, AGreaterThanB);
                    break;

                case Keys.Right:
                    move_labels("right", 3, 1, 0, BGreaterThanA);
                    break;
            }

            if (move)
                new_label_in_random_place();
        }

        private unsafe void move_labels(string dir, int b, int i_plus_num, int j_plus_num, Func<int, int, bool> op)
        {
            // Initialize
            int* a;
            int k, i, j;

            if (dir == "up" || dir == "down")
                a = &j;
            else
                a = &i;
            

            for (k = 0; k < 3; k++)
            {
                for (i = 0; i < 4; i++)
                {
                    for (j = 0; j < 4; j++)
                    {
                        if (op(*a, b) && game_board[i + i_plus_num, j + j_plus_num].Text == "" && game_board[i, j].Text != "")
                        {
                            move = true;
                            game_board[i + i_plus_num, j + j_plus_num].Text = game_board[i, j].Text;
                            game_board[i + i_plus_num, j + j_plus_num].BackColor = game_board[i, j].BackColor;

                            game_board[i, j].Text = "";
                            game_board[i, j].BackColor = defaultBackColor;
                        }
                    }
                }
            }
        }

        private unsafe void sum_same_labels(string dir, int b, int i_plus_num, int j_plus_num, Func<int, int, bool> op)
        {
            // Initialize
            int* a;
            int i, j;

            if (dir == "up" || dir == "down")
                a = &j;
            else
                a = &i;


            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (op(*a, b) && game_board[i + i_plus_num, j + j_plus_num].Text != "" && game_board[i, j].Text != "" && game_board[i + i_plus_num, j + j_plus_num].Text == game_board[i, j].Text)
                    {
                        move = true;
                        game_board[i + i_plus_num, j + j_plus_num].Text = Convert.ToString(Convert.ToInt32(game_board[i, j].Text) * 2);
                        game_board[i, j].Text = "";
                        game_board[i, j].BackColor = defaultBackColor;
                    }
                }
            }
        }

        private void new_label_in_random_place()
        {
            if (! exist_empty_place())
                return;

            Random rand = new Random();
            int r, r_x, r_y, random_index;
            int[] int_numbers = { 2, 2, 2, 2, 4 };

            random_index = rand.Next(0, int_numbers.Length);
            r = int_numbers[random_index];

            do
            {
                r_x = rand.Next(0, 4);
                r_y = rand.Next(0, 4);
            } while (game_board[r_x, r_y].Text != "");

            // Write Text to Labels
            game_board[r_x, r_y].Text = Convert.ToString(r);
            game_board[r_x, r_y].BackColor = Color.FromArgb(238, 228, 218);
        }

        private bool exist_empty_place()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (game_board[i, j].Text == "")
                        return true;
                }
            }

            return false;
        }

    }
}
