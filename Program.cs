using System;
using System.Threading;
using System.Threading.Tasks;

namespace JeuDeRole_v1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion
            MaitreDuJeu maitreDuJeu = new MaitreDuJeu();
            Joueur joueur = new Joueur();
            MonstreFacile monstreFacile = new MonstreFacile();
            De de = new De();
            #region MyRegion
            #endregion
            #endregion

            Fenetre(maitreDuJeu);
            Console.SetCursorPosition(45, 4);
            maitreDuJeu.Message1();
            //Console.Write("Aventurier saisie ton pseudo:");
            Console.SetCursorPosition(75, 4);
            var saisienom = Console.ReadLine();
            Console.CursorVisible = false;
            Fenetre(maitreDuJeu);
            joueur.Nom = saisienom.ToUpper();
            Tournois(maitreDuJeu, joueur, monstreFacile, de);
            Task thread1 = new Task(() => Monstre(monstreFacile, de));
            Task thread2 = new Task(() => Joueur(joueur, de));
            Task thread3 = new Task(() => Fenetre(maitreDuJeu));
            thread1.Start();
            thread1.Wait();
            thread2.Start();
            thread2.Wait();
            thread3.Start();
            thread3.Wait();
        }
        #region methodes
        static void Tournois(MaitreDuJeu maitreDuJeu, Joueur joueur, MonstreFacile monstreFacile, De de)
        {
            while (true)
            {

                if (joueur.EstVivant != false)
                {
                    Fenetre(maitreDuJeu);
                    monstreFacile.DegatsSubit = joueur.Degats;
                    joueur.DegatsSubit = monstreFacile.Degats;
                    joueur.Experience(monstreFacile);
                    joueur.EstVivant = true;
                    if (joueur.PointsDeVie > 0 && monstreFacile.PointsDeVie > 0)
                    {
                        if (true)
                        {
                            Joueur(joueur, de);
                            if (joueur.PointsDeVie < 1)
                            {
                                Console.SetCursorPosition(45, 20);
                                Console.WriteLine($"Partie terminé ton niveau d'experience est de {joueur.Xp} monstres battu");
                                Thread.Sleep(1000);
                                break;
                            }
                        }
                        if (true)
                        {
                            Monstre(monstreFacile, de);
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(45, 4);
                        Console.WriteLine("Un nouveaux combatant entre dans l'arene !!!");
                        Console.WriteLine("");
                        Jouer();
                        void Jouer()
                        {
                            Console.Clear();
                            monstreFacile = new MonstreFacile();
                            Monstre(monstreFacile, de);
                        }
                    }
                }
                Console.SetCursorPosition(43, 4);
                Console.WriteLine($"{joueur.Nom} appuis sur touche pour lancer le prochain tour...");
                Console.ReadKey(false);

            }
        }
        static void Joueur(Joueur joueur, De de)
        {
            joueur.RapportDuPersonnage(joueur, de);
        }

        static void Fenetre(MaitreDuJeu maitreDuJeu)
        {
            maitreDuJeu.CadrageFenetre(145, 43);//Fenetre 140x43
            maitreDuJeu.DrawABox(41, 0, 57, 8, '*', " ");
        }

        static void Monstre(MonstreFacile monstreFacile, De de)
        {
            monstreFacile.RapportDuPersonnage(monstreFacile, de);
        } 
        #endregion
    }
}
