using System.Collections;
using System.Collections.Generic;
using Manager;
using UnityEngine;
using UnityEngine.UI;
public class UIBackground : MonoBehaviour
{
    private static UIBackground _instance;
    public static UIBackground instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("UIManager is NULL");

            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    public Image imagem;
    public Color BaseColor;
    public float maxGreenColor, minGreenColor, newGreenColorValue;
    public void UpdateUI()
    {
        newGreenColorValue = 1 - ((Manager.SourceManager.instance.polution * 0.01f * (maxGreenColor - minGreenColor) + minGreenColor) / 255);
        BaseColor = new Color(BaseColor.r, newGreenColorValue, BaseColor.b, BaseColor.a);
        imagem.color = BaseColor;
    }
}
