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
        public List<PlayerModel> player { get; set; }
        public List<RestaurantModel> restaurent { get; set; }

    }
}
