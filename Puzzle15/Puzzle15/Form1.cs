namespace Puzzle15
{
    public partial class Form1 : Form
    {
        Random r;
        Button[,] cell;
        int empty_x, empty_y;

        private void button16_Click(object sender, EventArgs e)
        {
            int x = 0, y = 0;
            Button this_button = (Button)sender;
            
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cell[i, j] == this_button)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            // بررسی شرط همسایگی
            if (x == empty_x && (y == empty_y - 1 || y == empty_y + 1) ||  // left or right
                y == empty_y && (x == empty_x - 1 || x == empty_x + 1) )   // top or bottom
            {
                cell[empty_x, empty_y].Text = this_button.Text;
                this_button.Text = "16";

                cell[empty_x, empty_y].Show();
                this_button.Hide();

                empty_x = x;
                empty_y = y;

                check_to_win();
            }

        }

        public Form1()
        {
            InitializeComponent();

            cell = new Button[4, 4] { { button1, button2, button3, button4 },
                                      { button5, button6, button7, button8 },
                                      { button9, button10, button11, button12 },
                                      { button13, button14, button15, button16 } };

            // Random Unique Numbers
            r = new Random();
            int[] temp = new int[16];
            int n;

            for (int i = 0; i < 16; i++)
            {
                do
                {
                    n = r.Next(1, 17);
                } while (temp.Contains(n));

                temp[i] = n;
            }
            // end

            int index = 0;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (temp[index] == 16)
                    {
                        cell[i, j].Hide();
                        empty_x = i;
                        empty_y = j;
                    }
                    cell[i, j].Text = Convert.ToString(temp[index++]);
                    cell[i, j].Font = new Font("Arial", 24);
                }
            }

        }

        private void check_to_win()
        {
            int index = 1, match_count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (cell[i, j].Text != Convert.ToString(index++))
                    {
                        return;
                    }
                    else
                    {
                        match_count++;
                    }
                }
            }

            if (match_count == 16)
            {
                MessageBox.Show("You Win");
            }
        }
    }
}