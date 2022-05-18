namespace _2048
{
    public partial class Form1 : Form
    {
        Label[,] game_board;
        Color defaultBackColor = Color.FromArgb(205, 193, 180);
        Color defaultForeColor = Color.FromArgb(119, 110, 101);
        bool move, is_finished = false;
        
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
                    game_board[i, j].ForeColor = defaultForeColor;
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin = margin;
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    
                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                }
            }

            add_random_label();
            add_random_label();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (! is_finished)
            {
                move = false;

                switch (e.KeyCode)
                {
                    case Keys.Up:
                        move_up();
                        break;

                    case Keys.Down:
                        move_down();
                        break;

                    case Keys.Left:
                        move_left();
                        break;

                    case Keys.Right:
                        move_right();
                        break;
                }

                if (move)
                    add_random_label();

                check();
            }

        }

        private void move_up()
        {
            bool[,] combined = {
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false }
            };

            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (j > 0 && game_board[i, j].Text != "")
                        {
                            if (game_board[i, j - 1].Text == "")
                            {
                                move = true;
                                game_board[i, j - 1].Text = game_board[i, j].Text;
                                game_board[i, j - 1].BackColor = game_board[i, j].BackColor;
                                game_board[i, j - 1].ForeColor = game_board[i, j].ForeColor;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                            else if (game_board[i, j - 1].Text == game_board[i, j].Text && !combined[i, j - 1] && !combined[i, j])
                            {
                                move = true;
                                combined[i, j - 1] = true;
                                game_board[i, j - 1].Text = Convert.ToString(Convert.ToInt16(game_board[i, j - 1].Text) * 2);
                                game_board[i, j - 1].BackColor = get_my_back_color(Convert.ToInt32(game_board[i, j - 1].Text));
                                if (Convert.ToInt32(game_board[i, j - 1].Text) > 4)
                                    game_board[i, j - 1].ForeColor = Color.White;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                        }
                    }
                }
            }
        }

        private void move_down()
        {
            bool[,] combined = {
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false }
            };


            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        if (j < 3 && game_board[i, j].Text != "")
                        {
                            if (game_board[i, j + 1].Text == "")
                            {
                                move = true;
                                game_board[i, j + 1].Text = game_board[i, j].Text;
                                game_board[i, j + 1].BackColor = game_board[i, j].BackColor;
                                game_board[i, j + 1].ForeColor = game_board[i, j].ForeColor;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                            else if (game_board[i, j + 1].Text == game_board[i, j].Text && !combined[i, j + 1] && !combined[i, j])
                            {
                                move = true;
                                combined[i, j + 1] = true;
                                game_board[i, j + 1].Text = Convert.ToString(Convert.ToInt16(game_board[i, j + 1].Text) * 2);
                                game_board[i, j + 1].BackColor = get_my_back_color(Convert.ToInt32(game_board[i, j + 1].Text));
                                if (Convert.ToInt32(game_board[i, j + 1].Text) > 4)
                                    game_board[i, j + 1].ForeColor = Color.White;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                        }
                    }
                }
            }
        }

        private void move_left()
        {
            bool[,] combined = {
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false }
            };


            for (int k = 0; k < 3; k++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i > 0 && game_board[i, j].Text != "")
                        {
                            if (game_board[i - 1, j].Text == "")
                            {
                                move = true;
                                game_board[i - 1, j].Text = game_board[i, j].Text;
                                game_board[i - 1, j].BackColor = game_board[i, j].BackColor;
                                game_board[i - 1, j].ForeColor = game_board[i, j].ForeColor;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                            else if (game_board[i - 1, j].Text == game_board[i, j].Text && !combined[i - 1, j] && !combined[i, j])
                            {
                                move = true;
                                combined[i - 1, j] = true;
                                game_board[i - 1, j].Text = Convert.ToString(Convert.ToInt16(game_board[i - 1, j].Text) * 2);
                                game_board[i - 1, j].BackColor = get_my_back_color(Convert.ToInt32(game_board[i - 1, j].Text));
                                if (Convert.ToInt32(game_board[i - 1, j].Text) > 4)
                                    game_board[i - 1, j].ForeColor = Color.White;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                        }
                    }
                }
            }
        }

        private void move_right()
        {
            bool[,] combined = {
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false },
                { false, false, false, false }
            };


            for (int k = 0; k < 3; k++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (i < 3 && game_board[i, j].Text != "")
                        {
                            if (game_board[i + 1, j].Text == "")
                            {
                                move = true;
                                game_board[i + 1, j].Text = game_board[i, j].Text;
                                game_board[i + 1, j].BackColor = game_board[i, j].BackColor;
                                game_board[i + 1, j].ForeColor = game_board[i, j].ForeColor;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                            else if (game_board[i + 1, j].Text == game_board[i, j].Text && !combined[i + 1, j] && !combined[i, j])
                            {
                                move = true;
                                combined[i + 1, j] = true;
                                game_board[i + 1, j].Text = Convert.ToString(Convert.ToInt16(game_board[i + 1, j].Text) * 2);
                                game_board[i + 1, j].BackColor = get_my_back_color(Convert.ToInt32(game_board[i + 1, j].Text));
                                if (Convert.ToInt32(game_board[i + 1, j].Text) > 4)
                                    game_board[i + 1, j].ForeColor = Color.White;

                                game_board[i, j].Text = "";
                                game_board[i, j].BackColor = defaultBackColor;
                                game_board[i, j].ForeColor = defaultForeColor;
                            }
                        }
                    }
                }
            }
        }

        private Color get_my_back_color(int num)
        {
            Color BackColor2 = Color.FromArgb(238, 228, 218);
            Color BackColor4 = Color.FromArgb(237, 224, 200);
            Color BackColor8 = Color.FromArgb(242, 177, 121);
            Color BackColor16 = Color.FromArgb(245, 149, 99);
            Color BackColor32 = Color.FromArgb(246, 124, 95);
            Color BackColor64 = Color.FromArgb(246, 94, 59);
            Color BackColor128 = Color.FromArgb(237, 207, 114);
            Color BackColor256 = Color.FromArgb(237, 204, 97);
            Color BackColor512 = Color.FromArgb(235, 200, 80);
            Color BackColor1024 = Color.FromArgb(236, 197, 62);
            Color BackColor2048 = Color.FromArgb(237, 194, 46);

            if (num == 2)
                return BackColor2;
            else if (num == 4)
                return BackColor4;
            else if (num == 8)
                return BackColor8;
            else if (num == 16)
                return BackColor16;
            else if (num == 32)
                return BackColor32;
            else if (num == 64)
                return BackColor64;
            else if (num == 128)
                return BackColor128;
            else if (num == 256)
                return BackColor256;
            else if (num == 512)
                return BackColor512;
            else if (num == 1024)
                return BackColor1024;
            else
                return BackColor2048;
        }

        private bool exist_empty_label()
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

        private void add_random_label()
        {
            if (!exist_empty_label())
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
            game_board[r_x, r_y].BackColor = get_my_back_color(Convert.ToInt32(game_board[r_x, r_y].Text));
            game_board[r_x, r_y].ForeColor = defaultForeColor;
        }

        private void check()
        {
            bool exist_empty_label = false, exist_combinable_labels = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (game_board[i, j].Text == "2048")
                    {
                        is_finished = true;
                        result_label.Text = "You Win";
                        result_label.Visible = true;
                        reset_btn.Visible = true;
                        return;
                    }
                    else if (game_board[i, j].Text == "")
                    {
                        exist_empty_label = true;
                    }
                    else if ( (i != 3 && j != 3 && (game_board[i, j].Text == game_board[i + 1, j].Text || game_board[i, j].Text == game_board[i, j + 1].Text)) ||
                              (i != 3 && j == 3 && game_board[i, j].Text == game_board[i + 1, j].Text) ||
                              (i == 3 && j != 3 && game_board[i, j].Text == game_board[i, j + 1].Text) )
                    {
                        exist_combinable_labels = true;
                    }
                }
            }

            if (!exist_empty_label && !exist_combinable_labels)
            {
                is_finished = true;
                result_label.Text = "Game Over";
                result_label.Visible = true;
                reset_btn.Visible = true;
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            result_label.Visible = false;
            reset_btn.Visible = false;
            is_finished = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    game_board[i, j].Text = "";
                    game_board[i, j].BackColor = defaultBackColor;
                }
            }

            add_random_label();
            add_random_label();
        }
    }
}
