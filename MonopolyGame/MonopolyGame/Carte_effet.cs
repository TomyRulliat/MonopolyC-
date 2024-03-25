using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    class Carte_effet
    {
        #region Variables
        private int id; // 1 => 10
        private string type; // chance / community
        private string categorie; // deplacer / item / gagnerArgent / perdreArgent
        private string nom; // Avancer jusqu'a la case départ
        private string description; // gagner $200
        private int effet; // Si effet = 50 et que category = gagnerArgent alors  argent += 100
        #endregion

        public Carte_effet(int unId, string unType, string uneCategorie, string unNom, string uneDescription, int unEffet)
        {
            id = unId;
            type = unType;
            categorie = uneCategorie;
            nom = unNom;
            description = uneDescription;
            effet = unEffet;
        }

        public void ActiverEffet(Joueur leJoueur)
        {
            Console.WriteLine(nom + " - " + description);
            if (categorie.Equals("item"))
            {
                leJoueur.SetCartePrison(true);
            }
            else if (categorie.Equals("deplacer"))
            {
                leJoueur.SetPosition(0);
                leJoueur.SetArgent(leJoueur.GetArgent() + effet);
            }
            else if (categorie.Equals("gagnerArgent"))
            {
                leJoueur.SetArgent(leJoueur.GetArgent() + effet);
            }
            else
            {
                leJoueur.SetArgent(leJoueur.GetArgent() - effet);
            }
        }
    }
}
