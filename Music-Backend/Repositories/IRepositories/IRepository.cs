namespace Music_Backend.Repositories.IRepositories
{
    public interface IRepository<TypeInput, TypeOutput>
         where TypeInput : class
         where TypeOutput : class
    {
        #region GET
        public Task<List<TypeInput>> GetAllObjectAsync(int pageNumber = -1, int pageSize = -1);
        public Task<List<TypeInput>> SearchObjectAsync(string query = "", int pageNumber = -1, int pageSize = -1);
        public Task<TypeInput?> GetObjectAsync(params object[] id);
        public Task<int> GetCountAsync();
        #endregion GET

        #region POST
        public Task<TypeOutput?> AddObjectAsync(TypeInput obj);

        #endregion POST

        #region PUT
        public Task<TypeOutput?> UpdateObjectAsync(TypeInput obj);
        #endregion PUT

        #region DELETE
        public Task<TypeOutput?> DeleteObjectSync(params object[] id);
        #endregion DELETE
    }
}
