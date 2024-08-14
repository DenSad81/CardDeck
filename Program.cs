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

        diller.ShowSituation(desk, player);

        Console.Write("How match cards player wonts to take: ");
        int quantityOfCards = diller.GetIntFromConsole();

        for (int i = 0; i < quantityOfCards; i++)
        {
            if (desk.TryGiveCard(out Card card))
                player.AcceptCard(card);
        }

        diller.ShowSituation(desk, player);
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
    public  int GetIntFromConsole()
    {
        int digitToOut;

        while (int.TryParse(Console.ReadLine(), out digitToOut) == false)
        { }

        return digitToOut;
    }

    public  void ShowSituation(Desk desc, Player player)
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
    private List<Card> _cards = new List<Card>() { };
    private List<int> values = new List<int>() { 6, 7, 8, 9, 10, 11, 12 };
    private List<string> suits = new List<string>() { "♠", "♣", "♦", "♥" };

    public Desk()
    {
        foreach (var suit in suits)
        {
            foreach (var value in values)
            {
                _cards.Add(new Card(suit, value));
            }
        }
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