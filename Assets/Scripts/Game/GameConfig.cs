using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "SO/GameConfig")]
public class GameConfig : ScriptableObject
{
    public float CharacterMovementSpeed;
    public float FruitSpawnTime;
    public float FruitGatherDelay;

    public float CustomerSpawnDelay;
    public int FruitPrice;

    public float MoneyCollectDelay;
}
