using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    class Carte_Autre : Case
    {
        #region Variables
        private string type; // Depart, Impots, Service, Prison, AllerEnPrison, ParcGratuit, Community, Chance
        #endregion

        public Carte_Autre(string unType) 
        { 
            type = unType;
        }

        #region Getters
        public override string[] GetInformations()
        {
            string[] tab = new string[]
            {
                type
            };

            return tab;
        }

        public override string AfficherNom()
        {
            return type;
        }
        #endregion

        #region Setters
        public override void afficherCase()
        {
            Console.WriteLine("  " + type);
        }



        #endregion



    }
}
