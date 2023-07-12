using UnityEngine;
using Manager;
using MyIA;
using System.Collections.Generic;

namespace Cards
{
    public class CardBuy : MonoBehaviour
    {
        CardReader card;
        [SerializeField] List<string> cartasNome;
        bool removed = false;
        bool buy=false;
        public void Buy()
        {
            if (buy)
            {
                return;
            }
            if (!SourceManager.instance.inGame)
            {
                Debug.Log("loja fechada");
                return;
            }
            if (card == null)
            {
                card = gameObject.GetComponent<CardReader>();
            }
            if (card.Custo() > SourceManager.instance.actualMoney)
            {
                Debug.Log("Não ha dinheiro suficiente");
                return;
            }
            buy=true;
            SourceManager.instance.actualMoney -= card.Custo();
            card.ChangeCanvas(false);
            Debug.Log("compra realizada");
            SourceManager.instance.nextTurnExp += card.Exp();
            SourceManager.instance.nextTurnHappynes += card.Felicidade();
            SourceManager.instance.moneyForTurn += card.MoneyForTurn();
            SourceManager.instance.nextTurnPolution += card.Poluicao();
            PlacesUse.instance.UpdateTurnIA(card.card.locais);


            foreach (var item in SourceManager.instance.cartas)
            {
                Debug.Log(card.Nome());
                if (item == card.Nome() && !removed)
                {
                    Debug.Log(item + " nao passou 1 foreach");
                    removed = true;
                }
                else
                {
                    Debug.Log(item + " passou 1 foreach");
                    cartasNome.Add(item);
                }
            }
            SourceManager.instance.cartas.Clear();
            foreach (var item in cartasNome)
            {
                Debug.Log(item + " passou 2 foreach");
                SourceManager.instance.cartas.Add(item);
            }
            cartasNome.Clear();
            removed = false;
            buy=false;
            UIManager.instance.UpdateUI();

        }

    }
}