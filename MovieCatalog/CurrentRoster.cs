using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountTime
{
    public class CurrentRoster
    {
        public int GDCNum { get; set; }

        public bool InActive { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Dorm { get; set; }

        public int Bed { get; set; }

        public DateTime LastUpdate { get; set; }
    }
    public class CountMain
    {
        public int CountEventID { get; set; }

        public DateTime CountDate { get; set; }

        public DateTime CountTime { get; set; }

        public int TotalInCount { get; set; }

        public int TotalOutCount { get; set;}

        public DateTime CountCleared { get; set; }

        public int AUnitTotal { get; set; }

        public int RSATTotal { get; set;}

        public int TIC { get; set;}

        public int UnitCountDorm1 { get; set;}

        public int UnitCountDorm2 { get; set;}

        public int UnitCountDorm3 { get; set;}

        public int UnitCountDorm4 { get; set;}

        public int UnitCountDorm5 { get; set;}

        public int UnitCountDorm6 { get; set;}

        public int UnitCountDorm7 { get; set;}

        public int UnitCountDorm8 { get; set;}

        public int UnitCountDorm9 { get; set;}

        public int UnitCountDorm10 { get; set;}

        public int UnitCountDorm11 { get; set;}

        public int UnitCountDorm12 { get; set;}

        public int UnitCountDorm13 { get; set;}

        public int UnitCountDorm14 { get; set;}
    }
}
