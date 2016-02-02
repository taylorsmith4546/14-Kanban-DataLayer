using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanbanDataLayer
{
    class Program
    {
        private static bool quit = false;

        static void Main(string[] args)
        {
            using (var db = new KanbanEntities())
            {
                while (true)
                {
                    Console.WriteLine("Please choose an option:  1.Show all data  2.Add new list  3.Quit");
                    try
                    {
                        int userEntry = int.Parse(Console.ReadLine());
                        switch (userEntry)
                        {
                            case 1:

                                //var list = db.Lists.First();
                                foreach (var list in db.Lists)
                                {
                                    Console.WriteLine(list.Name);

                                    foreach (var card in list.Cards)
                                    {
                                        Console.WriteLine("\t" + card.Text);
                                    }
                                }
                                break;

                            case 2:
                                {
                                    Console.WriteLine("Add a List: ");
                                    string newListText = Console.ReadLine();
                                    List newList = new List();
                                    newList.Name = newListText;
                                    newList.CreatedDate = DateTime.Now;
                                    db.Lists.Add(newList);
                                    db.SaveChanges();

                                    Console.WriteLine("Add a Card? \n 1. Enter a new card. \n 2. Quit");
                                    string needCard = Console.ReadLine();
                                    if (needCard == "1")
                                    {
                                        Console.WriteLine("Enter a new Card: ");
                                        string newCardText = Console.ReadLine();
                                        Card newCard = new Card();
                                        newCard.Text = newCardText;
                                        newCard.CreatedDate = DateTime.Now;
                                        newList.Cards.Add(newCard);
                                        db.SaveChanges();
                                    }
                                    break;
                                }
                            case 3:
                                {

                                    quit = true;
                                    break;
                                }

                        }
                    }


                    catch (FormatException e)
                    {
                        Console.WriteLine("Please choose an option:  1.Show all data  2.Add new list  3.Quit");
                        continue;
                    }
                    break;
                };
            }

        }
    }
}





