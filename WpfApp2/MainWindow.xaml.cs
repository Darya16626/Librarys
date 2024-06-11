using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FunctionalLib;
using SerializationLibrary;


namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        private char currentPlayer = 'X';
        private bool gameOver = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!gameOver)
            {
                Button button = (Button)sender;
                int index = grid.Children.IndexOf(button);
                if (board[index] == ' ')
                {
                    button.Content = currentPlayer;
                    board[index] = currentPlayer;

                    if (CheckWin())
                    {
                        gameOver = true;
                        resultText.Text = currentPlayer + " Конец!";
                    }
                    else if (!board.Contains(' '))
                    {
                        gameOver = true;
                        resultText.Text = "It's a draw!";
                    }
                    else
                    {
                        currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
                        if (currentPlayer == 'O')
                        {
                            MakeRobotMove();
                        }
                    }
                }
            }
        }

        private void MakeRobotMove()
        {
            Random random = new Random();
            int index = random.Next(0, 9);
            while (board[index] != ' ')
            {
                index = random.Next(0, 9);
            }

            Button button = (Button)grid.Children[index];
            button.Content = currentPlayer;
            board[index] = currentPlayer;

            if (CheckWin())
            {
                gameOver = true;
                resultText.Text = currentPlayer + " wins!";
            }
            else if (!board.Contains(' '))
            {
                gameOver = true;
                resultText.Text = "Ничья!";
            }
            else
            {
                currentPlayer = currentPlayer == 'X' ? 'O' : 'X';
            }
        }

        private bool CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i * 3] != ' ' && board[i * 3] == board[i * 3 + 1] && board[i * 3] == board[i * 3 + 2])
                {
                    return true;
                }
                if (board[i] != ' ' && board[i] == board[i + 3] && board[i] == board[i + 6])
                {
                    return true;
                }
            }
            if (board[0] != ' ' && board[0] == board[4] && board[0] == board[8])
            {
                return true;
            }
            if (board[2] != ' ' && board[2] == board[4] && board[2] == board[6])
            {
                return true;
            }

            return false;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            board = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
            currentPlayer = 'X';
            gameOver = false;
            resultText.Text = "";
            foreach (Button btn in grid.Children)
            {
                btn.Content = "";
            }
        }
    }
}