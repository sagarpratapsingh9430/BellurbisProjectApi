namespace BellurbisProjectApi.Models
{
    public class FavRestraurantPlayer

    {

        public FavRestraurantPlayer()
        {
            player = new PlayerModel();
            restaurent = new RestaurantModel();
            Fav = new RestroPlayerLinkModel();
        }
        public PlayerModel player { get; set; }
        public RestaurantModel restaurent { get; set; }

        public RestroPlayerLinkModel Fav { get; set; }


    }
    public class PlayersFavRestroList

    {
        internal List<PlayerModel> player;
        internal List<RestaurantModel> restaurent;
        internal RestaurantModel rest;

        public PlayerModel Player { get; set; }
        public List<PlayerModel> players { get; set; }
        public List<RestaurantModel> restaurents { get; set; }
        public RestaurantModel Restaurant { get; set; }

    }
}