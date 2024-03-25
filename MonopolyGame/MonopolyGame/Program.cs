/*
███╗░░░███╗░█████╗░███╗░░██╗░█████╗░██████╗░░█████╗░██╗░░░░░██╗░░░██╗  ░██████╗░░█████╗░███╗░░░███╗███████╗
████╗░████║██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██║░░░░░╚██╗░██╔╝  ██╔════╝░██╔══██╗████╗░████║██╔════╝
██╔████╔██║██║░░██║██╔██╗██║██║░░██║██████╔╝██║░░██║██║░░░░░░╚████╔╝░  ██║░░██╗░███████║██╔████╔██║█████╗░░
██║╚██╔╝██║██║░░██║██║╚████║██║░░██║██╔═══╝░██║░░██║██║░░░░░░░╚██╔╝░░  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░
██║░╚═╝░██║╚█████╔╝██║░╚███║╚█████╔╝██║░░░░░╚█████╔╝███████╗░░░██║░░░  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗
╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░╚═╝░░░░░░╚════╝░╚══════╝░░░╚═╝░░░  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝

░░██╗░█████╗░░░░██╗░██╗░  ██████╗░██████╗░░█████╗░░░░░░██╗███████╗░█████╗░████████╗██╗░░
░██╔╝██╔══██╗██████████╗  ██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔════╝██╔══██╗╚══██╔══╝╚██╗░
██╔╝░██║░░╚═╝╚═██╔═██╔═╝  ██████╔╝██████╔╝██║░░██║░░░░░██║█████╗░░██║░░╚═╝░░░██║░░░░╚██╗
╚██╗░██║░░██╗██████████╗  ██╔═══╝░██╔══██╗██║░░██║██╗░░██║██╔══╝░░██║░░██╗░░░██║░░░░██╔╝
░╚██╗╚█████╔╝╚██╔═██╔══╝  ██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗╚█████╔╝░░░██║░░░██╔╝░
░░╚═╝░╚════╝░░╚═╝░╚═╝░░░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝░╚════╝░░░░╚═╝░░░╚═╝░░
*/
using System;

namespace MonopolyGame
{
    class Program
    {

        #region Variables globales
        public static List<Joueur> lesJoueurs = new List<Joueur>();
        public static List<Case> lesCases = new List<Case>();
        public static List<Carte_effet> lesCartesEffet = new List<Carte_effet>();
        public static Case[] Plateau = new Case[40];
        public static bool FinDePartie;
        public static List<String> ListeCouleur;
        public static List<int> ListeNumRachat;
        #endregion

        static void Main(string[] args)
        {
            Initialisation();
            Jouer();
        }       

        static void Initialisation()
        {
            // Les variables principales
            FinDePartie = false;

            // Tous les joueurs
            Joueur p = new Joueur("Joueur",1);
            lesJoueurs.Add(p);
            Joueur c1 = new Joueur("Ordinateur 1",2);
            lesJoueurs.Add(c1);
            Joueur c2 = new Joueur("Ordinateur 2", 3);
            lesJoueurs.Add(c2);
            Joueur c3 = new Joueur("Ordinateur 3", 4);
            lesJoueurs.Add(c3);

            // La liste des couleurs
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

            // la liste des numéro disponibles pour rachat
            ListeNumRachat = new List<int>();

            // Toutes les cartes effet
            Carte_effet Carte_effet1 = new Carte_effet(1, "chance", "deplacer", "##   Rendez-vous à la case départ", "gagnez $200", 200);
            Carte_effet Carte_effet3 = new Carte_effet(3, "chance", "item", "##   Le juge est sympa !", "Vous pourrez sortir de prison", 0);
            Carte_effet Carte_effet4 = new Carte_effet(4, "chance", "gagnerArgent", "##   Rendez-vous à la case départ", "gagnez $50", 50);
            Carte_effet Carte_effet5 = new Carte_effet(5, "chance", "gagnerArgent", "##   Vous gagnez à la loterie", "gagnez $200", 200);
            Carte_effet Carte_effet6 = new Carte_effet(6, "chance", "perdreArgent", "##   Vous vous cassez le bras", "perdez $50", 50);
            Carte_effet Carte_effet7 = new Carte_effet(7, "chance", "perdreArgent", "##   Vous devez regler le dentiste", "perdez $100", 100);
            Carte_effet Carte_effet8 = new Carte_effet(8, "community", "deplacer", "##   Rendez-vous à la case départ", "gagnez $200", 200);
            Carte_effet Carte_effet10 = new Carte_effet(10, "community", "item", "##   Le juge est sympa !", "Vous pourrez sortir de prison", 0);
            Carte_effet Carte_effet11 = new Carte_effet(11, "community", "gagnerArgent", "##   Rendez-vous à la case départ", "gagnez $200", 200);
            Carte_effet Carte_effet12 = new Carte_effet(12, "community", "gagnerArgent", "##   Vous gagnez à la loterie", "gagnez $200", 200);
            Carte_effet Carte_effet13 = new Carte_effet(13, "community", "perdreArgent", "##   Vous vous cassez le bras", "perdez $50", 50);
            Carte_effet Carte_effet14 = new Carte_effet(14, "community", "perdreArgent", "##   Vous devez regler le dentiste", "perdez $100", 100);
            
            // Ajout des cartes Autre dans la liste lesCartesEffet
            lesCartesEffet.Add(Carte_effet1);
            lesCartesEffet.Add(Carte_effet3);
            lesCartesEffet.Add(Carte_effet4);
            lesCartesEffet.Add(Carte_effet5);
            lesCartesEffet.Add(Carte_effet6);
            lesCartesEffet.Add(Carte_effet7);
            lesCartesEffet.Add(Carte_effet8);
            lesCartesEffet.Add(Carte_effet10);
            lesCartesEffet.Add(Carte_effet11);
            lesCartesEffet.Add(Carte_effet12);
            lesCartesEffet.Add(Carte_effet13);
            lesCartesEffet.Add(Carte_effet14);

            // Toutes les Cases
            Carte_Autre Case0 = new Carte_Autre("Depart");
            Carte_Achat Case1 = new Carte_Achat("Ville", "Roubaix", "Marron", 60, 2);
            Carte_Autre Case2 = new Carte_Autre("Community");
            Carte_Achat Case3 = new Carte_Achat("Ville", "Annecy", "Marron", 60, 4);
            Carte_Autre Case4 = new Carte_Autre("Impots");
            Carte_Achat Case5 = new Carte_Achat("Gare", "Gare Montparnasse", "Noir", 200, 25);
            Carte_Achat Case6 = new Carte_Achat("Ville", "Saint-Etienne", "BleuClair", 100, 6);
            Carte_Autre Case7 = new Carte_Autre("Chance");
            Carte_Achat Case8 = new Carte_Achat("Ville", "Saint-Martin-En-Haut", "BleuClair",100,6);
            Carte_Achat Case9 = new Carte_Achat("Ville", "Montlauzun", "BleuClair",120,8);
            Carte_Autre Case10 = new Carte_Autre("VisitePrison");
            Carte_Achat Case11 = new Carte_Achat("Ville", "Lille", "Rose", 140, 10);
            Carte_Achat Case12 = new Carte_Achat("Service", "Electricité", "Service", 200, 0);
            Carte_Achat Case13 = new Carte_Achat("Ville", "Bordeaux", "Rose", 140, 10);
            Carte_Achat Case14 = new Carte_Achat("Ville", "Mulhouse", "Rose", 160, 12);
            Carte_Achat Case15 = new Carte_Achat("Gare", "Gare De Lyon", "Noir", 200, 25);
            Carte_Achat Case16 = new Carte_Achat("Ville", "Grenoble", "Orange", 180, 14);
            Carte_Autre Case17 = new Carte_Autre("Community");
            Carte_Achat Case18 = new Carte_Achat("Ville", "Rennes", "Orange", 180, 14);
            Carte_Achat Case19 = new Carte_Achat("Ville", "Caen", "Orange", 200, 16);
            Carte_Autre Case20 = new Carte_Autre("ParcGratuit");
            Carte_Achat Case21 = new Carte_Achat("Ville", "Toulon", "Rouge", 220, 18);
            Carte_Autre Case22 = new Carte_Autre("Chance");
            Carte_Achat Case23 = new Carte_Achat("Ville", "Nîmes", "Rouge", 220, 18);
            Carte_Achat Case24 = new Carte_Achat("Ville", "Dijon", "Rouge", 240, 20);
            Carte_Achat Case25 = new Carte_Achat("Gare", "Gare Du Nord", "Noir", 200, 25);
            Carte_Achat Case26 = new Carte_Achat("Ville", "Angers", "Jaune", 260, 22);
            Carte_Achat Case27 = new Carte_Achat("Ville", "Strasbourg", "Jaune", 260, 22);
            Carte_Achat Case28 = new Carte_Achat("Service", "Eau", "Service", 200, 0);
            Carte_Achat Case29 = new Carte_Achat("Ville", "Reims", "Jaune", 280, 24);
            Carte_Autre Case30 = new Carte_Autre("EnvoiPrison");
            Carte_Achat Case31 = new Carte_Achat("Ville", "Toulouse", "Vert", 300, 26);
            Carte_Achat Case32 = new Carte_Achat("Ville", "Marseille", "Vert", 300, 26);
            Carte_Autre Case33 = new Carte_Autre("Community");
            Carte_Achat Case34 = new Carte_Achat("Ville", "Nice", "Vert", 320, 28);
            Carte_Achat Case35 = new Carte_Achat("Gare", "Gare Saint-Lazare", "Noir", 200, 25);
            Carte_Autre Case36 = new Carte_Autre("Chance");
            Carte_Achat Case37 = new Carte_Achat("Ville", "Monaco", "BleuFonce", 350, 35);
            Carte_Autre Case38 = new Carte_Autre("Impots");
            Carte_Achat Case39 = new Carte_Achat("Ville", "Paris", "BleuFonce", 400, 50);

            // Le plateau de jeu, représenté par un tableau de 40 objets de type <Case>
            // Ces Cases vont admettre une méthode TomberDessus() qui va permettre d'activer leurs effets
            Plateau = new Case[]
            {
                Case0, Case1, Case2, Case3, Case4, Case5, Case6, Case7, Case8, Case9, Case10,
                Case11, Case12, Case13, Case14, Case15, Case16, Case17, Case18, Case19, Case20,
                Case21, Case22, Case23, Case24, Case25, Case26, Case27, Case28, Case29, Case30,
                Case31, Case32, Case33, Case34, Case35, Case36, Case37, Case38, Case39
            };

        }

        static void Jouer()
        {
            int[] lancer = new int[2];
            int doubleDes = 0;
            int nbCases;
            int nbTour = 1;
            Case laCase = new Case();
            int ReponseAchat;
            int nbJoueursRestants = 4;
            Joueur joueurCourant;
            bool aFaitDouble = false;
            string Fin = "";
            Case Casecourante;
            while (!FinDePartie)
            {
                ///////////////////////
                // AFFICHAGE GENERAL //
                ///////////////////////
                AfficherPlateau();
                //Thread.Sleep(5000);
                Console.WriteLine("\r\n░█▀▀█ ░█▀▀▀ ░█▀▀█  █▀▀█ ░█▀▀█ ▀█▀ ▀▀█▀▀ ░█ ░█ ░█     █▀▀█ ▀▀█▀▀ ▀█▀ ░█▀▀▀ \r\n░█▄▄▀ ░█▀▀▀ ░█    ░█▄▄█ ░█▄▄█ ░█   ░█   ░█ ░█ ░█    ░█▄▄█  ░█   ░█  ░█▀▀▀ \r\n░█ ░█ ░█▄▄▄ ░█▄▄█ ░█ ░█ ░█    ▄█▄  ░█    ▀▄▄▀ ░█▄▄█ ░█ ░█  ░█   ▄█▄ ░█   ");
                Console.WriteLine("\n###################################################################" +
                    "" +
                    "\n##   Tour numéro " + nbTour);
                foreach (var item in lesJoueurs)
                {
                    if (!item.GetFaillite())
                    {
                        Console.WriteLine("##   " + item.GetNom() +" est sur la case " + Plateau[item.GetPosition()].AfficherNom() + " avec " + item.GetArgent() + "$");
                    }
                    else
                    {
                        Console.WriteLine("##   " + item.GetNom() + " a fait faillite !");
                    }
                }
 
                lesJoueurs[0].AfficherCartes();

                ////////////////////
                // Tour du joueur //
                ////////////////////

                Console.WriteLine("\r\n▀▀█▀▀ ░█▀▀▀█ ░█ ░█ ░█▀▀█ 　 ░█▀▀▄ ░█ ░█ 　    ░█ ░█▀▀▀█ ░█ ░█ ░█▀▀▀ ░█ ░█ ░█▀▀█ \r\n ░█   ░█  ░█ ░█ ░█ ░█▄▄▀ 　 ░█ ░█ ░█ ░█ 　  ▄ ░█ ░█  ░█ ░█ ░█ ░█▀▀▀ ░█ ░█ ░█▄▄▀ \r\n ░█   ░█▄▄▄█  ▀▄▄▀ ░█ ░█ 　 ░█▄▄▀  ▀▄▄▀ 　 ░█▄▄█ ░█▄▄▄█  ▀▄▄▀ ░█▄▄▄  ▀▄▄▀ ░█ ░█");
                doubleDes = 0;
                joueurCourant = lesJoueurs[0];
                lesJoueurs[0].SetJouer(false);
                lesJoueurs[1].SetJouer(false);
                lesJoueurs[2].SetJouer(false);
                lesJoueurs[3].SetJouer(false);
                Console.WriteLine("\n###################################################################");

                while (!joueurCourant.aJouer())
                {
                    Casecourante = Plateau[joueurCourant.GetPosition()];
                    aFaitDouble = false;
                    if (joueurCourant.EstEnPrison())
                    {
                        Console.WriteLine("##   Vous êtes en prison depuis " + joueurCourant.GetTourPrison() + " tour(s)");
                        if (joueurCourant.CarteSortiePrison())
                        {
                            Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                            Console.Write("##   \n##   Que voulez-vous faire ? " +
                                "\n##   [1] - Utiliser la carte de sortie de prison" +
                                "\n##   [2] - Payer 50$" +
                                "\n##   [3] - Lancer les dés" +
                                "\n##   [4] - Voir les cartes des autres joueurs" +
                                "\n##   [5] - Racheter la carte d'un autre joueur" +
                                "\n##   [6] - Afficher le plateau" +
                                "\n##   Réponse : ");
                            int SortiePrisonAvecCarte = Int32.Parse(Console.ReadLine());
                            switch (SortiePrisonAvecCarte)
                            {
                                case 0:
                                    FinDePartie = true;
                                    joueurCourant.SetJouer(true);
                                    break;
                                case 1:
                                    Console.WriteLine("##   Carte sortie de prison utilisée ! Vous pourrez jouer au prochain tour !");
                                    joueurCourant.SetCartePrison(false);
                                    joueurCourant.SetPrison(false);
                                    joueurCourant.SetTourPrison(0);
                                    joueurCourant.SetJouer(true);
                                    break;
                                case 2:
                                    Console.WriteLine("##   Vous avez payer 50$ ! Vous pourrez jouer au prochain tour !");
                                    joueurCourant.SetArgent(joueurCourant.GetArgent() - 50);
                                    joueurCourant.SetPrison(false);
                                    joueurCourant.SetTourPrison(0);
                                    Console.WriteLine("##   Il vous reste " + joueurCourant.GetArgent() + "$");
                                    joueurCourant.SetJouer(true);
                                    break;
                                case 3:
                                    lancer = LancerDeDes();
                                    Console.WriteLine("##   Les dés sont lancés ! Vous avez obtenus un " + lancer[0] + " et un " + lancer[1]);
                                    if (lancer[0] == lancer[1])
                                    {
                                        Console.WriteLine("##   C'est un double ! Vous sortez de prison ! Vous pourrez jouer au prochain tour !");
                                        joueurCourant.SetPrison(false);
                                        joueurCourant.SetTourPrison(0);
                                        joueurCourant.SetJouer(true);
                                    }
                                    else if (joueurCourant.GetTourPrison() >= 2)
                                    {
                                        Console.WriteLine("##   Vous avez passer assez de temps en prison ! Vous pourrez jouer au prochain tour !");
                                        joueurCourant.SetPrison(false);
                                        joueurCourant.SetTourPrison(0);
                                        joueurCourant.SetJouer(true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("##   Ce n'est pas un double ! Vous restez en prison !");
                                        joueurCourant.SetTourPrison(joueurCourant.GetTourPrison() + 1);
                                    }
                                    break;
                                case 4:
                                    Console.WriteLine("##   ");
                                    for (int i = 1; i < 4; i++)
                                    {
                                        lesJoueurs[i].AfficherCartesComputer();
                                    }
                                    break;
                                case 5:
                                    AfficherCartesPourAchat();
                                    Console.Write("##   Quelle carte voulez-vous acheter pour le double du prix ? [-1] - Ne pas acheter\n##   Réponse :");
                                    int ReponseAchatDispo = Int32.Parse(Console.ReadLine());
                                    bool TrouveNumero = false;
                                    foreach (var numero in ListeNumRachat)
                                    {
                                        if (ReponseAchatDispo == numero)
                                        {
                                            TrouveNumero = true;
                                            if (joueurCourant.GetArgent() < Plateau[numero].GetPrix())
                                            {
                                                Console.WriteLine("##   " + "Vous n'avez pas assez d'argent pour l'acheter !");
                                                Thread.Sleep(3000);
                                            }
                                            else
                                            {
                                                joueurCourant.RacheterCarte(Plateau[numero]);
                                                Console.WriteLine("##   " + "Carte achetée avec succès !");
                                                Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                                                Thread.Sleep(3000);
                                            }
                                        }
                                    }
                                    if (!TrouveNumero)
                                    {
                                        Console.WriteLine("##   Le numéro demandé ne correspond pas !");
                                    }
                                    break;
                                case 6:
                                    AfficherPlateau();
                                    break;
                                default:
                                    FinDePartie = true;
                                    joueurCourant.SetJouer(true);
                                    break;

                            }
                        }
                        else
                        {
                            Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                            Console.Write("\n##   Que voulez-vous faire ? " +
                                "\n##   [1] - Payer 50$" +
                                "\n##   [2] - Lancer les dés" +
                                "\n##   [3] - Voir les cartes des autres joueurs" +
                                "\n##   [4] - Racheter la carte d'un autre joueur" +
                                "\n##   [5] - Afficher le plateau" +
                                "\n##   Réponse : ");
                            int SortiePrisonSansCarte = Int32.Parse(Console.ReadLine());
                            switch (SortiePrisonSansCarte)
                            {
                                case 0:
                                    FinDePartie = true;
                                    joueurCourant.SetJouer(true);
                                    break;
                                case 1:
                                    Console.WriteLine("##   Vous avez payer 50$ ! Vous pourrez jouer au prochain tour !");
                                    joueurCourant.SetArgent(joueurCourant.GetArgent() - 50);
                                    joueurCourant.SetPrison(false);
                                    joueurCourant.SetTourPrison(0);
                                    Console.WriteLine("##   Il vous reste " + joueurCourant.GetArgent() + "$");
                                    joueurCourant.SetJouer(true);
                                    break;
                                case 2:
                                    lancer = LancerDeDes();
                                    Console.WriteLine("##   Les dés sont lancés ! Vous avez obtenus un " + lancer[0] + " et un " + lancer[1]);
                                    if (lancer[0] == lancer[1])
                                    {
                                        Console.WriteLine("##   C'est un double ! Vous sortez de prison ! Vous pourrez jouer au prochain tour !");
                                        joueurCourant.SetPrison(false);
                                        joueurCourant.SetTourPrison(0);
                                        joueurCourant.SetJouer(true);
                                        AfficherPlateau();
                                    }
                                    else if (joueurCourant.GetTourPrison() == 3)
                                    {
                                        Console.WriteLine("##   Vous avez passer assez de temps en prison ! Vous pourrez jouer au prochain tour !");
                                        joueurCourant.SetPrison(false);
                                        joueurCourant.SetTourPrison(0);
                                        joueurCourant.SetJouer(true);
                                    }
                                    else
                                    {
                                        Console.WriteLine("##   Ce n'est pas un double ! Vous restez en prison !");
                                        joueurCourant.SetTourPrison(joueurCourant.GetTourPrison() + 1);
                                        joueurCourant.SetJouer(true);
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("##   ");
                                    for (int i = 1; i < 4; i++)
                                    {
                                        lesJoueurs[i].AfficherCartesComputer();
                                    }
                                    break;
                                case 4:
                                    AfficherCartesPourAchat();
                                    Console.Write("##   Quelle carte voulez-vous acheter pour le double du prix ? [-1] - Ne pas acheter\n##   Réponse :");
                                    int ReponseAchatDispo = Int32.Parse(Console.ReadLine());
                                    bool TrouveNumero = false;
                                    foreach (var numero in ListeNumRachat)
                                    {
                                        if (ReponseAchatDispo == numero)
                                        {
                                            TrouveNumero = true;
                                            if (joueurCourant.GetArgent() < Plateau[numero].GetPrix())
                                            {
                                                Console.WriteLine("##   " + "Vous n'avez pas assez d'argent pour l'acheter !");
                                                Thread.Sleep(3000);
                                            }
                                            else
                                            {
                                                joueurCourant.RacheterCarte(Plateau[numero]);
                                                Console.WriteLine("##   " + "Carte achetée avec succès !");
                                                Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                                                Thread.Sleep(3000);
                                            }
                                        }
                                    }
                                    if (!TrouveNumero)
                                    {
                                        Console.WriteLine("##   Le numéro demandé ne correspond pas !");
                                    }
                                    break;
                                case 5:
                                    AfficherPlateau();
                                    break;
                                default:
                                    FinDePartie = true;
                                    joueurCourant.SetJouer(true);
                                    break;

                            }
                        }
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Console.Write("##   Vous avez " + joueurCourant.GetArgent()+ "$" +
                            "\n##   Que voulez-vous faire ? " +
                            "\n##   [1] - Lancer les dés" +
                            "\n##   [2] - Voir les cartes des autres joueurs" +
                            "\n##   [3] - Racheter la carte d'un autre joueur" +
                            "\n##   [4] - Afficher le plateau" +
                            "\n##   [5] - Construire sur le terrain" +
                            "\n##   Réponse : ");
                        int jouer = -1;
                        jouer = Int32.Parse(Console.ReadLine());
                        switch (jouer)
                        {
                            case 0:
                                FinDePartie = true;
                                joueurCourant.SetJouer(true);
                                break;
                            case 1:
                                lancer = LancerDeDes();
                                Console.WriteLine("\n##   \n##   Les dés sont lancés ! Vous avez obtenus un " + lancer[0] + " et un " + lancer[1]);
                                nbCases = lancer[0] + lancer[1];
                                if (lancer[0] == lancer[1])
                                {
                                    aFaitDouble = true;
                                    Console.WriteLine("##   C'est un double !");
                                    doubleDes ++;
                                    if (doubleDes == 3)
                                    {
                                        Console.WriteLine("##   C'est le troisième double ! Vous allez en prison !");
                                        joueurCourant.AllerEnPrison();
                                        joueurCourant.SetJouer(true);
                                        break;
                                    }
                                }
                                else
                                {
                                    joueurCourant.SetJouer(true);
                                }
                                joueurCourant.AddPosition(nbCases);
                                laCase = Plateau[joueurCourant.GetPosition()];

                                Console.WriteLine("##   Vous avancez de " + nbCases + " cases !");
                                Console.WriteLine("##   Vous atterrissez sur la case " + laCase.AfficherNom());

                                if (laCase.GetType().ToString() == "MonopolyGame.Carte_Achat")
                                {
                                    if (laCase.EstAcheter())
                                    {
                                        if (laCase.GetProprio().GetNom().Equals("Joueur"))
                                        {
                                            Console.WriteLine("##   Vous êtes chez vous !");
                                            joueurCourant.SetJouer(true);
                                            Thread.Sleep(3000);
                                        }
                                        else
                                        {
                                            Console.WriteLine("##   Vous êtes chez " + laCase.GetProprio().GetNom());
                                            if (laCase.AfficherType().Equals("Gare"))
                                            {
                                                Console.WriteLine("##   " + laCase.GetProprio().GetNom() + " a " + laCase.GetProprio().GetNbGares() + " gare(s) !");
                                                Console.WriteLine("##   " +"Vous devez donc payer " + laCase.GetProprio().GetNbGares() * 50 + "$ !");
                                                joueurCourant.SetArgent(joueurCourant.GetArgent() - (laCase.GetProprio().GetNbGares() * 50));

                                            }
                                            else if (laCase.AfficherType().Equals("Service"))
                                            {
                                                Console.WriteLine("##   " +"Vous devez payer votre nombre de déplacement multiplié par 10 !");
                                                Console.WriteLine("##   " +"Payez " + nbCases * 10 +"$ !");
                                            }
                                            else
                                            {
                                                Console.WriteLine("##   " +"Vous devez payer un loyer de " + laCase.GetLoyer() + "$");
                                                joueurCourant.SetArgent(joueurCourant.GetArgent() - laCase.GetLoyer());
                                            }
                                            joueurCourant.SetJouer(true);
                                            Thread.Sleep(3000);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("##   " +"Vous avez " + joueurCourant.GetArgent() + "$");
                                        Console.Write("##   " + "Personne ne détient cette carte, voulez-vous l'acheter pour " + laCase.GetPrix() + "$ ? \n##   [0] - non \n##   [1] - oui\n##   Réponse :");
                                        ReponseAchat = Int32.Parse(Console.ReadLine());
                                        switch (ReponseAchat)
                                        {
                                            case 0:
                                                Console.WriteLine("##   " +"Vous n'achetez donc pas cette carte !");
                                                Thread.Sleep(3000);
                                                break;
                                            case 1:
                                                if (joueurCourant.GetArgent() < laCase.GetPrix())
                                                {
                                                    Console.WriteLine("##   " +"Vous n'avez pas assez d'argent pour l'acheter !");
                                                    Thread.Sleep(3000);
                                                }
                                                else
                                                {
                                                    joueurCourant.AcheterCarte(laCase);
                                                    Console.WriteLine("##   " +"Carte achetée avec succès !");
                                                    Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                                                    Thread.Sleep(3000);
                                                }
                                                break;
                                            default:
                                                Console.WriteLine("##   " +"Vous n'achetez donc pas cette carte !");
                                                Thread.Sleep(3000);
                                                break;
                                        }
                                    }
                                }
                                else
                                {
                                    if (laCase.AfficherNom().Equals("VisitePrison"))
                                    {
                                        Console.WriteLine("##   " +"Vous êtes en visite dans la prison");
                                        Thread.Sleep(3000);
                                    }
                                    else if (laCase.AfficherNom().Equals("EnvoiPrison"))
                                    {
                                        Console.WriteLine("##   " +"Vous êtes envoyé en prison !");
                                        joueurCourant.AllerEnPrison();
                                        Thread.Sleep(3000);
                                    }
                                    else if (laCase.AfficherNom().Equals("Depart"))
                                    {
                                        Console.WriteLine("##   " +"Case Départ !");
                                        Thread.Sleep(3000);
                                    }
                                    else if (laCase.AfficherNom().Equals("ParcGratuit"))
                                    {
                                        Console.WriteLine("##   " +"Vous êtes en visite du parc gratuit !");
                                        Thread.Sleep(3000);
                                    }
                                    else if (laCase.AfficherNom().Equals("Impots"))
                                    {
                                        Console.WriteLine("##   " +"Vous devez payer des impôts ! Vous donnez 200$ !");
                                        joueurCourant.SetArgent(joueurCourant.GetArgent() - 200);
                                        Thread.Sleep(3000);
                                    }
                                    else if (laCase.AfficherNom().Equals("Chance"))
                                    {
                                        Console.WriteLine("##   " +"Carte Chance !");
                                        Random rnd = new Random();
                                        Carte_effet Effet = lesCartesEffet[rnd.Next(0, 6)];
                                        Effet.ActiverEffet(joueurCourant);
                                        Thread.Sleep(3000);
                                    }
                                    else
                                    {
                                        Console.WriteLine("##   " +"Carte Community !");
                                        Random rnd = new Random();
                                        Carte_effet Effet = lesCartesEffet[rnd.Next(6, 12)];
                                        Effet.ActiverEffet(joueurCourant);
                                        Thread.Sleep(3000);
                                    }
                                }

                                break;
                            case 2:
                                Console.WriteLine("##   ");
                                for (int i = 1; i < 4; i++)
                                {
                                    lesJoueurs[i].AfficherCartesComputer();
                                }
                                break;
                            case 3:
                                AfficherCartesPourAchat();
                                Console.Write("##   Quelle carte voulez-vous acheter pour le double du prix ? [-1] - Ne pas acheter\n##   Réponse :");
                                int ReponseAchatDispo = Int32.Parse(Console.ReadLine());
                                bool TrouveNumero = false;
                                foreach (var numero in ListeNumRachat)
                                {
                                    if (ReponseAchatDispo == numero)
                                    {
                                        TrouveNumero = true;
                                        if (joueurCourant.GetArgent() < Plateau[numero].GetPrix())
                                        {
                                            Console.WriteLine("##   " + "Vous n'avez pas assez d'argent pour l'acheter !");
                                            Thread.Sleep(3000);
                                        }
                                        else
                                        {
                                            joueurCourant.RacheterCarte(Plateau[numero]);
                                            Console.WriteLine("##   " + "Carte achetée avec succès !");
                                            Console.WriteLine("##   Vous avez " + joueurCourant.GetArgent() + "$");
                                            Thread.Sleep(3000);
                                        }
                                    }
                                }
                                if (!TrouveNumero)
                                {
                                    Console.WriteLine("##   Le numéro demandé ne correspond pas !");
                                }
                                break;
                            case 4:
                                AfficherPlateau();
                                break;
                            case 5:
                                Console.Write("##   Voulez-vous vraiment construire sur le terrain pour " + Casecourante.GetLoyerBatiment()[0] + "$ ? \n##   [0] - non \n##   [1] - oui\n##   Réponse : ");
                                int ReponseConstruct = Int32.Parse(Console.ReadLine());
                                switch (ReponseConstruct)
                                {
                                    case 0:
                                        Console.WriteLine("##   Idée de construction abandonnée !");
                                        break;
                                    case 1:
                                        // Vérifie si la carte est constructible le nbCouleurs
                                        if (joueurCourant.verifieNbCouleurs(Casecourante.GetCouleur()))
                                        {
                                            joueurCourant.AchatBatiment(Casecourante);
                                            Console.WriteLine("##   Vous avez maintenant " + joueurCourant.GetArgent() + "$ !");
                                        }
                                        else
                                        {
                                            Console.WriteLine("##   Le terrain n'est pas constructible !");
                                        }
                                        break;
                                }
                                break;
                            default:
                                FinDePartie = true;
                                joueurCourant.SetJouer(true);
                                break;
                        }

                        Console.Write("##   \n###################################################################\n");
                        if (aFaitDouble)
                        {
                            Console.WriteLine("##   " +"Vous avez fait un double ! Rejouez !");
                            joueurCourant.SetJouer(false);
                        }
                    }
                }


                //////////////////////////
                // Tour des ordinateurs //
                //////////////////////////
                ///
                Console.WriteLine("\n\r\n▀▀█▀▀ ░█▀▀▀█ ░█ ░█ ░█▀▀█ 　 ░█▀▀▄ ░█▀▀▀ ░█▀▀▀█ 　 ░█▀▀▀█ ░█▀▀█ ░█▀▀▄ ▀█▀ ░█▄ ░█  █▀▀█ ▀▀█▀▀ ░█▀▀▀ ░█ ░█ ░█▀▀█ ░█▀▀▀█ \r\n ░█   ░█  ░█ ░█ ░█ ░█▄▄▀ 　 ░█ ░█ ░█▀▀▀  ▀▀▀▄▄ 　 ░█  ░█ ░█▄▄▀ ░█ ░█ ░█  ░█░█░█ ░█▄▄█  ░█   ░█▀▀▀ ░█ ░█ ░█▄▄▀  ▀▀▀▄▄ \r\n ░█   ░█▄▄▄█  ▀▄▄▀ ░█ ░█ 　 ░█▄▄▀ ░█▄▄▄ ░█▄▄▄█ 　 ░█▄▄▄█ ░█ ░█ ░█▄▄▀ ▄█▄ ░█  ▀█ ░█ ░█  ░█   ░█▄▄▄  ▀▄▄▀ ░█ ░█ ░█▄▄▄█");

                for (int i=1; i<4; i++)
                {
                    doubleDes = 0;
                    joueurCourant = lesJoueurs[i];
                    if (joueurCourant.GetFaillite() == false)
                    {
                        Console.Write("\n###################################################################");
                        while (!joueurCourant.aJouer())
                        {
                            if (joueurCourant.EstEnPrison())
                            {
                                Console.WriteLine("\n##   " +joueurCourant.GetNom() + " est en prison depuis " + joueurCourant.GetTourPrison() + " tour(s)");
                                if (joueurCourant.CarteSortiePrison())
                                {
                                    Console.WriteLine("##   " +"Carte sortie de prison utilisée !\n##   Il pourra jouer au prochain tour !");
                                    joueurCourant.SetCartePrison(false);
                                    joueurCourant.SetPrison(false);
                                    joueurCourant.SetTourPrison(0);
                                    joueurCourant.SetJouer(true);
                                }
                                else
                                {
                                    Random rnd = new Random();
                                    int SortiePrisonSansCarte = rnd.Next(1, 3);
                                    switch (SortiePrisonSansCarte)
                                    {
                                        case 1:
                                            Console.WriteLine("##   " +joueurCourant.GetNom() + " a payer 50$ ! \n##   Il pourra jouer au prochain tour !");
                                            joueurCourant.SetArgent(joueurCourant.GetArgent() - 50);
                                            joueurCourant.SetPrison(false);
                                            joueurCourant.SetTourPrison(0);
                                            joueurCourant.SetJouer(true);
                                            break;
                                        case 2:
                                            lancer = LancerDeDes();
                                            Console.WriteLine("##   " + "Les dés sont lancés !\n##   " + joueurCourant.GetNom() + " a obtenu un " + lancer[0] + " et un " + lancer[1]);
                                            if (lancer[0] == lancer[1])
                                            {
                                                Console.WriteLine("##   " + "C'est un double !\n##   " + joueurCourant.GetNom() + " sort de prison !\n##   Il peut donc jouer !");
                                                joueurCourant.SetPrison(false);
                                                joueurCourant.SetTourPrison(0);
                                                joueurCourant.SetJouer(true);
                                            }
                                            else if (joueurCourant.GetTourPrison() == 3)
                                            {
                                                Console.WriteLine("##   " +joueurCourant.GetNom() + " a passer assez de temps en prison !\n##   Il pourra jouer au prochain tour !");
                                                joueurCourant.SetJouer(true);
                                            }
                                            else
                                            {
                                                Console.WriteLine("##   " + "Ce n'est pas un double !\n##   Il reste en prison !");
                                                joueurCourant.SetTourPrison(joueurCourant.GetTourPrison() + 1);
                                                joueurCourant.SetJouer(true);
                                            }
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                lancer = LancerDeDes();
                                Console.WriteLine("\n##   \n##   Les dés sont lancés !\n##   " + joueurCourant.GetNom() + " a obtenu un " + lancer[0] + " et un " + lancer[1]);
                                nbCases = lancer[0] + lancer[1];
                                if (lancer[0] == lancer[1])
                                {
                                    Console.WriteLine("##   " +"C'est un double !");
                                    doubleDes++;
                                    if (doubleDes == 3)
                                    {
                                        Console.WriteLine("##   " +"C'est le troisième double ! " + joueurCourant.GetNom() + " va en prison !");
                                        joueurCourant.AllerEnPrison();
                                        joueurCourant.SetJouer(true);
                                    }
                                }
                                else
                                {
                                    joueurCourant.SetJouer(true);
                                }


                                if (!joueurCourant.EstEnPrison())
                                {
                                    joueurCourant.AddPosition(nbCases);
                                    laCase = Plateau[joueurCourant.GetPosition()];

                                    Console.WriteLine("##   " +joueurCourant.GetNom() + " avance de " + nbCases + " cases !");
                                    Console.WriteLine("##   " +"Il atterri sur la case " + laCase.AfficherNom());

                                    if (laCase.GetType().ToString() == "MonopolyGame.Carte_Achat")
                                    {
                                        if (laCase.EstAcheter())
                                        {
                                            if (laCase.GetProprio().GetNom().Equals(joueurCourant.GetNom()))
                                            {
                                                Console.WriteLine("##   " +joueurCourant.GetNom() + " est chez lui !");
                                                joueurCourant.SetJouer(true);
                                                Thread.Sleep(3000);
                                            }
                                            else
                                            {
                                                Console.WriteLine("##   " +joueurCourant.GetNom() + " est chez " + laCase.GetProprio().GetNom());
                                                if (laCase.AfficherType().Equals("Gare"))
                                                {
                                                    Console.WriteLine("##   " +laCase.GetProprio().GetNom() + " a " + laCase.GetProprio().GetNbGares() + " gare(s) !");
                                                    Console.WriteLine("##   " +joueurCourant.GetNom() + " doit donc payer " + laCase.GetProprio().GetNbGares() * 50 + "$ !");
                                                    joueurCourant.SetArgent(joueurCourant.GetArgent() - (laCase.GetProprio().GetNbGares() * 50));
                                                    laCase.GetProprio().SetArgent(laCase.GetProprio().GetArgent() + (laCase.GetProprio().GetNbGares() * 50));
                                                }
                                                else if (laCase.AfficherType().Equals("Service"))
                                                {
                                                    Console.WriteLine("##   " +joueurCourant.GetNom() + " doit payer son nombre de déplacement multiplié par 10 !");
                                                    Console.WriteLine("##   " +"Il paye " + nbCases * 10 + "$ !");
                                                    joueurCourant.SetArgent(joueurCourant.GetArgent() - nbCases * 10);
                                                    laCase.GetProprio().SetArgent(laCase.GetProprio().GetArgent() + nbCases * 10);
                                                }
                                                else
                                                {
                                                    Console.WriteLine("##   " +joueurCourant.GetNom() + " doit payer un loyer de " + laCase.GetLoyer() + "$");
                                                    joueurCourant.SetArgent(joueurCourant.GetArgent() - laCase.GetLoyer());
                                                    laCase.GetProprio().SetArgent(laCase.GetProprio().GetArgent() + laCase.GetLoyer());
                                                }
                                                joueurCourant.SetJouer(true);
                                                Thread.Sleep(3000);
                                            }
                                        }
                                        else
                                        {
                                            Random rnd = new Random();
                                            ReponseAchat = rnd.Next(0, 2);
                                            switch (ReponseAchat)
                                            {
                                                case 0:
                                                    Console.WriteLine("##   " +joueurCourant.GetNom() + " n'achete pas cette carte !");
                                                    Thread.Sleep(3000);
                                                    break;
                                                case 1:
                                                    if (joueurCourant.GetArgent() < laCase.GetPrix())
                                                    {
                                                        Console.WriteLine("##   " +joueurCourant.GetNom() + " n'a pas assez d'argent pour l'acheter !");
                                                        Thread.Sleep(3000);
                                                    }
                                                    else
                                                    {
                                                        joueurCourant.AcheterCarte(laCase);
                                                        Console.WriteLine("##   " +"Carte achetée avec succès !");
                                                        Console.WriteLine("##   " + joueurCourant.GetNom() + " a maintenant " + joueurCourant.GetArgent() + "$");
                                                        Thread.Sleep(3000);
                                                    }
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (laCase.AfficherNom().Equals("VisitePrison"))
                                        {
                                            Console.WriteLine("##   " +joueurCourant.GetNom() + " est en visite dans la prison");
                                            Thread.Sleep(3000);
                                        }
                                        else if (laCase.AfficherNom().Equals("EnvoiPrison"))
                                        {
                                            Console.WriteLine("##   " +joueurCourant.GetNom() + " est envoyé en prison !");
                                            joueurCourant.AllerEnPrison();
                                            Thread.Sleep(3000);
                                        }
                                        else if (laCase.AfficherNom().Equals("Depart"))
                                        {
                                            Console.WriteLine("##   " +"Case Départ !");
                                            Thread.Sleep(3000);
                                        }
                                        else if (laCase.AfficherNom().Equals("ParcGratuit"))
                                        {
                                            Console.WriteLine("##   " +joueurCourant.GetNom() + " est en visite du parc gratuit !");
                                            Thread.Sleep(3000);
                                        }
                                        else if (laCase.AfficherNom().Equals("Impots"))
                                        {
                                            Console.WriteLine("##   " +joueurCourant.GetNom() + " doit payer des impôts ! il donne 200$ !");
                                            joueurCourant.SetArgent(joueurCourant.GetArgent() - 200);
                                            Thread.Sleep(3000);
                                        }
                                        else if (laCase.AfficherNom().Equals("Chance"))
                                        {
                                            Console.WriteLine("##   " +"Carte Chance !");
                                            Random rnd = new Random();
                                            Carte_effet Effet = lesCartesEffet[rnd.Next(0, 6)];
                                            Effet.ActiverEffet(joueurCourant);
                                            Thread.Sleep(3000);
                                        }
                                        else
                                        {
                                            Console.WriteLine("##   " +"Carte Community !");
                                            Random rnd = new Random();
                                            Carte_effet Effet = lesCartesEffet[rnd.Next(6, 12)];
                                            Effet.ActiverEffet(joueurCourant);
                                            Thread.Sleep(3000);
                                        }
                                    }
                                }
                            }
                        }
                        //joueurCourant.SetArgent(joueurCourant.GetArgent() - 500);
                    }
                }
                //joueurCourant.SetArgent(joueurCourant.GetArgent() +200);




                ///////////////////////////////////
                // VERIFICATION DE FIN DE PARTIE //
                ///////////////////////////////////
                nbTour++;
                foreach (var item in  lesJoueurs)
                {
                    if (item.GetArgent() < 0 && !item.GetFaillite())
                    {
                        Console.WriteLine("\n###################################################################");
                        Console.WriteLine("##   " +item.GetNom() + " a fait faillite, il ne pourra donc plus jouer !\n##   Toutes ses propriétés sont remises au jeu !");
                        item.SetFaillite();
                    }
                }
                if (lesJoueurs[0].GetFaillite())
                {
                    Fin = "Vous avez fait faillite ! Vous pouvez quand-même rejouer !";
                    FinDePartie = true;
                }
                if (lesJoueurs[1].GetFaillite() && lesJoueurs[2].GetFaillite() && lesJoueurs[3].GetFaillite())
                {
                    Fin = "Vous êtes le grand gagnant ! Tous vos concurrents on fait faillite !";
                    FinDePartie = true;
                }
                Console.WriteLine("###################################################################");
                Thread.Sleep(3000);
            }
            Console.WriteLine("\n\n###################################################################\n##   " + Fin + "\n###################################################################");
            Thread.Sleep(5000);
            Console.WriteLine("\r\n██████╗░██████╗░░█████╗░██╗░░░██╗░█████╗░  ██╗\r\n██╔══██╗██╔══██╗██╔══██╗██║░░░██║██╔══██╗  ██║\r\n██████╦╝██████╔╝███████║╚██╗░██╔╝██║░░██║  ██║\r\n██╔══██╗██╔══██╗██╔══██║░╚████╔╝░██║░░██║  ╚═╝\r\n██████╦╝██║░░██║██║░░██║░░╚██╔╝░░╚█████╔╝  ██╗\r\n╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░░╚════╝░  ╚═╝");
        }

        static int[] LancerDeDes()
        {
            int[] tab = { 0, 0 };
            Random rnd = new Random();

            tab[0] = rnd.Next(1, 7); // creates a number between 1 and 6 from dice 1
            tab[1] = rnd.Next(1, 7);   // creates a number between 1 and 6 from dice 2

            return tab;
        }

        static void AfficherCartesPourAchat()
        {
            ListeNumRachat.Clear();
            Console.WriteLine("###################################################################");
            Console.WriteLine("##   Les cartes disponibles :\n##  ----------------------");
            foreach (var couleur in ListeCouleur)
            {
                Console.WriteLine("##   " + couleur + " :");
                for (int i=0; i< Plateau.Count(); i++)
                {
                    if (Plateau[i].EstAcheter())
                    { 
                        if (Plateau[i].GetCouleur() == couleur && !Plateau[i].GetProprio().GetNom().Equals("Joueur"))
                        {
                            ListeNumRachat.Add(i);
                            Console.Write("##   Numéro " + i + " détenu par " + Plateau[i].GetProprio().GetNom() + " - ");
                            Plateau[i].afficherCase();
                        }
                    }
                    
                }
                Console.WriteLine("##   ");
            }
            Console.WriteLine("###################################################################\n");
        }

        static void AfficherPlateau()
        {
            Console.WriteLine("_________________________________________________________________________________________________________________________________________________________________________________");
            //Thread.Sleep(25);
            Console.WriteLine("| SIMPLE VISITE |    Ville      |    Service    |    Ville      |    Ville      |     Gare      |    Ville      |               |   Ville       |    Ville      |               |");
            //Thread.Sleep(25);
            Console.WriteLine("|       +-------|    Lille      |  Electricité  |   Bordeaux    |   Mulhouse    |    De Lyon    |   Grenoble    |    Carte      |   Rennes      |    Caen       |    PARC       |");
            //Thread.Sleep(25);
            Console.WriteLine("|       |  EN   |    140$       |     200$      |     140$      |     160$      |     200$      |     180$      |   Community   |    180$       |    200$       |   GRATUIT     |");
            //Thread.Sleep(25);
            Console.WriteLine("|       |PRISON |" + Plateau[11].afficherAcheteur() + "|" + Plateau[12].afficherAcheteur() + "|" + Plateau[13].afficherAcheteur() + "|" + Plateau[14].afficherAcheteur() + "|" + Plateau[15].afficherAcheteur() + "|" + Plateau[16].afficherAcheteur() + "|               |" + Plateau[18].afficherAcheteur() + "|" + Plateau[19].afficherAcheteur() + "|               |");
            //Thread.Sleep(25);
            Console.WriteLine("|_______|_______|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Ville      |                                                                                                                                               |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("|  Montlauzun   |                                                                                                                                               |    Toulon     |");
            //Thread.Sleep(25);
            Console.WriteLine("|     120$      |                                                                                                                                               |     220$      |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[9].afficherAcheteur() + "|                                                                                                                                               |" + Plateau[21].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Ville      |                                                                                                                                               |               |");
            //Thread.Sleep(25);
            Console.WriteLine("| Saint-Martin  |                                                                                                                                               |    Carte      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    100$       |                                                                                                                                               |    Chance     |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[8].afficherAcheteur() + "|                                                                                                                                               |               |");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|               |                  ███╗░░░███╗░█████╗░███╗░░██╗░█████╗░██████╗░░█████╗░██╗░░░░░██╗░░░██╗  ░██████╗░░█████╗░███╗░░░███╗███████╗                  |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Carte      |                  ████╗░████║██╔══██╗████╗░██║██╔══██╗██╔══██╗██╔══██╗██║░░░░░╚██╗░██╔╝  ██╔════╝░██╔══██╗████╗░████║██╔════╝                  |    Nîmes      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Chance     |                  ██╔████╔██║██║░░██║██╔██╗██║██║░░██║██████╔╝██║░░██║██║░░░░░░╚████╔╝░  ██║░░██╗░███████║██╔████╔██║█████╗░░                  |     220$      |");
            Console.WriteLine("|               |                  ██║╚██╔╝██║██║░░██║██║╚████║██║░░██║██╔═══╝░██║░░██║██║░░░░░░░╚██╔╝░░  ██║░░╚██╗██╔══██║██║╚██╔╝██║██╔══╝░░                  |" + Plateau[23].afficherAcheteur() + "|");
            Console.WriteLine("|_______________|                  ██║░╚═╝░██║╚█████╔╝██║░╚███║╚█████╔╝██║░░░░░╚█████╔╝███████╗░░░██║░░░  ╚██████╔╝██║░░██║██║░╚═╝░██║███████╗                  |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Ville      |                  ╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚══╝░╚════╝░╚═╝░░░░░░╚════╝░╚══════╝░░░╚═╝░░░  ░╚═════╝░╚═╝░░╚═╝╚═╝░░░░░╚═╝╚══════╝                  |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("| Saint-Etienne |                                                                                                                                               |    Dijon      |");
            //Thread.Sleep(25);
            Console.WriteLine("|     100$      |                                                                                                                                               |    240$       |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[6].afficherAcheteur() + "|                                                                                                                                               |" + Plateau[24].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Gare       |                                                                                                                                               |     Gare      |");
            //Thread.Sleep(25);
            Console.WriteLine("| Montparnasse  |                                                                                                                                               |    Du Nord    |");
            //Thread.Sleep(25);
            Console.WriteLine("|     200$      |                                                                                                                                               |     200$      |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[5].afficherAcheteur() + "|                                                                                                                                               |" + Plateau[25].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|               |                            ░░██╗░█████╗░░░░██╗░██╗░  ██████╗░██████╗░░█████╗░░░░░░██╗███████╗░█████╗░████████╗██╗░░                           |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Carte      |                            ░██╔╝██╔══██╗██████████╗  ██╔══██╗██╔══██╗██╔══██╗░░░░░██║██╔════╝██╔══██╗╚══██╔══╝╚██╗░                           |    Angers     |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Impots     |                            ██╔╝░██║░░╚═╝╚═██╔═██╔═╝  ██████╔╝██████╔╝██║░░██║░░░░░██║█████╗░░██║░░╚═╝░░░██║░░░░╚██╗                           |     260$      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    -200$      |                            ╚██╗░██║░░██╗██████████╗  ██╔═══╝░██╔══██╗██║░░██║██╗░░██║██╔══╝░░██║░░██╗░░░██║░░░░██╔╝                           |" + Plateau[26].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                            ░╚██╗╚█████╔╝╚██╔═██╔══╝  ██║░░░░░██║░░██║╚█████╔╝╚█████╔╝███████╗╚█████╔╝░░░██║░░░██╔╝░                           |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Ville      |                            ░░╚═╝░╚════╝░░╚═╝░╚═╝░░░  ╚═╝░░░░░╚═╝░░╚═╝░╚════╝░░╚════╝░╚══════╝░╚════╝░░░░╚═╝░░░╚═╝░░                           |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Annecy     |                                                                                                                                               |  Strasbourg   |");
            //Thread.Sleep(25);
            Console.WriteLine("|     60$       |                                                                                                                                               |     260$      |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[3].afficherAcheteur() + "|                                                                                                                                               |" + Plateau[27].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|               |                                                                                                                                               |    Service    |");
            //Thread.Sleep(25);
            Console.WriteLine("|    Carte      |                                                                                                                                               |   Des Eaux    |");
            //Thread.Sleep(25);
            Console.WriteLine("|  Community    |                                                                                                                                               |     200$      |");
            //Thread.Sleep(25);
            Console.WriteLine("|               |                                                                                                                                               |" + Plateau[28].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|                                                                                                                                               |_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|    Ville      |                                                                                                                                               |    Ville      |");
            //Thread.Sleep(25);
            Console.WriteLine("|   Roubaix     |                                                                                                                                               |    Reims      |");
            //Thread.Sleep(25);
            Console.WriteLine("|     60$       |                                                                                                                                               |    280$       |");
            //Thread.Sleep(25);
            Console.WriteLine("|" + Plateau[1].afficherAcheteur() + "|                                                                                                                                               |" + Plateau[29].afficherAcheteur() + "|");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|_______________________________________________________________________________________________________________________________________________|_______________|");
            //Thread.Sleep(25);
            Console.WriteLine("|               |    Ville      |               |    Ville      |               |     Gare      |    Ville      |               |    Ville      |    Ville      |               |");
            //Thread.Sleep(25);
            Console.WriteLine("|    DEPART     |    Paris      |    Carte      |    Monaco     |   Carte       | Saint-Lazarre |    Nice       |   Carte       |  Marseille    |   Toulouse    |     ALLER     |");
            //Thread.Sleep(25);
            Console.WriteLine("|     200$      |    400$       |   Impots      |    350$       |   Chance      |     200$      |    320$       |  Community    |    300$       |     300$      |      EN       |");
            //Thread.Sleep(25);
            Console.WriteLine("|               |" + Plateau[39].afficherAcheteur() + "|   -200$       |" + Plateau[37].afficherAcheteur() + "|               |" + Plateau[35].afficherAcheteur() + "|" + Plateau[34].afficherAcheteur() + "|               |" + Plateau[32].afficherAcheteur() + "|" + Plateau[31].afficherAcheteur() + "|    PRISON     |");
            //Thread.Sleep(25);
            Console.WriteLine("|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|_______________|");


        }

    }
}