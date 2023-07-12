using System.Collections.Generic;
using UnityEngine;
using Manager;
using System.Linq;

namespace Cards
{
    public class CardsManager : MonoBehaviour
    {
        private static CardsManager _instance;
        public static CardsManager instance
        {
            get
            {
                if (_instance is null)
                    Debug.LogError("CardsManager is NULL");

                return _instance;
            }

        }
        void Awake()
        {
            _instance = this;
            Cartas = GetComponentsInChildren<CardReader>();
            // allCards = (Card[])Resources.FindObjectsOfTypeAll(typeof(Card));
        }
        [SerializeField] Card[] allCards;
        [SerializeField] List<Card> myCards;
        [SerializeField] List<Card> activeCards;
        CardReader[] Cartas;
        public int cartas = 0;

        [ContextMenu("teste updade cartas")]
        public void UpdateCards()
        {
            SourceManager.instance.cartas.Clear();
            myCards.Clear();
            Card newCard;
            if (allCards == null)
            {
                Debug.Log("failed :::( " + cartas);
            }
            foreach (Card c in allCards)
            {
                if (SourceManager.instance.level < c.nvl) continue;
                myCards.Add(c);
                cartas++;
            }
            foreach (CardReader cR in Cartas)
            {
                
                newCard = myCards[Random.Range(0, myCards.Count())];
                SourceManager.instance.cartas.Add(newCard.name);
                cR.card = newCard;
                cR.ChangeCanvas(true);
            }
            UIManager.instance.UpdateUI();
        }
        public void UpdateCardsOnMenu()
        {
            if (allCards == null)
            {
                Debug.Log("failed :::( " + cartas);
            }
            foreach (CardReader cR in Cartas)
            {
                cR.card = allCards[Random.Range(0, allCards.Length)];
                cR.GetComponent<UI.CardDisplay>().UpdateUI();
                cR.ChangeCanvas(true);
            }
        }

        public void SetCards()
        {

            if (allCards == null)
            {
                Debug.Log("failed :::( " + cartas);
            }
            foreach (Card c in allCards)
            {
                if (SourceManager.instance.level < c.nvl) continue;
                foreach (var item in SourceManager.instance.cartas)
                {
                    if (c.name == item)
                    {
                        activeCards.Add(c);
                    }
                }
                myCards.Add(c);
                cartas++;
            }
            foreach (var cR in Cartas.Select((Value, i) => new { i, Value }))
            {
                if (activeCards.ElementAtOrDefault(cR.i) != null)
                {
                    cR.Value.card = activeCards[cR.i];
                    cR.Value.ChangeCanvas(true);
                }
                else
                {
                    cR.Value.card = myCards[Random.Range(0, cartas)];
                    cR.Value.ChangeCanvas(false);
                }


            }
            UIManager.instance.UpdateUI();
        }
    }
}
