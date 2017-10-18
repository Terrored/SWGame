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
        //Opponent newOpponent = new Opponent(100);
        Sith sith1;
        Jedi jedi1,jedi2;
        
        string description = "";

        public MainWindow()
        {
            InitializeComponent();
            
            sith1 = new Sith("Kylo Ren",20,30,100,10);

            jedi1 = new Jedi("Anakin Skywalker", 30, 25, 100, 10);
            jedi2 = new Jedi("Anakin Skywalker", 30, 25, 100, 10);
            sith1.opponent = jedi1;
            jedi1.opponent = sith1;

            List<Character> inty = new List<Character>()
            {
                jedi1,sith1,jedi2,
            };

            listBoxOfCharacters.ItemsSource = inty;







        }

        private void player1Attack_Click(object sender, RoutedEventArgs e)
        {
            description+= jedi1.Attack_Move();
            UpdateLabels();
        }

        private void player1Spell_Click(object sender, RoutedEventArgs e)
        {                    
            description += jedi1.Force_Push();
            UpdateLabels();
        }
        private void player2Attack_Click(object sender, RoutedEventArgs e)
        {
            description += sith1.Attack_Move();
            UpdateLabels();
        }

        private void player2Spell_Click(object sender, RoutedEventArgs e)
        {
            description += sith1.Force_Lightning();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            descriptionBox.Text = description;
            player1Name.Content = jedi1.Name;
            player2Name.Content = sith1.HP.ToString();
        }
        private void Labels()
        {

        }

        
    }
}
