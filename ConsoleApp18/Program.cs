using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Card cards = new Card();
        int schet = 0;
        int schetPC = 0;
        int acesCount = 0;
        int cardValue = cards.Take();
        schet += cardValue;
        cardValue = cards.Take();
        schet += cardValue;
        while (true)
        {
            Console.WriteLine($"Ваш счет {schet}");
            Console.WriteLine("Взять карту да/нет");
            string variant = Console.ReadLine();
            if ("да" == variant.ToLower())
            {
                cardValue = cards.Take();
                schet += cardValue;

                if (cardValue == 11)
                {
                    acesCount++;
                }

                if (acesCount == 2 && schet == 22)
                {
                    schet = 21;
                }
            }
            else if ("нет" == variant.ToLower())
            {
                break;
            }
            else
            {
                Console.WriteLine("Выберите действие");
            }
            if (schet >= 21)
            {
                break;
            }
        }

        Console.WriteLine("Диллер выкидывает случайные карты");
        while (true)
        {
            Console.WriteLine($"Счет дилера {schetPC}");
            schetPC += cards.Take();
            if (schetPC >= 18)
            {
                break;
            }
        }

        Console.WriteLine($"Ваш счет {schet} Счет дилера {schetPC}");

        if (schetPC > 21)
        {
            Console.WriteLine("Диллер проиграл! Ваша победа!");
        }
        else if (schetPC > schet)
        {
            Console.WriteLine("Диллер победил");
        }
        else if (schetPC < schet)
        {
            Console.WriteLine("Ваша победа");
        }
        else
        {
            Console.WriteLine("Ничия");
        }
    }
}

public class Card
{
    List<int> list = new List<int> { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };

    public int Take()
    {
        Random rand = new Random();
        int index = rand.Next(list.Count);
        int schet = list[index];
        list.RemoveAt(index); 

        switch (schet)
        {
            case 2:
                Console.WriteLine(" выпал валет");
                break;
            case 3:
                Console.WriteLine(" выпала Дама");
                break;
            case 4:
                Console.WriteLine(" выпал Король");
                break;
            case 6:
                Console.WriteLine(" выпало 6");
                break;
            case 7:
                Console.WriteLine(" выпало 7");
                break;
            case 8:
                Console.WriteLine(" выпало 8");
                break;
            case 9:
                Console.WriteLine(" выпало 9");
                break;
            case 10:
                Console.WriteLine(" выпало 10");
                break;
            case 11:
                Console.WriteLine(" выпал туз");
                break;
        }
        return schet;
    }
}
