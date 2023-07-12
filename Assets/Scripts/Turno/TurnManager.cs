using MyIA;
using UnityEngine;
namespace Manager
{
    public class TurnManager : MonoBehaviour
    {
        private static TurnManager _instance;
        public static TurnManager instance
        {
            get
            {
                if (_instance is null)
                    Debug.LogError("EndGame is NULL");

                return _instance;
            }
        }
        void Awake()
        {
            _instance = this;

        }

        public void StartGame(bool isLoading)
        {

            if (isLoading)
            {

                Cards.CardsManager.instance.SetCards();
            }
            else
            {
                SourceManager.instance.totalExp = SourceManager.instance.exp;
                SourceManager.instance.turn++;
                Cards.CardsManager.instance.UpdateCards();

            }
            UpdadeLevel();
            UIManager.instance.UpdateUI();

        }

        public void NextTurn()
        {
            UpdadeValues();
            CheckValues();
            UpdadeLevel();

            if (CheckDefeat())
            {
                EndGame.instance.End("Perdeu");
                SourceManager.instance.inGame = false;
                SourceManager.instance.turn++;
                UIManager.instance.UpdateUI();
                return;
            }
            if (SourceManager.instance.turn == SourceManager.instance.maxTurns)
            {
                EndGame.instance.End("Venceu");
                SourceManager.instance.inGame = false;
                SourceManager.instance.turn++;
                UIManager.instance.UpdateUI();
                return;
            }
            SourceManager.instance.turn++;
            PlacesUse.instance.CheckIAChange();
            Cards.CardsManager.instance.UpdateCards();

        }

        private static void CheckValues()
        {
            SourceManager.instance.nextTurnPolution++;
            SourceManager.instance.nextTurnHappynes--;
            if (SourceManager.instance.polution > 100) SourceManager.instance.polution = 100;
            if (SourceManager.instance.polution < 0) SourceManager.instance.polution = 0;
            if (SourceManager.instance.happynes < 0) SourceManager.instance.happynes = 0;
            if (SourceManager.instance.happynes > 100) SourceManager.instance.happynes = 100;
            if (SourceManager.instance.nextTurnPolution < -6) SourceManager.instance.nextTurnPolution = -6;
            if (SourceManager.instance.nextTurnHappynes < -6) SourceManager.instance.nextTurnHappynes = -6;
            if (SourceManager.instance.nextTurnPolution > 6) SourceManager.instance.nextTurnPolution = 6;
            if (SourceManager.instance.nextTurnHappynes > 6) SourceManager.instance.nextTurnHappynes = 6;
        }

        private static void UpdadeValues()
        {
            SourceManager.instance.polution += SourceManager.instance.nextTurnPolution;
            SourceManager.instance.happynes += SourceManager.instance.nextTurnHappynes;
            SourceManager.instance.actualMoney += SourceManager.instance.moneyForTurn;
        }

        void UpdadeLevel()
        {
            SourceManager.instance.exp += SourceManager.instance.nextTurnExp;
            SourceManager.instance.totalExp += SourceManager.instance.nextTurnExp;
            int tempLvl = 0;
            int totalExpToChange = SourceManager.instance.totalExp;
          
            foreach (int NLvl in SourceManager.instance.nextLevelExp)
            {
                if (NLvl <= totalExpToChange)
                {
                    totalExpToChange -= NLvl;
                    tempLvl++;
                    continue;
                }
                break;
            }
            SourceManager.instance.exp = totalExpToChange;
            SourceManager.instance.level = tempLvl;
            if (SourceManager.instance.exp < 0) SourceManager.instance.exp = 0;
            SourceManager.instance.nextTurnExp = 0;
        }
        bool CheckDefeat()
        {
            if (SourceManager.instance.polution == 100)
            {
                Debug.Log("Polution");
                return true;
            }
            else if (SourceManager.instance.happynes == 0)
            {
                Debug.Log("Happynes");
                return true;
            }
            else if (SourceManager.instance.actualMoney <= 0 && SourceManager.instance.moneyForTurn <= 0)
            {
                Debug.Log("Money");
                return true;
            }
            return false;
        }
    }
}