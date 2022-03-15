using Newtonsoft.Json;
using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class SSDManager : MonoBehaviour
{
    [SerializeField] string ssdServerURL = "https://ssd.orbit-lab.org/";

    [SerializeField] string h3Index = "ssrs?h3Index=882a13d23bfffff";
    [SerializeField] string countryCode = "us";

    [SerializeField] GameObject listItemPrefab;

    [SerializeField] RectTransform rectTransformSpawn;

    public static event Action<string> ServerResponseGet;

    private void OnEnable()
    {
        ServerResponseGet += HandleResponse;
    }

    private void OnDisable()
    {
        ServerResponseGet -= HandleResponse;
    }

    private void HandleResponse(string response)
    {
        CreateListItems(JSON.Parse(response));
    }

    public void GetServicesInH3()
    {
        GetSpatialContentRecords(h3Index);

    }

    public void CreateListItems(JSONNode response)
    {
        List<JSONNode> listJSONNode = new List<JSONNode>();

        int length = response[0]["services"].Count;

        for (int i = 0; i < length; i++)
        {

            if (string.Equals(response[0]["services"][i]["type"], "geopose"))
            {
                listJSONNode.Add(response[0][i]);

                Debug.Log(response[0]["services"][i]);
            }

        }

        if (listJSONNode.Count > 0)
        {

            Instantiate(listItemPrefab, rectTransformSpawn);

        }



    }


    async void GetSpatialContentRecords(string h3Index)
    {

        //output("Making Call to read SSD services...");

        //sends the request
        HttpWebRequest apiInforequest = (HttpWebRequest)WebRequest.Create(ssdServerURL + countryCode + "/ssrs?h3Index=" + h3Index);
        apiInforequest.Method = "GET";
        // apiInforequest.Headers.Add(string.Format("Authorization: Bearer " + accessToken));
        apiInforequest.ContentType = "application/x-www-form-urlencoded";

        // gets the response
        WebResponse apiResponse = await apiInforequest.GetResponseAsync();
        using (StreamReader apiInforResponseReader = new StreamReader(apiResponse.GetResponseStream()))
        {
            // reads response body
            string apiInfoResponseText = await apiInforResponseReader.ReadToEndAsync();
            Debug.Log("Response from scd-orbit read: " + apiInfoResponseText);

            ServerResponseGet?.Invoke(apiInfoResponseText);
        }
    }
}
