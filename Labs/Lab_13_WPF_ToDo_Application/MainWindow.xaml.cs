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

namespace Lab_13_WPF_ToDo_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // List<string> items = new List<string>();
        List<Task> taskItems = new List<Task>();
        List<Category> categories = new List<Category>();

        Task task = new Task();

        public MainWindow()
        {
            InitializeComponent();
            Initialise();
        }

        /*
        private void InitialiseListBoxOfStrings()
        {
            // Displays as strings
            ListBoxTasks.ItemsSource = items;

            using (var db = new NewTasksDBEntities())
            {
                taskItems = db.Tasks.ToList();
            }

            // Get description and add to list
            foreach(var item in taskItems)
            {
                items.Add($"{item.TaskID,-5}{item.Description}{item.Done,-10}{item.DateCompleted}");
            }
        }
        */

        private void Initialise()
        {
            using (var db = new NewTasksDBEntities())
            {
                taskItems = db.Tasks.ToList();
                categories = db.Categories.ToList();
            }
            ListBoxTasks.ItemsSource = taskItems;
            ComboBoxCategory.ItemsSource = categories;

            // Displays as objects
            ListBoxTasks.DisplayMemberPath = "Description";
            ComboBoxCategory.DisplayMemberPath = "CategoryName";
        }

        private void ListBoxTasks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Print details of selected item
            // instance = (convert to Task) the item selected in listbox by user
            task = (Task)ListBoxTasks.SelectedItem;

            if (task != null)
            {
                TextBoxId.Text = task.TaskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;
                ButtonDelete.IsEnabled = true;
                
                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID - 1;
                }

                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }
            }

            
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonEdit.Content.ToString() == "Edit")
            {
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
            }

            else
            {
                using (var db = new NewTasksDBEntities())
                {
                    var taskToEdit = db.Tasks.Find(task.TaskID);

                    // Update description and categoryID
                    taskToEdit.Description = TextBoxDescription.Text;

                    // Convert category id to int from text box (string)
                    // Tryparse is safe to do conversion : null if fails
                    int.TryParse(TextBoxCategoryId.Text, out int categoryId);
                    taskToEdit.CategoryID = categoryId;

                    // Update records to database
                    db.SaveChanges();

                    // Update list box
                    ListBoxTasks.ItemsSource = null; // Reset list box
                    taskItems = db.Tasks.ToList(); // Get fresh list
                    ListBoxTasks.ItemsSource = taskItems; // Relink 
                }
                ButtonEdit.Content = "Edit";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#B3A4C5");
            }
            
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonAdd.Content.ToString() == "Add")
            {
                ButtonAdd.Content = "Confirm";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;

                // Clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";
            }

            else
            {
                ButtonAdd.Content = "Add";
                ButtonEdit.IsEnabled = false;
                TextBoxDescription.IsReadOnly = true;
                TextBoxCategoryId.IsReadOnly = true;
                var brush = new BrushConverter();
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#B3A4C5");

                int.TryParse(TextBoxCategoryId.Text, out int categoryId);

                var addTask = new Task() 
                {
                    Description = TextBoxDescription.Text,
                    CategoryID = categoryId
                };

                using (var db = new NewTasksDBEntities())
                {
                    // Add to database
                    db.Tasks.Add(addTask);
                    db.SaveChanges();

                    // Update list box
                    ListBoxTasks.ItemsSource = null; // Reset list box
                    taskItems = db.Tasks.ToList(); // Get fresh list
                    ListBoxTasks.ItemsSource = taskItems; // Relink 
                }
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ButtonDelete.Content.ToString() == "Delete")
            {
                ButtonDelete.Content = "Sure?";
                TextBoxId.Background = Brushes.PaleVioletRed;
                TextBoxDescription.Background = Brushes.PaleVioletRed;
                TextBoxCategoryId.Background = Brushes.PaleVioletRed;

            }

            else
            {
                using (var db = new NewTasksDBEntities())
                {
                    var taskToDelete = db.Tasks.Find(task.TaskID);
                    db.Tasks.Remove(taskToDelete);

                    // Update records to database
                    db.SaveChanges();

                    // Update list box
                    ListBoxTasks.ItemsSource = null; // Reset list box
                    taskItems = db.Tasks.ToList(); // Get fresh list
                    ListBoxTasks.ItemsSource = taskItems; // Relink 
                }

                ButtonDelete.Content = "Delete";
                ButtonDelete.IsEnabled = false;

                // Clear out boxes
                TextBoxId.Text = "";
                TextBoxDescription.Text = "";
                TextBoxCategoryId.Text = "";

                var brush = new BrushConverter();
                TextBoxId.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxDescription.Background = (Brush)brush.ConvertFrom("#B3A4C5");
                TextBoxCategoryId.Background = (Brush)brush.ConvertFrom("#B3A4C5");
            }
        }

        private void ListBoxTasks_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get object
            task = (Task)ListBoxTasks.SelectedItem;

            if (task != null)
            {
                // Set boxes for edit
                TextBoxId.Text = task.TaskID.ToString();
                TextBoxDescription.Text = task.Description;
                TextBoxCategoryId.Text = task.CategoryID.ToString();
                ButtonEdit.IsEnabled = true;


                if (task.CategoryID != null)
                {
                    ComboBoxCategory.SelectedIndex = (int)task.CategoryID - 1;
                }

                else
                {
                    ComboBoxCategory.SelectedItem = null;
                }

                TextBoxDescription.IsReadOnly = false;
                TextBoxCategoryId.IsReadOnly = false;
                ButtonEdit.Content = "Save";
                TextBoxDescription.Background = Brushes.White;
                TextBoxCategoryId.Background = Brushes.White;
            }
        }
    }
}
