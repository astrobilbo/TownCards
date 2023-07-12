using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Project1.Dialogue;
using Manager;
public class IA : MonoBehaviour
{
    private static IA _instance;
    public static IA instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("SourceManager is NULL");

            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }
    [SerializeField] int money, happynes, polution;
    [SerializeField] GameObject Warning;
    [SerializeField] MyDialoques[] Dialogos;
    [SerializeField] AIConversant aiConversant;
    bool inRage = false;
    // Start is called before the first frame update
    public void InRage(bool rage)
    {
        inRage = rage;
        Warning.SetActive(inRage);
        if (inRage)
        {
            SourceManager.instance.moneyForTurn -= money;
            SourceManager.instance.nextTurnHappynes -= happynes;
            SourceManager.instance.nextTurnPolution += polution;
        }
    }

    // Update is called once per frame
    public void StartMyDialogue()
    {
        Dialogue newDialogue;
        if (inRage)
        {
            newDialogue = Dialogos[1].Dialoques[UnityEngine.Random.Range(0, Dialogos[1].Dialoques.Length)];
        }
        else
        {
            newDialogue = Dialogos[0].Dialoques[UnityEngine.Random.Range(0, Dialogos[0].Dialoques.Length)];
        }
        aiConversant.ChangeDialogue(newDialogue);
    }


}


[Serializable]
public class MyDialoques
{
    public string name;
    public Dialogue[] Dialoques;

}
