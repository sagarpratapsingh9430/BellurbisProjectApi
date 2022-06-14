using Microsoft.EntityFrameworkCore;
using BellurbisProjectApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BellurbisProjectApi.Repository
{
    public interface IRP
    {
       
        List<RestaurantModel> Index();
        List<PlayerModel> PlayerIndex();

        bool Create(RestaurantModel emp);
        bool PlayerCreate(PlayerModel mac);

        RestaurantModel Edit(int id);
        PlayerModel PlayerEdit(int id);

        bool Delete(int id);
        bool PlayerDelete(int id);




        FavRestraurantPlayer FvtplyRest(string name, bool status = true);
        List<RestaurantModel> ResturantByName(string name);
        List<PlayerModel> PlayerByName(string name);

        List<FavRestraurantPlayer> getall();

        bool RestroPlayerLink(RestroPlayerLinkModel Obj);


    }
    public abstract class RP : IRP
    {
        public abstract List<RestaurantModel> Index();
        public abstract bool Create(RestaurantModel emp);
        public abstract RestaurantModel Edit(int id);
        public abstract bool Delete(int id);

        public abstract List<PlayerModel> PlayerIndex();
        public abstract bool PlayerCreate(PlayerModel mac);
        public abstract PlayerModel PlayerEdit(int id);
        public abstract bool PlayerDelete(int id);

        public abstract FavRestraurantPlayer FvtplyRest(string name, bool status = true);


        public abstract List<RestaurantModel> ResturantByName(string name);

        public abstract List<PlayerModel> PlayerByName(string name);



        public abstract List<FavRestraurantPlayer> getall();

        
        public abstract bool  RestroPlayerLink(RestroPlayerLinkModel Obj);



    }

    public class RPRepository : RP
    {
        private readonly DBContext dbcontext = null;
        public RPRepository(DBContext _dbContxet)
        {
            dbcontext = _dbContxet;
        }


        // For Restaurant
        public override bool Create(RestaurantModel emp)
        {
            if (emp == null)
            {
                return false;
            }
            else
            {
                if (emp.RestaurantId == 0)
                {
                    dbcontext.Add(emp);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
        }


        // For Player
        public override bool PlayerCreate(PlayerModel mac)
        {
            if (mac == null)
            {
                return false;
            }
            else
            {
                if (mac.PlayerId == 0)
                {
                    dbcontext.Add(mac);
                    dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    dbcontext.Entry(mac).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dbcontext.SaveChanges();
                    return true;
                }
            }
        }


        // For Reasurant
        public override List<RestaurantModel> Index()
        {
            return dbcontext.RestaurantTab.ToList();
        }
        public override RestaurantModel Edit(int id)
        {
            var a = dbcontext.RestaurantTab.Find(id);
            return a;
        }
        public override bool Delete(int id)
        {
            var a = dbcontext.RestaurantTab.Find(id);
            if (a == null)
            {
                return false;
            }
            else
            {
                dbcontext.Remove(a);
                dbcontext.SaveChanges();
                return true;
            }
        }


        // For Player
        public override List<PlayerModel> PlayerIndex()
        {
            return dbcontext.PlayerTab.ToList();
        }
        public override PlayerModel PlayerEdit(int id)
        {
            var a = dbcontext.PlayerTab.Find(id);
            return a;
        }
        public override bool PlayerDelete(int id)
        {
            var a = dbcontext.PlayerTab.Find(id);
            if (a == null)
            {
                return false;
            }
            else
            {
                dbcontext.Remove(a);
                dbcontext.SaveChanges();
                return true;
            }
        }

       

        public override List<RestaurantModel> ResturantByName(string name)
        {
            var obj = dbcontext.RestaurantTab.Where(Models => Models.Name == name).ToList();
            return obj;
        }

        public override List<PlayerModel> PlayerByName(string name)
        {
            var obj1 = dbcontext.PlayerTab.Where(Models => Models.Name == name).ToList();
            return obj1;
        }

        public override List<FavRestraurantPlayer> getall()
        {
            List<FavRestraurantPlayer> allplayer = new List<FavRestraurantPlayer>();
            var res = (from player in dbcontext.PlayerTab
                       from Fav in dbcontext.RPLinkTab
                       from restaurent in dbcontext.RestaurantTab
                       where player.PlayerId == Fav.PlayerId
                       && restaurent.RestaurantId == Fav.RestaurantId
                       where player.PlayerId > 0
                       select new
                       {
                           player = player,
                           restaurent = restaurent,
                           //Fav = /*Fav*/
                       }).ToList();

            foreach (var item in res)
            {
                FavRestraurantPlayer obj = new FavRestraurantPlayer();

                obj.player = item.player;
                obj.restaurent = item.restaurent;
                //obj.Fav = item.Fav;
                allplayer.Add(obj);
            }
            return allplayer;
        }

        public override bool RestroPlayerLink(RestroPlayerLinkModel Obj)
        {

            return true;

        }

       
        public override FavRestraurantPlayer FvtplyRest(string name, bool status = true)
        {
            FavRestraurantPlayer lt = new FavRestraurantPlayer();

            var playerDetail = dbcontext.PlayerTab.Where(x => x.Name == name).ToList();
            if (playerDetail != null)
            {
                var playerID = playerDetail.FirstOrDefault().PlayerId;

                var resDetail = (from map in dbcontext.RPLinkTab
                                 join res in dbcontext.RestaurantTab
                                 on map.RestaurantId equals res.RestaurantId
                                 where map.PlayerId == playerID
                                 select new RestaurantModel
                                 {
                                     RestaurantId = map.RestaurantId,
                                     Name = res.Name
                                 }).ToList();

                //lt.player = playerDetail;
                //lt.restaurent = resDetail;
            }
            return lt;

        }

    }
}

