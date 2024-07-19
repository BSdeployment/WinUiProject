
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace NoteBooks.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddNewNoteDialog : ContentDialog
    {
       
        public AddNewNoteDialog()
        {
          
            this.InitializeComponent();
        }
        public string NoteTitle { get; private set; }
        public string NoteContent { get; private set; }


        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            NoteTitle = txtTitle.Text;
            NoteContent = txtContent.Text;  
        }
    }
}
