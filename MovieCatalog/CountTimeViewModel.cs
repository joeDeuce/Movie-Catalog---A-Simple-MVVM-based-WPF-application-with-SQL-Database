using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CountTime
{
    public class CountTimeViewModel
    {
        public ObservableCollection<CurrentRoster> Baseline { get; set; }
        private CountRepository CountRepository { get; set; }

        public CountTimeViewModel()
        {
            CountRepository = new CountRepository();
            Baseline = new ObservableCollection<CurrentRoster>(CountRepository.CountRepo);
            Baseline.CollectionChanged += Baseline_CollectionChanged;       // Event Handler for change in collection
        }

        /*
         * Function: Search for the query string in Movies Collection
         * Saves time and resources by searching in Collection in memory
         * rather than in database
         */
        public List<CurrentRoster> SearchActive()
        {
            List<CurrentRoster> RosterList =                // Temporary list for storing results returned from search query
            (from tempBaseline in Baseline where tempBaseline.InActive is false select tempBaseline).ToList();
            //Baseline.ToList();
            return RosterList;
        }

        /*
         * Function: Return all records where InActive = false
         * Also uses a temporary snapshot of the db table to prevent
         * unneeded resource usage
         */
        public List<CurrentRoster> GetActive()
        {
            List<CurrentRoster> RosterList =                // Temporary list for storing results returned from search query
            (from tempBaseline in Baseline where tempBaseline.InActive is false select tempBaseline).ToList();
            //Baseline.ToList();
            return RosterList;
        }

        /*
         * Function: Add Record to Collection and Database
         */
        public void AddRecordToRepo(CurrentRoster inmateRecord)
        {
            if (inmateRecord == null)
                throw new ArgumentNullException("Error: The argument is Null");
            Baseline.Add(inmateRecord);
        }

        /*
         * Function: Delete Records from Collection and Database
         */
        public void DeleteRecordFromRepo(int id)
        {
            if (id < 0)
                throw new Exception("GDC ID must be non-negative");

            int index = 0;
            while (index < Baseline.Count)
            {
                if (Baseline[index].GDCNum == id)
                {
                    Baseline.RemoveAt(index);
                    break;
                }
                index++;
            }
        }

        /*
         * Function: Updates the Object in Collection
         * with refernce to the id
         */
        public void UpdateRecordInRepo(CurrentRoster inmateRecord)
        {
            if (inmateRecord.GDCNum < 0)
                throw new Exception("GDC ID cannot be negative");

            int index = 0;
            while(index < Baseline.Count)
            {
               if (Baseline[index].GDCNum == inmateRecord.GDCNum)
                {
                    Baseline[index] = inmateRecord;
                    break;
                }
                index++;
            }
        }

        /*
         * Event Handler: Handles the CollectionChanged event of ObservableCollection
         * Updates the Database if any change is made to the Movies Collection
         * Thus removes unncecessary burden of accessing Database
         */
        private void Baseline_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                int newIndex = e.NewStartingIndex;
                CountRepository.AddNewRecord(Baseline[newIndex]);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                List<CurrentRoster> tempListOfRemovedItems = e.OldItems.OfType<CurrentRoster>().ToList();
                CountRepository.DelRecord(tempListOfRemovedItems[0].GDCNum);
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                List<CurrentRoster> tempRoster = e.NewItems.OfType<CurrentRoster>().ToList();
                CountRepository.UpdateRecord(tempRoster[0]);      // As the IDs are unique, only one row will be effected hence first index only
            }
        }
    }
}