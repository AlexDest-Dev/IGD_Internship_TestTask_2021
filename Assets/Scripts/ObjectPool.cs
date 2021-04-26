using System;
using System.Collections;
using System.Collections.Generic;
using Cube;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int instancesAmount = 10;
    [SerializeField] private GameObject reference;
    private List<GameObject> _objectPool;

    private void Awake()
    {
        EventBroker.StackableCubeTriggered += InactivateObject;
        EventBroker.StackableCubeInvisible += InactivateObject;
        InitializeInstances();
    }

    public List<GameObject> GetPool()
    {
        return _objectPool;
    }

    public GameObject GetObject()
    {
        foreach (GameObject instance in _objectPool)
        {
            if (!instance.activeSelf && instance != null)
            {
                return instance;
            }
        }
        Debug.Log("No free instances!");
        return null;
    }

    public void InactivateObject(GameObject obj)
    {
        if (_objectPool.Contains(obj))
        {
            if (obj != null)
            {
                StackableCube stackableCube = obj.GetComponent<StackableCube>();
                if (stackableCube != null)
                {
                    stackableCube.IsActive = false;
                }

                BoxCollider boxCollider = obj.GetComponent<BoxCollider>();
                if (boxCollider != null)
                {
                    boxCollider.isTrigger = false;
                }
                
                Rigidbody rb = obj.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                }

                obj.SetActive(false);
            }
            else
            {
                Debug.Log("Cannot inactivate object. Object is null");
            }
        }
    }

    private void InitializeInstances()
    {
        _objectPool = new List<GameObject>();
        for (int i = 0; i < instancesAmount; i++)
        {
            GameObject objectCopy = Instantiate(reference, transform);
            objectCopy.SetActive(false);
            _objectPool.Add(objectCopy);
        }
    }

    private void OnDestroy()
    {
        EventBroker.StackableCubeInvisible -= InactivateObject;
        EventBroker.StackableCubeTriggered -= InactivateObject;
    }
}
