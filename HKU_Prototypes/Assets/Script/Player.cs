using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Speed;

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        this.gameObject.transform.position += new Vector3(Horizontal, Vertical, 0) * Time.deltaTime * Speed;
    }
}
