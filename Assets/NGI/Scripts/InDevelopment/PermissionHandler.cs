using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class PermissionHandler : MonoBehaviour
{



    void Start()
    {
        StartCoroutine(WaitForPermission());


    }

    private IEnumerator WaitForPermission()
    {
<<<<<<< HEAD

#if PLATFORM_ANDROID || UNITY_IOS
=======
        //TODO: Change while loop to a list of permissions, ask the user about each specific permission and remember users choice.
>>>>>>> soeroesg
        while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation) || !Permission.HasUserAuthorizedPermission(Permission.Camera))
        {

            if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
            {
                //Simple sulution to stop coruitne from executinng many permission requests.
                if (Application.isFocused)
                {
                    Permission.RequestUserPermission(Permission.FineLocation);
                }
            }
            else if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
            {
                if (Application.isFocused)
                {
                    Permission.RequestUserPermission(Permission.Camera);
                }

            }

            yield return null;

        }
#endif

        SceneManager.LoadSceneAsync("AugCityToNGI_Dev_Interaction");

    }


    private void PermissionCallbacks_PermissionDeniedAndDontAskAgain(string obj)
    {
        throw new NotImplementedException();
    }

    private void PermissionCallbacks_PermissionGranted(string obj)
    {
        Debug.Log("Permission was granted: " + obj);
        // throw new NotImplementedException();
    }

    private void PermissionCallbacks_PermissionDenied(string obj)
    {
        throw new NotImplementedException();
    }

}
