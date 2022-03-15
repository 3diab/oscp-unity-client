using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ACityAPIDev;

public class CreateObject : MonoBehaviour
{

    public static event Action<GeoPose> UpdateGeoPose;


    //Get GeoPose updates

    public GeoPose latestGeoPose;

    public GameObject currentSelectedObj;


    [SerializeField] Canvas canvasObjects;



    //Start browser window for selecting models
    public void OpenObjectList(bool isOpen)
    {
        canvasObjects.enabled = isOpen;
    }



   
    
    //Return selected object url

    //Create object at geopose position

    //Send new object to orbit server and save




}

