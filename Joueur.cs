using System;

namespace JeuDeRole_v1._2
{
    public class Joueur : Combatant
    {
        public string Classe { get; set; }
        public int Bouclier { get; set; }
        public int Niveaux { get; set; }
        public int Xp { get; set; }

        protected Random randomJoueur = new Random();
        public Joueur()
        {
            this.Nom = "TAO";
            this.PointsDeVie = 200;
            this.PointsDeVieMax = 200;
            this.Classe = "Guerrier";
            this.Xp = 0;
            this.Bouclier = 20;
            this.Niveaux = 1;
            this.EstVivant = true;
            this.Degats = default;//Dégats generé par le joueur
            this.DegatsRandom = default;//Dégats generé par le joueur
            this.DegatsSubit = default;//AttaquePhysisque du monstre facile
            this.DegatsMin = 5;
            this.DegatsMax = 20;
            if (this.PointsDeVie < 1)
            {
                this.EstVivant = false;
                this.PointsDeVie = 0;                
            }
        }
        public float Experience(Combatant combatant)
        {
            if (combatant.PointsDeVie<1)
            {
                this.Xp++;
            }
            return Xp;
        }
        public override float AttaquePhysisque(Combatant combatant, De de)
        {
            var result = (AttaqueMinMax() + AttaqueRandomDe(de));
            return this.Degats = result;
        }
        public override float AttaqueRandomDe(De de)
        {
            return this.DegatsRandom = de.LanceLeDe();
        }
        public override float AttaqueMinMax()
        {
            var result = randomJoueur.Next((int)this.DegatsMin, (int)this.DegatsMax);
            return result;
        }
        public override void RapportDuPersonnage(Combatant combatant, De de)
        {
            Console.SetCursorPosition(100, 1);
            Console.Write("Nom du gladiateur    : [" + this.Nom + "]\n");
            Console.SetCursorPosition(100, 2);
            BarrePv();
            Console.SetCursorPosition(100, 3);
            Console.Write("Personnage de classe : [" + this.Classe + "]\n");
            Console.SetCursorPosition(100, 4);
            Console.Write("Niveaux d'expérience : [" + this.Niveaux + "]\n");
            Console.SetCursorPosition(100, 5);
            Console.Write("Puissance d'attaque  : [" + $"{this.DegatsMin}-{this.DegatsMax}" + "]\n");
            Console.SetCursorPosition(100, 6);
            Console.Write("Dégats total infligés: [" + $"{AttaquePhysisque(combatant, de)}" + "]\n");
            //Console.SetCursorPosition(100, 7);
            //Console.Write("Ramdom du dé         : [" + $"{AttaqueRandomDe(de)}" + "]\n");
            Console.SetCursorPosition(100, 7);
            Console.Write("Bouclier             : [" + this.Bouclier + "]\n");
            Console.SetCursorPosition(100, 8);
            Console.Write("Experience acquise   : [" + Xp + "]");
            Console.SetCursorPosition(100, 9);
            Console.Write("Dégats subis         : [" + this.DegatsSubit + "]");
        }
        public void BarrePv()
        {
            this.PointsDeVie -= this.DegatsSubit;
            var result = this.PointsDeVie;

            Console.CursorLeft = 100;
            Console.Write("["); //start 
            Console.CursorLeft = 131;
            Console.Write("]"); //end 
            Console.CursorLeft = 101;
            float totcombatant = 200;
            float onechunk = 30.0f / totcombatant; //draw filled part 
            int position = 101;
            float progress = result;

            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }
            //draw unfilled part 
            for (int i = position; i <= 130; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }
            //draw totals 
            Console.CursorLeft = 133;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " / " + this.PointsDeVieMax); //blanks at the end remove any excess } 
            Console.CursorVisible = false;

        }
    }
}