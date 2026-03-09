var viga = string.Empty;
do
{
    Console.Write("Ingrese la viga : ");
    viga = Console.ReadLine();
    if (viga!.ToLower() == "")
    {
        continue;
    }
    if (string.IsNullOrEmpty(viga)) return;


    int resistencia = 0;
    char tipoBase = viga[0];

    switch (tipoBase)
    {
        case '%': resistencia = 10; break;
        case '&': resistencia = 30; break;
        case '#': resistencia = 90; break;
        default:
            Console.WriteLine("La viga está mal construida");
            return;
    }

    double pesoTotal = 0;
    double pesoSecuenciaActual = 0;
    int contadorLargueros = 0;
    bool ultimaFueConexion = false;


    for (int i = 1; i < viga.Length; i++)
    {
        char pieza = viga[i];

        if (pieza == '=')
        {
            contadorLargueros++;
            pesoSecuenciaActual += contadorLargueros;
            pesoTotal += contadorLargueros;
            ultimaFueConexion = false;
        }
        else if (pieza == '*')
        {

            if (ultimaFueConexion || contadorLargueros == 0)
            {
                Console.WriteLine("La viga está mal construida");
                return;
            }


            double pesoConexion = pesoSecuenciaActual * 2;
            pesoTotal += pesoConexion;


            pesoSecuenciaActual = 0;
            contadorLargueros = 0;
            ultimaFueConexion = true;
        }
        else
        {

            Console.WriteLine("La viga está mal construida");
            return;
        }
    }


    if (pesoTotal <= resistencia)
    {
        Console.WriteLine("La viga soporta el peso!");
    }
    else
    {
        Console.WriteLine("La viga NO soporta el peso!");
    }
}while (viga!.ToLower() != "salir") ;

    