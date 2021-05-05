using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = Random.Range(100, 3000);
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("sudar broo");
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().AddGold(gold);
            Destroy(gameObject);
        }
    }
}
