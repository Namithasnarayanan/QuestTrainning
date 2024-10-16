using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace creditcard
{
    internal class creditcard
    {
        public class Creditcard
        {
            public string Name;
            public long CardNumber;
            public byte ExpiryMonth;
            public int ExpiryYear;
            public int Cvc;

            public static List<Creditcard> cardDetails = new List<Creditcard>();

            public void AddCreditcard()
            {


                Creditcard card = new Creditcard();

                Console.Write("Enter Name: ");
                card.Name = Console.ReadLine();

                Console.Write("Enter Card Number: ");
                card.CardNumber = long.Parse(Console.ReadLine());

                Console.Write("Enter Expiry Month (1-12): ");
                card.ExpiryMonth = byte.Parse(Console.ReadLine());

                Console.Write("Enter Expiry Year: ");
                card.ExpiryYear = int.Parse(Console.ReadLine());

                Console.Write("Enter CVC: ");
                card.Cvc = int.Parse(Console.ReadLine());

                cardDetails.Add(card);
                Console.WriteLine("Card added successfully.");
            }






            public void UpdateCard()
            {
                Console.Write("Enter the card number to update: ");
                long cardToReplace = long.Parse(Console.ReadLine());
                bool found = false;

                foreach (var card in cardDetails)
                {
                    if (card.CardNumber == cardToReplace)
                    {
                        Console.Write("Enter new Name: ");
                        card.Name = Console.ReadLine();

                        Console.Write("Enter new Expiry Month (1-12): ");
                        card.ExpiryMonth = byte.Parse(Console.ReadLine());

                        Console.Write("Enter new Expiry Year: ");
                        card.ExpiryYear = int.Parse(Console.ReadLine());

                        Console.Write("Enter new CVC: ");
                        card.Cvc = int.Parse(Console.ReadLine());

                        Console.WriteLine("Card updated successfully.");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Card not found.");
                }
            }




            public void DeleteCard()
            {
                Console.Write("Enter the card number to delete: ");
                long cardToDelete = long.Parse(Console.ReadLine());
                bool found = false;

                for (int i = 0; i < cardDetails.Count; i++)
                {
                    if (cardDetails[i].CardNumber == cardToDelete)
                    {
                        cardDetails.RemoveAt(i);
                        Console.WriteLine("Card deleted successfully.");
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Card not found.");
                }
            }


            public override string ToString()
            {
                return $"Number:{CardNumber},Expiry:{ExpiryMonth}/{ExpiryYear},cvc:{Cvc}";
            }
        }
    }
}

