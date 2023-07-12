using UnityEngine;
using TMPro;

public class ShowDeck : MonoBehaviour
{
    bool activeDeck;
    Animator anim;

    void Awake()
    {
        anim = this.GetComponent<Animator>();
    }

    public void ShowMyDeck()
    {
        if (!activeDeck)
        {
            anim.Play("ShowCards");
            activeDeck = true;
            
        }
        else
        {
            anim.Play("DontShowCards");
            activeDeck = false;
        }
    }
}
