using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    public Vector3 newPosition;
    public float speed = 10f;
    public bool smoothDamp;

    //private variables

    bool isNewPositionActive = false;
    Vector3 oldPosition;

    Vector3 targetposition;

    Vector3 currentSpeed; // for SmoothDamp

    void Start()
    {
        oldPosition = transform.position;
        targetposition = oldPosition;
    }

  
    void Update()
    {
        Vector3 currentPosition = transform.position;

        if (smoothDamp)
            transform.position = Vector3.SmoothDamp(currentPosition, targetposition, ref currentSpeed, 2f / speed);
        else
            transform.position = Vector3.MoveTowards(currentPosition, targetposition, speed * Time.deltaTime);
    }

    public void MoveObject()
    {
      isNewPositionActive = !isNewPositionActive;

        if (isNewPositionActive)
            targetposition = newPosition;
        else
            targetposition = oldPosition;
        
    }
}
