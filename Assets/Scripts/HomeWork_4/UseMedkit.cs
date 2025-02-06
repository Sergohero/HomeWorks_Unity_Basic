using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseMedkit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
