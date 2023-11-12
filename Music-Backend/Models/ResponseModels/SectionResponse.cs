namespace Music_Backend.Models.ResponseModels
{
    public class SectionResponse
    {
        public List<object> Sections { get; set; }
    }

    public class Item<T>
    {
        public string? SectionType { get; set; }
        public string? ViewType { get; set; }
        public string? Search { get; set; }
        public T Items { get; set; } = default(T);

        public Item()
        {
            
        }
        public Item(string sectionType, string viewType, string search)
        {
            SectionType = sectionType;
            ViewType = viewType;
            Search = search;
        }
    }
}
