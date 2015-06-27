using AppTrabalhoG2.DB;
using AppTrabalhoG2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Repositórios
{
    public class FavMSRep
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

        public static List<FavMS> Get()
        {
            DataBase db = GetDataBase();

            var query = from megasena in db.FavoritosMegaSena orderby megasena.nConcurso select megasena;

            List<FavMS> favoritosMS = new List<FavMS>(query.AsEnumerable());
            return favoritosMS;
        }

        public static void Inserir(FavMS pFavMS)
        {
            DataBase db = GetDataBase();

            db.FavoritosMegaSena.InsertOnSubmit(pFavMS);
            db.SubmitChanges();
        }

        public static void Delete(FavMS pFavMS)
        {
            DataBase db = GetDataBase();

            var query = from ms in db.FavoritosMegaSena
                        where ms.Id == pFavMS.Id
                        select ms;
            db.FavoritosMegaSena.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();
        }
    }
}
