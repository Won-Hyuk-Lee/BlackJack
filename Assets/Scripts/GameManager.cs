using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text playerScoreText;
    public Text dealerScoreText;
    public Text resultText;

    private Deck deck;
    private Player player;
    private Dealer dealer;

    private bool isPlayerTurn;

    void Start()
    {
        deck = new Deck();
        player = new Player();
        dealer = new Dealer();

        // 초기 카드 두 장씩 배분
        DealInitialCards();

        UpdateUI();
        isPlayerTurn = true;
    }

    void DealInitialCards()
    {
        player.AddCard(deck.DrawCard());
        player.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());
        dealer.AddCard(deck.DrawCard());
    }

    void Update()
    {
        // 플레이어 턴 관리
        if (isPlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.AddCard(deck.DrawCard());
                UpdateUI();

                if (player.Score > 21)
                {
                    Debug.Log("Player busts!");
                    EndGame("Player busts! Dealer wins!");
                }
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                isPlayerTurn = false;
                DealerTurn();
            }
        }
    }

    void DealerTurn()
    {
        dealer.PlayTurn(deck);
        UpdateUI();

        if (dealer.Score > 21)
        {
            EndGame("Dealer busts! Player wins!");
        }
        else
        {
            DetermineWinner();
        }
    }

    void DetermineWinner()
    {
        if (player.Score > dealer.Score)
        {
            EndGame("Player wins!");
        }
        else if (player.Score < dealer.Score)
        {
            EndGame("Dealer wins!");
        }
        else
        {
            EndGame("It's a tie!");
        }
    }

    void EndGame(string result)
    {
        resultText.text = result;
        Debug.Log(result);
    }

    void UpdateUI()
    {
        playerScoreText.text = "Player's Score: " + player.Score;
        dealerScoreText.text = "Dealer's Score: " + dealer.Score;
    }
}
