using AppTrabalhoG2.DB;
using AppTrabalhoG2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AppTrabalhoG2.Repositórios
{
    public class FavQURep
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

        public static List<FavQU> Get()
        {
            DataBase db = GetDataBase();

            var query = from quina in db.FavoritosQuina orderby quina.nConcurso select quina;

            List<FavQU> favoritosQU = new List<FavQU>(query.AsEnumerable());
            return favoritosQU;
        }

        public static void Inserir(FavQU pFavQU)
        {
            DataBase db = GetDataBase();

            db.FavoritosQuina.InsertOnSubmit(pFavQU);
            db.SubmitChanges();
        }

        public static void Delete(FavQU pFavQU)
        {
            DataBase db = GetDataBase();

            var query = from quina in db.FavoritosQuina 
                        where quina.Id == pFavQU.Id 
                        select quina;
            db.FavoritosQuina.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }
    }
}
