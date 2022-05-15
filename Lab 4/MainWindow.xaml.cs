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
        private readonly RenderService renderer;
        private readonly HorseService horseService;

        public MainWindow()
        {
            InitializeComponent();
            this.horseService = new HorseService();
            this.renderer = new RenderService(GameField_Image, new Size(4532, 1980), horseService.Horses);
            renderer.RenderFrame();
        }

        private void Start_Button_Click(object sender, RoutedEventArgs e)
        {
            horseService.UpdateState();
            renderer.RenderFrame();
        }
    }
}
