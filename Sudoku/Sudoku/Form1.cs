namespace Sudoku
{
    public partial class Form1 : Form
    {
        TextBox[,] cells;
        public Form1()
        {
            InitializeComponent();

            cells = new TextBox[9, 9];

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    cells[i, j] = new TextBox();
                    cells[i, j].Multiline = true;
                    cells[i, j].TextAlign = HorizontalAlignment.Center;
                    cells[i, j].Font = new Font("Arial", 20);
                    cells[i, j].Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
                    cells[i, j].MaxLength = 1;
                    cells[i, j].TextChanged += new EventHandler(text_box_changed);
                    cells[i, j].ReadOnlyChanged += new EventHandler(text_box_readonly_changed);

                    tableLayoutPanel1.Controls.Add(cells[i, j], i, j);
                }
            }

        }

        private void text_box_changed(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (! System.Text.RegularExpressions.Regex.IsMatch(tb.Text, "^[1-9]$"))
            {
                tb.Text = "";
            }
        }

        private void text_box_readonly_changed(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.BackColor = Color.FromArgb(255, 211, 101);
            //tb.BackColor = Color.FromArgb(255, 211, 45);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            if (x.ShowDialog() == DialogResult.OK)
            {
                string file_path = x.FileName;
                StreamReader my_file_reader = new StreamReader(file_path);
                string big_text = my_file_reader.ReadToEnd();
                char[] my_seperatores = { ' ', '\r' };
                big_text = big_text.Replace("\n", "");
                string[] numbers = big_text.Split(my_seperatores);

                int index = 0;
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9; j++)
                    {
                        cells[j, i].Text = "";
                        cells[j, i].ReadOnly = false;

                        if (numbers[index] != "0")
                        {
                            cells[j, i].Text = numbers[index];
                            cells[j, i].ReadOnly = true;
                        }

                        index++;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Test
            //MessageBox.Show(cells[0, 0].Text + cells[1, 0].Text + cells[2, 0].Text);
            //MessageBox.Show(cells[0, 1].Text + cells[1, 1].Text + cells[2, 1].Text);
            //MessageBox.Show(cells[0, 2].Text + cells[1, 2].Text + cells[2, 2].Text);
            //return;


            int[] row, col, square;
            int index;

            // Check Rows and Cols
            for (int i = 0; i < 9; i++)
            {
                row = new int[9];
                col = new int[9];

                for (int j = 0; j < 9; j++)
                {
                    if (cells[j, i].Text != "" && cells[i, j].Text != "")
                    {
                        int rowCell = Convert.ToInt16(cells[j, i].Text);
                        int colCell = Convert.ToInt16(cells[i, j].Text);

                        if (0 < rowCell && rowCell < 10 && !row.Contains(rowCell) &&
                            0 < colCell && colCell < 10 && !col.Contains(colCell))
                        {
                            row[j] = rowCell;
                            col[j] = colCell;
                            continue;
                        }
                    }

                    MessageBox.Show("Try More...");
                    return;
                }
            }
            // end


            // Check Squares
            for (int h = 1, s1 = 0, e1 = 3, s2 = 0, e2 = 3; h <= 9; h++, s2 += 3, e2 += 3)
            {
                if ((h - 1) % 3 == 0)
                {
                    s2 = 0;
                    e2 = 3;
                }

                square = new int[9];
                index = 0;

                for (int i = s1; i < e1; i++)
                {
                    for (int j = s2; j < e2; j++)
                    {
                        int cell = Convert.ToInt16(cells[j, i].Text);

                        if (!square.Contains(cell))
                        {
                            square[index++] = cell;
                            continue;
                        }

                        MessageBox.Show("Try More...");
                        return;
                    }
                }

                if (h % 3 == 0)
                {
                    s1 += 3;
                    e1 += 3;
                }
            }
            // end



            MessageBox.Show("It's True");
        }
    }


}