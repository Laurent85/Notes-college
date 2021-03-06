﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace Notes_collège
{
    /// <summary>
    /// Logique d'interaction pour Bilan_Année.xaml
    /// </summary>
    public partial class Bilan_Année
    {
        public Bilan_Année()
        {
            InitializeComponent();
        }

        private void Bilan_Loaded(object sender, RoutedEventArgs e)
        {
            //Titre.Content = "Bilan - " + Principal.classe;
            classe.SelectedIndex = Principal.index_classe;
            classe.BorderBrush = Brushes.Transparent;

            try
            {
                Lecture_Moyenne("Baptiste", Principal.classe);
            }
            catch
            {
                // ignored
            }
            try
            {
                Lecture_Moyenne("Justine", Principal.classe);
            }
            catch
            {
                // ignored
            }
            try
            {
                Lecture_Moyenne("Emilien", Principal.classe);
            }
            catch
            {
                // ignored
            }
        }

        private void classe_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            effacer();
            //Titre.Content = "Bilan - " + classe.SelectedValue;

            try
            {
                Lecture_Moyenne("Baptiste", classe.SelectedValue.ToString());
            }
            catch
            {
                // ignored
            }
            try
            {
                Lecture_Moyenne("Justine", classe.SelectedValue.ToString());
            }
            catch
            {
                // ignored
            }
            try
            {
                Lecture_Moyenne("Emilien", classe.SelectedValue.ToString());
            }
            catch
            {
                // ignored
            }
        }

        private void classe_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> data = new List<string>();
            data.Add("6ème");
            data.Add("5ème");
            data.Add("4ème");
            data.Add("3ème");
            var comboBox = sender as ComboBox;
            if (comboBox != null) comboBox.ItemsSource = data;
        }

        private void Lecture_Moyenne(string prenom, string classe)
        {
            Label moyenne1 = (Label)this.FindName("moy1_" + prenom);
            Label moyenne2 = (Label)this.FindName("moy2_" + prenom);
            Label moyenne3 = (Label)this.FindName("moy3_" + prenom);
            Label moyenne1Classe = (Label)this.FindName("moy1_classe_" + prenom);
            Label moyenne2Classe = (Label)this.FindName("moy2_classe_" + prenom);
            Label moyenne3Classe = (Label)this.FindName("moy3_classe_" + prenom);
            Label moyenneAnnee = (Label)this.FindName("moy_annee_" + prenom);
            Label moyenneAnneeClasse = (Label)this.FindName("moy_annee_classe_" + prenom);

            LireMoyennesEleves lireMoyennes = new LireMoyennesEleves();

            lireMoyennes.Lecture_moyennes(prenom, classe);
            moyenne1.Content = lireMoyennes.Tri1.Content;
            moyenne2.Content = lireMoyennes.Tri2.Content;
            moyenne3.Content = lireMoyennes.Tri3.Content;
            moyenne1Classe.Content = lireMoyennes.Tri1Classe.Content;
            moyenne2Classe.Content = lireMoyennes.Tri2Classe.Content;
            moyenne3Classe.Content = lireMoyennes.Tri3Classe.Content;

            lireMoyennes.Calcul_moyenne_générale(prenom, classe);
            moyenneAnnee.Content = lireMoyennes.Annee.Content;
            moyenneAnneeClasse.Content = lireMoyennes.AnneeClasse.Content;

            if (((Convert.ToDouble(moyenne1.Content)) > (Convert.ToDouble(moyenne2.Content))) &&
                     (moyenne1.Content.ToString() != "") && (moyenne2.Content.ToString() != ""))
            {
                Afficher_fleche("Régression", prenom, "1");
            }
            if (((Convert.ToDouble(moyenne1.Content)) < (Convert.ToDouble(moyenne2.Content))) &&
                    (moyenne1.Content.ToString() != "") && (moyenne2.Content.ToString() != ""))
            {
                Afficher_fleche("Progression", prenom, "1");
            }
            if (moyenne2.Content.ToString() == "")
            { Supprimer_fleche(prenom, "1"); }

            if (((Convert.ToDouble(moyenne2.Content)) > (Convert.ToDouble(moyenne3.Content))) &&
                    (moyenne2.Content.ToString() != "") && (moyenne3.Content.ToString() != ""))
            {
                Afficher_fleche("Régression", prenom, "2");
            }
            if (((Convert.ToDouble(moyenne2.Content)) < (Convert.ToDouble(moyenne3.Content))) &&
                    (moyenne2.Content.ToString() != "") && (moyenne3.Content.ToString() != ""))
            {
                Afficher_fleche("Progression", prenom, "2");
            }
            if (moyenne3.Content.ToString() == "")
            { Supprimer_fleche(prenom, "2"); }

            lireMoyennes.Tri1.Content = "";
            lireMoyennes.Tri2.Content = "";
            lireMoyennes.Tri3.Content = "";
            lireMoyennes.Tri1Classe.Content = "";
            lireMoyennes.Tri2Classe.Content = "";
            lireMoyennes.Tri3Classe.Content = "";
        }

        private void Afficher_fleche(string progression, string prenom, string trimestre)
        {
            Image Fleche = (Image)this.FindName("Fleche" + trimestre + "_" + prenom);
            string chemin = "Ressources\\" + progression.ToString() + ".png";
            Fleche.Source = new BitmapImage(new Uri(@chemin, UriKind.Relative));
        }

        private void Supprimer_fleche(string prenom, string trimestre)
        {
            Image Fleche = (Image)this.FindName("Fleche" + trimestre + "_" + prenom);
            Fleche.Source = null;
        }

        private void effacer()
        {
            moy1_Baptiste.Content = "";
            moy1_Justine.Content = "";
            moy1_Emilien.Content = "";
            moy2_Baptiste.Content = "";
            moy2_Justine.Content = "";
            moy2_Emilien.Content = "";
            moy3_Baptiste.Content = "";
            moy3_Justine.Content = "";
            moy3_Emilien.Content = "";
            moy_annee_Baptiste.Content = "";
            moy_annee_classe_Baptiste.Content = "";
            moy_annee_Justine.Content = "";
            moy_annee_classe_Justine.Content = "";
            moy_annee_Emilien.Content = "";
            moy_annee_classe_Emilien.Content = "";
            Fleche1_Baptiste.Source = null;
            Fleche2_Baptiste.Source = null;
            Fleche1_Justine.Source = null;
            Fleche2_Justine.Source = null;
            Fleche1_Emilien.Source = null;
            Fleche2_Emilien.Source = null;
        }
    }
}