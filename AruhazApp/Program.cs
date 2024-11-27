using System.Buffers;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace AruhazApp
{
    internal class Program
    {
        static string[] raktarTermekek = new string[10];
        static int[] raktarMennyiseg = new int[10];
        static int[] raktarAr = new int[10];

        static List<string> vasarloLista = new List<string>();
        static List<int> vasarloMennyisegek = new List<int>();
        static void Main(string[] args)
        {
            bool fut = true;
            while (fut)
            {
                Console.WriteLine("Raktár Kezelő Felület\n");
                Console.WriteLine("1. Raktárkészlet kezelése");
                Console.WriteLine("2. Vásárlói kosár kezelése");
                Console.WriteLine("3. Vásárlói műveletek szimulálása");
                Console.WriteLine("4. Statisztikák előállítása");
                Console.WriteLine("5. Kilépés\n");
                Console.Write("Válasz egy opciót: ");
                int.TryParse(Console.ReadLine(), out int opcio);

                switch (opcio)
                {
                    case 1:
                        bool fut2 = true;
                        Console.Clear();
                        while (fut2)
                        {
                            Console.WriteLine("1. Raktár Megtekintése");
                            Console.WriteLine("2. Raktár Feltöltése");
                            Console.WriteLine("3. Vissza\n");
                            Console.Write("Válasz egy opciót: ");
                            int.TryParse(Console.ReadLine(), out int opciox);

                            switch (opciox)
                            {
                                case 1:
                                    Console.Clear();
                                    kilistazas();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    raktarFeltoltes();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Vissza...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    fut2 = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Érvénytelen opció!");
                                    break;
                            }
                        }
                        break;
                    case 2:
                        bool fut3 = true;
                        Console.Clear();
                        while (fut3)
                        {
                            Console.WriteLine("1. Kosár feltöltése");
                            Console.WriteLine("2. Kosár megtekintése");
                            Console.WriteLine("3. Kosárból termék eltávolítása");
                            Console.WriteLine("4. Kosár kiürítése");
                            Console.WriteLine("5. Vissza\n");
                            Console.Write("Válasz egy opciót: ");

                            int.TryParse(Console.ReadLine(), out int opcioy);

                            switch (opcioy)
                            {
                                case 1:
                                    Console.Clear();
                                    kosarFeltoltes();
                                    break;
                                case 2:
                                    Console.Clear();
                                    kosarMegtekintes();
                                    break;
                                case 3:
                                    Console.Clear();
                                    kosarTermekTorles();
                                    break;
                                case 4:
                                    Console.Clear();
                                    kosarTorles();
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Vissza");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    fut3 = false;
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Érvénytelen opció!");
                                    break;

                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        vasarlas();
                        break;
                    case 4:
                        Console.Clear();
                        bool fut4 = true;
                        Console.Clear();
                        while (fut4)
                        {
                            Console.WriteLine("1. Kosár statisztikák");
                            Console.WriteLine("2. Egyéb statisztikák");
                            Console.WriteLine("3. Vissza\n");
                            Console.Write("Válasz egy opciót: ");
                            int.TryParse(Console.ReadLine(),out int opcioz);

                            switch (opcioz)
                            {
                                case 1:
                                    Console.Clear();
                                    kosarStatisztika();
                                    kosarErtek();
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Clear();
                                    olcsoDragaRaktar();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Vissza...");
                                    Thread.Sleep(1000);
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Érvénytelen opció!");
                                    break;
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Kilépés....");
                        fut = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Érvénytelen opció!");
                        break;
                }
            }
            
        }
        static void kilistazas()
        {
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarTermekek[i] == null)
                {
                    Console.WriteLine("Ez a polc üres!");
                } else
                {
                    Console.WriteLine($"{raktarTermekek[i]} : {raktarMennyiseg[i]} - {raktarAr[i]} FT");
                }
            }
        }
        static void raktarFeltoltes()
        {
            Console.Write("Adja meg a termék nevét: ");
            string termek = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(termek))
            {
                Console.WriteLine("Nem adott meg termék nevet!");
                return;
            } 

            int index = Array.IndexOf(raktarTermekek, termek);
            if (index == -1)
            {
                Console.WriteLine("Ez a termék nincs a raktárban, ezért hozzáadjuk");
                int indexv = Array.IndexOf(raktarTermekek, null);
                if (indexv == -1)
                {
                    Console.WriteLine("Nincs üres polc a raktárban!");
                }
                raktarTermekek[indexv] = termek;
                Console.Write("Adja meg a termék mennyiségét: ");
                int.TryParse(Console.ReadLine(), out int termekMennyiseg);
                if (termekMennyiseg < 0)
                {
                    Console.WriteLine("A termék mennyisége nem lehet nulla!");
                    return;
                }
                raktarMennyiseg[indexv] = termekMennyiseg;
                Console.Write("Adja meg a termék árát: ");
                int.TryParse(Console.ReadLine(), out int termekAr);
                if (termekAr <= 0)
                {
                    Console.WriteLine("A termék ára nem lehet kisebb vagy egyenlő mint nulla");
                    return;
                }
                raktarAr[indexv] = termekAr;
            }
        }

        static void kosarFeltoltes()
        {
            Console.Write("Adja meg a termék nevét: ");
            string termek = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(termek))
            {
                Console.WriteLine("A terméknek nem adott nevet!");
                return;
            }
            int index = Array.IndexOf(raktarTermekek, termek);
            if (index == -1)
            {
                Console.WriteLine("Ez a termék nem található a raktárban!");
                return;
            }
            Console.Write("Adja meg a mennyiséget: ");
            int.TryParse(Console.ReadLine(), out int mennyiseg);
            if (mennyiseg <= 0)
            {
                Console.WriteLine("A termék mennyisége amit kér nem lehet kisebb vagy egyenlő mint nulla");
                return;
            }
            if (mennyiseg > raktarMennyiseg[index])
            {
                Console.WriteLine("Nincs ennyi a raktáron!");
                return;
            }
            vasarloLista.Add(termek);
            vasarloMennyisegek.Add(mennyiseg);
        }
        static void kosarMegtekintes()
        {
            if (vasarloLista.Count == 0)
            {
                Console.WriteLine("A bevásárlólista üres!\n");
                return;
            }
            for (int i = 0; i < vasarloLista.Count; i++)
            {
                Console.WriteLine($"{vasarloLista[i]} : {vasarloMennyisegek[i]}");
            }
        }
        static void kosarTorles()
        {
            if (vasarloLista.Count == 0)
            {
                Console.WriteLine("A bevásárlólista üres!\n");
                return;
            }
            vasarloLista.Clear();
            vasarloMennyisegek.Clear();
            Console.WriteLine("Kosár sikeresen kiürítve!\n");
        }
        static void kosarTermekTorles()
        {
            Console.Write("Adja meg a termék nevét amit el szeretne távolítani a kosárból: ");
            string termek = Console.ReadLine();
            
            if (!vasarloLista.Contains(termek))
            {
                Console.WriteLine("Ez a termék nincs a bevásárlólistán!");
            }
            int index = vasarloLista.IndexOf(termek);
            vasarloLista.RemoveAt(index);
            vasarloMennyisegek.RemoveAt(index);
            Console.WriteLine("A termék sikeresen el lett távolítva a kosárból!\n");
        }
        static void vasarlas()
        {
            int osszeg = 0;
            if (vasarloLista.Count == 0)
            {
                Console.WriteLine("A bevásárlólista üres!");
                return;
            }
            for (int i = 0; i < vasarloLista.Count; i++)
            {
                string termek = vasarloLista[i];
                int mennyiseg = vasarloMennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    Console.WriteLine($"Nincs a raktárban: {termek}");
                    return;
                }

                if (raktarMennyiseg[index] < mennyiseg)
                {
                    Console.WriteLine($"Nincs elég {termek} a raktárban!");
                }
                else
                {
                    osszeg += raktarAr[index]*mennyiseg;
                    raktarMennyiseg[index] -= mennyiseg;
                    Console.WriteLine($"Sikeresen megvásárolt: {termek}, {mennyiseg} darabot {osszeg} forintért.");
                }
            }
        }
        static void kosarStatisztika()
        {
            int osszeg = 0;
            int osszeg2 = 0;
            for (int i = 0; i < vasarloMennyisegek.Count; i++)
            {
                osszeg += vasarloMennyisegek[i];
            }
            Console.WriteLine($"Jelenleg {osszeg} db számú, {vasarloLista.Count} különböző típusú termék található a kosárban");
        }
        static void kosarErtek()
        {
            int osszeg = 0;
            for (int i = 0; i < vasarloMennyisegek.Count; i++)
            {
                osszeg += vasarloMennyisegek[i] * raktarAr[i];
            }
            Console.WriteLine($"A kosár értéke: {osszeg} forint!");
        }
        static void olcsoDragaRaktar()
        {
            int olcso = raktarAr[0];
            int draga = raktarAr[0];
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (olcso > raktarAr[i])
                {
                    olcso = raktarAr[i];
                }

                if (draga < raktarAr[i])
                {
                    draga = raktarAr[i];
                }
            }
            int ujindex = Array.IndexOf(raktarTermekek, draga);
            int ujindex2 = Array.IndexOf(raktarTermekek, olcso);
            Console.WriteLine($"A legolcsóbb termék: {raktarTermekek[ujindex2]}, a legdrágább termék: {raktarTermekek[ujindex]}");
        }
    }
}
