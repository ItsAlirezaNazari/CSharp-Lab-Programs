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
                    game_board[i, j].Text = "2";
                    game_board[i, j].Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    game_board[i, j].Font = new Font("verdana", 24, FontStyle.Bold);
                    game_board[i, j].BackColor = Color.FromArgb(238, 228, 218);
                    game_board[i, j].ForeColor = Color.FromArgb(119, 110, 101);
                    var margin = game_board[i, j].Margin;
                    margin.All = 4;
                    game_board[i, j].Margin = margin;
                    game_board[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    
                    tableLayoutPanel1.Controls.Add(game_board[i, j], i, j);
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up)
            {

            }
            else if (e.KeyData == Keys.Down)
            {

            }
            else if (e.KeyData == Keys.Right)
            {

            }
            else if (e.KeyData == Keys.Left)
            {

            }
        }
    }
}