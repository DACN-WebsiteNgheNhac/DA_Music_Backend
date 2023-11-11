namespace Music_Backend.Utils.Const
{
    public static class WebApiEndPoint
    {
        private const string AreaName = "api";

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

        public static class InventoryReceiving
        {
            private const string BaseEndpoint = "~/" + AreaName + "/InventoryReceiving";
            public const string GetAllInventoryReceivings = BaseEndpoint + "/get-all";
            public const string GetInventoryReceivingById = BaseEndpoint + "/{id}";
            public const string SearchInventoryReceivings = BaseEndpoint + "/search";
            public const string CreateInventoryReceiving = BaseEndpoint + "/create";
            public const string UpdateInventoryReceiving = BaseEndpoint + "/update/{id}";
            public const string DeleteInventoryReceiving = BaseEndpoint + "/delete";
        }

        public static class ProductPortfolio
        {
            private const string BaseEndpoint = "~/" + AreaName + "/ProductPortfolio";
            public const string GetAllProductPortfolios = BaseEndpoint + "/get-all";
            public const string GetProductPortfolioById = BaseEndpoint + "/{id}";
            public const string SearchProductPortfolios = BaseEndpoint + "/search";
            public const string CreateProductPortfolio = BaseEndpoint + "/create";
            public const string CreateProductPortfolioWithImage = BaseEndpoint + "/create-image";
            public const string UpdateProductPortfolio = BaseEndpoint + "/update/{id}";
            public const string UpdateProductPortfolioWithFile = BaseEndpoint + "/update-with-file/{id}";
            public const string DeleteProductPortfolio = BaseEndpoint + "/delete";
            public const string GetSuggestProductPortfolio = BaseEndpoint + "/suggest";
        }

        public static class Product
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Product";
            public const string GetAllProducts = BaseEndpoint + "/get-all";
            public const string GetProductById = BaseEndpoint + "/{id}";
            public const string SearchProducts = BaseEndpoint + "/search";
            public const string CreateProduct = BaseEndpoint + "/create";
            public const string UpdateProduct = BaseEndpoint + "/update/{id}";
            public const string DeleteProduct = BaseEndpoint + "/delete";
        }

        public static class SupplierProduct
        {
            private const string BaseEndpoint = "~/" + AreaName + "/SupplierProduct";
            public const string GetAllSupplierProducts = BaseEndpoint + "/get-all";
            public const string GetAllSupplierProductsBySupplierId = BaseEndpoint + "/get-all/{supplierId}";
            public const string GetAllSupplierProductsByProductId = BaseEndpoint + "/get-all/ProductPortfolio/{productId}";
            public const string GetSupplierProductById = BaseEndpoint + "/{id}";
            public const string SearchSupplierProducts = BaseEndpoint + "/search";
            public const string CreateSupplierProduct = BaseEndpoint + "/create";
            public const string CreateMultiSupplierProduct = BaseEndpoint + "/create-multi";
            public const string UpdateSupplierProduct = BaseEndpoint + "/update/{id}";
            public const string DeleteSupplierProduct = BaseEndpoint + "/delete";
        }

        public static class Category
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Category";
            public const string GetAllCategorys = BaseEndpoint + "/get-all";
            public const string GetCategoryById = BaseEndpoint + "/{id}";
            public const string SearchCategorys = BaseEndpoint + "/search";
            public const string CreateCategory = BaseEndpoint + "/create";
            public const string UpdateCategory = BaseEndpoint + "/update/{id}";
            public const string DeleteCategory = BaseEndpoint + "/delete";
        }
        
        public static class User
        {
            private const string BaseEndpoint = "~/" + AreaName + "/User";
            public const string GetAllUsers = BaseEndpoint + "/get-all";
            public const string GetAllOrders = BaseEndpoint + "/get-all/Order/";
            public const string GetUserById = BaseEndpoint + "/{id}";
            public const string SearchUsers = BaseEndpoint + "/search";
            public const string CreateUser = BaseEndpoint + "/create";
            public const string UpdateUser = BaseEndpoint + "/update/{id}";
            public const string DeleteUser = BaseEndpoint + "/delete";
            public const string Login = BaseEndpoint + "/login";
            public const string Register = BaseEndpoint + "/register";

            public const string SendMail = BaseEndpoint + "/send-mail";
        }
         
        public static class Employee
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Employee";
            public const string GetAllEmployees = BaseEndpoint + "/get-all";
            public const string GetEmployeeById = BaseEndpoint + "/{id}";
            public const string SearchEmployees = BaseEndpoint + "/search";
            public const string CreateEmployee = BaseEndpoint + "/create";
            public const string UpdateEmployee = BaseEndpoint + "/update/{id}";
            public const string DeleteEmployee = BaseEndpoint + "/delete";
            public const string Login = BaseEndpoint + "/login";

        }
        public static class Order
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Order";
            public const string GetAllOrders = BaseEndpoint + "/get-all";
            public const string GetAllOrdersByUserId = BaseEndpoint + "/get-all/User/";
            public const string GetOrderById = BaseEndpoint + "/{id}";
            public const string SearchOrders = BaseEndpoint + "/search";
            public const string CreateOrder = BaseEndpoint + "/create";
            public const string UpdateOrder = BaseEndpoint + "/update/{id}";
            public const string DeleteOrder = BaseEndpoint + "/delete";
        }
        
        public static class OrderItem
        {
            private const string BaseEndpoint = "~/" + AreaName + "/OrderItem";
            public const string GetAllOrderItems = BaseEndpoint + "/get-all";
            public const string GetOrderItemById = BaseEndpoint + "/{id}";
            public const string SearchOrderItems = BaseEndpoint + "/search";
            public const string CreateOrderItem = BaseEndpoint + "/create";
            public const string UpdateOrderItem = BaseEndpoint + "/update/";
            public const string DeleteOrderItem = BaseEndpoint + "/delete";
        }
        
        public static class Payment
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Payment";
            public const string GetAllPayments = BaseEndpoint + "/get-all";
            public const string GetPaymentById = BaseEndpoint + "/{id}";
            public const string SearchPayments = BaseEndpoint + "/search";
            public const string CreatePayment = BaseEndpoint + "/create";
            public const string UpdatePayment = BaseEndpoint + "/update/";
            public const string DeletePayment = BaseEndpoint + "/delete";
        }
        public static class Evaluate
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Evaluate";
            public const string GetAllEvaluates = BaseEndpoint + "/get-all";
            public const string GetEvaluateById = BaseEndpoint + "/{id}";
            public const string GetEvaluateByProductId = BaseEndpoint + "/ProductPortfolio/{productId}";
            public const string SearchEvaluates = BaseEndpoint + "/search";
            public const string CreateEvaluate = BaseEndpoint + "/create";
            public const string UpdateEvaluate = BaseEndpoint + "/update/";
            public const string DeleteEvaluate = BaseEndpoint + "/delete";
        }
        
        public static class MediaContent
        {
            private const string BaseEndpoint = "~/" + AreaName + "/MediaContent";
            public const string GetAllMediaContents = BaseEndpoint + "/get-all";
            public const string GetMediaContentById = BaseEndpoint + "/{id}";
            public const string SearchMediaContents = BaseEndpoint + "/search";
            public const string CreateMediaContent = BaseEndpoint + "/create";
            public const string UpdateMediaContent = BaseEndpoint + "/update/";
            public const string UpdateMediaContentWithFile = BaseEndpoint + "/update-with-file/";
            public const string DeleteMediaContent = BaseEndpoint + "/delete";
        }

        public static class Role
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Role";
            public const string GetAllRoles = BaseEndpoint + "/get-all";
            public const string GetRoleById = BaseEndpoint + "/{id}";
            public const string SearchRoles = BaseEndpoint + "/search";
            public const string CreateRole = BaseEndpoint + "/create";
            public const string UpdateRole = BaseEndpoint + "/update/{id}";
            public const string DeleteRole = BaseEndpoint + "/delete";
        }
        
        public static class GroupRole
        {
            private const string BaseEndpoint = "~/" + AreaName + "/GroupRole";
            public const string GetAllGroupRoles = BaseEndpoint + "/get-all";
            public const string GetGroupRoleById = BaseEndpoint + "/{id}";
            public const string SearchGroupRoles = BaseEndpoint + "/search";
            public const string CreateGroupRole = BaseEndpoint + "/create";
            public const string UpdateGroupRole = BaseEndpoint + "/update/{id}";
            public const string DeleteGroupRole = BaseEndpoint + "/delete";
        }

        public static class DetailGroupRole
        {
            private const string BaseEndpoint = "~/" + AreaName + "/DetailGroupRole";
            public const string GetAllDetailGroupRoles = BaseEndpoint + "/get-all";
            public const string GetDetailGroupRoleById = BaseEndpoint + "/";
            public const string SearchDetailGroupRoles = BaseEndpoint + "/search";
            public const string CreateDetailGroupRole = BaseEndpoint + "/create";
            public const string UpdateDetailGroupRole = BaseEndpoint + "/update";
            public const string DeleteDetailGroupRole = BaseEndpoint + "/delete";
        }

        public static class Screen
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Screen";
            public const string GetAllScreens = BaseEndpoint + "/get-all";
            public const string GetScreenById = BaseEndpoint + "/{id}";
            public const string SearchScreens = BaseEndpoint + "/search";
            public const string CreateScreen = BaseEndpoint + "/create";
            public const string UpdateScreen = BaseEndpoint + "/update/{id}";
            public const string DeleteScreen = BaseEndpoint + "/delete";
        }

        public static class ScreenRole
        {
            private const string BaseEndpoint = "~/" + AreaName + "/ScreenRole";
            public const string GetAllScreenRoles = BaseEndpoint + "/get-all";
            public const string GetScreenRoleById = BaseEndpoint + "/";
            public const string SearchScreenRoles = BaseEndpoint + "/search";
            public const string CreateScreenRole = BaseEndpoint + "/create";
            public const string UpdateScreenRole = BaseEndpoint + "/update";
            public const string DeleteScreenRole = BaseEndpoint + "/delete";
        }
        public static class EmployeeRole
        {
            private const string BaseEndpoint = "~/" + AreaName + "/EmployeeRole";
            public const string GetAllEmployeeRoles = BaseEndpoint + "/get-all";
            public const string GetEmployeeRoleById = BaseEndpoint + "/";
            public const string SearchEmployeeRoles = BaseEndpoint + "/search";
            public const string CreateEmployeeRole = BaseEndpoint + "/create";
            public const string UpdateEmployeeRole = BaseEndpoint + "/update";
            public const string DeleteEmployeeRole = BaseEndpoint + "/delete";
        }

        public static class Statistical
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Statistical";
            public const string GetAllSuppliers = BaseEndpoint + "/get-all";
            public const string GetTotalSalesInYear = BaseEndpoint + "/get-total-sales-in-year/{year}";

            public const string GetTotalSalesInDate = BaseEndpoint + "/get-total-sales-in-date";
            public const string GetCountOrderInDate = BaseEndpoint + "/get-count-order-in-date";

            public const string GetTotalSalesInMultiDate = BaseEndpoint + "/get-total-sales-in-multi-date";
            public const string GetCountOrderInMultiDate = BaseEndpoint + "/get-count-order-in-multi-date";
            public const string SearchSuppliers = BaseEndpoint + "/search";
            public const string CreateSupplier = BaseEndpoint + "/create";
            public const string UpdateSupplier = BaseEndpoint + "/update/{id}";
            public const string DeleteSupplier = BaseEndpoint + "/delete";
        }








        public static class Account
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Account";
            public const string GetAllAccounts = BaseEndpoint + "/get-all";
            public const string SearchAccounts = BaseEndpoint + "/search";
            public const string SignUp = BaseEndpoint + "/signup";
            public const string Login = BaseEndpoint + "/login";
            public const string UpdateAccount = BaseEndpoint + "/update";
            public const string DeleteAccount = BaseEndpoint + "/delete";
        }

        public static class Room
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Room";
            public const string GetAllRooms = BaseEndpoint + "/get-all";
            public const string SearchRooms = BaseEndpoint + "/search";
            public const string CreateRoom = BaseEndpoint + "/create";
            public const string UpdateRoom = BaseEndpoint + "/update";
            public const string DeleteRoom = BaseEndpoint + "/delete";



        }
        public static class MemberRoom
        {
            private const string BaseEndpoint = "~/" + AreaName + "/MemberRoom";
            public const string GetAllMemberRooms = BaseEndpoint + "/get-all";
            public const string SearchMemberRooms = BaseEndpoint + "/search";
            public const string CreateMemberRoom = BaseEndpoint + "/create";
            public const string UpdateMemberRoom = BaseEndpoint + "/update";
            public const string DeleteMemberRoom = BaseEndpoint + "/delete";

            public const string GetChatRoomByUserId = BaseEndpoint + "/get-all/{userId}";

        }
        public static class Publisher
        {
            private const string BaseEndpoint = "~/" + AreaName + "/Publisher";
            public const string GetAllPublishers = BaseEndpoint + "/get-all";
            public const string SearchPublishers = BaseEndpoint + "/search";
            public const string CreatePublisher = BaseEndpoint + "/create";
            public const string UpdatePublisher = BaseEndpoint + "/update";
            public const string DeletePublisher = BaseEndpoint + "/delete";
        }


    }
}
