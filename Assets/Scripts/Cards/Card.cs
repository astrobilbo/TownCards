using UnityEngine;
using Manager.Places;

namespace Cards
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Create Card")]
    public class Card : ScriptableObject
    {
        [Header("Nome e imagem da carta")]
        public string nome;
        public Sprite sprite;
        [Header("atributos da poluição e da felicidade")]
        public int poluicao;
        public int felicidade;
        [Header("atributos da exp e do dinheiro/turno")]
        public int exp;
        public int moneyForTurn;
        [Header("Locais de interação da carta")]
        public Places locais;
        [Header("nvl e custo da carta")]
        public int nvl;
        public int custo;

    }
}