
namespace S1L4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isLogged = false;

            while (true)
            {
                Console.WriteLine("===============OPERAZIONI==============");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1: Login");
                Console.WriteLine("2: Logout");
                Console.WriteLine("3: Verifica ora e data di login");
                Console.WriteLine("4: Lista degli accessi");
                Console.WriteLine("5: Esci");
                Console.WriteLine("========================================");
                Console.WriteLine("Scelta:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        if (!isLogged)
                        {
                            Console.WriteLine("Username: ");
                            string username = Console.ReadLine();
                            Console.WriteLine("Password: ");
                            string password = Console.ReadLine();
                            Console.WriteLine("Conferma Password: ");
                            string confirmPassword = Console.ReadLine();

                            if (Utente.Login(username, password, confirmPassword))
                            {
                                Console.WriteLine("Accesso effettuato con successo.");
                                isLogged = true;
                            }
                            else
                            {
                                Console.WriteLine("Errore durante il login. Riprova.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Utente già loggato.");
                        }
                        break;

                    case "2":
                        if (isLogged)
                        {
                            Utente.Logout();
                            Console.WriteLine("Logout effettuato");
                            isLogged = false;
                        }
                        else
                        {
                            Console.WriteLine("Nessun utente loggato.");
                        }
                        break;

                    case "3":
                        if (isLogged)
                        {
                            Console.WriteLine($"Ultimo login: {Utente.GetUltimoAccesso()}");
                        }
                        else
                        {
                            Console.WriteLine("Nessun utente loggato");
                        }
                        break;

                    case "4":
                        if (isLogged)
                        {
                            List<string> accessi = Utente.GetAccessi();
                            Console.WriteLine("Lista degli accessi:");
                            foreach (var accesso in accessi)
                            {
                                Console.WriteLine(accesso);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nessun utente loggato.");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }
                Console.WriteLine();
            }

        }
    }

    public static class Utente
    {
        private static string username;
        private static string ultimoAccesso;
        private static List<string> accessi = new List<string>();

        public static bool Login(string username, string password, string confirmPassword)
        {
            if (password == confirmPassword && !string.IsNullOrEmpty(username))
            {
                Utente.username = username;
                Utente.ultimoAccesso = DateTime.Now.ToString();
                Utente.accessi.Add(ultimoAccesso);
                return true;
            }
            return false;
        }

        public static void Logout()
        {
            username = null;
        }
        public static string GetUltimoAccesso()
        {
            return ultimoAccesso;
        }
        public static List<string> GetAccessi()
        {
            return accessi;
        }
    }
}
