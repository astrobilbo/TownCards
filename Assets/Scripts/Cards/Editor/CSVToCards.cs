using System.IO;
using UnityEngine;
using UnityEditor;
using Manager.Places;
using System;
namespace Cards
{
    public class CSVToCards
    {
        private static string cardCSVPath = "/Scripts/Cards/Editor/CSVs/CardCSV.csv";
        private static string cardPath = "/Scriptable Objectes/cards/";

        [MenuItem("Tools/Csv To Cards")]
        private static void GenerateCards()
        {
            string[] allLines = File.ReadAllLines(Application.dataPath + cardCSVPath);

            foreach (string s in allLines)
            {
                if (s == allLines[0]) continue;

                string[] splitData = s.Split(',');

                Card card = ScriptableObject.CreateInstance<Card>();
                card.nome = splitData[0];
                card.sprite= Resources.Load<Sprite>(card.nome);
                card.poluicao = int.Parse(splitData[1]);
                card.felicidade = int.Parse(splitData[2]);
                card.exp = int.Parse(splitData[3]);
                card.moneyForTurn = int.Parse(splitData[4]);
                card.nvl = int.Parse(splitData[5]);
                card.custo = int.Parse(splitData[6]);
                var p = Places.none;
                for (int i = 7; i < splitData.Length; i++)
                {
                    if (splitData[i] == "") continue;
                    p |= (Places)Enum.Parse(typeof(Places), splitData[i]);
                }
                card.locais = p;

                AssetDatabase.CreateAsset(card, $"Assets/{cardPath}{card.nome}.asset");
            }
            AssetDatabase.SaveAssets();
        }
    }
}