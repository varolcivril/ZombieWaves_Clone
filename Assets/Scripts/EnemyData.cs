using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Data", menuName = "ScriptableObjects/Enemy")]
public class EnemyData : ScriptableObject
{
    public int health;
    public int damage;
    public float moveSpeed;
}
