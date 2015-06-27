using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using AppTrabalhoG2.Entities;
using Newtonsoft.Json.Linq;
using AppTrabalhoG2.Repositórios;
using System.Reflection;
using System.Net.NetworkInformation;

namespace AppTrabalhoG2
{
    public partial class MainPage : PhoneApplicationPage
    {
        ConcursoQuina SorteioQUDoJson = new ConcursoQuina();
        ConcursoMegaSena SorteioMSDoJson = new ConcursoMegaSena();
        ConcursoTimemania SorteioTMDoJson = new ConcursoTimemania();
        bool carregouMS = false;
        bool carregouTM = false;
        bool carregouQU = false;

        public MainPage()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
            {
                InitializeComponent();
               
            }
            else
            {
                MessageBox.Show("Você não está conectado a Internet.\nConecte-se e tente novamente.");
                Application.Current.Terminate();
            }

        }

        private void ConsultaSorteioMS()
        {
            WebClient dadosSorteioMS = new WebClient();

            dadosSorteioMS.DownloadStringCompleted += new DownloadStringCompletedEventHandler(dadosSorteioMS_DownloadStringCompleted);
            dadosSorteioMS.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
            dadosSorteioMS.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/loterias/megasena/json"));
        }

        private void ConsultaSorteioQU()
        {
            WebClient dadosSorteioQU = new WebClient();

            dadosSorteioQU.DownloadStringCompleted += new DownloadStringCompletedEventHandler(dadosSorteioQU_DownloadStringCompleted);
            dadosSorteioQU.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
            dadosSorteioQU.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/loterias/quina/json"));
        }

        private void ConsultaSorteioTM()
        {
            WebClient dadosSorteioTM = new WebClient();

            dadosSorteioTM.DownloadStringCompleted += new DownloadStringCompletedEventHandler(dadosSorteioTM_DownloadStringCompleted);
            dadosSorteioTM.Encoding = System.Text.Encoding.GetEncoding("UTF-8");
            dadosSorteioTM.DownloadStringAsync(new Uri(@"http://developers.agenciaideias.com.br/loterias/timemania/json"));
        }

        private void dadosSorteioQU_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                ParseJsonQU(e.Result);
                if (SorteioQUDoJson.cidadeConcurso != null)
                {
                    setTextsJsonQU();
                    carregouQU = true;
                }
            }
            catch (TargetInvocationException)
            {
                MessageBox.Show("Você não está conectado a Internet.\nConecte-se e tente novamente.");
            }
        }

        private void dadosSorteioTM_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                ParseJsonTM(e.Result);
                if (SorteioTMDoJson.cidadeConcurso != null)
                {
                    setTextsJsonTM();
                    carregouTM = true;
                }
            }
            catch (TargetInvocationException)
            {
                MessageBox.Show("Você não está conectado a Internet.\nConecte-se e tente novamente.");
            }
        }

        private void dadosSorteioMS_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                ParseJsonMS(e.Result);
                if (SorteioMSDoJson.cidadeConcurso != null)
                {
                    setTextsJsonMS();
                    carregouMS = true;
                }
            }
            catch (TargetInvocationException)
            {
                MessageBox.Show("Você não está conectado a Internet.\nConecte-se e tente novamente.");
            }
        }

        private ConcursoMegaSena ParseJsonMS(string pJson)
        {
            if (pJson != null)
            {
                JObject jobject = JObject.Parse(pJson);
                
                SorteioMSDoJson.lerDadosJson(jobject);
            }
            return SorteioMSDoJson;
        }

        private ConcursoQuina ParseJsonQU(string pJson)
        {
            if (pJson != null)
            {
                JObject jobject = JObject.Parse(pJson);

                SorteioQUDoJson.lerDadosJson(jobject);
            }
            return SorteioQUDoJson;
        }

        private ConcursoTimemania ParseJsonTM(string pJson)
        {
            if (pJson != null)
            {
                JObject jobject = JObject.Parse(pJson);

                SorteioTMDoJson.lerDadosJson(jobject);
            }
            return SorteioTMDoJson;
        }

        private void setTextsJsonMS()
        {
            titleConcursoMS.Text += SorteioMSDoJson.nConcurso.ToString();
            txtDataSorteio.Text += SorteioMSDoJson.dataConcurso;
            txtCidadeSorteioMS.Text += SorteioMSDoJson.cidadeConcurso;
            txtLocalSorteioMS.Text += SorteioMSDoJson.localConcurso;
            txtEstPremioMS.Text += SorteioMSDoJson.proxConcMS.valorEstimado;
            txtDataProxMS.Text += SorteioMSDoJson.proxConcMS.dataProxConcurso;
            txtValorAcumMS.Text += SorteioMSDoJson.valorAcumulado;

            if (SorteioMSDoJson.valorAcumulado != "0,00")
            {
                SpAcumulouMS.Visibility = System.Windows.Visibility.Visible;
            }

            txtN1MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(0).ToString();
            txtN2MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(1).ToString();
            txtN3MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(2).ToString();
            txtN4MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(3).ToString();
            txtN5MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(4).ToString();
            txtN6MS.Text = SorteioMSDoJson.NumerosSorteados.ElementAt(5).ToString();

            txtNumGanhadorSena.Text = SorteioMSDoJson.Sena.nGanhadores;
            txtNumGanhadorQuina.Text = SorteioMSDoJson.Quina.nGanhadores;
            txtNumGanhadorQuadra.Text = SorteioMSDoJson.Quadra.nGanhadores;

            txtValorGanhadorSena.Text = SorteioMSDoJson.Sena.valorPago;
            txtValorGanhadorQuina.Text = SorteioMSDoJson.Quina.valorPago;
            txtValorGanhadorQuadra.Text = SorteioMSDoJson.Quadra.valorPago;

            txtArrecTotalMS.Text += SorteioMSDoJson.arrecadacaoTotal;
            txtValorAcumProxMS.Text += SorteioMSDoJson.proxConcMS.valorEstimado;
            txtValorAcumMSVirada.Text += SorteioMSDoJson.valorAcumMegaVirada;
        }

        private void setTextsJsonQU()
        {
            titleConcursoQU.Text += SorteioQUDoJson.nConcurso.ToString();
            txtDataSorteioQU.Text += SorteioQUDoJson.dataConcurso;
            txtCidadeSorteioQU.Text += SorteioQUDoJson.cidadeConcurso;
            txtLocalSorteioQU.Text += SorteioQUDoJson.localConcurso;
            txtEstPremioQU.Text += SorteioQUDoJson.proxConcMS.valorEstimado;
            txtDataProxQU.Text += SorteioQUDoJson.proxConcMS.dataProxConcurso;
            txtValorAcumQU.Text += SorteioQUDoJson.valorAcumulado;

            if (SorteioQUDoJson.valorAcumulado != "0,00")
            {
                SpAcumulouQU.Visibility = System.Windows.Visibility.Visible;
            }

            txtN1QU.Text = SorteioQUDoJson.NumerosSorteados.ElementAt(0).ToString();
            txtN2QU.Text = SorteioQUDoJson.NumerosSorteados.ElementAt(1).ToString();
            txtN3QU.Text = SorteioQUDoJson.NumerosSorteados.ElementAt(2).ToString();
            txtN4QU.Text = SorteioQUDoJson.NumerosSorteados.ElementAt(3).ToString();
            txtN5QU.Text = SorteioQUDoJson.NumerosSorteados.ElementAt(4).ToString();

            txtNumGanhadorQuinaQU.Text = SorteioQUDoJson.Quina.nGanhadores;
            txtNumGanhadorQuadraQU.Text = SorteioQUDoJson.Quadra.nGanhadores;
            txtNumGanhadorTernoQU.Text = SorteioQUDoJson.Terno.nGanhadores;

            txtValorGanhadorQuinaQU.Text = SorteioQUDoJson.Quina.valorPago;
            txtValorGanhadorQuadraQU.Text = SorteioQUDoJson.Quadra.valorPago;
            txtValorGanhadorTernoQU.Text = SorteioQUDoJson.Terno.valorPago;

            txtArrecTotalQU.Text += SorteioQUDoJson.arrecadacaoTotal;
            txtValorAcumProxQU.Text += SorteioQUDoJson.valorAcumEspSJ;
        }

        private void setTextsJsonTM()
        {
            titleConcursoTM.Text += SorteioTMDoJson.nConcurso.ToString();
            txtDataSorteioTM.Text += SorteioTMDoJson.dataConcurso;
            txtCidadeSorteioTM.Text += SorteioTMDoJson.cidadeConcurso;
            txtLocalSorteioTM.Text += SorteioTMDoJson.localConcurso;
            txtEstPremioTM.Text += SorteioTMDoJson.proxConcTM.valorEstimado;
            txtDataProxTM.Text += SorteioTMDoJson.proxConcTM.dataProxConcurso;
            txtValorAcumTM.Text += SorteioTMDoJson.valorAcumulado;

            if (SorteioTMDoJson.valorAcumulado != "0,00")
            {
                SpAcumulouTM.Visibility = System.Windows.Visibility.Visible;
            }

            txtN1TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(0).ToString();
            txtN2TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(1).ToString();
            txtN3TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(2).ToString();
            txtN4TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(3).ToString();
            txtN5TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(4).ToString();
            txtN5TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(5).ToString();
            txtN6TM.Text = SorteioTMDoJson.NumerosSorteados.ElementAt(6).ToString();

            txtNumGanhador7TM.Text = SorteioTMDoJson.SeteAcertos.nGanhadores;
            txtNumGanhador6TM.Text = SorteioTMDoJson.SeisAcertos.nGanhadores;
            txtNumGanhador5TM.Text = SorteioTMDoJson.CincoAcertos.nGanhadores;
            txtNumGanhador4TM.Text = SorteioTMDoJson.QuatroAcertos.nGanhadores;
            txtNumGanhador3TM.Text = SorteioTMDoJson.TresAcertos.nGanhadores;

            txtValorGanhador7TM.Text = SorteioTMDoJson.SeteAcertos.valorPago;
            txtValorGanhador6TM.Text = SorteioTMDoJson.SeisAcertos.valorPago;
            txtValorGanhador5TM.Text = SorteioTMDoJson.CincoAcertos.valorPago;
            txtValorGanhador4TM.Text = SorteioTMDoJson.QuatroAcertos.valorPago;
            txtValorGanhador3TM.Text = SorteioTMDoJson.TresAcertos.valorPago;

            txtArrecTotalTM.Text += SorteioTMDoJson.arrecadacaoTotal;

            txtNomeTimeTM.Text += SorteioTMDoJson.nomeTimeCoracao;
            txtGanhadoresTimeTM.Text += SorteioTMDoJson.AcertosTimeCoracao.nGanhadores;
            txtValorTimeTM.Text += SorteioTMDoJson.AcertosTimeCoracao.valorPago;

            txtArrecTotalQU.Text += SorteioQUDoJson.arrecadacaoTotal;
            txtValorAcumProxTM.Text += SorteioTMDoJson.concFinalCinco.valorAcum;
        }

        private void LoadedPivotItem(object sender, PivotItemEventArgs e)
        {
            if (e.Item == MegaSena && !carregouMS)
            {
                ConsultaSorteioMS();
            }
            else if (e.Item == Quina && !carregouQU)
            {
                ConsultaSorteioQU();
            }
            else if (e.Item == Timemania && !carregouTM)
            {
                ConsultaSorteioTM();
            }
        }

        private void appBarAddFav_Click(object sender, EventArgs e)
        {
            if (pvtSorteios.SelectedIndex == 0)
            {
                FavMS addFavMs = new FavMS();

                if (SorteioMSDoJson != null)
                {
                    if (MessageBox.Show("Deseja adicionar este sorteio aos favoritos?") == MessageBoxResult.OK)
                    {
                        addFavMs.lerDados(SorteioMSDoJson);
                        FavMSRep.Inserir(addFavMs);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar.");
                }
            }
            else if (pvtSorteios.SelectedIndex == 1)
            {
                FavQU addFavQu = new FavQU();

                if (SorteioQUDoJson != null)
                {
                    if (MessageBox.Show("Deseja adicionar este sorteio aos favoritos?") == MessageBoxResult.OK)
                    {
                        addFavQu.lerDados(SorteioQUDoJson);
                        FavQURep.Inserir(addFavQu);
                    }
                }
                else
                {
                    MessageBox.Show("Não foi possível adicionar.");
                }
            }
            else
            {
                FavTM addFavTm = new FavTM();

                if (SorteioTMDoJson != null)
                {
                    if (MessageBox.Show("Deseja adicionar este sorteio aos favoritos?") == MessageBoxResult.OK)
                    {
                        addFavTm.lerDados(SorteioTMDoJson);
                        FavTMRep.Inserir(addFavTm);
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível adicionar.");
                    }
                }
            }
        }

        private void appBarVerFav_Click(object sender, EventArgs e)
        {
            if (pvtSorteios.SelectedIndex == 0)
            {
                NavigationService.Navigate(new Uri("/Pages/FavPage.xaml?item=0", UriKind.Relative));
            }
            else if (pvtSorteios.SelectedIndex == 1)
            {
                NavigationService.Navigate(new Uri("/Pages/FavPage.xaml?item=1", UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Pages/FavPage.xaml?item=2", UriKind.Relative));
            }
        }

        private void appBarSobre_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Pages/SobreAppPage.xaml",UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {

            while (NavigationService.BackStack.Any())
            {
                NavigationService.RemoveBackEntry();
            }

            base.OnBackKeyPress(e);
        }
    }
}