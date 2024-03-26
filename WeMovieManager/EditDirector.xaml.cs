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
using System.Windows.Shapes;
using WeMovieManager.Commands;
using WeMovieManager.Model;
using WeMovieManager.Services;
using WeMovieManager.ViewModels;

namespace WeMovieManager
{
    /// <summary>
    /// Interaction logic for EditDirector.xaml
    /// </summary>
    public partial class EditDirector : Window
    {
        FilmDirector director;
        public EditDirector(FilmDirector filmDirector)
        {
            director = filmDirector;
            InitializeComponent();
            bioToBind.Text = director.Bio;
            nameToBind.Text = director.DirectorName;
            //movieToBind.Text = director.FilmName;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from dir in App.WeMovieDb.Directors where dir.id == director.Id select dir;
            var result = query.Single();
            result.name = nameToBind.Text;
            result.biography = bioToBind.Text;
            App.WeMovieDb.SaveChanges();

            ICommand DirNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new DirectorManagementViewModel(); }));
            DirNavigateCommand.Execute(this);
            this.Close();
        }
    }
}
