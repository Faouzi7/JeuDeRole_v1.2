using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace JeuDeRole_v1._2
{

    public class Message
    {
        public void Messages(Combatant combatant, string message)
        {
            string text1 = $"Boujour Dominique, on fait quoi ce matin";
            string text2 = $"Cartes de lavage de voitures, de fidélité ou de paiement de carburant," + "\n" +
                            "les pétroliers proposent depuis longtemps une vaste panoplie " + "\n" +
                            "de cartes privatives à la clientèle de leurs stations-service." + "\n" +
                            "A puce ou magnétiques, elles suscitent une telle convoitise " + "\n" +
                            "qu'une analyse approfondie de leurs mécanismes de sécurité était bien tentante...";
            string text3 = $"";
            string text4 = $"";
            string text5 = $"";
            for (int i = 0; i < text2.Length; i++)
            {
                Console.Write((text2[i]));
                Thread.Sleep(100);
            }
        }
    }
}