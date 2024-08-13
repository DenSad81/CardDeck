using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        Desk desk = new Desk(new List<Card>() {new Card("bubi", 6),
                                               new Card("vini", 7),
                                               new Card("bubi", 8),
                                               new Card("vini", 9),
                                               new Card("bubi", 11),
                                               new Card("vini", 12),
                                               new Card("bubi", 14),
                                               new Card("vini", 19)});
        Player player = new Player("Jonn");

        ShowSituation(desk, player);

        Console.Write("How match cards player wonts to take: ");
        int quantityOfCards = GetIntFromConsole();

        for (int i = 0; i < quantityOfCards; i++)
            player.AcceptCard(desk.GiveCard());

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

class Desk
{
    private List<Card> _cards;
    public Desk(List<Card> cards)
    {
        _cards = cards;
    }

    public void ShowAllCards()
    {
        foreach (var card in _cards)
            card.Show();
    }

    public Card GiveCard()
    {
        Card tempCard;
        tempCard = _cards[0];
        _cards.RemoveAt(0);
        return tempCard;
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

class Player
{
    private List<Card> _cards;
    private string _name;

    public Player(string name = "no name")
    {
        _cards = new List<Card>();
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