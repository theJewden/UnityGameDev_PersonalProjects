using UnityEngine.Events;
using UnityEngine;

public class UnityEventBehavior : MonoBehaviour
{
    public UnityEvent awakeEvent, startEvent, onTriggerEvent;

    private void Awake()
    {
        awakeEvent.Invoke();
    }

    private void Start()
    {
        startEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onTriggerEvent.Invoke();
    }
}
