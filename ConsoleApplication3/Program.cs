using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Compte
    {
        protected int _Code;
        protected float _Solde;
        protected float _Montant;

        public int code
        {
            get { return _Code; }
            set { _Code = code;}
        }
        public float solde
        {
            get { return _Solde; }
            set { _Solde = solde; }
        }  
        public float montant
        {
            get { return _Montant; }
            set { _Montant = value; }
        }
        public   Compte( float solde=0)
        {
            _Solde = solde;
        }
    }
    class CompteEpargne:Compte
    {
       private float taux_interet;
        public float TI
        {
            get { return taux_interet; }
            set { taux_interet = 6/100; }
        }
        public CompteEpargne( float solde=0 ) : base(solde)
        {
            TI = taux_interet;
        }
        private float calculInteret(float X)
        {
            float interet = X * taux_interet;
            return interet;
        }
        public void initial_epargne()
        {
            int etat;
            code = code + 1;

            Console.WriteLine("Voulez vous un compte Epargne avec solde initial?   1: Oui,   0: Non");
            etat = int.Parse(Console.ReadLine());
            if (etat == 1)
            {
                Console.WriteLine("Solde Initial epargne");
                this.solde = float.Parse(Console.ReadLine());
            }else if (etat == 0)
            {
                this.solde = 0;
            }
        }
        public void depot_epargne()
        {
            Console.WriteLine("Montant du Depot");
            this.montant = float.Parse(Console.ReadLine());
            this.solde = (this.solde + this.montant);
        }
        public void retrait_epargne()
        {
            Console.WriteLine("Montant du retrait");
            this.montant = float.Parse(Console.ReadLine());
            this.solde = this.solde - this.montant;
        }
    }

    class ComptePayant : Compte
    {
        private float taux_retrait;
        public float TR
        {
            get { return taux_retrait; }
            set { taux_retrait = 5/100; }
        }
        public ComptePayant(float solde=0) : base(solde)
        {
            TR = taux_retrait;
        }
        private float calculretrait(float X)
        {
            float retrait = X * taux_retrait;
            return retrait;
        }
        public void initial_payant()
        {
            int etat;
            code = code + 1;

            Console.WriteLine("Voulez vous un compte Payant avec solde initial?   1: Oui,   0: Non");
            etat = int.Parse(Console.ReadLine());
            if (etat == 1)
            {
                Console.WriteLine("Solde Initial du conpte payant");
                this.solde = float.Parse(Console.ReadLine());
            }
            else if (etat == 0)
            {
                this.solde = 0;
            }
        }
        public void depot_payant()
        {
            Console.WriteLine("Montant du Depot");
            this.montant = float.Parse(Console.ReadLine());
            this.solde = (this.solde + this.montant);
        }
        public void retrait_payant()
        {
            Console.WriteLine("Montant du retrait");
            this.montant = float.Parse(Console.ReadLine());
            this.solde = (this.solde - this.montant)-calculretrait(this.montant);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Compte compte = new Compte();
            CompteEpargne Epargne= new CompteEpargne();
            ComptePayant Payant = new ComptePayant();
            Epargne.initial_epargne();
            Epargne.depot_epargne();
            Epargne.retrait_epargne();

            Console.WriteLine("Le solde de votre compte est : ");
            Console.Write(Epargne.solde.ToString());

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            
            Payant.initial_payant();
            Payant.depot_payant();
            Payant.retrait_payant();
            Console.WriteLine("Le solde de votre compte est : ");
            Console.Write(Payant.solde.ToString());
            Console.ReadLine();

        }
    }
}
