using System;
using System.Collections.Generic;
using System.Text;

namespace JeuDeRole_v1._2
{
    public abstract class Combatant
    {
        public string Nom;
        public float PointsDeVie;
        public float PointsDeVieMax;
        public bool EstVivant;
        public float Degats;
        public float DegatsRandom;
        public float DegatsSubit;
        public float DegatsMin;
        public float DegatsMax;
        public abstract float AttaqueMinMax();
        public abstract float AttaquePhysisque(Combatant combatant,De de);
        public abstract float AttaqueRandomDe(De de);
        public abstract void RapportDuPersonnage(Combatant combatant,De de);
    }
}