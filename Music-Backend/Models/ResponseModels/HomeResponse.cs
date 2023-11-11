using System.Collections;

namespace Music_Backend.Models.ResponseModels
{
    public class HomeResponse
    {
        public List<object> Sections { get; set; }
    }

    public class Item<T>
    {
        public string SectionType { get; set; }
        public string ViewType { get; set; }
        public List<T> Items { get; set; } = new List<T>();

        public Item()
        {
            
        }
        public Item(string sectionType, string viewType)
        {
            SectionType = sectionType;
            ViewType = viewType;
        }
    }
}
