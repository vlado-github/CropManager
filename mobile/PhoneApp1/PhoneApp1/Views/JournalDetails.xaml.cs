using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using PhoneApp1.Models;
using PhoneApp1.SerivceRepository;

namespace PhoneApp1.Views
{
    public partial class JournalDetails : PhoneApplicationPage
    {
        int cropId;
        public delegate void GetJournalsByCropIdCallback(List<JournalModel> journals);

        public JournalDetails()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string cropIdValue = NavigationContext.QueryString["parameter"];
            cropId = Int16.Parse(cropIdValue);

            JournalRepository journalRep = new JournalRepository();
            GetJournalsByCropIdCallback handler = new GetJournalsByCropIdCallback(GetJournalsByCropIdCompleted);
            journalRep.GetJournalsByCropId(new Action<List<JournalModel>>(handler), cropId);
        }

        private void GetJournalsByCropIdCompleted(List<JournalModel> journals)
        {
            journalListBox.ItemsSource = journals;
        }
    }
}