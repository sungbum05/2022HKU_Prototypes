using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Road
{
    public Transform Gate;

    public List<Transform> BuyZone;
}

public class GameManager : MonoBehaviour
{
    public Transform SpawnZone;
    public List<Road> Road;

    private void Awake()
    {
        
    }
}
