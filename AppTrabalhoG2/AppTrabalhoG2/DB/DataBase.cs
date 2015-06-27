using AppTrabalhoG2.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.DB
{
    class DataBase : DataContext
    {
        public static string DBConnectionString = "Data Source = 'isostore:sorteio.sdf'";

        public DataBase()
            : base(DBConnectionString)
        {}

        public Table<FavMS> FavoritosMegaSena
        {
            get { return this.GetTable<FavMS>(); }
        }

        public Table<FavQU> FavoritosQuina
        {
            get { return this.GetTable<FavQU>(); }
        }

        public Table<FavTM> FavoritosTimemania
        {
            get { return this.GetTable<FavTM>(); }
        }
    }
}
