/*
░░░░░██╗░█████╗░██╗░░░██╗███████╗██╗░░░██╗██████╗░  ░█████╗░██╗░░░░░░█████╗░░██████╗░██████╗
░░░░░██║██╔══██╗██║░░░██║██╔════╝██║░░░██║██╔══██╗  ██╔══██╗██║░░░░░██╔══██╗██╔════╝██╔════╝
░░░░░██║██║░░██║██║░░░██║█████╗░░██║░░░██║██████╔╝  ██║░░╚═╝██║░░░░░███████║╚█████╗░╚█████╗░
██╗░░██║██║░░██║██║░░░██║██╔══╝░░██║░░░██║██╔══██╗  ██║░░██╗██║░░░░░██╔══██║░╚═══██╗░╚═══██╗
╚█████╔╝╚█████╔╝╚██████╔╝███████╗╚██████╔╝██║░░██║  ╚█████╔╝███████╗██║░░██║██████╔╝██████╔╝
░╚════╝░░╚════╝░░╚═════╝░╚══════╝░╚═════╝░╚═╝░░╚═╝  ░╚════╝░╚══════╝╚═╝░░╚═╝╚═════╝░╚═════╝░
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    class Joueur
    {
        #region Variables
        private string nom;
        private int id; // Pour pouvoir admettre le rang de jeu (1,2,3,4)
        private int argent;
        private bool aJoue; // Vérifie si le joueur à déjà jouer
        private List<Case> lesCartesAchat; // Les cartes achat du joueur
        private bool sortiePrison; // Si le joueur a une carte de sortie de prison
        private int NbGares; // Indique combien de gare à le joueur pour le loyer
        private int position; // indique l'index de la position où le joueur se situe sur le plateau 0=>39
        private bool enPrison; // Indique si le joueur est en prison ou pas
        private int tourPrison; // Indique le nombre de tour en prison
        private bool faillite; // Indique si le joueur a fait faillite ou non
        private int nbMarron ;
        private int nbBleuClair ;
        private int nbRose ;
        private int nbOrange ;
        private int nbRouge ;
        private int nbJaune ;
        private int nbVert ;
        private int nbBleuFonce;
        private bool CoulMarron;
        private bool CoulBleuClair;
        private bool CoulRose;
        private bool CoulOrange;
        private bool CoulRouge;
        private bool CoulJaune;
        private bool CoulVert;
        private bool CoulBleuFonce;
        private List<String> ListeCouleur;
        #endregion

        public Joueur(string unNom, int unId) 
        {
            nom = unNom;
            id = unId;
            argent = 1750;
            aJoue = false;
            lesCartesAchat = new List<Case>();
            sortiePrison = false;
            NbGares = 0;
            position = 0;
            enPrison = false;
            tourPrison = 0;
            faillite = false;

            // Couleurs
            nbMarron = 0;
            nbBleuClair = 0;
            nbRose = 0;
            nbOrange = 0;
            nbRouge = 0;
            nbJaune = 0;
            nbVert = 0;
            nbBleuFonce = 0;

            CoulMarron = false;
            CoulBleuClair = false;
            CoulRose = false;
            CoulOrange = false;
            CoulRouge = false;
            CoulJaune = false;
            CoulVert = false;
            CoulBleuFonce = false;

            ListeCouleur = new List<String>();
            ListeCouleur.Add("Marron");
            ListeCouleur.Add("BleuClair");
            ListeCouleur.Add("Rose");
            ListeCouleur.Add("Orange");
            ListeCouleur.Add("Rouge");
            ListeCouleur.Add("Jaune");
            ListeCouleur.Add("Vert");
            ListeCouleur.Add("BleuFonce");
            ListeCouleur.Add("Noir");
            ListeCouleur.Add("Service");
        }

        #region Getters

        public int GetNbGares()
        {
            return NbGares;
        }

        public bool GetFaillite()
        {
            return faillite;
        }

        public bool aJouer()
        {
            return aJoue;
        }

        public int GetArgent()
        {
            return argent;
        }

        public int GetTourPrison()
        {
            return tourPrison;
        }

        public string GetNom()
        {
            return nom;
        }

        public int GetId()
        {
            return id;
        }

        public int GetPosition()
        {
            return position;
        }

        public bool EstEnPrison()
        {
            return enPrison;
        }

        public bool CarteSortiePrison()
        {
            return sortiePrison;
        }

        #endregion

        #region Setters
        public void SetFaillite()
        {
            faillite = true;
            foreach (var item in lesCartesAchat)
            {
                item.SetProprio(null);
                item.SetAcheter(false);
            }
            for (int i = 0; i < lesCartesAchat.Count; i++)
            {
                lesCartesAchat.RemoveAt(i);
            }
        }

        public void SetJouer(bool result)
        {
            aJoue = result;
        }

        public void AddPosition(int cases)
        {
            position += cases;
            if (position >= 40)
            {
                position -= 40;
                argent += 200;
                Console.WriteLine("##   Vous êtes passé par la case départ, vous recevez 200$\n##   Vous avez maintenant " + argent + "$");
            }
        }

        public void SetArgent(int nbArgent)
        {
            argent = nbArgent;
        }

        public void SetPosition(int unePosition)
        {
            position = unePosition;
        }

        public void SetTourPrison(int resultat)
        {
            tourPrison = resultat;
        }

        public void SetCartePrison(bool resultat)
        {
            sortiePrison = resultat;
        }

        public void SetPrison(bool resultat)
        {
            enPrison = resultat;
        }

        #endregion

        #region Méthodes

        public void AchatBatiment(Case uneCarte)
        {
            // le prix correspond au premier loyer du tableau des loyers
            double coutBat = uneCarte.GetLoyerBatiment()[0];
            if (argent < coutBat)
            {
                Console.WriteLine("##   Vous n'avez pas assez d'argent pour construire !");
            }
            else if (uneCarte.GetNbBatiments() == 5)
            {
                Console.WriteLine("##   Vous avez déjà un hotel sur cette case !");
            }
            else
            {
                this.argent -= (int)coutBat;
                int nbBat = uneCarte.GetNbBatiments();
                double nouveauLoyer = uneCarte.GetLoyerBatiment()[nbBat];
                Console.WriteLine("##   Batiment ajouté avec succès !\n##   Votre loyer passe de " + uneCarte.GetLoyer() + "$ à " + nouveauLoyer + "$ !");
                uneCarte.SetLoyer((int)nouveauLoyer);
                uneCarte.SetNbBat(uneCarte.GetNbBatiments()+1);
            }
        }

        public bool verifieNbCouleurs(string uneCouleur)
        {
            switch (uneCouleur)
            {
                case "Marron":
                    return CoulMarron;
                    break;
                case "BleuClair":
                    return CoulBleuClair;
                    break;
                case "Rose":
                    return CoulRose;
                    break;
                case "Vert":
                    return CoulVert;
                    break;
                case "Jaune":
                    return CoulJaune;
                    break;
                case "Rouge":
                    return CoulRouge;
                    break;
                case "BleuFonce":
                    return CoulBleuFonce;
                    break;
                case "Orange":
                    return CoulOrange;
                    break;
                default:
                    return false;
                    break;
            }
        }

        public void verifieCouleursCartes()
        {
            if (nbMarron == 2 && CoulMarron == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Marron":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulMarron = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes marrons ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbBleuClair == 3 && CoulBleuClair == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "BleuClair":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulBleuClair = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes Bleu Claires ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbRose == 3 && CoulRose == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Rose":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulRose = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes roses ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbOrange == 3 && CoulOrange == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Orange":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulOrange = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes oranges ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbRouge == 3 && CoulRouge == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Rouge":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulRouge = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes rouges ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbJaune == 3 && CoulJaune == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Jaune":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulJaune = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes jaunes ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbVert == 3 && CoulVert == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "Vert":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulVert = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes vertes ont été achetés par " + this.nom + ", leur loyer double !");
            }
            if (nbBleuFonce == 2 && CoulBleuFonce == false)
            {
                foreach (var item in lesCartesAchat)
                {
                    switch (item.GetCouleur())
                    {
                        case "BleuFonce":
                            item.SetLoyer(item.GetLoyer() * 2);
                            CoulBleuFonce = true;
                            break;
                        default:
                            break;
                    }
                }
                Console.WriteLine("##   Toutes les villes Bleu Foncées ont été achetés par " + this.nom + ", leur loyer double !");
            }
        }

        public void AcheterCarte(Case uneCarte)
        {
            lesCartesAchat.Add(uneCarte);
            uneCarte.SetProprio(this);
            uneCarte.SetAcheter(true);
            this.argent = (this.argent) - (uneCarte.GetPrix());

            if (uneCarte.AfficherType().Equals("Gare"))
            {
                NbGares++;
            }

            switch (uneCarte.GetCouleur())
            {
                case "BleuClair":
                    nbBleuClair++;
                    break;
                case "Vert":
                    nbVert++;
                    break;
                case "Marron":
                    nbMarron++;
                    break;
                case "Rose":
                    nbRose++;
                    break;
                case "Rouge":
                    nbRouge++;
                    break;
                case "Orange":
                    nbOrange++;
                    break;
                case "Jaune":
                    nbJaune++;
                    break;
                case "BleuFonce":
                    nbBleuFonce++;
                    break;
                default:
                    break;
            }

            this.verifieCouleursCartes();
        }

        public void RetirerCarte(Case uneCarte)
        {
            lesCartesAchat.Remove(uneCarte);
            uneCarte.SetLoyer(uneCarte.GetLoyer()/2);
            foreach (var item in lesCartesAchat)
            {
                if (item.GetCouleur() == uneCarte.GetCouleur())
                {
                    item.SetLoyer(item.GetLoyer() / 2);
                }
            }

            if (uneCarte.AfficherType().Equals("Gare"))
            {
                NbGares--;
            }

            switch (uneCarte.GetCouleur())
            {
                case "BleuClair":
                    nbBleuClair--;
                    break;
                case "Vert":
                    nbVert--;
                    break;
                case "Marron":
                    nbMarron--;
                    break;
                case "Rose":
                    nbRose--;
                    break;
                case "Rouge":
                    nbRouge--;
                    break;
                case "Orange":
                    nbOrange--;
                    break;
                case "Jaune":
                    nbJaune--;
                    break;
                case "BleuFonce":
                    nbBleuFonce--;
                    break;
                default:
                    break;
            }
        }

        public void RacheterCarte(Case uneCarte)
        {
            Joueur AncienProprio = uneCarte.GetProprio();
            AncienProprio.RetirerCarte(uneCarte);

            lesCartesAchat.Add(uneCarte);
            uneCarte.SetProprio(this);
            uneCarte.SetAcheter(true);
            this.argent = (this.argent) - (uneCarte.GetPrix() * 2 );

            if (uneCarte.AfficherType().Equals("Gare"))
            {
                NbGares++;
            }

            switch (uneCarte.GetCouleur())
            {
                case "BleuClair":
                    nbBleuClair++;
                    break;
                case "Vert":
                    nbVert++;
                    break;
                case "Marron":
                    nbMarron++;
                    break;
                case "Rose":
                    nbRose++;
                    break;
                case "Rouge":
                    nbRouge++;
                    break;
                case "Orange":
                    nbOrange++;
                    break;
                case "Jaune":
                    nbJaune++;
                    break;
                case "BleuFonce":
                    nbBleuFonce++;
                    break;
                default:
                    break;
            }

            this.verifieCouleursCartes();
        }

        public void AllerEnPrison()
        {
            position = 10;
            enPrison = true; 
            tourPrison = 0;
        }

        public void AfficherCartes()
        {
            Console.WriteLine("###################################################################");
            Console.WriteLine("##   Vos cartes :\n##  ----------------------");
            if (sortiePrison)
            {
                Console.WriteLine("##   Une carte de sortie de prison !\n##   ");
            }
            foreach (var couleur in ListeCouleur)
            {
                Console.WriteLine("##   " + couleur + " :");
                foreach (var item in lesCartesAchat)
                {
                    if (item.GetCouleur() == couleur)
                    {
                        Console.Write("##   ");
                        item.afficherCase();
                    }
                }
                Console.WriteLine("##   ");
            }
            Console.WriteLine("###################################################################\n");
        }

        public void AfficherCartesComputer()
        {
            if (!this.faillite)
            {
                Console.WriteLine("##################################");
                Console.WriteLine("##   Les cartes de " + this.nom + " :");
                Console.WriteLine("##   ----------------------------");
                if (sortiePrison)
                {
                    Console.WriteLine("##   Une carte de sortie de prison !");
                }

                foreach (var couleur in ListeCouleur)
                {
                    Console.WriteLine("##   " + couleur + " :");
                    foreach (var item in lesCartesAchat)
                    {
                        if (item.GetCouleur() == couleur)
                        {
                            Console.Write("##   ");
                            item.afficherCase();
                        }
                    }
                    Console.WriteLine("##   ");
                }
            }
            
        }
        #endregion
    }
}
