using UnityEngine;

[CreateAssetMenu(menuName = "Create Creature")]

public class CreatureStats : ScriptableObject
{
    public string creatureName;
    public string creatureNumber;
    public string creatureDescription;

    public Sprite creatureImageFront;
    public Sprite creatureImageBack;

    public int creatureLevel;

    public float healthStat;
    public float attackStat;
    public float defenseStat;
    public float speedStat;

    public MoveStats moveOne;
    public MoveStats moveTwo;
    public MoveStats moveThree;
    public MoveStats moveFour;

    public enum CreatureType
    {
        Fire,
        Water,
        Grass,
        Normal
    }

    public CreatureType creatureType = CreatureType.Grass;

}
