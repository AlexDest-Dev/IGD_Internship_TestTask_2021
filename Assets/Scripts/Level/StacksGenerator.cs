using Cube;
using UnityEngine;

namespace Level
{
    public class StacksGenerator : MonoBehaviour
    {
        [SerializeField] private int stacksAmount = 5;
        [SerializeField] private int maxCubesInStack = 3;
        [SerializeField] private float zStart;
        [SerializeField] private float zFinish;

        void Start()
        {
            for (int i = 0; i < stacksAmount; i++)
            {
                GameObject stack = Instantiate(new GameObject());
                stack.AddComponent<CubeStack>();
            
                Vector3 stackPosition = new Vector3(Random.Range(-2, 2), 0f, Random.Range(zStart, zFinish));
                stack.transform.position = stackPosition;

                CubeStack cubeStack = stack.GetComponent<CubeStack>();
                cubeStack.CubesAmount = Random.Range(1, maxCubesInStack);
                cubeStack.SetCubes();
            }
        }
    }
}
