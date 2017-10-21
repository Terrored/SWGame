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
using System.Windows.Interop;
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
            player1HP.Visibility = Visibility.Hidden;
            player2HP.Visibility = Visibility.Hidden;
            player1ProgressBarText.Visibility = Visibility.Hidden;
            player2ProgressBarText.Visibility = Visibility.Hidden;



            descriptionBox.Text = "Welcome! \n Choose yours characters and begin the fight! \n I hope You like it. " +
                "It 's my first project from the scratch using WPF and C# . \n \n\n\n ENJOY !";
          





             List <Character> chars = new List<Character>()
            {
                new Sith("Kylo Ren",20,30,100,false,new Uri("pack://application:,,,/Images/kylo.png", UriKind.Absolute),20),
                new Jedi("Anakin Skywalker", 30, 25, 100,false,new Uri("pack://application:,,,/Images/anakin.png",UriKind.Absolute), 10),
                //new Jedi("Obi-Wan Kenobi", 30, 25, 100, false,SWGame.Properties.Resources.kylo,50),
            };


            
            listBoxOfCharacters.ItemsSource = chars;


           





        }

        private void player1Attack_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr == 1 && player1.Turn == true)
            {
                description = player1.Attack_Move();
                player1.Turn = false;
                UpdateHPBar(player2HP, player2,player2ProgressBarText);
                WinCondition();
                
                
            }
            else MessageBox.Show("End turn !");
            
        }

        private void player1Spell_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr==1&& player1.Turn == true)
            {
                description = player1.Force();
                player1.Turn = false;
                UpdateHPBar(player2HP, player2,player1ProgressBarText);
                WinCondition();
               
            }
            else MessageBox.Show("End turn !");
        }
        private void player2Attack_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr==2 && player2.Turn == true)
            {
                description = player2.Attack_Move();
                player2.Turn = false;
                
                UpdateHPBar(player1HP, player1,player1ProgressBarText);
                WinCondition();
                
            }
            else MessageBox.Show("End turn !");


        }

        private void player2Spell_Click(object sender, RoutedEventArgs e)
        {
            if (turnNr== 2 && player2.Turn == true)
            {
                description = player2.Force();
                player2.Turn = false;
                UpdateHPBar(player1HP, player1,player1ProgressBarText);
                WinCondition();
                
            }
            else MessageBox.Show("End turn !");
        }

        private void UpdateLabels()
        {
            
            descriptionBox.AppendText(description);
            descriptionBox.SelectionStart = descriptionBox.Text.Length;
            descriptionBox.ScrollToEnd();



        }

        private void player1Character_Click(object sender, RoutedEventArgs e)
        {
            
            
            player1 = (Character)listBoxOfCharacters.SelectedItem;
            
            player1Name.Content = player1.Name;
            
            player1Image.Source = new BitmapImage(player1.Uri);

            
            

            



        }

        private void player2Character_Click(object sender, RoutedEventArgs e)
        {
            player2 = (Character)listBoxOfCharacters.SelectedItem;
            
            player2Name.Content = player2.Name;

            player2Image.Source = new BitmapImage(player2.Uri);

            



        }
        private void RestartGame()
        {
            player1Attack.Visibility = Visibility.Hidden;
            player2Attack.Visibility = Visibility.Hidden;
            player1Spell.Visibility = Visibility.Hidden;
            player2Spell.Visibility = Visibility.Hidden;
            playButton.Visibility = Visibility.Visible;
            endTurnButton.Visibility = Visibility.Hidden;
            player1HP.Visibility = Visibility.Hidden;
            player2HP.Visibility = Visibility.Hidden;

            player1ProgressBarText.Visibility = Visibility.Hidden;
            player2ProgressBarText.Visibility = Visibility.Hidden;

            listBoxOfCharacters.Visibility = Visibility.Visible;
            player1Character.Visibility = Visibility.Visible;
            player2Character.Visibility = Visibility.Visible;

            player1Name.Content = "";
            player2Name.Content = "";
            player1.HP = player1.MaxHP;
            player2.HP = player2.MaxHP;


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
            if (player1 != null && player2 != null)
            {
                descriptionBox.Text = "";
                player2.opponent = player1;
                player1.opponent = player2;
                player2.MaxHP = player2.HP;
                player1.MaxHP = player1.HP;
                player1Attack.Visibility = Visibility.Visible;
                player2Attack.Visibility = Visibility.Visible;
                player1Spell.Visibility = Visibility.Visible;
                player2Spell.Visibility = Visibility.Visible;
                playButton.Visibility = Visibility.Hidden;
                player1Character.Visibility = Visibility.Hidden;
                player2Character.Visibility = Visibility.Hidden;
                listBoxOfCharacters.Visibility = Visibility.Hidden;
                endTurnButton.Visibility = Visibility.Visible;
                player1HP.Visibility = Visibility.Visible;
                player2HP.Visibility = Visibility.Visible;
                player1ProgressBarText.Visibility = Visibility.Visible;
                player2ProgressBarText.Visibility = Visibility.Visible;

                turnNr = 1;
                player1.Turn = true;

                UpdateLabels();
                UpdateHPBar(player1HP, player1, player1ProgressBarText);
                UpdateHPBar(player2HP, player2, player2ProgressBarText);
            }
            else MessageBox.Show("Wybierz postacie !");

        }

        private void endTurnButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (turnNr==1)
            {
                turnNr = 2;
                description = "TURA " + player2.Name + "\n";
                UpdateLabels();
                player2.Turn = true;
            }
            else if(turnNr == 2)
            {
                turnNr = 1;
                description = "TURA " + player1.Name + "\n";
                UpdateLabels();
                player1.Turn = true;
            }


        }
        private void UpdateHPBar(ProgressBar hpbar,Character player,Label text)
        {
            
            double val = (double)player.HP / player.MaxHP * 100;
            if (val <= 100)
                hpbar.Foreground = Brushes.Green;
            
            if (val <= 50)
                hpbar.Foreground = Brushes.Orange;
            if (val <= 25)
                hpbar.Foreground = Brushes.Red;
            if (player.HP > 0)
                text.Content = player.HP + " / " + player.MaxHP;
            else text.Content = "";
            hpbar.Value = val;
            
        }
    }
}
