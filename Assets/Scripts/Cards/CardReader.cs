using UnityEngine;
using Manager.Places;
using UnityEngine.UI;

namespace Cards
{
    public class CardReader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
        public Card card;
        Card Card
        {
            get { return card; }
            set { card = value; }
        }
        public string Nome() { return Card.nome; }
        public Sprite Sprite() { return Card.sprite; }

        public int Nvl() { return Card.nvl; }
        public int Custo() { return Card.custo; }

        public int MoneyForTurn() { return Card.moneyForTurn; }
        public int Exp() { return Card.exp; }

        public int Poluicao() { return Card.poluicao; }
        public int Felicidade() { return Card.felicidade; }

        public Places Locais() { return Card.locais; }

        public void ChangeCanvas(bool value)
        {
            canvasGroup.alpha = value ? 1 : 0;
            canvasGroup.blocksRaycasts = value;
        }

    }

}