using PeopleViewer.Presentation;
using System;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        PeopleViewModel ViewModel { get; }

        public MainWindow(PeopleViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            DataContext = ViewModel;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.RefreshPeople();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.ClearPeople();
        }
    }
}
