using System;
using System.Collections.Generic;
using System.IO;
using IdentNumbers.Contracts;

namespace IdentNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lösung 1 Quick and Dirty
            Construct();
            //Lösung 2 Dependency Injection
            Console.Write("Bitte Pfad zur Datei eingeben: ");
            var path = Console.ReadLine();
            try
            {
                IMatrixHandler matrixHandler = new MatrixHandler();

                var result = matrixHandler.HandleMatrix(path);

                Console.WriteLine(result);

                Console.WriteLine("End");

                Console.WriteLine("Press enter to close...");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        static void Construct()
        {
            string path = "", lines;
            var matrix = new List<char[]>();
            char[] characters;
            int x = 0, y = 0, counter = 0;
            var numbers = new List<int>();
            try
            {
                Console.Write("Bitte Pfad zur Datei eingeben: ");
                path = Console.ReadLine();

                if(path == null || path == "")
                {
                    while (path == null || path == "")
                    {
                        Console.Write("Pfad ungültig! Gültigen Pfad eingeben: ");
                        path = Console.ReadLine();
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Fehler beim Einlesen", e);
            }
            

            try
            {
                StreamReader file = new StreamReader(path);
                while ((lines = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    characters = lines.ToCharArray();
                    matrix.Add(characters);
                    counter++;
                }
                file.Close();

                for (int i = 0; i < matrix.Count; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {

                        if (matrix[i][j].ToString() == ("-"))
                        {
                            //2,3,5
                            counter = i + 1;
                            if ((j + 2) < matrix[i].Length)
                            {
                                y = j + 2;
                            }

                            x = j + 1;
                            if (matrix[counter][j].ToString() == "|")
                            {
                                numbers.Add(5);
                                if ((j + 4) < matrix[i].Length)
                                {
                                    j = j + 4;
                                }
                                else
                                {
                                    j = matrix[i].Length - 1;
                                }
                            }
                            if (matrix[counter][y].ToString() == "|")
                            {
                                numbers.Add(2);
                                j = j + 2;
                            }
                            if (matrix[counter][x].ToString() == "/")
                            {
                                numbers.Add(3);
                                j = j + 2;
                            }

                        }
                        else if (matrix[i][j].ToString() == "|")
                        {
                            //1,4
                            counter = i + 2;
                            if (matrix[counter][j].ToString() == "|")
                            {
                                numbers.Add(1);
                            }
                            else
                            {
                                numbers.Add(4);
                                j = j + 4;
                            }
                        }
                    }
                    if ((i + 2) < matrix.Count)
                    {
                        i = i + 3;
                    }

                }
                Console.Write("Im Text enthaltene Zahlen: ");
                for (int i = 0; i < numbers.Count; i++)
                {
                    Console.Write(numbers[i]);
                    if (i < numbers.Count - 1)
                    {
                        Console.Write(" , ");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ein Fehler ist aufgetretten! " + e);
            }
            finally
            {
                Console.ReadLine();
            }
        }
    }
}
