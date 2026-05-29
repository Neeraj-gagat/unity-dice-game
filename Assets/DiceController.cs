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
        if (Input.GetKeyDown(KeyCode.Alpha1))
            RollDice(1);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            RollDice(2);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            RollDice(3);

        if (Input.GetKeyDown(KeyCode.Alpha4))
            RollDice(4);

        if (Input.GetKeyDown(KeyCode.Alpha5))
            RollDice(5);

        if (Input.GetKeyDown(KeyCode.Alpha6))
            RollDice(6);
    }

    public void RollDice(int targetNumber)
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        rb.AddForce(
            new Vector3(
                Random.Range(-2f, 2f),
                7f,
                Random.Range(3f, 6f)
            ),
            ForceMode.Impulse
        );

        rb.AddTorque(
            Random.insideUnitSphere * 30f,
            ForceMode.Impulse
        );

        StartCoroutine(SettleDice(targetNumber));
    }

    IEnumerator SettleDice(int number)
    {
        yield return new WaitForSeconds(2f);

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