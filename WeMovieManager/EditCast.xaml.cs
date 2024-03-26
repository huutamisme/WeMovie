using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for EditCast.xaml
    /// </summary>
    public partial class EditCast : Window
    {
        public FilmActor Actor { get; set; }
        public EditCast(FilmActor actor)
        {
            Actor = actor;
            InitializeComponent();
            bioToBind.Text = Actor.Bio;
            castNameToBind.Text = Actor.ActorName;
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var query = from cast in App.WeMovieDb.Actors where cast.id == Actor.Id select cast;
            var result = query.Single();
            result.name = castNameToBind.Text;
            result.biography = bioToBind.Text;
            App.WeMovieDb.SaveChanges();

            ICommand CastNavigateCommand = new NavigateCommand(new NavigationService(App._navigationStore, () => { return new CastManagementViewModel(); }));
            CastNavigateCommand.Execute(this);
            this.Close();
        }
    }
}
