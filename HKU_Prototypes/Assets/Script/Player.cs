using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed;

    public GameObject FillSnackObj;
    public GameObject SellObj;
    public GameObject ChatObj;
    public GameObject ChatZone;

    public bool IsShowCase;
    public bool IsSell;
    public bool IsChat;

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        this.gameObject.transform.position += new Vector3(Horizontal, Vertical, 0) * Time.deltaTime * Speed;

        if(IsShowCase == true && Input.GetKeyDown(KeyCode.Space))
        {
            FillSnackObj.gameObject.SetActive(true);
        }

        if (IsSell == true && Input.GetKeyDown(KeyCode.Space))
        {
            SellObj.gameObject.SetActive(true);
        }

        if (IsChat == true && Input.GetKeyDown(KeyCode.Space))
        {
            ChatObj.gameObject.SetActive(true);

            StartCoroutine(ChatZone.GetComponent<Chat>().Dialog());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("ShowCase"))
        {
            IsShowCase = true;
            FillSnackObj.GetComponent<FillSnackSystem>().CurBuyZone = other.transform.parent.GetComponent<BuyZone>();

            FillSnackObj.GetComponent<FillSnackSystem>().ResetSystem();
        }

        if (other.CompareTag("Sell"))
        {
            IsSell = true;
        }

        if (other.CompareTag("Chat"))
        {
            IsChat = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ShowCase"))
        {
            IsShowCase = false;
        }

        if (other.CompareTag("Sell"))
        {
            IsSell = false;
        }

        if (other.CompareTag("Chat"))
        {
            IsChat = false;
        }
    }
}
