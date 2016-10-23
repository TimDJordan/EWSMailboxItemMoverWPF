using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Shared;

namespace EWSMailboxItemMover
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Shared.mailbox thisMailbox;
        //private Shared.rules theseRules;
        private string fileName;
        private string rulesFileName;
        private List<Shared.rules> theseRules;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            errorsTB.Text = "";
            thisMailbox.email = mailboxTB.Text;
            //try and convert the input to a int if that fails set it to the default 300 second interval
            int intResult;
            if (int.TryParse(mailboxIntervalTB.Text, out intResult))
            {
                thisMailbox.refreshInterval = intResult;
                string json = JsonConvert.SerializeObject(thisMailbox, Formatting.Indented);
                if (fileName != null && fileName != "")
                {
                    try
                    {
                        System.IO.File.WriteAllText(fileName, json);
                        errorsTB.Foreground = new SolidColorBrush(Colors.Green);
                        errorsTB.Text = "File Saved";

                    }
                    catch (Exception ex)
                    {
                        errorsTB.Foreground = new SolidColorBrush(Colors.Red);
                        errorsTB.Text = ex.InnerException.Message;
                    }
                }
            }
            else
            {
                mailboxIntervalTB.Text = "300";
                thisMailbox.refreshInterval = 300;
                errorsTB.Foreground = new SolidColorBrush(Colors.Red);
                errorsTB.Text = "Invalid second value - Default Set, Save Discarded";
            }
            
        }

        private void BrowseForUser_Click(object sender, RoutedEventArgs e)
        {
            errorsTB.Text = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON documents (.json)|*.json";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                fileName = dlg.FileName;
                thisMailbox = JsonConvert.DeserializeObject<mailbox>(File.ReadAllText(fileName));
                mailboxTB.Text = thisMailbox.email.ToString();
                mailboxIntervalTB.Text = thisMailbox.refreshInterval.ToString();
            }            
        }

        private void BtnLoadRules_Click(object sender, RoutedEventArgs e)
        {
            TBRulesErrors.Text = "";
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON documents (.json)|*.json";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                rulesFileName = dlg.FileName;
                try
                {
                    theseRules = JsonConvert.DeserializeObject<List<Shared.rules>>(File.ReadAllText(rulesFileName));
                }
                catch (Exception ex)
                {
                    TBRulesErrors.Foreground = new SolidColorBrush(Colors.Red);
                    TBRulesErrors.Text = ex.InnerException.Message.ToString();
                }
                
            }
        }
    }
}
