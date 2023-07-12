using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class SourceManager : MonoBehaviour
    {
        private static SourceManager _instance;
        public static SourceManager instance
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
        public bool inGame = true;
        [Header("dinheiro")]
        public int actualMoney;
        public int moneyForTurn;
        [Header("nivel")]
        public int level;
        public int totalExp = 0;
        public int exp;
        public int[] nextLevelExp;
        public int nextTurnExp;
        [Header("poluição")]
        [Range(0, 100)]
        public int polution;
        [Range(-100, 100)]
        public int nextTurnPolution;
        [Header("felicidade")]
        [Range(0, 100)]
        public int happynes;
        [Range(-100, 100)]
        public int nextTurnHappynes;
        [Header("meses")]
        public int turn;
        public int maxTurns;
        public List<string> cartas;
    }
}