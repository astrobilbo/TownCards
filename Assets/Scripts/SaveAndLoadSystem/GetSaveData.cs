using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSaveData : MonoBehaviour
{
    // Start is called before the first frame update
    public void SaveIntoJson()
    {
        SaveData.saveData.SaveIntoJson();
    }

    // Update is called once per frame
    public void LoadFromJson(bool isLoading)
    {
        SaveData.saveData.LoadFromJson(isLoading);
    }
}
