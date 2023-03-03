using System;
using System.Collections.Generic;

namespace Listak
{
    class Program
    {
        static void DisplayList<T>(List<T> lista, String message)
        {

            Console.WriteLine('\n' + new String('─', Console.WindowHeight - 1));
            Console.WriteLine(message);
            Console.Write($"Count:{lista.Count} │");
            foreach (var item in lista)
                Console.Write(item.ToString() + '│');
            Console.WriteLine();
        }
        static void Main(string[] args)

        {
            //LISTA ADATSZERKEZET
            //
            //Használatához szükséges a 
            //using System.Collections.Generic;

            //Megjegyzés: A System.Collections számos további adatszerkezetet is tartalmaz
            // - System.Collections.Stack - Verem
            // - System.Collections.Queue - Sor
            // - System.Collections.SortedList - Rendezett lista
            // - System.Collections.ArrayList - Dinamikus tömb

            //1. DEKLARÁCIÓ és INICIALIZÁLÁS ────────────────────────────────────────────────────────────────
            // [TÖMB] deklarálása és inicializálása
            int[] szamokTomb;
            szamokTomb = new int[100]; // tömb inicializálása 100 elemre


            //Lista deklarálása
            List<int> szamokLista;
            szamokLista = new List<int>(); //inicializálás, eredménye egy üres lista

            //Az előző üres lista megszűnik, helyette új jön létre a megadott értékekkel
            szamokLista = new List<int> { 12, 11, 345, 25, -47, 456 };
            DisplayList(szamokLista, "1. Alap:");

            //Inicializálás kezdeti elemszám megadásával. A Count értéke továbbra is 0 marad!
            //A tárkezelés optimalizálása miatt hasznos. Kevésbé erőforrásigényes 20 elemnek egyszerre
            //memóriahelyet foglalni, mint 20 alkalommal egynek.
            List<double> masikLista = new List<double>(20);

            //inicializálás az értékek megadásával
            List<String> gyumolcsok = new List<string>() { "alma", "körte", "szilva", "barack", "füge" };
            DisplayList(gyumolcsok, "1. Alap:");

            //2. ELEMSZÁM ───────────────────────────────────────────────────────────────────────────────────

            // [TÖMB]
            // Console.WriteLine(szamokTomb.Length);

            // [LISTA, SZÓTÁR]
            Console.WriteLine(szamokLista.Count); //elemek száma

            //3. ELEM ELÉRÉSE és MÓDOSÍTÁSA ─────────────────────────────────────────────────────────────────
            // [TÖMB, LISTA]
            //szamokTomb[12] = 122;  //tömb elemének módosítása
            gyumolcsok[1] = "banán"; //A "körte" helyére "banán" kerül

            //4. ÚJ ELEM FELVÉTELE ──────────────────────────────────────────────────────────────────────────
            // [TÖMB] NEM lehetséges!

            // [LISTA]
            // Felvétel a lista végére
            szamokLista.Add(122);
            gyumolcsok.Add("szőlő");
            DisplayList(gyumolcsok, "4. Add után:");

            // Beszúrás egy elem elé
            gyumolcsok.Insert(2, "narancs"); //0-tól indexelés mellett a megadott indexű elem elé szúr be
            DisplayList(gyumolcsok, "Insert után [2-es indexű elé]:");

            //5. ELEM TÖRLÉSE ───────────────────────────────────────────────────────────────────────────────
            // [TÖMB] NEM lehetséges!

            // [LISTA]
            //Érték eltávolítása listából
            // a) index segítségével távolítja el az elemet
            gyumolcsok.RemoveAt(3);

            // b) a törlendő elemet adjuk meg
            // bool érték határozza meg a sikerességet /true=sikeres/
            if (gyumolcsok.Remove("füge") == true)
            {
                Console.WriteLine("Sikeres a törlés, mivel volt ilyen elem!");
            }
            else
            {
                Console.WriteLine("A törlés sikertelen!");
            }

            DisplayList(gyumolcsok, "5. A 3-as indexű és a \"füge\" törlése után:");

            Console.WriteLine("Tovább...");
            Console.ReadKey();

            //6. KERESÉS az ADATSZERKEZETBEN ────────────────────────────────────────────────────────────────
            // [TÖMB] NEM lehetséges!

            // [LISTA]
            //A keresett elem helyét adja vissza. Ha nem létezik akkor -1-et
            Console.WriteLine($"6. Milyen indexű a \"narancs\" elem (ha van) :{gyumolcsok.IndexOf("narancs")}");

            // gyumolcsok.LastIndexOf("körte")  - a keresést a lista végéről kezdi
            //gyumolcsok.IndexOf("alma", 3); - az "alma" elemet a 3-as indexű elemtől kezdi keresni (elejéről a vége felé halad)

            //Eldönti, hogy a megadott elem benne van-e a listában?
            if (gyumolcsok.Contains("mandarin"))
            {
                Console.WriteLine("6. Van a gyümölcsök között \"mandarin\"!");
            }
            else
            {
                Console.WriteLine("6. Nincs a gyümölcsök között \"mandarin\"!");
            }

            //7. ADATSZERKEZET RENDEZÉSE ────────────────────────────────────────────────────────────────────
            // [TÖMB] NEM lehetséges!

            // [LISTA]
            szamokLista.Sort(); //Növekvő sorrendbe rendezi
            DisplayList(szamokLista, "7. Rendezés után a számok:");
            gyumolcsok.Sort();
            DisplayList(gyumolcsok, "7. Rendezés után a gyümölcsök:");

            //8. ADATSZERKEZET TÖRLÉSE ──────────────────────────────────────────────────────────────────────
            // [TÖMB] NEM lehetséges!
            gyumolcsok.Clear();
            DisplayList(gyumolcsok, "8. Törlés után:");

            //9. EGYÉB ÉRDEKES ──────────────────────────────────────────────────────────────────────────────
            szamokLista.Insert(3, -264);
            szamokLista.Insert(6, 10);
            DisplayList(szamokLista, "9. Két elemmel bővítve: -264; 10;");
            szamokLista.Reverse(); //Elemek sorrendjének megfordítása. Az elsőből utolsó lesz és fordítva.
            DisplayList(szamokLista, "9. Megfordítás:");

        }
    }
}
