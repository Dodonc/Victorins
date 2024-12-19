using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorins
{
    public class CVictorin
    {
        private readonly ISaveList<List<CQuest>> _serialzer = new CJsonQuestSaver();
        public List<CQuest> cQuests;

        public string NameVictorins {  get; set; }

        public CVictorin(string NameVictorins)
        {
            cQuests = new List<CQuest>();
            this.NameVictorins = NameVictorins;
        }

        public List<CQuest> GetQuests() { return cQuests; }

        public void AddShow(string Quest, string Name, bool isAns, string answer, int questIndex)
        {
            switch (questIndex)
            {
                case 1:
                    cQuests.Add(new CQuest2Variants(Quest,Name, isAns));
                    break;
                case 0:
                    cQuests.Add(new CQuestAsk(Quest, Name, answer)); 
                    break;
            }
        }
        
        public string GetNameVictori()
        {
            return NameVictorins;
        }
        public CQuest GetListOfQuestNames(string quest)
        {
            return cQuests.Find(names => names.Name.Equals(quest, StringComparison.OrdinalIgnoreCase));
        }

        public CQuest GetListOfQuestByIndex(int index)
        {
            if (index < 0 || index >= cQuests.Count)
            {
                return null;
            }
            return cQuests[index];
        }

        public void DeleteListOfQuestByName(string quest)
        {
            cQuests.RemoveAll(names => names.Name.Equals(quest, StringComparison.OrdinalIgnoreCase));
        }

        public void DeleteListOfQuestIndex(int index)
        {
            if (index >= 0 && index < cQuests.Count)
            {
                cQuests.RemoveAt(index);
            }
        }

        public List<string> GetListOfQuestNames()
        {
            return cQuests.ConvertAll(names => names.Name);
        }
        public List<string> GetListOfQuest()
        {
            return cQuests.ConvertAll(quest => quest.Quest);
        }

        public void SaveToJson(string path)
        {
            _serialzer.Save(cQuests, path);
        }

        public void LoadFromJson(string path)
        {
            cQuests = _serialzer.Load(path);
        }
    }
}
