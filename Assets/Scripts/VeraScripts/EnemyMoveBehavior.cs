using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BaseUnit))]
public class EnemyMoveBehavior : MonoBehaviour
{
    public BaseUnit thisUnit { get => GetComponent<BaseUnit>(); }
    public Vector3 Direction;
    private Vector3 minVector, maxVector;
    private Vector3 destination;
    public float GetTargetRange;

    public Slider EnemyHp { get => GetComponentInChildren<Slider>(); }

    private void Start()
    {
        minVector = transform.position - Direction; maxVector = transform.position + Direction;
        destination = maxVector;
        StartCoroutine(MoveTowardsPosition(thisUnit.UnitStats[StatType.STRUT]/3));
        StartCoroutine(AttackTargetOnInterval(4));
        EnemyHp.maxValue = thisUnit.UnitStats[StatType.HEALTH]; 
    }

    private void Update()
    {
        EnemyHp.value = thisUnit.CurrentHP.CurrentValue;
    }

    public bool PlayerUnitInRange()
    {
        foreach (var p in PlayerUnitManager.ActivePlayerUnits)
        {
            if(Vector3.Distance(p.transform.position, transform.position) <= GetTargetRange)
            {
                thisUnit.SetTargetToEffect(p);
                return true;
            }
        }
        return false;
    }

    public IEnumerator MoveTowardsPosition(float speed)
    {
        if (thisUnit.TargetToEffect == null)
        {
            while (!SqueezeVector(transform.position, destination))
            {
                transform.position = Vector3.Lerp(transform.position, destination, Time.deltaTime * speed);
                yield return null;
            }
            transform.position = destination;
            destination = destination == minVector ? maxVector : minVector;
        }
        yield return new WaitForSeconds(.5f);
        yield return StartCoroutine(MoveTowardsPosition(speed));
    }

    public IEnumerator AttackTargetOnInterval(float interval)
    {
        float c = 0;
        if (PlayerUnitInRange() && thisUnit.TargetToEffect != null)
        {
            int move = Random.Range(0, thisUnit.UnitCombatMoves.Count);
            thisUnit.BroadcastUnitAttacked(thisUnit.UnitCombatMoves[move]);
            c = thisUnit.UnitCombatMoves[move].GetMoveByType().CoolDown;
        }
        yield return new WaitForSeconds(interval + c);
        yield return StartCoroutine(AttackTargetOnInterval(interval));
    }

    public bool SqueezeVector(Vector3 curr, Vector3 targ, float threshold = 0.01f)
    {
        return Mathf.Abs(Vector3.Distance(curr, targ)) <= threshold;
    }
    
}
