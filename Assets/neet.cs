using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class neet : MonoBehaviour
{

    public int[] integerArray = {1,2,3,5,6,8,11,13};

    public int target = 9;

   
    private void Start()
    {
        int value1, value2;

        bool found = TwoSum(integerArray, target, out value1,out value2);
        if (found)
        {
            Debug.Log($"Returned value1 : {value1}, value2: {value2}");
        } else
        {
            Debug.Log($"No pair found");
        }
    }

    public bool TwoSum(int[] array, int target, out int value1, out int value2)
    {
        if(array == null || array.Length == 0)
        {
            value1 = 0;
            value2 = 0;
            return false;
        }
        int leftIndex = 0;
        int rightIndex = array.Length - 1;

        while (leftIndex < rightIndex)
        {
            Debug.Log($"Leftindex {leftIndex}, rightIndex {rightIndex}");
            int currentSum = array[leftIndex] + array[rightIndex];

            if (currentSum == target)
            {
                value1 = array[leftIndex];
                value2 = array[rightIndex];

                return true;
            }
            else if (currentSum < target)
            {
                leftIndex++;
            }
            else
            {
                rightIndex--;
            }
        }
            value1 = 0;
            value2 = 0;

            return false;

    }

}


