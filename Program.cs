namespace Solicitud
{
    enum EstadoSolicitud
    {
        Pendiente = 1,
        EnProceso = 2,
        Completada = 3,
        Cancelada = 4
    }

    class Solicitud
    {
        public int Id { get; set; }
        public string NombreCliente { get; set; }
        public string Descripcion { get; set; }
        public EstadoSolicitud Estado { get; set; }

        public void Mostrar()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Cliente: {NombreCliente}");
            Console.WriteLine($"Descripcion: {Descripcion}");
            Console.WriteLine($"Estado: {Estado}");
        }
    }

    class Program
    {
        static List<Solicitud> solicitudes = new List<Solicitud>();
        static int contadorId = 1;

        static void Main(string[] args)
        {
            int opcion;

            do
            {
                MostrarMenu();
                opcion = int.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        RegistrarSolicitud();
                        break;
                    case 2:
                        MostrarSolicitudes();
                        break;
                    case 3:
                        CambiarEstado();
                        break;
                    case 4:
                        BuscarPorId();
                        break;
                    case 0:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("Opcion no valida");
                        break;
                }

            } while (opcion != 0);
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Registrar solicitud");
            Console.WriteLine("2. Mostrar solicitudes");
            Console.WriteLine("3. Cambiar estado");
            Console.WriteLine("4. Buscar por ID");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opcion: ");
        }

        static void RegistrarSolicitud()
        {
            Solicitud s = new Solicitud();

            s.Id = contadorId++;

            Console.Write("Nombre del cliente: ");
            s.NombreCliente = Console.ReadLine();

            Console.Write("Descripcion: ");
            s.Descripcion = Console.ReadLine();

            s.Estado = EstadoSolicitud.Pendiente;

            solicitudes.Add(s);

            Console.WriteLine("Solicitud registrada con estado Pendiente");
        }

        static void MostrarSolicitudes()
        {
            if (solicitudes.Count == 0)
            {
                Console.WriteLine("No hay solicitudes");
                return;
            }

            foreach (var s in solicitudes)
            {
                s.Mostrar();
            }
        }

        static void CambiarEstado()
        {
            Console.Write("Ingrese ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido");
                return;
            }

            var solicitud = solicitudes.FirstOrDefault(s => s.Id == id);

            if (solicitud == null)
            {
                Console.WriteLine("Solicitud no encontrada");
                return;
            }

            Console.WriteLine("Seleccione nuevo estado:");
            foreach (var estado in Enum.GetValues(typeof(EstadoSolicitud)))
            {
                Console.WriteLine($"{(int)estado}. {estado}");
            }

            if (!int.TryParse(Console.ReadLine(), out int opcionEstado) || !Enum.IsDefined(typeof(EstadoSolicitud), opcionEstado))
            {
                Console.WriteLine("Estado invalido");
                return;
            }

            solicitud.Estado = (EstadoSolicitud)opcionEstado;

            Console.WriteLine("Estado actualizado");
        }

        static void BuscarPorId()
        {
            Console.Write("Ingrese ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("ID invalido");
                return;
            }

            var solicitud = solicitudes.FirstOrDefault(s => s.Id == id);

            if (solicitud == null)
            {
                Console.WriteLine("Solicitud no encontrada");
                return;
            }

            solicitud.Mostrar();
        }
    }
}