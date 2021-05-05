using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{

    public Text dialogText;

    private Queue<string> recenice;

    public Animator animator;

    private Quest[] Quests;

    void Start()
    {
        recenice = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, Quest[] quests = null)
    {
        Quests = quests;
        animator.SetBool("IsOpen", true);

        recenice.Clear();

        foreach(string recenica in dialog.recenice)
        {
            recenice.Enqueue(recenica);
        }
        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(recenice.Count == 0)
        {
            EndDialog();
            return;
        }

        string recenica = recenice.Dequeue();
        dialogText.text = recenica;
    }

    public void EndDialog()
    {
       if(Quests != null)
        {

            foreach(Quest q in Quests)
            {
                QuestLog.MyInstance.AceptQuest(q);
            }
       }
        Quests = null;
        animator.SetBool("IsOpen", false);
    }

   
}