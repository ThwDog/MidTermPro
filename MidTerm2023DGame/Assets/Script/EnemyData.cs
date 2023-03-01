using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Data/Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public string type;
    public GameObject image;
    public float maxHp;
    public float currentHp;
    public float speed;
    public int damege;
    public float distance;

}
