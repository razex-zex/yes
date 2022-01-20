using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MoveObject : MonoBehaviour
{
    float timeElapsed;
    [SerializeField] float moveDuration;
    [SerializeField] float waitBetweenLerp;
    float waitElapsed;
    Vector3 startPos;
    [SerializeField] Transform endPosTransform;
    Vector3 endPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        endPos = endPosTransform.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (timeElapsed < moveDuration)
        {
            transform.position = Vector3.Lerp(startPos, endPos, timeElapsed /
           moveDuration);
            timeElapsed += Time.deltaTime;
        }
        if (timeElapsed >= moveDuration)
        {
            waitElapsed += Time.deltaTime;
            if (waitElapsed >= waitBetweenLerp)
            {
                Vector3 temp = startPos;
                startPos = endPos;
                endPos = temp;
                timeElapsed = 0;
                waitElapsed = 0;
            }
        }

    }
}