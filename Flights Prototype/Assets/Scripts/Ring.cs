using UnityEngine;
using System.Collections;

public class Ring : MonoBehaviour
{
    public bool isTaken = false;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine("TakenCheck");
    }

    IEnumerator TakenCheck()
    {
        yield return new WaitForSeconds(0.5f);
        isTaken = true;
    }
}
