using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    class Carte_Achat : Case
    {
        #region Variables
        private string type; // Gare, Ville
        private string nom; // Le nom de la carte
        private string couleur; // bleu, rouge, violet...
        private bool estAchete; // Si la carte est acheté
        private Joueur joueurAchat; // Le joueur qui a acheté la carte
        private int prix; // Prix d'achat
        private int loyer; // Prix du loyer
        private int batiment; // Pour les batiments (sans rien : 0 || maisons : 1,2,3,4 || hotel : 5)
        private double[] LoyerBatiment; // int[200,600,1400,1700,2000]
        #endregion

        public Carte_Achat(string unType, string unNom, string uneCouleur, int unPrix, int unLoyer)
        {
            type = unType; 
            nom = unNom; 
            couleur = uneCouleur;
            estAchete = false;
            joueurAchat = null;
            prix = unPrix;
            loyer = unLoyer;
            LoyerBatiment = new double[5] {unPrix/2, unPrix*1.50, unPrix*3.50, unPrix*4.25, unPrix*5};
            batiment = 0;
        }

        #region Getters
        public override int GetNbBatiments()
        {
            return batiment;
        }

        public override double[] GetLoyerBatiment()
        {
            return LoyerBatiment;
        }

        public override int GetPrix()
        {
            return prix;
        }

        public override int GetLoyer()
        {
            return loyer;
        }

        public override Joueur GetProprio()
        {
            return joueurAchat;
        }

        public override bool EstAcheter()
        {
            return estAchete;
        }

        public override string[] GetInformations()
        {
            string[] tab = new string[]
            {
                type, nom, prix.ToString()
            };
            return tab;
        }

        public override string GetCouleur()
        {
            return couleur;
        }

        public override string AfficherNom()
        {
            return nom;
        }

        public override string AfficherType()
        {
            return type;
        }
        #endregion

        #region Setters
        public override void SetProprio(Joueur unJoueur)
        {
            joueurAchat = unJoueur;
        }

        public override void SetAcheter(bool result)
        {
            estAchete = result;
        }

        public override void SetLoyer(int unLoyer)
        {
            loyer = unLoyer;
        }

        public override void SetNbBat(int unInt)
        {
            batiment = unInt;
        }
        #endregion

        #region Méthodes
        public override void afficherCase()
        {
            Console.WriteLine(type + " - " + nom + " - " + prix + "$ - " + loyer + "$ - " + batiment + " batiment(s)");
        }

        public override string afficherAcheteur()
        {
            if (joueurAchat == null)
            {
                return "    LIBRE      ";
            }
            else if (joueurAchat.GetNom() == "Joueur")
            {
                return "    Joueur     ";
            }
            else
            {
                return "  COMPUTER " + (joueurAchat.GetId() - 1) + "   ";
            }
        }
        #endregion

    }
}
