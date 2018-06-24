using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChiffresRomains
{
    /// <summary>
    /// Classe tools conversion chiffre nombre decimal - chiffre romain
    /// </summary>
    public static class cConvertChiffreRomain
    {
        private const int C_VALMIN = 1;         // valeur min nombre decimal 
        private const int C_VALMAX = 4000;      // valeur max nombre decimal


        /// <summary>Table d'équivalence entre chiffres romains et decimal</summary>
        private static List<Tuple<int, string>> m_tabCorrespondances = null;


        /// <summary>
        /// Constructeur static : init tables internes
        /// </summary>
        static cConvertChiffreRomain()
        {
            // init table d'équivalence interne chiffres romains/decimal
            m_tabCorrespondances = new List<Tuple<int, string>>();

            m_tabCorrespondances.Add(new Tuple<int, string>(1, "I"));
            m_tabCorrespondances.Add(new Tuple<int, string>(2, "II"));
            m_tabCorrespondances.Add(new Tuple<int, string>(3, "III"));
            m_tabCorrespondances.Add(new Tuple<int, string>(4, "IV"));
            m_tabCorrespondances.Add(new Tuple<int, string>(5, "V"));
            m_tabCorrespondances.Add(new Tuple<int, string>(6, "VI"));
            m_tabCorrespondances.Add(new Tuple<int, string>(7, "VII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(8, "VIII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(9, "IX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(11, "XI"));
            m_tabCorrespondances.Add(new Tuple<int, string>(12, "XII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(13, "XIII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(14, "XIV"));
            m_tabCorrespondances.Add(new Tuple<int, string>(15, "XV"));
            m_tabCorrespondances.Add(new Tuple<int, string>(16, "XVI"));
            m_tabCorrespondances.Add(new Tuple<int, string>(17, "XVII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(18, "XVIII"));
            m_tabCorrespondances.Add(new Tuple<int, string>(19, "XIX"));

            m_tabCorrespondances.Add(new Tuple<int, string>(10, "X"));
            m_tabCorrespondances.Add(new Tuple<int, string>(20, "XX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(30, "XXX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(40, "XL"));
            m_tabCorrespondances.Add(new Tuple<int, string>(50, "L"));
            m_tabCorrespondances.Add(new Tuple<int, string>(60, "LX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(70, "LXX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(80, "LXXX"));
            m_tabCorrespondances.Add(new Tuple<int, string>(90, "XC"));

            m_tabCorrespondances.Add(new Tuple<int, string>(100, "C"));
            m_tabCorrespondances.Add(new Tuple<int, string>(200, "CC"));
            m_tabCorrespondances.Add(new Tuple<int, string>(300, "CCC"));
            m_tabCorrespondances.Add(new Tuple<int, string>(400, "CD"));
            m_tabCorrespondances.Add(new Tuple<int, string>(500, "D"));
            m_tabCorrespondances.Add(new Tuple<int, string>(600, "DC"));
            m_tabCorrespondances.Add(new Tuple<int, string>(700, "DCC"));
            m_tabCorrespondances.Add(new Tuple<int, string>(800, "DCCC"));
            m_tabCorrespondances.Add(new Tuple<int, string>(900, "CM"));

            m_tabCorrespondances.Add(new Tuple<int, string>(1000, "M"));
            m_tabCorrespondances.Add(new Tuple<int, string>(2000, "MM"));
            m_tabCorrespondances.Add(new Tuple<int, string>(3000, "MMM"));
            m_tabCorrespondances.Add(new Tuple<int, string>(4000, "MMMM"));
        }

        /// <summary>
        /// Conversion int en chiffre romain
        /// </summary>
        /// <param name="iValue">Valeur à convertir</param>
        /// <returns>Conversion</returns>
        public static string Convert(int iValeur)
        {
            StringBuilder oStrRetValue = new StringBuilder("");
            int iValeurRestante = iValeur;
            int iCptInfiniteLoop = 5000;            // securite pour eviter une boucle infinie (au cas où)

            try
            {
                // Check valeur : Min / max géré
                if( iValeur < C_VALMIN || iValeur > C_VALMAX )
                {
                    throw new ArgumentException(string.Format("La valeur doit être comprise entre {0} et {1} !", C_VALMIN, C_VALMAX));
                }

                // principe : a partir d'une table d'équivalence (decimal/romain), on récupère le nb decimal <= valeur à convertir
                // ensuite, on continue avec le reste tant qu'il en reste...
                while (iValeurRestante > 0 && iCptInfiniteLoop > 0 )
                {
                    // recherche du nb decimal <= iValeurRestante dans la table (le plus proche)
                    var oItemTrouve = m_tabCorrespondances.Where((item) => { return item.Item1 <= iValeurRestante; }).Max<Tuple<int, string>>();
                    if(oItemTrouve != null )
                    {
                        iValeurRestante -= oItemTrouve.Item1;       // Maj du reste à traiter
                        oStrRetValue.Append(oItemTrouve.Item2);     // ajout chiffres romains
                    }
                    else
                    {
                        // erreur algo !
                        throw new Exception("Erreur interne !");
                    }
                    iCptInfiniteLoop --;
                }

                if( iCptInfiniteLoop <=0 )
                {
                    // erreur algo !
                    throw new Exception("Erreur interne !");
                }
            }
            catch (Exception)
            {
                // pas de tmt particulier ..
                throw;
            }

            return oStrRetValue.ToString();
        }
    }
}
