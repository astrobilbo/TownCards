using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
public class SceneAndApplicationTextChanger : MonoBehaviour
{
    enum TextOptions
    {
        ApplicationCompanyName,
        ApplicationProductName,
        ApplicationVersion,
        ApplicationUnityVersion
    }
    [SerializeField] TextOptions textOptions;
    SceneAndApplicationManager sceneAndApplicationManager;
    TextMeshProUGUI textMeshProUGui;
    void Awake()
    {
        sceneAndApplicationManager = FindObjectOfType<SceneAndApplicationManager>();
        textMeshProUGui = this.GetComponent<TextMeshProUGUI>();
        textMeshProUGui.text = Text();
    }


    string Text()
    {

        if (textOptions == TextOptions.ApplicationCompanyName)
            return sceneAndApplicationManager.ApplicationCompanyName();
        if (textOptions == TextOptions.ApplicationProductName)
            return sceneAndApplicationManager.ApplicationProductName();
        if (textOptions == TextOptions.ApplicationVersion)
            return $"v{sceneAndApplicationManager.ApplicationVersion()}";
        if (textOptions == TextOptions.ApplicationUnityVersion)
            return sceneAndApplicationManager.ApplicationUnityVersion();
        return "";
    }
}
