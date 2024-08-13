using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Desk desk = new Desk();
        Player player = new Player("Jonn");
        Diller diller = new Diller();

        ShowSituation(desk, player);

        Console.Write("How match cards player wonts to take: ");
        int quantityOfCards = GetIntFromConsole();

        for (int i = 0; i < quantityOfCards; i++)
        {
            if (diller.TryGiveCard(out Card card))
                player.AcceptCard(card);
        }

        while (diller.TryGiveCard(out Card card))
            desk.AcceptCard(card);


        ShowSituation(desk, player);
    }

    private static int GetIntFromConsole()
    {
        int digitToOut;

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
        { }

        return digitToOut;
    }

    private static void ShowSituation(Desk desc, Player player)
    {
        Console.WriteLine();
        Console.WriteLine("Cards into desk");
        desc.ShowAllCards();
        Console.WriteLine();
        Console.WriteLine("Cards into player");
        player.ShowAllCards();
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

class Desk
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

class Diller
{
    private List<Card> _cards = new List<Card>() {new Card("bubi", 6),
                                                  new Card("vini", 7),
                                                  new Card("bubi", 8),
                                                  new Card("vini", 9),
                                                  new Card("bubi", 11),
                                                  new Card("vini", 12),
                                                  new Card("bubi", 14),
                                                  new Card("vini", 19)};

    public bool TryGiveCard(out Card card)
    {
        card = null;

        if (_cards.Count == 0)
            return false;

        card = _cards[0];
        _cards.RemoveAt(0);
        return true;
    }
}

class Player
{
    private List<Card> _cards = new List<Card>();
    private string _name = "no name";

    public Player(string name)
    {
        _name = name;
    }

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