using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tech : MonoBehaviour
{

    public GameObject cube;

    Transform mousePos;

    Ray ray;

    

    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
            }
        }
            
    }
}
