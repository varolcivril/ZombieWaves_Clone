using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minmax : MonoBehaviour
{
    int[] intArray = { 22, 3, 4, 5, 16, 7, 38, 9, 10 , 1};

    private void Start()
    {

        (int max, int min) result = FindMinMax(intArray);

        Debug.Log($"Max: {result.max}, min: {result.min}");

    }

    public (int max, int min) FindMinMax(int[] array)
    {
        int min = array[0];
        int max = array[array.Length - 1];

        foreach(int item in array)
        {
            if (item < min)
                min = item;

            if (item > max)
                max = item;
        }

        return (max, min);
    }
}
