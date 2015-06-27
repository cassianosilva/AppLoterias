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
using AppTrabalhoG2.Repositórios;
using System.Reflection;

namespace AppTrabalhoG2.Pages
{
    public partial class FavPage : PhoneApplicationPage
    {
        FavMS MegaSena;
        FavQU Quina;
        FavTM Timemania;

        public FavPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (NavigationContext.QueryString.ContainsKey("item"))
            {
                var index = NavigationContext.QueryString["item"];
                var indexParsed = int.Parse(index);
                pvtFavs.SelectedIndex = indexParsed;
            }
            Refresh();
        }

        private void Refresh()
        {
            List<FavMS> listaFavMS = Repositórios.FavMSRep.Get();
            lstMegaSena.ItemsSource = listaFavMS;
            
            List<FavQU> listaFavQU = Repositórios.FavQURep.Get();
            lstQuina.ItemsSource = listaFavQU;

            List<FavTM> listaFavTM = Repositórios.FavTMRep.Get();
            lstTimemania.ItemsSource = listaFavTM;
        }

        private void MegaSena_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MegaSena = (sender as ListBox).SelectedItem as FavMS;
        }

        private void Quina_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Quina = (sender as ListBox).SelectedItem as FavQU;
        }

        private void Timemania_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Timemania = (sender as ListBox).SelectedItem as FavTM;
        }

        private void appBarDelete_Click(object sender, EventArgs e)
        {
            if (pvtFavs.SelectedIndex == 0)
            {
                try
                {
                    if ((MessageBox.Show("Deseja excluir o sorteio nº " + MegaSena.nConcurso + " dos favoritos?")) == MessageBoxResult.OK)
                    {
                        FavMSRep.Delete(MegaSena);
                        Refresh();
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Selecione um sorteio para excluir.");
                }
            }
            else if (pvtFavs.SelectedIndex == 1)
            {
                try
                {
                    if ((MessageBox.Show("Deseja excluir o sorteio nº " + Quina.nConcurso + " dos favoritos?")) == MessageBoxResult.OK)
                    {
                       FavQURep.Delete(Quina);
                       Refresh();
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Selecione um sorteio para excluir.");
                }
            }
            else
            {
                try
                {
                    if ((MessageBox.Show("Deseja excluir o sorteio nº " + Timemania.nConcurso + " dos favoritos?")) == MessageBoxResult.OK)
                    {
                        FavTMRep.Delete(Timemania);
                        Refresh();
                    }
                }
                catch (NullReferenceException)
                {
                    MessageBox.Show("Selecione um sorteio para excluir.");
                }
            }
        }
    }
}