using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Coroutines : MonoBehaviour
{

    // IEnumerator : En "interface" / strategi som tillåter oss att utföra något steg för steg.
    // yield : Ge väg för "Vänta på", Jag tar en paus nu och återkommer senare.

    //yield return : Jag tar en paus nu (yield), (return) här är när jag planerar att återkomma.





    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            StartCoroutine(DelayedExecution());

        if (Input.GetKeyDown(KeyCode.Alpha2))
            StartCoroutine(RepeatingExecution());

        if (Input.GetKeyDown(KeyCode.Alpha3))
            StartCoroutine(RepeatingExecDuration());

        if (Input.GetKeyDown(KeyCode.Alpha4))
            StartCoroutine(ConditionalExecution());
    }

    IEnumerator DelayedExecution(float delaySeconnds = 5f)
    {
        yield return new WaitForSeconds(delaySeconnds);

        Debug.Log("Time is up");
    }
    IEnumerator RepeatingExecution(float intervalSeconds = 1f)
    {
        while (true)
        {
            Debug.Log($"Executing with an interval of {intervalSeconds}");
            yield return new WaitForSeconds(intervalSeconds);
        }
    }

    IEnumerator RepeatingExecDuration(float intervalSeconds = 1f, float durationSeconds = 10f) 
    {
        float timeElapsed = 0f;

        while (timeElapsed<durationSeconds)
        {
            Debug.Log($"Executing with an interval of {intervalSeconds}"); 

            timeElapsed += intervalSeconds;
            yield return new WaitForSeconds(intervalSeconds);
        }

        Debug.Log("Time is up!");
    }

    //Döp om boolen undertill till något mer passande för funktionen och det du vill göra.
    bool SomeCondition()
    {
        bool result = Input.GetKeyDown(KeyCode.Space);
        return result;
    }
    IEnumerator ConditionalExecution()
    {
        Debug.Log("Time to work!");

        yield return new WaitUntil(SomeCondition);
        yield return null; //Waits one frame.

        Debug.Log("Worker did work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker did more work work!");

        yield return new WaitUntil(SomeCondition);
        yield return null;

        Debug.Log("Worker finished the job!");
    }

}


