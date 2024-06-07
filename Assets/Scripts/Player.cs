using System.Collections.Generic;
using System.Linq;

public class Player
{
    public List<Card> Hand { get; private set; }
    public int Score { get; private set; }
    public bool IsDealer { get; private set; }

    public Player(bool isDealer = false)
    {
        Hand = new List<Card>();
        Score = 0;
        IsDealer = isDealer;
    }

    public void AddCard(Card card)
    {
        Hand.Add(card);
        Score += card.Value;
        AdjustForAces();
    }

    private void AdjustForAces()
    {
        int aceCount = Hand.Count(card => card.Rank == Rank.Ace);
        while (Score > 21 && aceCount > 0)
        {
            Score -= 10;
            aceCount--;
        }
    }
}
