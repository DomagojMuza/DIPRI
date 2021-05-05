using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiverDialogTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialog questDialog;

    public Dialog normalDialog;

    public Quest[] quests;
    public void TriggerDialog()
    {
        if(quests == null)
        {
            FindObjectOfType<DialogManager>().StartDialog(normalDialog);
            return;
        }
        FindObjectOfType<DialogManager>().StartDialog(questDialog, quests);
        quests = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            TriggerDialog();
        }
    }
}
