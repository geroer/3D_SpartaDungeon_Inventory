public class Character
{
    public string Name {  get; private set; }
    public int Level { get; private set; }
    public int Exp {  get; private set; }
    public int MaxExp {  get; private set; }
    public string Description { get; private set; }
    public int Attack { get; private set; }
    public int Defense {  get; private set; }
    public int Health { get; private set; }
    public int CriticalHit {  get; private set; }

    public Character(string name, int level, int exp, int maxExp, string description, int attack, int defense, int health, int criticalHit)
    {
        Name = name;
        Level = level;
        Exp = exp;
        MaxExp = maxExp;
        Description = description;
        Attack = attack;
        Defense = defense;
        Health = health;
        CriticalHit = criticalHit;
    }
}
