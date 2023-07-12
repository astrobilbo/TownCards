using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Project1.Dialogue;

public class AIConversant : MonoBehaviour
{
    [SerializeField] bool CallOnAwake;
    [SerializeField] Dialogue dialogue;
    [SerializeField] Conversant conversant;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        if (CallOnAwake)
        {
            conversant.StartDialogue(this, dialogue);
        }
    }
    public void ActiveConversation()
    {
        if (dialogue == null)
        {
            return;
        }
        if (conversant.IsActive())
        {
            return;
        }
        if (Input.GetMouseButtonUp(0))
        {
            conversant.StartDialogue(this, dialogue);
        }
    }
    public void ChangeDialogue(Dialogue newDialogue)
    {
        dialogue = newDialogue;
        if (dialogue == null)
        {
            return;
        }
        if (conversant.IsActive())
        {
            return;
        }
        conversant.StartDialogue(this, dialogue);

    }
}
