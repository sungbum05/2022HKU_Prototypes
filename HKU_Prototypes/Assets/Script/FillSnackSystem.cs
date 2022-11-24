using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillSnackSystem : MonoBehaviour
{
    public List<GameObject> Snacks;

    public BuyZone CurBuyZone;
    public GameObject MoveSnack;

    public Vector3 OriginSnackPos;
    public bool IsSelectSnack = false;

    private void Awake()
    {
        OriginSnackPos = MoveSnack.transform.position;
    }

    private void Update()
    {
        if (CurBuyZone != null)
        {
            for (int i = 0; i < Snacks.Count; i++)
            {
                if (i < CurBuyZone.MaxCount - CurBuyZone.CurCount)
                {
                    Snacks[i].SetActive(false);
                }

                else
                    Snacks[i].SetActive(true);
            }
        }

        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, 20.0f);

        if (Input.GetMouseButton(0))
        {
            if (hit2D && hit2D.collider.CompareTag("Snack"))
            {
                hit2D.collider.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0,0,10);
                IsSelectSnack = true;
            }
        }

        if(Input.GetMouseButtonUp(0) && IsSelectSnack)
        {
            MoveSnack.transform.position = OriginSnackPos;
            CurBuyZone.CurCount++;
        }
    }

    public void ResetSystem()
    {
        for (int i = 0; i < Snacks.Count; i++)
        {
            Snacks[i].SetActive(true);

            Snacks[i].GetComponent<SpriteRenderer>().sprite = CurBuyZone.SnackImg;
            MoveSnack.GetComponent<SpriteRenderer>().sprite = CurBuyZone.SnackImg;
        }
    }
}
