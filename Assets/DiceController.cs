// using UnityEngine;

// public class DiceController : MonoBehaviour
// {
//     Rigidbody rb;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody>();
//     }

//     void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.Space))
//         {
//             RollDice();
//         }
//     }

//     void RollDice()
//     {
//         // Reset motion
//         rb.linearVelocity = Vector3.zero;
//         rb.angularVelocity = Vector3.zero;

//         // Add jump + spin
//         rb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
//         rb.AddTorque(Random.insideUnitSphere * 15f, ForceMode.Impulse);
//     }
// }
using UnityEngine;
using System.Collections;

public class DiceController : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RollDice(Random.Range(1, 7));
        }
    }

    public void RollDice(int targetNumber)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(Vector3.up * 7f, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * 15f, ForceMode.Impulse);

        StartCoroutine(SettleDice(targetNumber));
    }

    IEnumerator SettleDice(int number)
    {
        yield return new WaitForSeconds(1.5f);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        transform.rotation = GetRotationForNumber(number);
    }

    Quaternion GetRotationForNumber(int num)
    {
        switch (num)
        {
            case 1: return Quaternion.Euler(0, 0, 0);
            case 2: return Quaternion.Euler(0, 0, 180);
            case 3: return Quaternion.Euler(0, 0, 90);
            case 4: return Quaternion.Euler(0, 0, -90);
            case 5: return Quaternion.Euler(90, 0, 0);
            case 6: return Quaternion.Euler(-90, 0, 0);
            default: return Quaternion.identity;
        }
    }
}