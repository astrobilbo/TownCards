using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;
public class SceneAndApplicationManager : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public void SceneLoad(string Load)
    {
        SceneManager.LoadScene(Load);
    }
    public void SceneLoad(int Load)
    {
        SceneManager.LoadScene(Load);
    }
    public void SceneLoadAsync(int Load)
    {
        StartCoroutine(LoadAsynchronously(Load));
    }
    public void Exit()
    {
        Application.Quit();
    }


    public string ApplicationCompanyName()
    {
        return Application.companyName;
    }
    public string ApplicationProductName()
    {
        return Application.productName;
    }
    public string ApplicationVersion()
    {
        return Application.version;
    }
    public string ApplicationUnityVersion()
    {
        return Application.unityVersion;
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        yield return new WaitForSeconds(2f);

    }
}
