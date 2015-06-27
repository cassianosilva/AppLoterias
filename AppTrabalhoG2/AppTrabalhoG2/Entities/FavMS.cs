using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Entities
{
    [Table(Name = "FavoritosMegaSena")]
    public class FavMS
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public int nConcurso { get; private set; }

        [Column(CanBeNull = false)]
        public string DataConcurso { get; private set; }

        [Column(CanBeNull = false)]
        public int FirstNum { get; private set; }

        [Column(CanBeNull = false)]
        public int SecondNum { get; private set; }

        [Column(CanBeNull = false)]
        public int ThirdNum { get; private set; }

        [Column(CanBeNull = false)]
        public int FourthNum { get; private set; }

        [Column(CanBeNull = false)]
        public int FifthNum { get; private set; }

        [Column(CanBeNull = false)]
        public int SixthNum { get; private set; }

        public void lerDados(ConcursoMegaSena pMS)
        {
            if (pMS != null)
            {
                this.nConcurso = pMS.nConcurso;
                this.DataConcurso = pMS.dataConcurso;
                this.FirstNum = pMS.NumerosSorteados.ElementAt(0);
                this.SecondNum = pMS.NumerosSorteados.ElementAt(1);
                this.ThirdNum = pMS.NumerosSorteados.ElementAt(2);
                this.FourthNum = pMS.NumerosSorteados.ElementAt(3);
                this.FifthNum = pMS.NumerosSorteados.ElementAt(4);
                this.SixthNum = pMS.NumerosSorteados.ElementAt(5);
            }
        }
    }
}
