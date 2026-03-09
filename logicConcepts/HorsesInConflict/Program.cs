using System;
class Program
{
    
    class Caballo
    {
        public string PosicionOriginal { get; set; }
        public int X { get; set; } 
        public int Y { get; set; } 

        public Caballo(string pos)
        {
            PosicionOriginal = pos.Trim().ToUpper();
            X = PosicionOriginal[0] - 'A';
            Y = int.Parse(PosicionOriginal[1].ToString()) - 1;
        }
    }

    static void Main()

    {
        Console.WriteLine("Ingrese ubicación de los caballos ( B7, C5, E2, H7, G5, F6):");
        string entrada = Console.ReadLine();

        if (string.IsNullOrEmpty(entrada)) return;

       
        List<Caballo> listaCaballos = entrada.Split(',')
            .Select(p => new Caballo(p))
            .ToList();

        foreach (var actual in listaCaballos)
        {
            List<string> conflictos = new List<string>();

            foreach (var otro in listaCaballos)
            {
                if (actual == otro) continue; 

                int diffX = Math.Abs(actual.X - otro.X);
                int diffY = Math.Abs(actual.Y - otro.Y);

                if ((diffX == 2 && diffY == 1) || (diffX == 1 && diffY == 2))
                {
                    conflictos.Add(otro.PosicionOriginal);
                }
            }

            string resultadoConflictos = conflictos.Count > 0
                ? string.Join(", ", conflictos)
                : "ninguno";

            Console.WriteLine($"Analizando Caballo en {actual.PosicionOriginal} => Conflicto con {resultadoConflictos}");
        }
    }
}