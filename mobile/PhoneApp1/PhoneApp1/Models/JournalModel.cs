using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using PhoneApp1.SerivceRepository;

namespace PhoneApp1.Models
{
    public class JournalModel
    {
        public delegate void SaveJournalCallback(int journalId);
        public delegate void GetJournalsByCropId(List<JournalModel> journalModels);
        Action<int> ViewSaveCallback;
        Action<List<JournalModel>> ViewGetJournalsByCropId;

        public int JournalId { get; set; }
        public DateTime DateEntered { get; set; }
        public String Description { get; set; }
        public byte[] Photo { get; set; }
        public int CropId { get; set; }

        public void SaveJournal(Action<int> callback, JournalModel journalModel)
        {
            ViewSaveCallback = callback;
            JournalRepository journalRepository = new JournalRepository();
            SaveJournalCallback handler = new SaveJournalCallback(SaveJournalCompleted);
            journalRepository.SaveJournal(new Action<int>(handler), journalModel);
        }

        public void GetJournalsByCropId(Action<List<JournalModel>> callback, int cropId)
        {
            ViewGetJournalsByCropId = callback;
            JournalRepository journalRepository = new JournalRepository();
            GetJournalsByCropId handler = new GetJournalsByCropId(GetJournalByCropIdCompleted);
            journalRepository.GetJournalsByCropId(new Action<List<JournalModel>>(handler), cropId);
        }

        public void SaveJournalCompleted(int id)
        {
            ViewSaveCallback(id);
        }

        public void GetJournalByCropIdCompleted(List<JournalModel> journalModels)
        {
            ViewGetJournalsByCropId(journalModels);
        }
    }
}
