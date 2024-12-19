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

namespace Victorins
{
    /// <summary>
    /// Логика взаимодействия для WindowVic.xaml
    /// </summary>
    public partial class WindowVic : Window
    {
        CVictorin victor;
        public CPlayerScope playerScope = new CPlayerScope("Name",0);

        public event Action<int> ProcessedTextReturned;

        int i = 0;
        public WindowVic(CVictorin victor)
        {
            
            InitializeComponent();
            this.victor = victor;
            
           
            AskQuest(i);
        }
        

        public void AskQuest(int i)
        {
            if (victor.GetQuests()[i] is CQuestAsk)
            {
                Answer.IsEnabled = true;
            }
            else if (victor.GetQuests()[i] is CQuest2Variants)
            {
                TrueFalse.IsEnabled = true;

            }
            else { }

            Quest.Content = victor.GetQuests()[i].TakeQuest();

            QuestName.Content = victor.GetQuests()[i].GetName();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (victor.GetQuests()[i] is CQuestAsk)
            {
                var question = victor.GetQuests()[i] as CQuestAsk;
                 playerScope = victor.GetQuests()[i].TakeScope(question.IsRight(Answer.Text),playerScope);
            }
            else if (victor.GetQuests()[i] is CQuest2Variants)
            {
                bool ans;
                if (TrueFalse.IsChecked == true)
                {
                    ans = true;
                }
                else
                {
                    ans = false;
                }
                var question = victor.GetQuests()[i] as CQuest2Variants;
                playerScope = victor.GetQuests()[i].TakeScope(question.IsRight(ans), playerScope);
            }
            else { }
            Scope.Content = playerScope.getPlayerScope();

            if (i < victor.GetQuests().Count - 1) { i++; AskQuest(i); }
            else 
            {
                ProcessedTextReturned?.Invoke(playerScope.getPlayerScope());
                this.Close();
            }

            
        }
    }
}
