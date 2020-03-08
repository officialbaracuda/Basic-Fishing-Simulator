using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish", menuName = "Fish")]
public class Fish : ScriptableObject {

    public enum Rarity { Common, Uncommon, Rare, Epic, Legendary, Mythical }

    public new string name;
    public string description;
    public Rarity rarity;
    public float sellPrice;
    public Sprite picture;
    public float missPercentage;
}
