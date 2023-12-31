﻿namespace Music_Backend.Utils.Const
{
    public static class WebApiEndPoint
    {
        private const string AreaName = "api";

        public static class Home
        {
            private const string BaseEndpoint = "~/" + AreaName + "/home";
            public const string GetHome = BaseEndpoint ;

            public const string GetAudioUrlFromYoutube = BaseEndpoint + "/audio/youtube" ;
        }

        public static class Search
        {
            private const string BaseEndpoint = "~/" + AreaName + "/search";
            public const string SearchData = BaseEndpoint + "/";
        }

        public static class Song
        {
            private const string BaseEndpoint = "~/" + AreaName + "/song";
            public const string GetAllSongs = BaseEndpoint + "/get-all";
            public const string GetSongById = BaseEndpoint + "/{id}";
            public const string SearchSongs = BaseEndpoint + "/search";
            public const string GetSongsByArtistId = BaseEndpoint + "/search/artist-id/{artistId}";
            public const string CreateSong = BaseEndpoint + "/create";
            public const string UpdateSong = BaseEndpoint + "/update/{id}";
            public const string DeleteSong = BaseEndpoint + "/delete";


            public const string GetTopSongListens = BaseEndpoint + "/top-listens";
            public const string GetTopSongDownloads = BaseEndpoint + "/top-downloads";
            public const string GetTopSongFavorites = BaseEndpoint + "/top-favorites";

            public const string AddListensSong = BaseEndpoint + "/listens/{songId}";
            public const string AddDownloadsSong = BaseEndpoint + "/downloads/{songId}";
        }

        public static class User
        {
            private const string BaseEndpoint = "~/" + AreaName + "/user";

            public const string Register = BaseEndpoint + "/register";
            public const string Login = BaseEndpoint + "/login";
            public const string UpdateUser = BaseEndpoint + "/update/{id}";


            public const string GetPlaylistsByUserId = BaseEndpoint + "/playlist/{userId}";
            public const string CreatePlaylist = BaseEndpoint + "/playlist/create/{userId}";
            public const string DeletePlaylist = BaseEndpoint + "/playlist";
            public const string AddSongsToPlaylist = BaseEndpoint + "/playlist/{playlistId}";
            public const string RemoveSongsFromPlaylist = BaseEndpoint + "/playlist/{playlistId}";
            
            public const string CreateCommentSong = BaseEndpoint + "/comment-song";
            public const string UpdateCommentSong = BaseEndpoint + "/comment-song";
            public const string DeleteCommentSong = BaseEndpoint + "/comment-song";

            public const string GetFavoriteSongsByUserId = BaseEndpoint + "/fav-song";
            public const string AddSongToFavoriteSongs = BaseEndpoint + "/fav-song";
            public const string DeleteSongFromFavoriteSongs = BaseEndpoint + "/fav-song";

        }

        public static class Album
        {
            private const string BaseEndpoint = "~/" + AreaName + "/album";
            public const string GetAllAlbums = BaseEndpoint + "/get-all";
            public const string GetAlbumById = BaseEndpoint + "/{albumId}";
            public const string GetSuggestionAlbumById = BaseEndpoint + "/suggestion/{albumId}";
            public const string GetAlbumsByArtistId = BaseEndpoint + "/artist-id/{artistId}";
            public const string GetAlbumsByTopicId = BaseEndpoint + "/topic-id";
            public const string SearchAlbums = BaseEndpoint + "/search";
            public const string CreateAlbum = BaseEndpoint + "/create";
            public const string UpdateAlbum = BaseEndpoint + "/update/{id}";
            public const string DeleteAlbum = BaseEndpoint + "/delete";
        }

        public static class Comment
        {
            private const string BaseEndpoint = "~/" + AreaName + "/comment";
            public const string GetCommentsBySongId = BaseEndpoint + "/song-id/{songId}";
          
        }

        public static class Playlist
        {
            private const string BaseEndpoint = "~/" + AreaName + "/playlist";
            public const string GetPlaylistsByUserId = BaseEndpoint + "/user-id/{userId}";
            public const string GetPlaylistByPlaylistId = BaseEndpoint + "/playlist-id/{playlistId}";
            public const string CreatePlaylist = BaseEndpoint + "/create/{userId}";
            public const string DeletePlaylist = BaseEndpoint + "/delete/{playlistId}";
            public const string AddSongsToPlaylist = BaseEndpoint + "/add-songs/{playlistId}";
            public const string RemoveSongsFromPlaylist = BaseEndpoint + "/remove-songs/{playlistId}";

            public const string UpdatePlaylist = BaseEndpoint + "/update/{playlistId}";
        }

        public static class Artist
        {
            private const string BaseEndpoint = "~/" + AreaName + "/artist";
            public const string GetArtistById = BaseEndpoint + "/{id}";
        }



    }
}
