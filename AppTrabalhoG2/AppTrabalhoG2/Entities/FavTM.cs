using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Entities
{
    [Table(Name = "FavoritosTimemania")]
    public class FavTM
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id { get; set; }

        [Column(CanBeNull = false)]
        public int nConcurso { get; set; }

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

        [Column(CanBeNull = false)]
        public int SeventhNum { get; private set; }

        public void lerDados(ConcursoTimemania pTM)
        {
            if (pTM != null)
            {
                this.nConcurso = pTM.nConcurso;
                this.DataConcurso = pTM.dataConcurso;
                this.FirstNum = pTM.NumerosSorteados.ElementAt(0);
                this.SecondNum = pTM.NumerosSorteados.ElementAt(1);
                this.ThirdNum = pTM.NumerosSorteados.ElementAt(2);
                this.FourthNum = pTM.NumerosSorteados.ElementAt(3);
                this.FifthNum = pTM.NumerosSorteados.ElementAt(4);
                this.SixthNum = pTM.NumerosSorteados.ElementAt(5);
                this.SeventhNum = pTM.NumerosSorteados.ElementAt(6);
            }
        }
    }
}
