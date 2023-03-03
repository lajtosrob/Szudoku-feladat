using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// See https://aka.ms/new-console-template for more information

StreamReader sr = new StreamReader("C:\\Users\\LifebookE736\\source\\repos\\Szudoku_2023.03.03\\Szudoku_2023.03.03\\DATA\\feladvanyok.txt");
List<Feladvany> sorok = new List<Feladvany>();  

while (!sr.EndOfStream)
{
    Feladvany line = new Feladvany(sr.ReadLine());
    sorok.Add(line);
}

sr.Close();

Console.WriteLine($"3. feladat: Beolvasva {sorok.Count} feladvány");

int feladvanySzamlalo = 0;
int feladvanyMeret = 0;

do
{
    Console.Write("\n4. feladat: Kérem a feladvány méretét [4..9]: ");
    feladvanyMeret = Convert.ToInt32(Console.ReadLine());

} while (feladvanyMeret > 9 || feladvanyMeret <  4);

foreach (var line in sorok)
{
    if (feladvanyMeret == line.Meret)
    {
        feladvanySzamlalo++;
    }
}

Console.WriteLine($"{feladvanyMeret}x{feladvanyMeret} méretű feladványból {feladvanySzamlalo} darab van tárolva");

Random rnd= new Random();
int randomSzam = rnd.Next(feladvanySzamlalo);

int randomSzamlalo = 0;
Feladvany kivalasztottSor;
int kitoltottseg = 0;


foreach (var sor in sorok)
{
    if (sor.Meret == feladvanyMeret)
    {
        randomSzamlalo++;
        if (randomSzamlalo == randomSzam)
        {
            kivalasztottSor = sor;
            Console.WriteLine($"\n5. feladat: A kiválasztott feladvány: \n{kivalasztottSor.Kezdo}");
            foreach (var item in kivalasztottSor.Kezdo)
            {
                if(item != '0')
                {
                    kitoltottseg++;
                }
            }
            Console.WriteLine($"\n6. feladat: A feladvány kitöltöttsége: {(Convert.ToDouble(kitoltottseg))/(Convert.ToDouble(kivalasztottSor.Kezdo.Length))*100}%");

            Console.WriteLine("\n7. feladat: A feladvány kirajzolva");

            kivalasztottSor.Kirajzol();

            continue;
        }
    }
}

List<Feladvany> kivalasztottList = new List<Feladvany>();

StreamWriter sw = new StreamWriter("sudoku" + feladvanyMeret + ".txt");

foreach (var sor in sorok)
{
    if(feladvanyMeret == sor.Meret)
    {
        sw.WriteLine(sor.Kezdo);
    }
}
sw.Close();
string allomanyNev = "sudoku" + feladvanyMeret + ".txt";
Console.WriteLine($"\n8. feladat: {allomanyNev} állomány {feladvanySzamlalo} darab feladvánnyal létrehozva ");





