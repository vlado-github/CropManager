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
using PhoneApp1.Models;
using PhoneApp1.JournalServiceReference;
using System.Collections.Generic;

namespace PhoneApp1.SerivceRepository
{
    public class JournalRepository
    {
        public Action<int> SaveJournalCallback;
        public Action<List<JournalModel>> GetJournalsByCropIdCallback;

        public void SaveJournal(Action<int> callback, JournalModel journalModel)
        {
            SaveJournalCallback = callback;
            Journal journal = MappingJournalModelToJournal(journalModel);
            JournalServiceClient journalSvc = new JournalServiceClient();
            journalSvc.InsertJournalAsync(journal);
            journalSvc.InsertJournalCompleted += new EventHandler
                <InsertJournalCompletedEventArgs>(journalSvc_InsertJournalCompleted);
        }

        public void GetJournalsByCropId(Action<List<JournalModel>> callback, int cropId)
        {
            GetJournalsByCropIdCallback = callback;
            JournalServiceClient journalSvc = new JournalServiceClient();
            journalSvc.SelectJournalByCropIdAsync(cropId);
            journalSvc.SelectJournalByCropIdCompleted += new EventHandler
                <SelectJournalByCropIdCompletedEventArgs>(journalSvc_SelectJournalByCropIdCompleted);
        }

        void journalSvc_SelectJournalByCropIdCompleted(object sender, SelectJournalByCropIdCompletedEventArgs e)
        {
            IEnumerable<Journal> journals = (IEnumerable<Journal>) e.Result;
            List<Journal> journalList = new List<Journal>(journals);
            List<JournalModel> journalModels = new List<JournalModel>();
            foreach (Journal j in journalList)
            {
                JournalModel jm = MappingJournalToJournalModel(j);
                journalModels.Add(jm);
            }
            GetJournalsByCropIdCallback(journalModels);
        }

        void journalSvc_InsertJournalCompleted(object sender, InsertJournalCompletedEventArgs e)
        {
            int id = e.Result;
            SaveJournalCallback(id);
        }

        private Journal MappingJournalModelToJournal(JournalModel journalModel)
        {
            Journal journal = new Journal();
            journal.cropid = journalModel.CropId;
            journal.dateentered = journalModel.DateEntered;
            journal.description = journalModel.Description;
            journal.journalimage = journalModel.Photo;

            return journal;
        }

        private JournalModel MappingJournalToJournalModel(Journal journal)
        {
            JournalModel journalModel = new JournalModel();
            journalModel.JournalId = journal.journalid;
            journalModel.CropId = journal.cropid;
            journalModel.DateEntered = journal.dateentered;
            journalModel.Description = journal.description;
            journalModel.Photo = journal.journalimage;

            return journalModel;
        }
    }
}
