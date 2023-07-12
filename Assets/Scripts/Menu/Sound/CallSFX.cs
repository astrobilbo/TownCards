using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallSFX : MonoBehaviour
{
    
    public void OnButtonClick()
    {
        AudioManager.audioManager.SFXToca(0);
    }
    public void OnWin()
    {
        AudioManager.audioManager.SFXToca(1);
    }
}
