using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "DataCoin")]
public class SOCoin : ScriptableObject
{
    public int coin;
    public List<Character> charater;
}
[System.Serializable]
public class Character
{
    public int id;
    public string name;
    public int price;
    public int ownershipCheck;
    public int useCharacter;
}

