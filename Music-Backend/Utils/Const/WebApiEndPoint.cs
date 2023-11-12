namespace Music_Backend.Utils.Const
{
    public static class WebApiEndPoint
    {
        private const string AreaName = "api";

        public static class Home
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Home";
            public const string GetHome = BaseEndpoint + "/get-home-page";
        }

        public static class Search
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Search";
            public const string SearchData = BaseEndpoint + "/";
        }

        public static class Song
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Song";
            public const string GetAllSongs = BaseEndpoint + "/get-all";
            public const string GetSongById = BaseEndpoint + "/{id}";
            public const string SearchSongs = BaseEndpoint + "/search";
            public const string CreateSong = BaseEndpoint + "/create";
            public const string UpdateSong = BaseEndpoint + "/update/{id}";
            public const string DeleteSong = BaseEndpoint + "/delete";
        }

        public static class User
        {
            private const string BaseEndpoint = "~/" + AreaName + "/User";



            public const string CreatePlaylist = BaseEndpoint + "/playlist/{userId}";
            public const string DeletePlaylist = BaseEndpoint + "/playlist";
            public const string AddSongsToPlaylist = BaseEndpoint + "/playlist/{playlistId}";
            public const string RemoveSongsFromPlaylist = BaseEndpoint + "/playlist/{playlistId}";
        }

        public static class Album
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Album";
            public const string GetAllAlbums = BaseEndpoint + "/get-all";
            public const string GetAlbumById = BaseEndpoint + "/{id}";
            public const string GetAlbumsByTopicId = BaseEndpoint + "/topic-id";
            public const string SearchAlbums = BaseEndpoint + "/search";
            public const string CreateAlbum = BaseEndpoint + "/create";
            public const string UpdateAlbum = BaseEndpoint + "/update/{id}";
            public const string DeleteAlbum = BaseEndpoint + "/delete";
        }


    }
}
