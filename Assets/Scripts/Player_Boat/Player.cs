using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int goldAmount;

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
}