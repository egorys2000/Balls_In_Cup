using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailZone : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        GameManager.Get().LevelFailed();
    }
}
