using UnityEngine;
using UnityEngine.Events;

public class SimpleTrigger : MonoBehaviour
{
    public bool destroyOnTrigger;
    public string tagFilter;

    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagFilter))
            onTriggerEnter.Invoke();
            Debug.Log("Entered Trigger");
    }

    void OnTriggerExit(Collider other)
    {
       

       
        if (other.CompareTag(tagFilter))
        {
            onTriggerExit.Invoke();

            // Debug message that displays on Unity console what happens when trigger is entered
            Debug.Log("Entered Trigger");

            if (destroyOnTrigger)
                Destroy(gameObject);
        }
    }


}
