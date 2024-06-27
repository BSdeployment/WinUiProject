using App1.Model;
using App1.ViewModel;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        SectionsViewModel sections1;

        public BlankPage1()
        {
            
           
           
            


        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            var par = e.Parameter;
           string pathFromNav = par.ToString();

            this.InitializeComponent();
            this.DataContext = this;
            txtDescription.Text = Path.GetFileName(Path.GetDirectoryName(pathFromNav));
            TreeViewNode root = new TreeViewNode();
             sections1 = new SectionsViewModel(pathFromNav);

            foreach (var section in sections1.sections)
            {
                root = new TreeViewNode() { Content = section.SectionName };

                foreach (var lactu in section.Lacts)
                {

                    //root.Children.Add(new TreeViewNode() {   Content = new TreeViewItem { Tag= lactu.VideoUrl, Content = lactu.LactureName }.Content });
                    root.Children.Add(new TreeViewNode() { Content = lactu });
                }
                mytree.RootNodes.Add(root);
            }

            base.OnNavigatedTo(e);
        }

        private async void mytree_ItemInvoked(TreeView sender, TreeViewItemInvokedEventArgs args)  //this event when change selected betewwn items
        {
            //var invokedItem = args.InvokedItem as TreeViewNode;
            //var contentData = args.InvokedItem as 
            if(args.InvokedItem is TreeViewNode node && node.Content is Lacture itemData)
            {
                if (node != null)
                {
                    // Handle the item click event
                    var content = node.Content;
                    // For example, display the content in a MessageBox or perform some action


                    videoPlay.Source = MediaSource.CreateFromUri(new Uri($"file:///{itemData.VideoUrl}"));



                    //var dialog = new ContentDialog
                    //{
                    //    Title = "Item Invoked",
                    //    Content = $"You clicked on: {itemData.VideoUrl}",
                    //    CloseButtonText = "OK"
                    //};
                    //dialog.XamlRoot = this.XamlRoot;
                    //await dialog.ShowAsync();
                }
            
            }
        }

        private void btngoback_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainWindow));
        }
    }
}
