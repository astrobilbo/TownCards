using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EndGame : MonoBehaviour
{
    private static EndGame _instance;
    public static EndGame instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("EndGame is NULL");

            return _instance;
        }
    }
    CanvasGroup canvasGroup;
    public TextMeshProUGUI nome;
    void Awake()
    {
        _instance = this;
        canvasGroup = GetComponent<CanvasGroup>();

    }
    
    
    public void End(string end)
    {
        ChangeCanvas(true);
        switch (end)
        {
            case "Venceu":
                print(end);
                nome.text = "Você Ganhou!!!";
                nome.color= Color.green;
                break;
            case "Perdeu":
                print(end);
                nome.text = "Derrota";
                nome.color= Color.red;
                break;
            default:
                print("Incorrect word.");
                break;
        }
    }
    public void ChangeCanvas(bool value)
    {
        canvasGroup.alpha = value ? 1 : 0;
        canvasGroup.blocksRaycasts = value;
    }
}
