using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Guest : MonoBehaviour
{
    public float MoveSpeed = 0.0f;

    public BuyZone SelectZone;

    public IEnumerator Buy()
    {
        yield return null;

        int RandomBuyCount = Random.Range(1, SelectZone.CurCount);

        for (int i = 0; i < RandomBuyCount; i++)
        {
            SelectZone.CurCount--;

            yield return new WaitForSeconds(0.2f);
        }

        yield break;
    }

    public IEnumerator Move(Transform Pos)
    {
        yield return null;

        this.transform.DOMove(Pos.position, MoveSpeed);
        yield return new WaitForSeconds(MoveSpeed);

        yield break;
    }
}
