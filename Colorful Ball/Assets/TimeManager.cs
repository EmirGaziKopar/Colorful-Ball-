using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    
    public float slowdownFactor=0.05f;
    public float slowdownLenght=2f;
    public IEnumerator SlowMotion()
    {

        float time = 0f;

        float counterTime = 0f;
        while (counterTime<0.22f)
        {
            counterTime += Time.deltaTime;
            yield return null;
        }

        while (time < 0.1f)
        {

            Time.timeScale = slowdownFactor;
            Time.fixedDeltaTime = Time.timeScale * .02f; //0.02 varsayýlan ayardýr.
            time += Time.deltaTime;
            yield return null;
        }
        Time.fixedDeltaTime = 0.02f;
        Time.timeScale = 1f;



    }

    public void slowMotionEffectCall()
    {
        //slowMotion effect'in sallantýdan sonra devreye girmesini saðlar
        
        StartCoroutine(SlowMotion());
    }
}
