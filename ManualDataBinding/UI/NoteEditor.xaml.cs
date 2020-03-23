using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ManualDataBinding.Data;

namespace ManualDataBinding.UI
{
    /// <summary>
    /// Interaction logic for NoteEditor.xaml
    /// </summary>
    public partial class NoteEditor : UserControl
    {
        public NoteEditor()
        {
            InitializeComponent();
        }

        private Note note;
        /// <summary>
        /// This holds the note that will be edited
        /// </summary>
        public Note Note 
        {
            get { return note; }
            set
            {
                if (note != null) note.NoteChanged -= OnNoteChanged;
                note = value;
                if (note != null)
                {
                    note.NoteChanged += OnNoteChanged;
                    OnNoteChanged(note, new EventArgs());
                }

            }
        }

        /// <summary>
        /// Handles the changes made to a note
        /// </summary>
        /// <param name="sender">The Note changing</param>
        /// <param name="e"></param>
        public void OnNoteChanged(object sender, EventArgs e)
        {
            if (Note == null) return; 
            Title.Text = Note.Title;
            Body.Text = Note.Body;
        }

        /// <summary>
        /// Handles changes made to title
        /// </summary>
        /// <param name="sender">Title text changed</param>
        /// <param name="e">EventArgs</param>
        public void OnTitleChanged(object sender, TextChangedEventArgs e)
        {
            Note.Title = Title.Text;
        }

        /// <summary>
        /// Handles the changes made to body
        /// </summary>
        /// <param name="sender">Title Text</param>
        /// <param name="e">EventArgs</param>
        public void OnBodyChanged(object sender, TextChangedEventArgs e)
        {
            Note.Body = Body.Text;
        }
    }
}
