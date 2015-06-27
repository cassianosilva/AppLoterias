using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTrabalhoG2.Entities
{
    public class ConcursoTimemania
    {
        public int nConcurso { get; private set; }

        public string dataConcurso { get; private set; }

        public string cidadeConcurso { get; private set; }

        public string localConcurso { get; private set; }

        public List<int> NumerosSorteados { get; private set; }

        public string valorAcumulado { get; private set; }

        public GanhadorConcurso SeteAcertos { get; private set; }

        public GanhadorConcurso SeisAcertos { get; private set; }

        public GanhadorConcurso CincoAcertos { get; private set; }

        public GanhadorConcurso QuatroAcertos { get; private set; }

        public GanhadorConcurso TresAcertos { get; private set; }

        public string nomeTimeCoracao { get; private set; }

        public GanhadorConcurso AcertosTimeCoracao { get; private set; }

        public string arrecadacaoTotal { get; private set; }

        public ProximoConcurso proxConcTM { get; private set; }

        public ConcursoEspecial concFinalCinco { get; private set; }

        public void lerDadosJson(JObject pJsonObject)
        {
            JObject jsSorteio = (JObject)pJsonObject["concurso"];
            JArray jsNumsSorteados = (JArray)jsSorteio["numeros_sorteados"];
            JObject jsGanhadores = (JObject)jsSorteio["premiacao"];
            JObject jsTimeCoracao = (JObject)jsSorteio["time_coracao"];

            this.nConcurso = (int)jsSorteio["numero"];
            this.dataConcurso = (string)jsSorteio["data"];
            this.cidadeConcurso = (string)jsSorteio["cidade"];
            this.localConcurso = (string)jsSorteio["local"];
            this.valorAcumulado = (string)jsSorteio["valor_acumulado"];
            this.NumerosSorteados = jsNumsSorteados.ToObject<List<int>>();

            JObject jsGanhador = (JObject)jsGanhadores["acertos_7"];

            this.SeteAcertos = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]

            };

            jsGanhador = (JObject)jsGanhadores["acertos_6"];

            this.SeisAcertos = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            jsGanhador = (JObject)jsGanhadores["acertos_5"];

            this.CincoAcertos = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            jsGanhador = (JObject)jsGanhadores["acertos_4"];

            this.QuatroAcertos = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            jsGanhador = (JObject)jsGanhadores["acertos_3"];

            this.TresAcertos = new GanhadorConcurso
            {
                nGanhadores = (string)jsGanhador["ganhadores"],
                valorPago = (string)jsGanhador["valor_pago"]
            };

            this.nomeTimeCoracao = (string)jsTimeCoracao["time"];

            this.AcertosTimeCoracao = new GanhadorConcurso
            {
                nGanhadores = (string)jsTimeCoracao["ganhadores"],
                valorPago = (string)jsTimeCoracao["valor_pago"]
            };

            this.arrecadacaoTotal = (string)jsSorteio["arrecadacao_total"];

            JObject proxCon = (JObject)pJsonObject["proximo_concurso"];

            this.proxConcTM = new ProximoConcurso
            {
                dataProxConcurso = (string)proxCon["data"],
                valorEstimado = (string)proxCon["valor_estimado"]
            };

            JObject concFinal = (JObject)pJsonObject["concurso_final_cinco"];

            this.concFinalCinco = new ConcursoEspecial
            {
                numConc = (int)concFinal["numero"],
                valorAcum = (string)concFinal["valor_acumulado"]
            };
        }
    }
}
