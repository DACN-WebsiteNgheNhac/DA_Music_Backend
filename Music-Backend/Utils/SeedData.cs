using Music_Backend.Data;

namespace Music_Backend.Utils
{
    public class SeedData
    {
        private readonly DataContext dataContext;
        public SeedData(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
        }

    }
}
