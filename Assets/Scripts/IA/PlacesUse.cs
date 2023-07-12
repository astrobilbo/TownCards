using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Manager;
using UnityEngine.Events;
using Manager.Places;
namespace MyIA
{
    public class PlacesUse : MonoBehaviour
    {
        private static PlacesUse _instance;
        public static PlacesUse instance
        {
            get
            {
                if (_instance is null)
                    Debug.LogError("SourceManager is NULL");

                return _instance;
            }
        }
        void Awake()
        {
            _instance = this;
        }

        [SerializeField] PlacesUsed[] places;
        public void UpdateTurnIA(Places locais)
        {
            foreach (var item in places)
            {
                if (locais.HasFlag(item.place))
                {
                    item.turnoModificado = SourceManager.instance.turn;
                }
            }
        }

        public void CheckIAChange()
        {
            foreach (var item in places)
            {
                if (item.poluicao)
                {
                    if (SourceManager.instance.polution > 70 || SourceManager.instance.turn - item.turnoModificado > 3)
                    {
                        item.angryEvent.Invoke();
                    }
                    else
                    {
                        item.happyEvent.Invoke();
                    }
                }
                if (item.satisfacao)
                {
                    if (SourceManager.instance.happynes < 30 || SourceManager.instance.turn - item.turnoModificado > 3)
                    {
                        item.angryEvent.Invoke();
                    }
                    else
                    {
                        item.happyEvent.Invoke();
                    }
                }
                if (item.dinheiro)
                {
                    if (SourceManager.instance.moneyForTurn < 5 || SourceManager.instance.turn - item.turnoModificado > 3)
                    {
                        item.angryEvent.Invoke();
                    }
                    else
                    {
                        item.happyEvent.Invoke();
                    }
                }
                if (item.ciencia)
                {
                    if (SourceManager.instance.turn - item.turnoModificado > 3)
                    {
                        item.angryEvent.Invoke();
                    }
                    else
                    {
                        item.happyEvent.Invoke();
                    }
                }
            }
        }
    }
    [Serializable]
    public class PlacesUsed
    {
        public string name;
        public Places place;
        public int turnoModificado=1;
        public bool poluicao, satisfacao, dinheiro, ciencia;
        public UnityEvent angryEvent;
        public UnityEvent happyEvent;
    }
}
