using System;
using System.Collections;
using System.Collections.Generic;
using Cube;
using Player;
using UnityEngine;
using UnityEngine.Serialization;

public class CubeStacker : MonoBehaviour
{
    [SerializeField] private float cubeSize = 1;
    [SerializeField] private float pivotYOffset = 0.5f;
    private ObjectPool _pool;
    private List<GameObject> _stack;
    private GameObject _player;
    private void Start()
    {
        _pool = FindObjectOfType<ObjectPool>();
        _stack = new List<GameObject>();
        _player = FindObjectOfType<PlayerAnimationController>().gameObject;
        
        EventBroker.StackableCubeTriggered += AddStackableCube;
        EventBroker.StackableCubeInvisible += CheckIfStacked;
        EventBroker.ObstacleCubeCollided += CheckIfStacked;
        EventBroker.CubeAbsorbed += RemoveAndDisableCube;
        
        AddStackableCube(null);
    }

    private void AddStackableCube(GameObject obj)
    {
        GameObject cube = _pool.GetObject();
        if (cube != null)
        {
            _stack.Add(cube);
            
            StackableCube controller = cube.GetComponent<StackableCube>();
            cubeSize = controller.CubeSize;
            controller.IsActive = true;
            
            cube.gameObject.isStatic = false;
            cube.GetComponent<BoxCollider>().isTrigger = false;
            cube.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            
            Vector3 playerPosition = _player.transform.position;
            Vector3 newCubePosition = new Vector3(playerPosition.x, playerPosition.y + pivotYOffset, playerPosition.z);
            cube.transform.position = newCubePosition;
            cube.transform.SetParent(transform);
            _player.transform.position = new Vector3(playerPosition.x, playerPosition.y + cubeSize, playerPosition.z);
            
            cube.SetActive(true);
        }
    }

    private void CheckIfStacked(GameObject obj)
    {
        if (_stack.Contains(obj) && obj.TryGetComponent(out StackableCube controller))
        {
            RemoveCube(obj);
        }
    }

    private void RemoveAndDisableCube(GameObject obj)
    {
        RemoveCube(obj);
        _pool.InactivateObject(obj);
    }

    private void RemoveCube(GameObject obj)
    {
        _stack.Remove(obj);

        if (_stack.Count == 0)
        {
            EventBroker.CallLevelFailed();
        }
    }

    private void OnDestroy()
    {
        EventBroker.StackableCubeTriggered -= AddStackableCube;
        EventBroker.StackableCubeInvisible -= CheckIfStacked;
        EventBroker.ObstacleCubeCollided -= CheckIfStacked;
        EventBroker.CubeAbsorbed -= RemoveAndDisableCube;
    }
}
