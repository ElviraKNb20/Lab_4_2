using System;

namespace Lab_4_2
{
    abstract class TVector
    {
        public double a1 { get; set; }
        public double a2 { get; set; }
        public double b1 { get; set; }
        public double b2 { get; set; }
        public double sum { get; set; }

        public double[] vA = new double[2];
        public double[] vB = new double[2];

        public TVector(double a1, double b1, double a2, double b2)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b1 = b1;
            this.b2 = b2;
            vA[0] = a1;
            vA[1] = a2;
            vB[0] = b1;
            vB[1] = b2;
        }

        public abstract string Sum { get; }

        public override string ToString()
        {
            return Sum;
        }
    }

    class VectorTwo : TVector
    {
        public VectorTwo(double a1, double b1, double a2, double b2) : base(a1, a2, b1, b2) { }

        public override string Sum
        {
            get
            {
                double rez = 0, q = 0, a = 0, b = 0;
                for (int i = 0; i < vA.Length; i++)
                {
                    rez += vA[i] * vB[i];
                }
                if (rez == 0)
                {
                    for (int i = 0; i < vA.Length; i++)
                    {
                        q += Math.Pow(vA[i], 2);
                    }
                    a = Math.Round(Math.Sqrt(q), 2);
                    q = 0;
                    for (int i = 0; i < vB.Length; i++)
                    {
                        q += Math.Pow(vB[i], 2);
                    }
                    b = Math.Round(Math.Sqrt(q), 2);
                    sum = a + b;
                }
                if (sum != 0)
                {
                    return $"Суму паралельних довжин двовимiрних векторiв = {sum}";
                }
                return "Данi вектори не паралельнi, тому їхню суму визначити неможливо";
            }
        }
    }
    class VectorThree : TVector
    {
        public double a3 { get; set; }
        public double b3 { get; set; }

        public double[] vC = new double[3];
        public double[] vD = new double[3];
        public VectorThree(double a1, double b1, double a2, double b2, double a3, double b3) : base(a1, a2, b1, b2)
        {
            this.a3 = a3;
            this.b3 = b3;
            vC[0] = a1;
            vC[1] = a2;
            vC[2] = a3;
            vD[0] = b1;
            vD[1] = b2;
            vD[2] = b3;
        }
        public override string Sum
        {
            get
            {
                double q = 0, a = 0, b = 0;
                int z = 0;
                for (int i = 1; i < vC.Length; i++)
                {
                    double def = vC[i - 1] / vD[i - 1];
                    if (def == vC[i] / vD[i])
                    {
                        z++;
                    }
                }
                if (z > 0)
                {
                    for (int i = 0; i < vC.Length; i++)
                    {
                        q += Math.Pow(vC[i], 2);
                    }
                    a = Math.Round(Math.Sqrt(q), 2);
                    q = 0;
                    for (int i = 0; i < vD.Length; i++)
                    {
                        q += Math.Pow(vD[i], 2);
                    }
                    b = Math.Round(Math.Sqrt(q), 2);
                    sum = a + b;
                    if (sum != 0)
                    {
                        return $"Суму перпендикулярних довжин тривимiрних векторiв = {sum}";
                    }
                }
                return "Данi вектори не перпендикулярнi, тому їхню суму визначити неможливо";
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TVector[] vector = {
            new VectorTwo(2.5, 4, -2, 1.25),
            new VectorTwo(2, 1, -1, 2),
            new VectorTwo(6, 5.5, 4, 0.75),
            new VectorThree(2.4, 1.2, 7.2, 3.6, 9.6, 4.8),
            new VectorThree(2, 2, 2, 2, 2, 2),
            new VectorThree(2, 7, 1, -6, 21, 3),
            new VectorThree(2.5, 2, 1.25, 1, 4, 3.2)
        };

            foreach (TVector str in vector)
            {
                Console.WriteLine(str);
            }
        }
    }
}
