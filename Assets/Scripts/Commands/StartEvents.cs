using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Commands
{
public class StartEvents : MonoBehaviour
{
     [SerializeField]UnityEvent OnStartEvent;
    // Start is called before the first frame update
    void Start()
    {
        OnStartEvent.Invoke();
    }

}
}