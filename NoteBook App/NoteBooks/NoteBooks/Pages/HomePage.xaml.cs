using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using NoteBooks.Data;
using System;


// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NoteBooks.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        NoteServicesJson noteServices;
       
        public HomePage()
        {
            noteServices = new NoteServicesJson();
            
           
            this.InitializeComponent();
            if (noteServices.GetAllNote().Count > 0)
            {
                MyListView.Visibility = Visibility.Visible;
            }

            

           
          
          
              
           

        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {

            ContentDialog dialog = new ContentDialog();

            // XamlRoot must be set in the case of a ContentDialog running in a Desktop app
            dialog.XamlRoot = this.XamlRoot;
            dialog.Style = Application.Current.Resources["DefaultContentDialogStyle"] as Style;
            dialog.Title = "Delete Confirm?";
            dialog.PrimaryButtonText = "Delete";
            dialog.CloseButtonText = "Cancel";
            dialog.DefaultButton = ContentDialogButton.Primary;
            dialog.Content = "You Are Sure Delete This Item?";
            
            var result = await dialog.ShowAsync();

            string res = result.ToString();

            if(res == "Primary")
            {
                var button = (Button)sender;

                var NoteItem = (NoteModel)button.DataContext;

                noteServices.RemoveNote(NoteItem);

                MyListView.ItemsSource = null;
                if (noteServices.GetAllNote().Count > 0)
                    MyListView.ItemsSource = noteServices.GetAllNote();
                else
                    MyListView.Visibility = Visibility.Collapsed;
            }
            
          

            

        }

        private async void btnadd_Click(object sender, RoutedEventArgs e)
        {
           var dialog = new AddNewNoteDialog();
            dialog.XamlRoot = this.XamlRoot;
            var res =   await  dialog.ShowAsync();

            if(res== ContentDialogResult.Primary)
            {
                noteServices.AddNote(new NoteModel { Title = dialog.NoteTitle, Content = dialog.NoteContent });
                MyListView.ItemsSource = null;
                MyListView.ItemsSource = noteServices.GetAllNote();
                MyListView.Visibility = Visibility.Visible;            }

        }

        private async void deleteAll_Click(object sender, RoutedEventArgs e)
        {

            var dialog = new DeleteAllDialog();
            dialog.XamlRoot= this.XamlRoot;
            var res = await dialog.ShowAsync();
            if (res == ContentDialogResult.Primary)
            {
                noteServices.DeleteAllNotes();
               
                MyListView.Visibility = Visibility.Collapsed;
            }
           

        }
    }
}
