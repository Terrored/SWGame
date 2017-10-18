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
        Jedi jedi1;


        public MainWindow()
        {
            InitializeComponent();
            sith1 = new Sith("Kylo Ren", 30, 30, 100, 5);
            jedi1 = new Jedi("Anakin Skywalker", 30, 25, 100, 10, sith1);

        }

        private void player1Attack_Click(object sender, RoutedEventArgs e)
        {
            descriptionBox.Text= jedi1.Attack_Move();
            UpdateLabels();


        }

        private void player1Spell_Click(object sender, RoutedEventArgs e)
        {
            

            descriptionBox.Text = jedi1.Force_Push();
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            player1Name.Content = jedi1.Name;
            player2Name.Content = sith1.HP.ToString();
        }
    }
}
