using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonopolyGame
{
    class Case
    {
        #region Méthodes VIRTUAL
        public virtual int GetNbBatiments()
        {
            return 0;
        }

        public virtual double[] GetLoyerBatiment()
        {
            return null;
        }
        public virtual void SetLoyer(int unLoyer)
        {

        }
        public virtual string GetCouleur()
        {
            return "";
        }
        public virtual string AfficherNom()
        {
            return "";
        }

        public virtual string AfficherType()
        {
            return "";
        }

        public virtual Joueur GetProprio()
        {
            return null;
        }

        public virtual int GetPrix()
        {
            return 0;
        }

        public virtual void SetProprio(Joueur unJoueur)
        {
            ;
        }

        public virtual int GetLoyer()
        {
            return 0;
        }

        public virtual bool EstAcheter()
        {
            return false;
        }

        public virtual void SetAcheter(bool result)
        {
            ;
        }

        public virtual void afficherCase()
        {
        }


        public virtual string afficherAcheteur()
        {
            return "";
        }

        public virtual string[] GetInformations()
        {
            string[] tab = new string[3];
            return tab;
        }
        public virtual void SetNbBat(int unInt)
        {
            ;
        }
        #endregion
    }
}
