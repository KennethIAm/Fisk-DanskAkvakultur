using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5f;
    [SerializeField]
    float rotationSpeed = 50f;

    bool isWandering = false;
    bool isrotatingLeft = false;
    bool isrotatingRight = false;
    bool isWalking = false;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isWandering)
        {
            StartCoroutine(Wander());
        }
        if (isrotatingRight)
        {
            transform.Rotate(transform.up * Time.deltaTime * rotationSpeed);
        }
        if (isrotatingLeft)
        {
            transform.Rotate(transform.up * Time.deltaTime * -rotationSpeed);
        }
        if (isWalking)
        {
            rb.AddForce(transform.forward * movementSpeed);
        }
    }

    IEnumerator Wander()
    {
        int rotationtime = Random.Range(1, 3);
        int rotateWait = Random.Range(1, 3);
        int rotatedirection = Random.Range(1, 2);
        int walkWait = Random.Range(1, 3);
        int walkTime = Random.Range(1, 3);

        isWandering = true;

        yield return new WaitForSeconds(walkWait);

        isWalking = true;

        yield return new WaitForSeconds(walkTime);

        isWalking = false;

        yield return new WaitForSeconds(rotateWait);

        if (rotatedirection == 1)
        {
            isrotatingLeft = true;
            yield return new WaitForSeconds(rotationtime);
            isrotatingLeft = false;
        }

        if (rotatedirection == 2)
        {
            isrotatingRight = true;
            yield return new WaitForSeconds(rotationtime);
            isrotatingRight = false;
        }

        isWandering = false;
    }
}
