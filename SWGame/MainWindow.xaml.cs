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


namespace SWGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        
        Character player1;
        Character player2;

        int turnNr;
        string description = "";

        public MainWindow()
        {
            InitializeComponent();
            descriptionBox.Text = "";
            player1Attack.Visibility = Visibility.Hidden;
            player2Attack.Visibility = Visibility.Hidden;
            player1Spell.Visibility = Visibility.Hidden;
            player2Spell.Visibility = Visibility.Hidden;
            endTurnButton.Visibility = Visibility.Hidden;




            List<Character> chars = new List<Character>()
            {
                new Sith("Kylo Ren",20,30,100,false,10),
                new Jedi("Anakin Skywalker", 30, 25, 100,false, 10),
                new Jedi("Obi-Wan Kenobi", 30, 25, 100, false,10),
            };

            listBoxOfCharacters.ItemsSource = chars;


           





        }

        private void player1Attack_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr == 1 && player1.Turn == true)
            {
                description += player1.Attack_Move().ToString();
                player1.Turn = false;
                WinCondition();
                
                
            }
            else MessageBox.Show("Wykonałeś swój ruch zakończ turę");
            
        }

        private void player1Spell_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr==1&& player1.Turn == true)
            {
                description += player1.Force();
                player1.Turn = false;
                WinCondition();
               
            }
            else MessageBox.Show("Wykonałeś swój ruch zakończ turę");
        }
        private void player2Attack_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr==2 && player2.Turn == true)
            {
                description += player2.Attack_Move();
                player2.Turn = false;
                WinCondition();
                
            }
            else MessageBox.Show("Wykonałeś swój ruch zakończ turę");


        }

        private void player2Spell_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr== 2 && player2.Turn == true)
            {
                description += player2.Force();
                player2.Turn = false;
                WinCondition();
                
            }
            else MessageBox.Show("Wykonałeś swój ruch zakończ turę");
        }

        private void UpdateLabels()
        {
            descriptionBox.Text = description;
            Labeltest.Content = turnNr;
            
           
        }

        private void player1Character_Click(object sender, RoutedEventArgs e)
        {
            
            
            player1 = (Character)listBoxOfCharacters.SelectedItem;
            
            player1Name.Content = player1.Name;



        }

        private void player2Character_Click(object sender, RoutedEventArgs e)
        {
            player2 = (Character)listBoxOfCharacters.SelectedItem;
            
            player2Name.Content = player2.Name;
            
        }
        private void RestartGame()
        {
            player1Attack.Visibility = Visibility.Hidden;
            player2Attack.Visibility = Visibility.Hidden;
            player1Spell.Visibility = Visibility.Hidden;
            player2Spell.Visibility = Visibility.Hidden;
            playButton.Visibility = Visibility.Visible;

            player1Name.Content = "";
            player2Name.Content = "";

            player1 = null;
            player2 = null;
            descriptionBox.Text = "";
        }
        private void WinCondition()
        {
            if (player1.HP <= 0)
            {
                MessageBox.Show("Wygrał " + player2.Name);
                RestartGame();
            }
            else if (player2.HP <= 0)
            {
                MessageBox.Show("Wygrał " + player1.Name);
                RestartGame();
            }
            UpdateLabels();

        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            player2.opponent = player1;
            player1.opponent = player2;

            player1Attack.Visibility = Visibility.Visible;
            player2Attack.Visibility = Visibility.Visible;
            player1Spell.Visibility = Visibility.Visible;
            player2Spell.Visibility = Visibility.Visible;
            playButton.Visibility = Visibility.Hidden;
            endTurnButton.Visibility = Visibility.Visible;
            turnNr = 1;
            player1.Turn = true;

            UpdateLabels();
        }

        private void endTurnButton_Click(object sender, RoutedEventArgs e)
        {
            if(turnNr==1)
            {
                turnNr = 2;
                description += "TURA " + player2.Name + "\n";
                UpdateLabels();
                player2.Turn = true;
            }
            else if(turnNr == 2)
            {
                turnNr = 1;
                description += "TURA " + player1.Name + "\n";
                UpdateLabels();
                player1.Turn = true;
            }


        }
    }
}
