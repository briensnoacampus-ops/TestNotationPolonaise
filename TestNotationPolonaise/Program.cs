using System;

namespace TestNotationPolonaise
{
    class Program
    {
        /// <summary>
        /// saisie d'une réponse d'un caractère parmi 2
        /// </summary>
        /// <param name="message">message à afficher</param>
        /// <param name="carac1">premier caractère possible</param>
        /// <param name="carac2">second caractère possible</param>
        /// <returns>caractère saisi</returns>
        static char saisie(string message, char carac1, char carac2)
        {
            char reponse;
            do
            {
                Console.WriteLine();
                Console.Write(message + " (" + carac1 + "/" + carac2 + ") ");
                reponse = Console.ReadKey().KeyChar;
            } while (reponse != carac1 && reponse != carac2);
            return reponse;
        }

        static float Polonaise(string formule)
        {
            try
            {
                string[] tab = formule.Split(' ');
                int nbCases = tab.Length;

                // Parcours de la fin du tableau vers le début
                for (int n = nbCases - 1; n >= 0; n--)
                {
                    string elem = tab[n];

                    if (elem == "+" || elem == "-" || elem == "*" || elem == "/")
                    {
                        float a = float.Parse(tab[n + 1]);
                        float b = float.Parse(tab[n + 2]);
                        float res = 0;

                        if (elem == "+") res = a + b;
                        else if (elem == "-") res = a - b;
                        else if (elem == "*") res = a * b;
                        else if (elem == "/")
                        {
                            if (b == 0) return float.NaN;
                            res = a / b;
                        }

                        // Remplacer le signe par le résultat
                        tab[n] = res.ToString();

                        // Décaler de 2 cases vers la gauche à partir de n + 1
                        for (int j = n + 1; j < nbCases - 2; j++)
                        {
                            tab[j] = tab[j + 2];
                        }

                        // Remplacer les 2 dernières cases par un espace
                        tab[nbCases - 2] = " ";
                        tab[nbCases - 1] = " ";
                    }
                }

                // Vérifier qu'il ne reste pas d'opérateur ou d'élément invalide
                float resultatFinal = float.Parse(tab[0]);
                return resultatFinal;
            }
            catch
            {
                return float.NaN;
            }
        }

        /// <summary>
        /// Saisie de formules en notation polonaise pour tester la fonction de calcul
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            char reponse;
            // boucle sur la saisie de formules
            do
            {
                Console.WriteLine();
                Console.WriteLine("entrez une formule polonaise en séparant chaque partie par un espace = ");
                string laFormule = Console.ReadLine();
                // affichage du résultat
                Console.WriteLine("Résultat =  " + Polonaise(laFormule));
                reponse = saisie("Voulez-vous continuer ?", 'O', 'N');
            } while (reponse == 'O');
        }
    }
}
