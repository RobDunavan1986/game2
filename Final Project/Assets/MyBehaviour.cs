//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using System.Collections;
//using.UnityEnigine.Networking;
//using UnityEngine.Networking;
//using System;

//public class MyBehaviour : MonoBehaviour
//{
//    // Start is called before the first frame update
//    void Start()
//    {
//        StartCoroutine(GetText());
//    }

   

//    IEnumerable GetText()
//    {
//        UnityWebRequest www = UnityWebRequest.Get("https://cis-dunavan-web.azurewebsites.net");
//        yield return www.SendWebRequest();

//        if(www.isNetworkError || www.isHttpError)
//        {
//            Debug.Log(www.error);
//        }
//        else
//        {
//            Debug.Log(www.downloadHandler.text);
//            byte[] results = www.downloadHandler.data;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
        
//    }
//}
