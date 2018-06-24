using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestChiffresRomains
{
    class Program
    {
        static void Main(string[] args)
        {
            bool bExit = false;


            while (!bExit)
            {
                Console.WriteLine("Entrez un nombre à convertir en notation romaine (q+enter pour quitter) : ");

                var sInput = Console.ReadLine();
                if( string.Compare(sInput, "q", true) == 0 )
                {
                    bExit = true;
                }
                else
                {
                    // Convert
                    try
                    {
                        int iValeur = 0;
                        if( int.TryParse(sInput, out iValeur))
                        {
                            Console.WriteLine("Résultat : {0}", cConvertChiffreRomain.Convert(iValeur));
                        }
                        else
                        {
                            throw new Exception(string.Format("Valeur {0} incorrecte !", sInput));
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.WriteLine("Erreur : {0}", ex.Message);
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
