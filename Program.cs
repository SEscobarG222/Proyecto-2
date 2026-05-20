using System;

namespace Proyecto_Granja
{

    // =========================================================
    // CLASE TERRENO
    // GUARDA LOS DATOS DE CADA PARCELA DE LA GRANJA
    // =========================================================
    class Terreno
    {
        public string Cultivo;

        public int TiempoCultivo;

        public int TiempoMeta;

        public bool RecibioAgua;

        public double Ganancia;

        public string Estado;


        // =====================================================
        // CONSTRUCTOR
        // =====================================================
        public Terreno()
        {
            Cultivo = "Libre";

            TiempoCultivo = 0;

            TiempoMeta = 0;

            RecibioAgua = false;

            Ganancia = 0;

            Estado = "Sin cultivo";
        }
    }



    // =========================================================
    // CLASE PRINCIPAL
    // =========================================================
    class Program
    {

        // MATRIZ DE LA GRANJA
        static Terreno[,] Granja;


        // VARIABLES GENERALES
        static double Dinero;

        static double Ingresos = 0;

        static double Gastos = 0;

        static int Meses;

        static int MesActual = 0;

        static int Trabajadores;

        static double PagoTrabajador;

        static int TamañoFilas;

        static int TamañoColumnas;

        static int TotalRiegos = 0;


        // CONTADORES
        static int PapasPlantadas = 0;

        static int TomatesPlantados = 0;

        static int FresasPlantadas = 0;

        static int PapasRecolectadas = 0;

        static int TomatesRecolectados = 0;

        static int FresasRecolectadas = 0;



        // =====================================================
        // MAIN
        // =====================================================
        static void Main(string[] args)
        {
            Console.Title = "Proyecto de Granja";

            Console.WriteLine("======================================");

            Console.WriteLine("      SISTEMA DE GRANJA VIRTUAL");

            Console.WriteLine("======================================");

            Console.WriteLine();

            ConfiguracionSistema();

            CrearMatriz();

            while (Meses > 0 && Dinero > 0)
            {
                MostrarInformacion();

                MenuPrincipal();
            }

            Console.Clear();

            Console.WriteLine("SIMULACION TERMINADA");

            Console.WriteLine();

            ReporteFinal();

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para salir...");

            Console.ReadKey();
        }



        // =====================================================
        // CONFIGURACION
        // =====================================================
        static void ConfiguracionSistema()
        {
            Console.WriteLine("CONFIGURACION DEL SISTEMA");

            Console.WriteLine();

            Console.Write("Ingrese el dinero inicial: Q");
            Dinero = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Ingrese la cantidad de empleados: ");
            Trabajadores = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Ingrese el sueldo por empleado: Q");
            PagoTrabajador = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Ingrese los meses de simulacion: ");
            Meses = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Ingrese el numero de filas: ");
            TamañoFilas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Ingrese el numero de columnas: ");
            TamañoColumnas = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("La granja fue creada correctamente.");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para continuar...");

            Console.ReadKey();

            Console.Clear();
        }



        // =====================================================
        // CREAR MATRIZ
        // =====================================================
        static void CrearMatriz()
        {
            Granja = new Terreno[TamañoFilas, TamañoColumnas];

            for (int fila = 0; fila < TamañoFilas; fila++)
            {
                for (int columna = 0; columna < TamañoColumnas; columna++)
                {
                    Granja[fila, columna] = new Terreno();
                }
            }
        }



        // =====================================================
        // MOSTRAR GRANJA
        // =====================================================
        static void MostrarInformacion()
        {
            Console.WriteLine("DINERO DISPONIBLE: Q" + Dinero.ToString("F2"));

            Console.WriteLine("MESES RESTANTES: " + Meses);

            Console.WriteLine();

            Console.WriteLine("ESTADO DE LA GRANJA");

            Console.WriteLine();

            Console.Write("          ");

            for (int c = 0; c < TamañoColumnas; c++)
            {
                Console.Write("COL " + c + "      ");
            }

            Console.WriteLine();

            for (int f = 0; f < TamañoFilas; f++)
            {
                Console.Write("FILA " + f + "   ");

                for (int c = 0; c < TamañoColumnas; c++)
                {
                    Terreno t = Granja[f, c];

                    if (t.Cultivo == "Libre")
                    {
                        Console.Write("[ Libre ] ");
                    }
                    else
                    {
                        Console.Write("[" +
                                      t.Cultivo[0] +
                                      ":" +
                                      t.TiempoCultivo +
                                      "/" +
                                      t.TiempoMeta +
                                      "] ");
                    }
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }



        // =====================================================
        // MENU PRINCIPAL
        // =====================================================
        static void MenuPrincipal()
        {
            Console.WriteLine("1. Plantar cultivo");

            Console.WriteLine("2. Regar cultivo");

            Console.WriteLine("3. Consultar parcela");

            Console.WriteLine("4. Avanzar mes");

            Console.WriteLine("5. Ver reporte rapido");

            Console.WriteLine("6. Salir");

            Console.WriteLine();

            Console.Write("Seleccione una opcion: ");

            string opcion = Console.ReadLine();

            Console.Clear();

            switch (opcion)
            {
                case "1":

                    PlantarCultivo();

                    break;

                case "2":

                    RegarCultivo();

                    break;

                case "3":

                    VerParcela();

                    break;

                case "4":

                    SiguienteMes();

                    break;

                case "5":

                    ReporteRapido();

                    break;

                case "6":

                    Meses = 0;

                    break;

                default:

                    Console.WriteLine("Opcion invalida.");

                    break;
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Presione una tecla para continuar...");

            Console.ReadKey();

            Console.Clear();
        }



        // =====================================================
        // PLANTAR CULTIVO
        // =====================================================
        static void PlantarCultivo()
        {
            Console.WriteLine("PLANTAR CULTIVO");

            Console.WriteLine();

            int fila = PedirFila();

            int columna = PedirColumna();

            Terreno t = Granja[fila, columna];

            if (t.Cultivo != "Libre")
            {
                Console.WriteLine();

                Console.WriteLine("La parcela ya contiene un cultivo.");

                return;
            }

            Console.WriteLine();

            Console.WriteLine("1. Papa");

            Console.WriteLine("2. Tomate");

            Console.WriteLine("3. Fresa");

            Console.WriteLine();

            Console.Write("Seleccione el cultivo: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":

                    t.Cultivo = "Papa";

                    t.TiempoMeta = 2;

                    t.Ganancia = 500;

                    PapasPlantadas++;

                    break;

                case "2":

                    t.Cultivo = "Tomate";

                    t.TiempoMeta = 3;

                    t.Ganancia = 700;

                    TomatesPlantados++;

                    break;

                case "3":

                    t.Cultivo = "Fresa";

                    t.TiempoMeta = 4;

                    t.Ganancia = 1000;

                    FresasPlantadas++;

                    break;

                default:

                    Console.WriteLine();

                    Console.WriteLine("Cultivo invalido.");

                    return;
            }

            Console.WriteLine();

            Console.WriteLine("Cultivo sembrado correctamente.");
        }



        // =====================================================
        // REGAR CULTIVO
        // =====================================================
        static void RegarCultivo()
        {
            Console.WriteLine("REGAR CULTIVO");

            Console.WriteLine();

            int fila = PedirFila();

            int columna = PedirColumna();

            Terreno t = Granja[fila, columna];

            if (t.Cultivo == "Libre")
            {
                Console.WriteLine();

                Console.WriteLine("No existe cultivo en esta parcela.");

                return;
            }

            if (t.RecibioAgua)
            {
                Console.WriteLine();

                Console.WriteLine("Este cultivo ya fue regado.");

                return;
            }

            if (Dinero < 50)
            {
                Console.WriteLine();

                Console.WriteLine("No hay dinero suficiente.");

                return;
            }

            Dinero -= 50;

            Gastos += 50;

            TotalRiegos++;

            t.RecibioAgua = true;

            Console.WriteLine();

            Console.WriteLine("Riego realizado correctamente.");
        }



        // =====================================================
        // CONSULTAR PARCELA
        // =====================================================
        static void VerParcela()
        {
            Console.WriteLine("CONSULTAR PARCELA");

            Console.WriteLine();

            int fila = PedirFila();

            int columna = PedirColumna();

            Terreno t = Granja[fila, columna];

            Console.WriteLine();

            if (t.Cultivo == "Libre")
            {
                Console.WriteLine("La parcela esta vacia.");
            }
            else
            {
                Console.WriteLine("Cultivo: " + t.Cultivo);

                Console.WriteLine("Crecimiento: " +
                                  t.TiempoCultivo +
                                  "/" +
                                  t.TiempoMeta);

                Console.WriteLine("Regado: " +
                                  (t.RecibioAgua ? "Si" : "No"));

                Console.WriteLine("Ganancia: Q" +
                                  t.Ganancia);
            }
        }



        // =====================================================
        // AVANZAR MES
        // =====================================================
        static void SiguienteMes()
        {
            Console.WriteLine("SIGUIENTE MES");

            Console.WriteLine();

            double PagoTotal = Trabajadores * PagoTrabajador;

            if (Dinero < PagoTotal)
            {
                PagoTotal = Dinero;
            }

            Dinero -= PagoTotal;

            Gastos += PagoTotal;

            Console.WriteLine("Pago de empleados: Q" +
                              PagoTotal.ToString("F2"));

            Console.WriteLine();

            for (int f = 0; f < TamañoFilas; f++)
            {
                for (int c = 0; c < TamañoColumnas; c++)
                {
                    Terreno t = Granja[f, c];

                    if (t.Cultivo == "Libre")
                    {
                        continue;
                    }

                    if (t.RecibioAgua)
                    {
                        t.TiempoCultivo += 2;
                    }
                    else
                    {
                        t.TiempoCultivo += 1;
                    }

                    Console.WriteLine("PARCELA (" + f + "," + c + ")");

                    Console.WriteLine("Cultivo: " + t.Cultivo);

                    Console.WriteLine("Crecimiento: " +
                                      t.TiempoCultivo +
                                      "/" +
                                      t.TiempoMeta);

                    Console.WriteLine();

                    if (t.TiempoCultivo >= t.TiempoMeta)
                    {
                        Dinero += t.Ganancia;

                        Ingresos += t.Ganancia;

                        Console.WriteLine("Cultivo cosechado.");

                        Console.WriteLine("Ganancia obtenida: Q" +
                                          t.Ganancia);

                        Console.WriteLine();

                        if (t.Cultivo == "Papa")
                        {
                            PapasRecolectadas++;
                        }

                        if (t.Cultivo == "Tomate")
                        {
                            TomatesRecolectados++;
                        }

                        if (t.Cultivo == "Fresa")
                        {
                            FresasRecolectadas++;
                        }

                        Granja[f, c] = new Terreno();
                    }
                    else
                    {
                        t.RecibioAgua = false;
                    }
                }
            }

            Meses--;

            MesActual++;

            Console.WriteLine("Mes completado correctamente.");
        }



        // =====================================================
        // REPORTE RAPIDO
        // =====================================================
        static void ReporteRapido()
        {
            Console.WriteLine("REPORTE RAPIDO");

            Console.WriteLine();

            Console.WriteLine("Ingresos: Q" +
                              Ingresos.ToString("F2"));

            Console.WriteLine("Gastos: Q" +
                              Gastos.ToString("F2"));

            Console.WriteLine("Mes actual: " + MesActual);

            Console.WriteLine("Riegos realizados: " + TotalRiegos);
        }



        // =====================================================
        // REPORTE FINAL
        // =====================================================
        static void ReporteFinal()
        {
            Console.WriteLine("REPORTE FINAL");

            Console.WriteLine();

            Console.WriteLine("Dinero restante: Q" +
                              Dinero.ToString("F2"));

            Console.WriteLine("Ingresos totales: Q" +
                              Ingresos.ToString("F2"));

            Console.WriteLine("Gastos totales: Q" +
                              Gastos.ToString("F2"));

            Console.WriteLine("Meses completados: " +
                              MesActual);

            Console.WriteLine();

            Console.WriteLine("CULTIVOS PLANTADOS");

            Console.WriteLine("Papas: " + PapasPlantadas);

            Console.WriteLine("Tomates: " + TomatesPlantados);

            Console.WriteLine("Fresas: " + FresasPlantadas);

            Console.WriteLine();

            Console.WriteLine("CULTIVOS COSECHADOS");

            Console.WriteLine("Papas: " + PapasRecolectadas);

            Console.WriteLine("Tomates: " + TomatesRecolectados);

            Console.WriteLine("Fresas: " + FresasRecolectadas);
        }



        // =====================================================
        // PEDIR FILA
        // =====================================================
        static int PedirFila()
        {
            Console.Write("Ingrese la fila: ");

            int fila = Convert.ToInt32(Console.ReadLine());

            if (fila < 0 || fila >= TamañoFilas)
            {
                Console.WriteLine();

                Console.WriteLine("La fila no existe.");

                Console.WriteLine("Se utilizara la fila 0.");

                fila = 0;
            }

            return fila;
        }



        // =====================================================
        // PEDIR COLUMNA
        // =====================================================
        static int PedirColumna()
        {
            Console.Write("Ingrese la columna: ");

            int columna = Convert.ToInt32(Console.ReadLine());

            if (columna < 0 || columna >= TamañoColumnas)
            {
                Console.WriteLine();

                Console.WriteLine("La columna no existe.");

                Console.WriteLine("Se utilizara la columna 0.");

                columna = 0;
            }

            return columna;
        }
    }
}
