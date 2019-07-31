using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System;
using System.IO;
using System.Collections.ObjectModel;
using UIPathValidator.UIPath;
using UIPathValidator.Validation;
using UIPathValidator.Validation.Result;

namespace TestYourUiPathSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object dummyNode = null;

        public MainWindow()
        {
            
            InitializeComponent();
            
        }
        public string SelectedImagePath { get; set; }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeViewItem item = new TreeViewItem();
                item.Header = s;
                item.Tag = s;
                item.FontWeight = FontWeights.Normal;
                item.Items.Add(dummyNode);
                item.Expanded += new RoutedEventHandler(folder_Expanded);
                foldersItem.Items.Add(item);
            }
            AppendText(txtResult, "Please browse a UiPath project Folder using left Windows Folder Explorer!!!!", Colors.Black);
            AppendText(txtResult, "Or you can directly paste path of your UiPath Solution in above Text Box!!!!", Colors.Black);
            AppendText(txtResult, "Please click Run Test button after browsing!!!!", Colors.Black);
            AppendText(txtResult, "Your Solution Test Result will appear here!!!!!", Colors.Black);
            AppendText(txtResult, "For information please click Info!!!!!", Colors.Black);
        }

        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void foldersItem_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            TreeView tree = (TreeView)sender;
            TreeViewItem temp = ((TreeViewItem)tree.SelectedItem);

            if (temp == null)
                return;
            SelectedImagePath = "";
            string temp1 = "";
            string temp2 = "";
            while (true)
            {
                temp1 = temp.Header.ToString();
                if (temp1.Contains(@"\"))
                {
                    temp2 = "";
                }
                SelectedImagePath = temp1 + temp2 + SelectedImagePath;
                if (temp.Parent.GetType().Equals(typeof(TreeView)))
                {
                    break;
                }
                temp = ((TreeViewItem)temp.Parent);
                temp2 = @"\";
            }
            //show user selected path
            //MessageBox.Show(SelectedImagePath);
            txtDirPath.Text = SelectedImagePath;
            //lblDirPath.FontSize = 14;
            //lblDirPath.FontFamily= new FontFamily("Times New Roman Bold");
            //lblDirPath.FontWeight= 

        }

        public static string Project { get; set; }

        public int Execute(string loadProject)
        {
            try
            {
                Project project = new Project(loadProject);
                ProjectValidator validator = new ProjectValidator(project);
                project.Load();
                validator.Validate();
                PrintResultsOfType(validator, ValidationResultType.Error, Colors.Red);


                PrintResultsOfType(validator, ValidationResultType.Warning, Color.FromRgb(165, 176, 9));


                PrintResultsOfType(validator, ValidationResultType.Info, Colors.Blue);

                return 0;
            }
            catch (Exception ex)
            {
                AppendText(txtResult, "Error Occurred", Colors.Red);
                StringBuilder strBuild = new StringBuilder();
                strBuild.AppendLine("Exception Details");
                strBuild.AppendLine("Source: "+ex.Source);
                strBuild.AppendLine("Message: " + ex.Message);
                strBuild.AppendLine("StackTrace: " + ex.StackTrace);
                AppendText(txtResult, strBuild.ToString(), Colors.Red);
                return -1;
            }
            
        }

        private void PrintResultsOfType(ProjectValidator validator, ValidationResultType type, Color color)
        {
            var filteredResults = validator.GetResultsByType(type);

            StringBuilder strBuild = new StringBuilder();
            if (filteredResults.Count() > 0)
            {
                strBuild.AppendLine(filteredResults.Count().ToString() + " " + type + " messages:");
                foreach (var item in filteredResults)
                {
                    strBuild.AppendLine(item.FormattedMessage);
                }

                AppendText(txtResult, strBuild.ToString(), color);
            }
            
        }

        public  void AppendText(RichTextBox box, string text, Color color)
        {
            Run run = new Run(text);
            run.Foreground = new SolidColorBrush(color);
            run.FontWeight = FontWeights.Bold;
            Paragraph paragraph = new Paragraph(run);
            box.Document.Blocks.Add(paragraph);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(txtDirPath.Text))
            {
                txtResult.Document.Blocks.Clear();
                Project = txtDirPath.Text;
                Execute(txtDirPath.Text);
            }
            else { MessageBox.Show("Please browse a UiPath project Folder!!!!"); }
        }

        private void InfoButton_Click(object sender, RoutedEventArgs e)
        {
            Information infoWindow = new Information();

            infoWindow.ShowDialog();
        }
    }


   
    

}
