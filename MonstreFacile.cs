using System;
using System.Collections;
using System.Collections.Generic;

namespace JeuDeRole_v1._2
{
    enum Noms
    {
        KIKOUP,
        GROZBAF,
        GOUDURIX,
        TARTANPION
    }
    public class MonstreFacile : Combatant
    {
        public string Classe { get; set; }
        public int Sortileges { get; set; }
        public int Niveaux { get; set; }
        public int Xp { get; set; }

        protected Random randomMonstre = new Random();
        protected Random randomNoms = new Random();
        List<string> list = new List<string> { 
            "KIKOUP",
            "GROZBAF", 
            "GOUDURIX", 
            "TARTANPION",
            "TAPEDUR",
            "TETEDANCHOIX",
            "KEDAL",
            "KIKOUPTOU",
            "CELINEDION",
            "BARTABAS",
        };
        public MonstreFacile()
        {
            int index = randomNoms.Next(list.Count);            
            var result = list[index];
            this.Nom = result;
            this.PointsDeVie = 80;
            this.PointsDeVieMax = 80;
            this.Classe = "Non communiqué";
            this.Xp = 0;
            this.Sortileges = 0;
            this.Niveaux = 1;
            this.EstVivant = true;
            this.Degats = default;//Dégats généré par le monstre facile
            this.DegatsRandom = default;//Dégats généré par le monstre facile
            this.DegatsSubit = default;//AttaquePhysisque du joueur
            this.DegatsMin = 2;
            this.DegatsMax = 5;
            if (this.PointsDeVie < 1)
            {
                this.EstVivant = false;
                this.PointsDeVie = 0;
            }
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
            var result = randomMonstre.Next((int)this.DegatsMin, (int)this.DegatsMax);
            return result;
        }
        public void BarrePv()
        {

            this.PointsDeVie -= this.DegatsSubit;
            var result = this.PointsDeVie;

            Console.CursorLeft = 0;
            Console.Write("["); //start 
            Console.CursorLeft = 31;
            Console.Write("]"); //end 
            Console.CursorLeft = 1;
            float totcombatant = 80;
            float onechunk = 30.0f / totcombatant; //draw filled part 
            int position = 1;
            float progress = result;

            for (int i = 0; i < onechunk * progress; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }
            //draw unfilled part 
            for (int i = position; i <= 30; i++)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.CursorLeft = position++;
                Console.Write(" ");
            }
            //draw totals 
            Console.CursorLeft = 33;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Write(progress.ToString() + " / " + this.PointsDeVieMax); //blanks at the end remove any excess } 
            Console.CursorVisible = false;
        }
        public override void RapportDuPersonnage(Combatant combatant, De de)
        {
            Console.SetCursorPosition(1, 1);
            Console.Write("Nom du gladiateur    : [" + this.Nom + "]\n");
            Console.SetCursorPosition(1, 2);
            BarrePv();
            Console.SetCursorPosition(1, 3);
            Console.Write("Personnage de classe : [" + this.Classe + "]\n");
            Console.SetCursorPosition(1, 4);
            Console.Write("Niveaux d'expérience : [" + this.Niveaux + "]\n");
            Console.SetCursorPosition(1, 5);
            Console.Write("Puissance d'attaque  : [" + $"{this.DegatsMin}-{this.DegatsMax}" + "]\n");
            Console.SetCursorPosition(1, 6);
            Console.Write("Dégats total infligés: [" + $"{AttaquePhysisque(combatant, de)}" + "]\n");
            //Console.SetCursorPosition(1, 7);
            //Console.Write("Ramdom du dé         : [" + $"{AttaqueRandomDe(de)}" + "]\n");
            Console.SetCursorPosition(1, 7);
            Console.Write("Sortilèges           : [" + this.Sortileges + "]\n");
            Console.SetCursorPosition(1, 8);
            Console.Write("Experience acquise   : [" + Xp + "]");
            Console.SetCursorPosition(1, 9);
            Console.Write("Dégats subis         : [" + this.DegatsSubit + "]");
        }
    }
}