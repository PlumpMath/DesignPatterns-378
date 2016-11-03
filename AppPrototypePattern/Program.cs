using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPrototypePattern
{
    public  abstract class AProtagonist
    {
        int m_health;

        public int Health
        {
            get { return m_health; }
            set { m_health = value; }
        }
        int m_felony;

        public int Felony
        {
            get { return m_felony; }
            set { m_felony = value; }
        }
        double m_money;

        public double Money
        {
            get { return m_money; }
            set { m_money = value; }
        }
        public abstract AProtagonist Clone();
    }

    class CJ : AProtagonist
    {

        public override AProtagonist Clone()
        {
            return this.MemberwiseClone() as AProtagonist;
        }
    }
    public class AdditionalDetails
    {
        int m_charisma;
        int m_fitness;

        public int Charisma
        {
            get { return m_charisma; }
            set { m_charisma = value; }
        }

        public int Fitness
        {
            get { return m_fitness; }
            set { m_fitness = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            CJ player = new CJ();
            player.Money = 2.0;
            player.Health = 1;
            player.Felony = 10;

            Console.WriteLine("Original Player stats:");
            Console.WriteLine("Health: {0}, Felony: {1}, Money: {2}", player.Health.ToString(),player.Felony.ToString(),player.Money.ToString());

            CJ playerToSave = player.Clone() as CJ;
            Console.WriteLine("\nCopy of player to save on disk:");
            Console.WriteLine("Health: {0}, Felony: {1}, Money: {2}",playerToSave.Health.ToString(),playerToSave.Felony.ToString(),playerToSave.Money.ToString());
        }
    }
}
