using UnityEngine;
using TMPro;

namespace Manager.UI
{
    public class ResourcesUI : MonoBehaviour
    {
        private static ResourcesUI _instance;
        public static ResourcesUI instance
        {
            get
            {
                if (_instance is null)
                    Debug.LogError("ResourcesUI is NULL");

                return _instance;
            }
        }
        void Awake()
        {
            _instance = this;
        }
        public TextMeshProUGUI poluicao;
        public TextMeshProUGUI felicidade;
        public TextMeshProUGUI exp;
        public TextMeshProUGUI moneyForTurn;
        public TextMeshProUGUI turn;
        public TextMeshProUGUI nvl;


        [ContextMenu("atualizar os recursos")]
        public void UpdateUI()
        {
            poluicao.text = CheckPolution();
            felicidade.text = CheckHappynes();
            exp.text = CheckTecnology();
            moneyForTurn.text = CheckMoney();
            nvl.text = "" + SourceManager.instance.level;
            turn.text = "Mês: " + SourceManager.instance.turn;

        }

        private string CheckPolution()
        {
            if (SourceManager.instance.nextTurnPolution > 0)
            {
                // return "Poluição:\n" + SourceManager.instance.polution + "|+" + SourceManager.instance.nextTurnPolution;
                return SourceManager.instance.polution + "\n+" + SourceManager.instance.nextTurnPolution;

            }

            // return "Poluição:\n" + SourceManager.instance.polution + "|" + SourceManager.instance.nextTurnPolution;
            return SourceManager.instance.polution + "\n" + SourceManager.instance.nextTurnPolution;


        }
        private string CheckHappynes()
        {
            if (SourceManager.instance.nextTurnHappynes > 0)
            {
                // return "Satisfação: \n" + SourceManager.instance.happynes + "|+" + SourceManager.instance.nextTurnHappynes;
                return SourceManager.instance.happynes + "\n+" + SourceManager.instance.nextTurnHappynes;
            }
            else
            {
                // return "Satisfação: \n" + SourceManager.instance.happynes + "|" + SourceManager.instance.nextTurnHappynes;
                return SourceManager.instance.happynes + "\n" + SourceManager.instance.nextTurnHappynes;
            }
        }
        private string CheckTecnology()
        {
            if (SourceManager.instance.nextLevelExp.Length == SourceManager.instance.level)
            {
                // return "Tecnologia:\n Nivel maximo";
                return "Nivel maximo";

            }
            if (SourceManager.instance.nextTurnExp > 0)
            {
                // return "Tecnologia:\n" + SourceManager.instance.exp + "/" + SourceManager.instance.nextLevelExp[SourceManager.instance.level] + "| +" + SourceManager.instance.nextTurnExp;
                return SourceManager.instance.exp + "/" + SourceManager.instance.nextLevelExp[SourceManager.instance.level] + "\n+" + SourceManager.instance.nextTurnExp;
            }
            else
            {
                // return "Tecnologia:\n" + SourceManager.instance.exp + "/" + SourceManager.instance.nextLevelExp[SourceManager.instance.level] + "| " + SourceManager.instance.nextTurnExp;
                return SourceManager.instance.exp + "/" + SourceManager.instance.nextLevelExp[SourceManager.instance.level] + "\n" + SourceManager.instance.nextTurnExp;
            }
        }
        private string CheckMoney()
        {
            if (SourceManager.instance.moneyForTurn > 0)
            {
                // return "Caixa:" + SourceManager.instance.actualMoney + "\nImposto +" + SourceManager.instance.moneyForTurn;
                return SourceManager.instance.actualMoney + "k\n+" + SourceManager.instance.moneyForTurn + "k";

            }
            else
            {
                // return "Caixa:" + SourceManager.instance.actualMoney + "\nImposto +" + SourceManager.instance.moneyForTurn;
                return SourceManager.instance.actualMoney + "k\n" + SourceManager.instance.moneyForTurn + "k";

            }

        }
    }
}