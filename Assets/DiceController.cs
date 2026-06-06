using UnityEngine;
using System.Collections;

public class DiceController : MonoBehaviour
{
    private Rigidbody rb;
    private Coroutine settleCoroutine;

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

    void SetCenterOfMassForTarget(int target)
    {
        float bias = 0.12f;

        switch (target)
        {
            case 1:
                rb.centerOfMass = Vector3.down * bias;
                break;

            case 2:
                rb.centerOfMass = Vector3.up * bias;
                break;

            case 3:
                rb.centerOfMass = Vector3.left * bias;
                break;

            case 4:
                rb.centerOfMass = Vector3.right * bias;
                break;

            case 5:
                rb.centerOfMass = Vector3.back * bias;
                break;

            case 6:
                rb.centerOfMass = Vector3.forward * bias;
                break;
        }
    }

    public void RollDice(int targetNumber)
    {
        SetCenterOfMassForTarget(targetNumber);

        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Strong forward throw
        Vector3 throwForce = new Vector3(
            Random.Range(-3f, 3f),
            Random.Range(7f, 10f),
            Random.Range(5f, 9f)
        );

        rb.AddForce(throwForce, ForceMode.Impulse);

        // Aggressive spin
        Vector3 spinTorque = new Vector3(
            Random.Range(-40f, 40f),
            Random.Range(-40f, 40f),
            Random.Range(-40f, 40f)
        );

        rb.AddTorque(spinTorque, ForceMode.Impulse);
    }

    // IEnumerator SettleDice(int number)
    // {
    //     yield return new WaitForSeconds(2f);

    //     rb.linearVelocity = Vector3.zero;
    //     rb.angularVelocity = Vector3.zero;

    //     transform.rotation = GetRotationForNumber(number);

    //     Debug.Log("Target Number: " + number);
    // }

    // StartCoroutine(SettleDice(targetNumber));

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