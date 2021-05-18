using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int goldAmount;

    public float HP = 200;

    public GameObject ex;

    private static Player instance;

    public static Player MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<Player>();
            }
            return instance;
        }
        set => instance = value;
    }

    public int MyGoldAmount
    {
        get => goldAmount;
        set => goldAmount = value;

    }
    
    public void AddGold(int goldAmount)
    {
        MyGoldAmount += goldAmount;
        CheckGoldQuests(goldAmount);
        ScoreManager.instance.ChangeCoinsScore(MyGoldAmount);
    }

    public void CheckGoldQuests(int gold)
    {
        foreach (Quest quest in QuestLog.MyInstance.quests)
        {
            if (quest.MyComplete == false)
            {
                foreach (Objective obj in quest.MyCollectObjectives)
                {
                    if (obj.MyType == "Gold" && !obj.MyComplete)
                    {
                        obj.MyCurrentAmount += gold;
                        obj.Evaluate();
                    }
                }
                quest.Evaluate();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Cannonball")
        {
            this.HP -= other.GetComponent<Cannonball>().Dmg;
            GameObject firework = Instantiate(ex, other.transform.position, Quaternion.identity);
            firework.GetComponent<ParticleSystem>().Play();
            Destroy(firework, 1f);
            Destroy(other.gameObject);
        }
    }
}
