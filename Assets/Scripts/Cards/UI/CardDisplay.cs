using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Cards.UI
{
    public class CardDisplay : MonoBehaviour
    {
        CardReader card;
        public TextMeshProUGUI nome;
        public Image image;
        public TextMeshProUGUI poluicao;
        public TextMeshProUGUI felicidade;
        public TextMeshProUGUI exp;
        public TextMeshProUGUI moneyForTurn;
        public TextMeshProUGUI nvl;
        public TextMeshProUGUI custo;
        public TextMeshProUGUI local;

        [ContextMenu("atualizar a carta")]
        public void UpdateUI()
        {
            if (card == null) card = gameObject.GetComponent<CardReader>();

            nome.text = "" + card.Nome();
            Sprite();
            Poluicao();
            Satisfacao();
            // exp.text = "Tecnologia:\n" + card.Exp();
            exp.text = card.Exp()+"";
            Money();
            local.text = "" + card.Locais();
            Custo();
            // nvl.text = "Nivel:\n" + card.Nvl();
            nvl.text ="Nv: "+ card.Nvl()+"";
            
        }
        private void Sprite()
        {
            if (card.Sprite() == null)
            {
                image.sprite = default;
                return;
            }
            image.sprite = card.Sprite();
        }
        private void Poluicao()
        {
            // poluicao.text = "Poluição:\n" + card.Poluicao() + "%";
            poluicao.text = card.Poluicao() + "%";

        }

        private void Satisfacao()
        {
            if (card.Felicidade() > 0)
            { 
                // felicidade.text = "Satisfação:\n+" + card.Felicidade() + "%"; 
                felicidade.text = card.Felicidade() + "%"; 
            
            }
            else { 
                // felicidade.text = "Satisfação:\n" + card.Felicidade() + "%"; 
                felicidade.text =card.Felicidade() + "%"; 

            }
        }

        private void Money()
        {
            if (card.MoneyForTurn() > 0)
            { 
                // moneyForTurn.text = "Imposto:\n+" + card.MoneyForTurn();
                moneyForTurn.text = card.MoneyForTurn()+"k";

                 }
            else {
                //  moneyForTurn.text = "Imposto:\n" + card.MoneyForTurn(); 
                 moneyForTurn.text = card.MoneyForTurn()+"k"; 
            }
        }

        private void Custo()
        {
            if (card.Custo() < 0)
            { 
                custo.text = "Preço: +" + card.Custo() + "k $";
                // custo.text =  card.Custo() + "k $";

                 }
            else { 
                custo.text = "Preço: " + card.Custo() + "k $";
                // custo.text = card.Custo() + "k $";

            }
        }
    }
}
