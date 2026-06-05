using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
[SerializeField] private Transform SpielerCheck;
[SerializeField] private float zoffset = 0f;
[SerializeField] private float yoffset = 0f;
[SerializeField] private float xoffset = 0f;

private float maxZdistanz = 200f;
private float mindZdistanz = 0f;



    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(zoffset) > maxZdistanz || Mathf.Abs(zoffset) < mindZdistanz )
        {
            Debug.LogError("ZOffset ist ausserhalb des Limits");

            zoffset = Mathf.Clamp(zoffset, mindZdistanz, maxZdistanz);
        }
         transform.position = new Vector3 (
            SpielerCheck.position.x + xoffset, 
            SpielerCheck.position.y + yoffset, 
            SpielerCheck.position.z +zoffset) ;   
       
    
}
}
