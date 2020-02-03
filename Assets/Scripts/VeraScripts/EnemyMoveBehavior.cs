using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseUnit))]
public class EnemyMoveBehavior : MonoBehaviour
{
    BaseUnit thisUnit { get => GetComponent<BaseUnit>(); }
}
