using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStack : MonoBehaviour
{
    [SerializeField] private int cubesAmount;
    private List<GameObject> _stack;
    private ObjectPool _pool;

    public int CubesAmount
    {
        get => cubesAmount;
        set
        {
            if (value > 0)
            {
                cubesAmount = value;
            }
        }
    }

    private void Awake()
    {
        _stack = new List<GameObject>();
        _pool = FindObjectOfType<ObjectPool>();
        
        EventBroker.StackableCubeTriggered += RemoveStackableCube;
    }

    public void SetCubes()
    {
        for (int i = 0; i < cubesAmount; i++)
        {
            GameObject cube = _pool.GetObject();
            if (cube != null)
            {
                _stack.Add(cube);
                CubeController cubeController = cube.GetComponent<CubeController>();
                
                Vector3 stackPosition = transform.position;
                Vector3 newCubePosition = new Vector3(stackPosition.x, stackPosition.y + cubeController.CubeSize * _stack.Count, stackPosition.z);
                cube.transform.position = newCubePosition;
                cube.transform.SetParent(transform);
                
                cubeController.IsActive = true;
                cube.GetComponent<Rigidbody>().isKinematic = true;
                cube.GetComponent<BoxCollider>().isTrigger = true;
                cube.SetActive(true);
            }
        }
    }

    private void RemoveStackableCube(GameObject obj)
    {
        if (_stack.Contains(obj))
        {
            _stack.Remove(obj);
        }

        if (_stack.Count == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        EventBroker.StackableCubeTriggered -= RemoveStackableCube;
    }
}
