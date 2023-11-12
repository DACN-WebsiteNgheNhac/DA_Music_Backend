namespace Music_Backend.Models.RequestModels
{
    public class ListItemsRequest<T>
    {
        public List<T> Items { get; set; }
    }
}
