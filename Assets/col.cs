using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class col : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("THIS IS HAPPENEING");
        StartCoroutine(GetText());
        if (col.gameObject.name == "Sphere")
        {
            Destroy(col.gameObject);
        }
    }

    IEnumerator GetText()
    {
        var apiKey = "sandbox_MWQxNjkxYTktNzI3Yy00OGU3LTg2OGQtZjYxYTQyMTI5NjM5LnozQTJqYWFxbG1CQ25CT1IxNXhlVDZzaVNTS0IwRHBk";

        UnityWebRequest www = UnityWebRequest.Get("https://sandbox.root.co.za/v1");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}