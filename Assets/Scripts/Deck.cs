using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;

    public Deck()
    {
        cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
        Shuffle();
    }

    // 복사 생성자
    public Deck(Deck deckToCopy)
    {
        cards = new List<Card>(deckToCopy.cards);
    }

    public void Shuffle()
    {
        Random rng = new Random();
        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = cards[k];
            cards[k] = cards[n];
            cards[n] = value;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count == 0)
            throw new InvalidOperationException("The deck is empty.");
        Card card = cards[0];
        cards.RemoveAt(0);
        return card;
    }
}
