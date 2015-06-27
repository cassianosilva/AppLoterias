using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Entities
{
    public class ConcursoQuina
    {
        public int nConcurso { get; private set; }

        public string dataConcurso { get; private set; }

        public string cidadeConcurso { get; private set; }

        public string localConcurso { get; private set; }

        public List<int> NumerosSorteados { get; private set; }

        public string valorAcumulado { get; private set; }

        public GanhadorConcurso Quina { get; private set; }

        public GanhadorConcurso Quadra { get; private set; }

        public GanhadorConcurso Terno { get; private set; }

        public string arrecadacaoTotal { get; private set; }

        public string valorAcumEspSJ { get; private set; }

        public ProximoConcurso proxConcMS { get; private set; }

        public void lerDadosJson(JObject pJsonObject)
        {
            JObject jsSorteio = (JObject)pJsonObject["concurso"];
            JArray jsNumsSorteados = (JArray)jsSorteio["numeros_sorteados"];
            JObject jsGanhadores = (JObject)jsSorteio["premiacao"];

            this.nConcurso = (int)jsSorteio["numero"];
            this.dataConcurso = (string)jsSorteio["data"];
            this.cidadeConcurso = (string)jsSorteio["cidade"];
            this.localConcurso = (string)jsSorteio["local"];
            this.valorAcumulado = (string)jsSorteio["valor_acumulado"];
            this.NumerosSorteados = jsNumsSorteados.ToObject<List<int>>();

            JObject jsGanhador = (JObject)jsGanhadores["quina"];

            this.Quina = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            jsGanhador = (JObject)jsGanhadores["quadra"];

            this.Quadra = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            jsGanhador = (JObject)jsGanhadores["terno"];

            this.Terno = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]

            };

            this.arrecadacaoTotal = (string)jsSorteio["arrecadacao_total"];

            JObject proxCon = (JObject)pJsonObject["proximo_concurso"];

            this.proxConcMS = new ProximoConcurso
            {
                dataProxConcurso = (string)proxCon["data"],
                valorEstimado = (string)proxCon["valor_estimado"]
            };

            this.valorAcumEspSJ = (string)pJsonObject["especial_sao_joao_valor_acumulado"];

        }    
    }
}
