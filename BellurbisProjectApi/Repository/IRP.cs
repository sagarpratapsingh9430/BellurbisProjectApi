using Microsoft.EntityFrameworkCore;
using BellurbisProjectApi.Models;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BellurbisProjectApi.Repository
{
    public interface IRP
    {

        PlayersFavRestroList FvtplyRest(string name, bool status = true);//1
        List<RestaurantModel> ResturantByName(string name);              //2
        List<PlayerModel> PlayerByName(string name);                     //3

        List<FavRestraurantPlayer> getall();                             //4

        List<RestaurantModel> Index();                                   //5
        List<PlayerModel> PlayerIndex();                                 //6

        bool Create(RestaurantModel emp);                                //7
        bool PlayerCreate(PlayerModel mac);                              //8

        RestaurantModel Edit(int id);                                    //9
        PlayerModel PlayerEdit(int id);                                  //10

        bool Delete(int id);                                             //11
        bool PlayerDelete(int id);                                       //12
        PlayersFavRestroList GetbyAge(string Name, int age);             //13
       
        // PlayersFavRestroList FvtplyRest(string name);                 //14
        // List<string> FvtplyRes(string name, bool status = true);
    }
    public abstract class RP : IRP
    {
        public abstract PlayersFavRestroList FvtplyRest(string name, bool status = true);//1

        public abstract List<RestaurantModel> ResturantByName(string name);//2
        public abstract List<PlayerModel> PlayerByName(string name);         //3
        public abstract List<FavRestraurantPlayer> getall();              //4


        public abstract List<RestaurantModel> Index();                   //5 
        public abstract List<PlayerModel> PlayerIndex();                 //6  


        public abstract bool Create(RestaurantModel emp);                //7  
        public abstract bool PlayerCreate(PlayerModel mac);               //8  


        public abstract RestaurantModel Edit(int id);                     //9
        public abstract PlayerModel PlayerEdit(int id);                   //10 


        public abstract bool Delete(int id);                             //11  
        public abstract bool PlayerDelete(int id);                        //12 

        public abstract PlayersFavRestroList GetbyAge(string Name, int age);//13

        // public abstract FavRestraurantPlayer FvtplyRest(string name);      //14 

        //public abstract List<string> FvtplyRes(string name, bool status = true);//15


    }

    public class RPRepository : RP
    {
        private readonly DBContext dbcontext = null;
        public RPRepository(DBContext _dbContxet)
        {
            dbcontext = _dbContxet;
        }

        public override PlayersFavRestroList FvtplyRest(string name, bool statuss)//1
        {
            PlayersFavRestroList lt = new PlayersFavRestroList();

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

                lt.player = playerDetail;
                lt.restaurent = resDetail;
            }
            return lt;

        }
        public override List<RestaurantModel> ResturantByName(string name)      //2
        {
            var obj = dbcontext.RestaurantTab.Where(Models => Models.Name == name).ToList();
            return obj;
        }

        public override List<PlayerModel> PlayerByName(string name)             //3
        {
            var obj1 = dbcontext.PlayerTab.Where(Models => Models.Name == name).ToList();
            return obj1;
        }


        public override List<RestaurantModel> Index()                           //4
        {
            return dbcontext.RestaurantTab.ToList();
        }

        public override List<PlayerModel> PlayerIndex()                         //5
        {
            return dbcontext.PlayerTab.ToList();
        }

        public override bool Create(RestaurantModel emp)                        //6
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


      
        public override bool PlayerCreate(PlayerModel mac)                           //7
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


        public override RestaurantModel Edit(int id)                //8
        {
            var a = dbcontext.RestaurantTab.Find(id);
            return a;
        }

        public override PlayerModel PlayerEdit(int id)              //9
        {
            var a = dbcontext.PlayerTab.Find(id);
            return a;
        }
        public override bool Delete(int id)                         //10
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


       
      
        public override bool PlayerDelete(int id)                     //11
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



       
        public override List<FavRestraurantPlayer> getall()                 //12
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

      
        public override PlayersFavRestroList GetbyAge(string Name, int age)   //13
        {
            PlayersFavRestroList lst = new PlayersFavRestroList();
            var RestaurantCollection = dbcontext.RestaurantTab.FirstOrDefault(x => x.Name == Name);
            List<PlayerModel> pares = new List<PlayerModel>();
            List<PlayerModel> set = new List<PlayerModel>();

            if (RestaurantCollection != null)
            {
                var restaurentId = RestaurantCollection.RestaurantId;

                var LinkDetail = dbcontext.RPLinkTab.Where(x => x.RestaurantId == restaurentId).ToList();
                foreach (var item in LinkDetail)
                {

                    var abc = dbcontext.PlayerTab.Where(x => x.PlayerId == item.PlayerId).FirstOrDefault();
                    set.Add(abc);

                }

                foreach (var item in set)
                {

                    var years = DateTime.Now.Year - Convert.ToDateTime(item.DOB).Year;

                    if (years >= age)
                    {
                        pares.Add(item);
                    }

                    years = 0;
                }
                List<FavRestraurantPlayer> res = new List<FavRestraurantPlayer>();
                var areas = (from player in dbcontext.PlayerTab
                             from restaurent in dbcontext.RestaurantTab
                             from Fav in dbcontext.RPLinkTab
                             where player.PlayerId == Fav.PlayerId
                             && restaurent.RestaurantId == Fav.RestaurantId
                             select new
                             {
                                 player = player,
                                 restaurent = restaurent,
                                 Fav = Fav
                             }).ToList();
                foreach (var item in areas)
                {
                    FavRestraurantPlayer obj1 = new FavRestraurantPlayer();

                    obj1.player = item.player;
                    obj1.restaurent = item.restaurent;
                    obj1.Fav = item.Fav;
                    res.Add(obj1);
                }


                lst.rest = RestaurantCollection;
                lst.player = pares;
            }

            return lst;
        }

    }
}