using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{ 
    public float HP = 200f;

    public GameObject ex;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        if(this.HP <= 0)
        {
            GameObject firework = Instantiate(ex, gameObject.transform.position + new Vector3(0, 3, 0), Quaternion.identity);
            firework.GetComponent<ParticleSystem>().startSize = 20;
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(gameObject);
        }   
    }

    public void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Cannonball")
        {
            this.HP -= other.GetComponent<Cannonball>().Dmg;
            GameObject firework = Instantiate(ex, other.transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(other.gameObject);
        }
    }
}
