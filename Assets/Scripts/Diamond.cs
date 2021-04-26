using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    [SerializeField] private int diamondValue = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out StuckMovement movement))
        {
            EventBroker.CallUpdateMoney(diamondValue);
            gameObject.SetActive(false);
        }
    }
}
