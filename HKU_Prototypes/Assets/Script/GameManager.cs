using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

[System.Serializable]
public class Road
{
    public Transform Gate;

    public List<Transform> BuyZone;
}

public class GameManager : MonoBehaviour
{
    [Header("����")]
    public int DebtMoney;

    [Header("UI")]
    public Text MoneyText;

    [Header("��ġ")]
    public Transform SpawnZone;
    public Transform DestroyZone;
    public Transform SellZone;
    public List<Road> Road;

    [Header("�մ�")]
    public List<GameObject> Guests;
    public Guest CurGuest;

    [Header("���� ����")]
    public List<BuyZone> BuyZones;
    public GameObject Sncaks;

    [Header("�ǳ�")]
    public GameObject FillSnackObj;
    public GameObject SellSnackObj;

    private void Update()
    {
        MoneyText.text = $"{DebtMoney}$";

        RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), transform.forward, 20.0f);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit2D && hit2D.collider.CompareTag("Sell"))
            {
                Debug.Log(hit2D.collider.name);
                SellSnackObj.SetActive(true);
            }

            else if((hit2D && hit2D.collider.CompareTag("ShowCase")))
            {

            }

            else if ((hit2D && hit2D.collider.CompareTag("Snack")))
            {

            }

            if ((hit2D && hit2D.collider.CompareTag("Card")))
            {
                StartCoroutine(SnackBuy(hit2D.collider.gameObject));
            }

        }
    }

    private void Start()
    {
        StartCoroutine(SpawnGuest());
    }

    IEnumerator SpawnGuest()
    {
        yield return null;

        CurGuest = Instantiate(Guests[0], SpawnZone.position, Quaternion.identity).GetComponent<Guest>();
        CurGuest.GetComponent<SpriteRenderer>().sortingOrder = 9;

        int RandomGate = Random.Range(0, Road.Count);
        int RandomBuyZone = Random.Range(0, Road[RandomGate].BuyZone.Count);

        // �ش� BuyZone �� ����Ʈ�� �̵�
        yield return StartCoroutine(CurGuest.Move(Road[RandomGate].Gate));

        //BuyZone�̵�
        CurGuest.SelectZone = Road[RandomGate].BuyZone[RandomBuyZone].GetComponent<BuyZone>();
        yield return StartCoroutine(CurGuest.Move(Road[RandomGate].BuyZone[RandomBuyZone]));

        //���� ì��
        yield return StartCoroutine(CurGuest.Buy());

        // �ش� BuyZone �� ����Ʈ�� �̵�
        yield return StartCoroutine(CurGuest.Move(Road[RandomGate].Gate));
        yield return new WaitForSeconds(0.2f);

        //SellZone�̵�
        CurGuest.GetComponent<SpriteRenderer>().sortingOrder = 1;
        yield return StartCoroutine(CurGuest.Move(SellZone));
        Sncaks.SetActive(true);

        yield break;
    }

    IEnumerator SnackBuy(GameObject Obj)
    {
        yield return null;

        Obj.transform.DOMoveY(-6f, 1.0f);
        yield return new WaitForSeconds(2.0f);
        Obj.transform.DOMoveY(6f, 1.0f);
        yield return new WaitForSeconds(2.0f);

        SellSnackObj.SetActive(false);
        DebtMoney -= CurGuest.BuyCount * 1000;

        StartCoroutine(OutGuest());

        yield break;
    }

    IEnumerator OutGuest()
    {
        yield return null;

        yield return new WaitForSeconds(0.5f);
        Sncaks.SetActive(false);

        yield return StartCoroutine(CurGuest.Move(DestroyZone));
        yield return new WaitForSeconds(0.2f);

        Destroy(CurGuest.gameObject);
        CurGuest = null;

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(SpawnGuest());
    }
}
