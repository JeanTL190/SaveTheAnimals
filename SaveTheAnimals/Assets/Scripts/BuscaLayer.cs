using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuscaLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray rayH = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfoModel;

        if(Physics.Raycast(rayH, out hitInfoModel))
        {
            Debug.Log(hitInfoModel);
        }
    }
}
