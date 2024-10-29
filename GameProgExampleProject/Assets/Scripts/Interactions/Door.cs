using UnityEngine;

public class Door : MonoBehaviour
{
    
    public bool closed = true;
    public float openDegrees = 90f;
    public float openSpeed = 60;

    // Private variables
    float closedDegrees;

    Vector3 closedEulerAngles;
    Vector3 openedEulerAngles;
    void Start()
    {
        closedDegrees = transform.localEulerAngles.y;

        closedEulerAngles = new Vector3(0f, closedDegrees, 0f);
        openedEulerAngles = new Vector3(0f, closedDegrees + openDegrees, 0f);
    }

  
    void Update()
    {
        if (closed)
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, closedEulerAngles, openSpeed * Time.deltaTime);
        else
            transform.localEulerAngles = Vector3.MoveTowards(transform.localEulerAngles, openedEulerAngles, openSpeed * Time.deltaTime);

    }

    public void ToggleOpen()
    {
        closed = !closed;
    }
}
