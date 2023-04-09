using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Menu menu = new Menu();

        menu.Work();
    }
}

class Menu
{
    private readonly SoldiersCreator _soldiersCreator = new SoldiersCreator();
    private readonly List<Soldier> _soldiers;

    public Menu()
    {
        _soldiers = _soldiersCreator.Create();
    }

    public void Work()
    {
        Console.WriteLine("\nПодробная информация о военнослужащих:\n");

        ShowSoldiers();

        Console.WriteLine("\nКраткая информация о военнослужащих:\n");

        AssignData();
    }

    private void ShowSoldiers()
    {
        foreach (Soldier soldier in _soldiers)
        {
            soldier.ShowInfo();
        }
    }

    private void AssignData()
    {
        var filteredSoldiers = from soldier in _soldiers select new
        {
            soldier.FullName,
            soldier.Rank
        };

        foreach (var soldier in filteredSoldiers)
        {
            Console.WriteLine($"Имя солдата - {soldier.FullName} | Звание - {soldier.Rank}.");
        }
    }
}

class SoldiersCreator
{
    public List<Soldier> Create()
    {
        return new List<Soldier>()
        {
            new Soldier("Маслов А. А.", "Рядовой", "AK-74M", 11),
            new Soldier("Кузьмин М. П.", "Сержант", "Винторез", 18),
            new Soldier("Никулина Е. Я.", "Старжий Сержант", "ВСК-94", 26),
            new Soldier("Семенова А. А.", "Лейтинант", "AK-12", 28),
            new Soldier("Кудряшов Д. М.", "Майор", "AK-47", 54),
            new Soldier("Смирнов А. З.", "Прапорщик", "АШ-12", 21),
        };
    }
}

class Soldier
{
    public Soldier(string fullName, string rank, string weapons, int workExperienceInMonths)
    {
        FullName = fullName;
        Rank = rank;
        Weapons = weapons;
        WorkExperienceInMonths = workExperienceInMonths;
    }

    public string FullName { get; private set; }
    public string Rank { get; private set; }
    public string Weapons { get; private set; }
    public int WorkExperienceInMonths { get; private set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Имя и Инициалы: {FullName} | Звание: {Rank} | Оружие: {Weapons} | Срок службы: {WorkExperienceInMonths} месяц(ев).");
    }
}