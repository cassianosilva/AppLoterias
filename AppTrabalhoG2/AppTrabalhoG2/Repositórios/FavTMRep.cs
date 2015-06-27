using AppTrabalhoG2.DB;
using AppTrabalhoG2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Repositórios
{
    public class FavTMRep
    {
        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();

            if (!db.DatabaseExists())
            {
                db.CreateDatabase();
            }

            return db;
        }

        public static List<FavTM> Get()
        {
            DataBase db = GetDataBase();
            var query = from timemania in db.FavoritosTimemania orderby timemania.nConcurso select timemania;

            List<FavTM> favoritosTM = new List<FavTM>(query.AsEnumerable());
            return favoritosTM;
        }

        public static void Inserir(FavTM pFavTM)
        {
            DataBase db = GetDataBase();

            db.FavoritosTimemania.InsertOnSubmit(pFavTM);
            db.SubmitChanges();
        }

        public static void Delete(FavTM pFavTM)
        {
            DataBase db = GetDataBase();

            var query = from timemania in db.FavoritosTimemania 
                        where timemania.Id == pFavTM.Id 
                        select timemania;

            db.FavoritosTimemania.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }
    }
}
