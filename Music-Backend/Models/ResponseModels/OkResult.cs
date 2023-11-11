using System.Text.Json;

namespace Music_Backend.Models.ResponseModels
{
    public class OkResult<T>
    {
        public int StatusCode { get; set; }
        public T Metadata { get; set; }
        public string Message { get; set; }

        public Pagination? Pagination { get; set; }

        public OkResult()
        {
            
        } 
        
        public OkResult(string messsage)
        {
            Message = messsage;
        }

        public OkResult(T Metadata, string Message, int StatusCode)
        {
            this.Message = Message;
            this.StatusCode = StatusCode;
            this.Metadata = Metadata;
        }

        public OkResult(T Metadata, string Message, int StatusCode, Pagination? pagination)
        {
            this.Message = Message;
            this.StatusCode = StatusCode;
            this.Metadata = Metadata;
            this.Pagination = pagination;
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }

    public class Pagination
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int CurrentEntry { get; set; }

        public Pagination()
        {
            
        }

        public Pagination(int currentPage, int totalPage, int currentEntry)
        {
            CurrentPage = currentPage;
            TotalPage = totalPage;
            CurrentEntry = currentEntry;
        }
    }
}
