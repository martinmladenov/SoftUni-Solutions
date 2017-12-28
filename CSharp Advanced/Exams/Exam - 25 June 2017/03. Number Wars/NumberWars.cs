namespace _03.Number_Wars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NumberWars
    {
        public static void Main()
        {
            var p1Deck = new Queue<Card>(Console.ReadLine().Split().Select(s => new Card(s)));
            var p2Deck = new Queue<Card>(Console.ReadLine().Split().Select(s => new Card(s)));

            int turn = 0;
            while (turn < 1000000 && p1Deck.Count > 0 && p2Deck.Count > 0)
            {
                turn++;
                var p1Card = p1Deck.Dequeue();
                var p2Card = p2Deck.Dequeue();
                var field = new List<Card> { p1Card, p2Card };

                Queue<Card> turnWinnerDeck = null;
                if (p1Card.NumberPower > p2Card.NumberPower)
                {
                    turnWinnerDeck = p1Deck;
                }
                else if (p1Card.NumberPower < p2Card.NumberPower)
                {
                    turnWinnerDeck = p2Deck;
                }
                else
                {
                    while (turnWinnerDeck == null && p1Deck.Count >= 3 && p2Deck.Count >= 3)
                    {
                        int p1Sum = p1Deck.Take(3).Sum(c => c.LetterPower);
                        int p2Sum = p2Deck.Take(3).Sum(c => c.LetterPower);
                        for (int i = 0; i < 3; i++)
                        {
                            field.Add(p1Deck.Dequeue());
                            field.Add(p2Deck.Dequeue());
                        }

                        if (p1Sum > p2Sum)
                            turnWinnerDeck = p1Deck;
                        else if (p1Sum < p2Sum)
                            turnWinnerDeck = p2Deck;
                    }
                }
                if (turnWinnerDeck != null)
                    foreach (var card in field
                        .OrderByDescending(c => c.NumberPower)
                        .ThenByDescending(c => c.LetterPower))
                    {
                        turnWinnerDeck.Enqueue(card);
                    }
            }
            string result;
            if (p1Deck.Count > p2Deck.Count)
                result = "First player wins";
            else if (p1Deck.Count < p2Deck.Count)
                result = "Second player wins";
            else
                result = "Draw";

            Console.WriteLine("{0} after {1} turns", result, turn);
        }
    }

    public class Card
    {
        public int NumberPower { get; }
        public int LetterPower { get; }

        public Card(string card)
        {
            NumberPower = int.Parse(card.Substring(0, card.Length - 1));
            LetterPower = card[card.Length - 1] - 'a' + 1;
        }
    }
}