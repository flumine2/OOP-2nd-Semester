using Lab_4.ua.cdu.edu;
using Lab_4.ua.cdu.edu.model;
using Lab_4.ua.cdu.edu.service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Lab_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly FrontPresenter frontPresenter;

        public MainWindow()
        {
            InitializeComponent();

            HorseService horseService = new HorseService();
            RenderService renderService = new RenderService(
                image: GameField_Image,
                imageSize: () => new Size(Image_Column.ActualWidth, Image_Row.ActualHeight),
                horses: horseService.Horses,
                Horses_DataGrid);
            

            this.frontPresenter = new FrontPresenter(renderService, horseService);
            frontPresenter.GenerateHorseChoseBox(HorseChose_Box);
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            frontPresenter.StartRace();
        }

        private void NextHorse_Button_Click(object sender, RoutedEventArgs e)
        {
            frontPresenter.NextHorse();
        }

        private void PreviousHorse_Button_Click(object sender, RoutedEventArgs e) 
        {
            frontPresenter.PreviousHorse();
        }

        private void Reset_Button_Click(object sender, RoutedEventArgs e)
        {
            frontPresenter.ResetRace();
        }

        private void HorseChose_Box_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)((ComboBox)sender).SelectedItem;
        }

        private void Bet_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
