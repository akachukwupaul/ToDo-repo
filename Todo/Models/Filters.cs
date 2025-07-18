using Microsoft.VisualBasic;

namespace Todo.Models
{
    public class Filters
    {
        public Filters(string filterstring)
        {
            // If no filter string is passed, use the default "all-all-all"
            Filterstring = filterstring ?? "all-all-all";
            string[] filters = Filterstring.Split('-');
            // Assign each component to a property
            CategoryId = filters[0];
            Due = filters[1];
            StatusId = filters[2];
        }
        public string Filterstring { get; }
        public string CategoryId { get; }
        public string Due { get; }  
        public string StatusId { get; }

        public bool HasCategory => CategoryId.ToLower() != "all";
        public bool HasDue => Due.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";

        // Static dictionary containing due date filter options and their display labels
        public static Dictionary<string, string> DueFilterValues => new Dictionary<string, string>
        {
            {"future", "Future" },
            {"past", "Past" },
            {"today", "Today" }
        };
        public bool IsPast => Due.ToLower() == "past";
        public bool IsFuture => Due.ToLower() == "future";
        public bool IsToday => Due.ToLower() == "today";
       
    }
            

        
}
