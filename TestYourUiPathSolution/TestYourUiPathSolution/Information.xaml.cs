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

namespace TestYourUiPathSolution
{
    /// <summary>
    /// Interaction logic for Information.xaml
    /// </summary>
    public partial class Information : Window
    {
        public Information()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            AppendText(txtInformation, "Validations", Colors.Black, true);
            StringBuilder strBuild = new StringBuilder();
            string[] arVaribales = { "● Variables", "->Names should start with a lowercase letter (camelCase)", "->Names should not contain accents" };
            strBuild = ArrayToStringBuilder(arVaribales);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arArguments = { "● Arguments", "->Names should start with direction prefix (e.g. in_)", "->Names should start with a capital letter after the underscore (TitleCase)", "->Names should not contain accents" };
            strBuild = ArrayToStringBuilder(arArguments);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arInvokeWorkflow = { "● Invoke Workflow", "->Invoked workflow file should exist", "->All workflow arguments should be present", "->No spare arguments should be present", "->Arguments should have the same type and direction", "->Should avoid invoke recursion (chances of loop cycles)" };
            strBuild = ArrayToStringBuilder(arInvokeWorkflow);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arEmptyscopes = { "● Empty scopes", "->Flowchart activities should have at least one activity inside", "->Sequence activities should have at least one activity inside", "->While activities should have at least one activity inside", "->Do While activities should have at least one activity inside", "->If activities should have at least one activity on either then or else" };
            strBuild = ArrayToStringBuilder(arEmptyscopes);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arFlowchart = { "● Flowchart", "->Should not have any disconnected / orphan activities", "->Suggests that Flowchart with no decisions or switches should be sequences"};
            strBuild = ArrayToStringBuilder(arFlowchart);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arStateMachine = { "● State Machine", "->Should not have any disconnected / orphan states", "->All non-final states must have an exit and reach a final state" };
            strBuild = ArrayToStringBuilder(arStateMachine);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arTryCatch = { "● Try Catch", "->Should have at least one activity in the Try section", "->Should have at least one activity in either a catch or on the finally section" };
            strBuild = ArrayToStringBuilder(arTryCatch);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arSwitch = { "● Switch", "->Should have at least one case besides Default", "->Should have at least one activity in each case" };
            strBuild = ArrayToStringBuilder(arSwitch);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arFiles = { "● Files", "->Files should be invoked (directly or indirectly) from the main file at least once" };
            strBuild = ArrayToStringBuilder(arFiles);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arDelay = { "● Delay", "->Should avoid having delays, either as Delay activity or DelayBefore and DelayAfter attributes" };
            strBuild = ArrayToStringBuilder(arDelay);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            strBuild.Clear();
            string[] arComments = { "● Comments", "->Should not have CommentOut activities. If the activity is not being used, it should be removed" };
            strBuild = ArrayToStringBuilder(arComments);
            AppendText(txtInformation, strBuild.ToString(), Colors.Black, false);

            AppendText(txtInformation, "Validation results found within CommentOut activities blocks are not returned", Colors.Gray, true);

            AppendText(txtInformation, " ", Colors.Gray, true);

        }

        public StringBuilder ArrayToStringBuilder(string[] strArray)
        {
            StringBuilder strBuild = new StringBuilder();
            foreach (string str in strArray)
            {
                strBuild.AppendLine(str);
            }
            return strBuild;
        }

        public void AppendText(RichTextBox box, string text, Color color, bool isBold)
        {
            Run run = new Run(text);
            run.Foreground = new SolidColorBrush(color);
            if(isBold)
            {
                run.FontWeight = FontWeights.Bold;
            }
           
            Paragraph paragraph = new Paragraph(run);
            box.Document.Blocks.Add(paragraph);
        }
    }
}
