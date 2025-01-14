using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp6
{
    
    public partial class MainWindow : Window
    {
        private Random random;

        private int balance; 
        private const int BetAmount = 10;
        private const int JackpotReward = 50;
        public MainWindow()
             
        {
            InitializeComponent();
            random = new Random();
            balance = 100; 
            UpdateBalanceDisplay();
        }
        private void RollButton_Click(object sender, RoutedEventArgs e)
        {
            if (balance < BetAmount)
            {
                ResultTextBlock.Text = "Недостаточно средств для ставки!";
                return;
            }
            int die1 = random.Next(1, 7); 
            int die2 = random.Next(1, 7); 
            int die3 = random.Next(1, 7);

            DieText1.Text = die1.ToString();
            DieText2.Text = die2.ToString();
            DieText3.Text = die3.ToString();
            
            int total = die1 + die2 + die3; 

            ResultTextBlock.Text = $"Сумма: {total}.";

            if (die1 == die2 && die2 == die3) 
            {
                balance += JackpotReward;
                ResultTextBlock.Text += $" Вы выиграли джекпот {JackpotReward} единиц за комбинацию {die1}!";
            }

            if (total >= 10) 
            {
                balance += BetAmount; 
                ResultTextBlock.Text += $" Вы выиграли {BetAmount} единиц!";
            }
            else 
            {
                balance -= BetAmount; 
                ResultTextBlock.Text += $" Вы проиграли {BetAmount} единиц.";
            }

            UpdateBalanceDisplay(); 
        }

        private void UpdateBalanceDisplay()
        {
            BalanceTextBlock.Text = $"Баланс: {balance} единиц";
        }
    }
}

