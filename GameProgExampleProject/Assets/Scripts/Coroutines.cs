using System.Collections;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Coroutines : MonoBehaviour
{

    // IEnumerator : En "interface" / strategi som till�ter oss att utf�ra n�got steg f�r steg.
    // yield : Ge v�g f�r "V�nta p�", Jag tar en paus nu och �terkommer senare.

    //yield return : Jag tar en paus nu (yield), (return) h�r �r n�r jag planerar att �terkomma.





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

    //D�p om boolen undertill till n�got mer passande f�r funktionen och det du vill g�ra.
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


