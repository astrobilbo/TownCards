using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SaveData : MonoBehaviour
{
    public static SaveData saveData;
    void Awake()
    {
        if (saveData == null)
        {
            saveData = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [SerializeField] private Source _sourceData = new Source();
    [SerializeField] private Source _startsource = new Source();
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private Slider slider;
    bool isLoadingSaveFile;
    public void SaveIntoJson()
    {
        GetValuesToSave();

        string jsonText = JsonUtility.ToJson(_sourceData);
        File.WriteAllText(Application.persistentDataPath + "/Source.json", jsonText);
    }

    private void GetValuesToSave()
    {
        _sourceData.actualMoney = SourceManager.instance.actualMoney;
        _sourceData.moneyForTurn = SourceManager.instance.moneyForTurn;
        _sourceData.level = SourceManager.instance.level;
        _sourceData.totalExp = SourceManager.instance.totalExp;
        _sourceData.exp = SourceManager.instance.exp;
        _sourceData.polution = SourceManager.instance.polution;
        _sourceData.nextTurnPolution = SourceManager.instance.nextTurnPolution;
        _sourceData.happynes = SourceManager.instance.happynes;
        _sourceData.nextTurnHappynes = SourceManager.instance.nextTurnHappynes;
        _sourceData.turn = SourceManager.instance.turn;
        _sourceData.cartas = SourceManager.instance.cartas;

    }

    public void LoadFromJson(bool isLoading)
    {
        isLoadingSaveFile = isLoading;
        LoadScene(2);
    }

    private void SetStartValues()
    {
        SourceManager.instance.actualMoney = _startsource.actualMoney;
        SourceManager.instance.moneyForTurn = _startsource.moneyForTurn;
        SourceManager.instance.level = _startsource.level;
        SourceManager.instance.totalExp = _startsource.totalExp;
        SourceManager.instance.exp = _startsource.exp;
        SourceManager.instance.polution = _startsource.polution;
        SourceManager.instance.nextTurnPolution = _startsource.nextTurnPolution;
        SourceManager.instance.happynes = _startsource.happynes;
        SourceManager.instance.nextTurnHappynes = _startsource.nextTurnHappynes;
        SourceManager.instance.turn = _startsource.turn;
        TurnManager.instance.StartGame(false);
    }

    private void LoadSaveValues()
    {
        SourceManager.instance.actualMoney = _sourceData.actualMoney;
        SourceManager.instance.moneyForTurn = _sourceData.moneyForTurn;
        SourceManager.instance.level = _sourceData.level;
        SourceManager.instance.totalExp = _sourceData.totalExp;
        SourceManager.instance.exp = _sourceData.exp;
        SourceManager.instance.polution = _sourceData.polution;
        SourceManager.instance.nextTurnPolution = _sourceData.nextTurnPolution;
        SourceManager.instance.happynes = _sourceData.happynes;
        SourceManager.instance.nextTurnHappynes = _sourceData.nextTurnHappynes;
        SourceManager.instance.turn = _sourceData.turn;
        SourceManager.instance.cartas = _sourceData.cartas;
        TurnManager.instance.StartGame(true);
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }
    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            yield return null;
        }
        yield return new WaitForSeconds(4f);
        AffeterLoad();
        
    }

    private void AffeterLoad()
    {
        loadingScreen.SetActive(false);
        slider.value = 0;
        if (!isLoadingSaveFile)
        {
            SetStartValues();
        }
        else
        {
            string jsonText;
            jsonText = File.ReadAllText(Application.persistentDataPath + "/Source.json");
            _sourceData = JsonUtility.FromJson<Source>(jsonText);
            LoadSaveValues();
        }
    }
}

[System.Serializable]
public class Source
{
    public int actualMoney;
    public int moneyForTurn;
    public int level;
    public int totalExp;
    public int exp;
    public int nextTurnExp;
    public int polution;
    public int nextTurnPolution;
    public int happynes;
    public int nextTurnHappynes;
    public int turn;
    public List<string> cartas;
}