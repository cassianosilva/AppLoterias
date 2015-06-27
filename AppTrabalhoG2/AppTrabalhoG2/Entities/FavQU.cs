using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Entities
{
    [Table(Name="FavoritosQuina")]
    public class FavQU
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

        public void lerDados(ConcursoQuina pQU)
        {
            if (pQU != null)
            {
                this.nConcurso = pQU.nConcurso;
                this.DataConcurso = pQU.dataConcurso;
                this.FirstNum = pQU.NumerosSorteados.ElementAt(0);
                this.SecondNum = pQU.NumerosSorteados.ElementAt(1);
                this.ThirdNum = pQU.NumerosSorteados.ElementAt(2);
                this.FourthNum = pQU.NumerosSorteados.ElementAt(3);
                this.FifthNum = pQU.NumerosSorteados.ElementAt(4);
            }
        }
    }
}
