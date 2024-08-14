using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Deck deck = new Deck();
        Player player = new Player();
        Diller diller = new Diller();

        deck.Shaffl();
        diller.ShowStats(deck, player);
        diller.Play(deck, player);
        diller.ShowStats(deck, player);
    }
}

class Card
{
    private string _suit;
    private int _value;

    public Card(string suit, int value)
    {
        _suit = suit;
        _value = value;
    }

    public void Show()
    {
        Console.WriteLine(_suit + " " + _value);
    }
}

class Diller
{
    public int ReadInt()
    {
        int digitToOut;

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
        { }

        return digitToOut;
    }

    public void ShowStats(Deck desc, Player player)
    {
        Console.WriteLine();
        Console.WriteLine("Cards into desk");
        desc.ShowAllCards();
        Console.WriteLine();
        Console.WriteLine("Cards into player");
        player.ShowAllCards();
    }

    public void Play(Deck deck, Player player)
    {
        Console.Write("How match cards player wonts to take: ");
        int quantityOfCards = ReadInt();

        for (int i = 0; i < quantityOfCards; i++)
        {
            if (deck.TryGiveCard(out Card card))
                player.AcceptCard(card);
        }
    }
}

class Deck
{
    private List<Card> _cards;

    public Deck()
    {
        _cards = Create();
    }

    public bool TryGiveCard(out Card card)
    {
        card = null;

        if (_cards.Count == 0)
            return false;

        card = _cards[0];
        _cards.RemoveAt(0);
        return true;
    }

    public void ShowAllCards()
    {
        foreach (var card in _cards)
            card.Show();
    }

    public void Shaffl()
    {
        Random random = new Random();

        for (int i = 0; i < _cards.Count; i++)
        {
            int targetPositionInArray = random.Next(0, _cards.Count);
            Card temp = _cards[targetPositionInArray];
            _cards[targetPositionInArray] = _cards[i];
            _cards[i] = temp;
        }
    }

    private List<Card> Create()
    {
        List<int> values = new List<int>() { 6, 7, 8, 9, 10 };
        List<string> suits = new List<string>() { "♠", "♣", "♦", "♥" };
        List<Card> cards = new List<Card>();
        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                cards.Add(new Card(suit, value));
            }
        }

        return cards;
    }
}

class Player
{
    private List<Card> _cards = new List<Card>();

    public void ShowAllCards()
    {
        foreach (var card in _cards)
            card.Show();
    }

    public void AcceptCard(Card card)
    {
        _cards.Add(card);
    }
}