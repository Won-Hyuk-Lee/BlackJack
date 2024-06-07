using System.Collections.Generic;

public class Dealer : Player
{
    public Dealer() : base(true)
    {
    }

    public void PlayTurn(Deck deck)
    {
        while (Score < 17)
        {
            AddCard(deck.DrawCard());
        }
    }
}
