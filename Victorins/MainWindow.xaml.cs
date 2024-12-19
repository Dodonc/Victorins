using Microsoft.Win32;
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

namespace Victorins
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<CVictorin> cVictorins = new List<CVictorin>();
        int selectedIndex;
        
        
        //int selectedIndexl;
        public MainWindow()
        {
            InitializeComponent();
            QuestIndexs.Items.Add("WriteAnswer");
            QuestIndexs.Items.Add("True or False");

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var selectedItem = listBox.SelectedItem;
            selectedIndex = listBox.SelectedIndex;
            if (selectedItem != null) 
            {
                tb.Text = cVictorins[selectedIndex].GetNameVictori();
               
                Quests.ItemsSource = cVictorins[selectedIndex].GetListOfQuestNames();
                Quests.Items.Refresh();
            }

            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.FileName = "shows";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            bool? result = dlg.ShowDialog();

            if (result == true)
            {

                string filePath = dlg.FileName;
                var selectedItem = listBox.SelectedItem;
                selectedIndex = listBox.SelectedIndex;
                cVictorins[selectedIndex].SaveToJson(filePath);
            }
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "shows";
            dlg.DefaultExt = ".json";
            dlg.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            bool? result = dlg.ShowDialog();
            CVictorin victorin = new CVictorin(tb.Text);

            if (result == true)
            {
                string filePath = dlg.FileName;
                victorin.LoadFromJson(filePath);
            }
            cVictorins.Add(victorin);
            listBox.Items.Add(victorin.GetNameVictori());

            
        }

        private void AddQuest_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = listBox.SelectedItem;
            selectedIndex = listBox.SelectedIndex;
            int typeIndex = QuestIndexs.SelectedIndex;
            bool TF;
            if (isAns.IsChecked==true)
            {
                TF = true;
            }
            else
            {
                TF = false;
            }
            cVictorins[selectedIndex].AddShow(questAsk.Text,questName.Text,TF,questAnswer.Text,typeIndex);
            Quests.ItemsSource = cVictorins[selectedIndex].GetListOfQuestNames();
            Quests.Items.Refresh();
        }



        private void Quests_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = listBox.SelectedItem;
            selectedIndex = listBox.SelectedIndex;
            
            WindowVic vict = new WindowVic(cVictorins[selectedIndex]);
            vict.ProcessedTextReturned += ScopeInt;
            vict.Show();
            
            
        }
        private void ScopeInt(int scope)
        {
            Scope.Content = "Scope: " + scope;
        }
    }
}
