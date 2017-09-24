using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeckbrewRequester : MonoBehaviour
{
    public delegate void CallBack(bool was_success, string response);

    public void DoRequest(CallBack callback, string card_name)
    {
        Debug.Assert(callback != null, "CallBack cannot be null");
        StartCoroutine(GetResponse(callback, card_name));
    }

    private IEnumerator GetResponse(CallBack callback, string card_name)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.deckbrew.com/mtg/cards?name=" + card_name);
        yield return www.Send();
 
        string response = "";
        bool was_success = false;

        if(www.isNetworkError) {
            response = www.error;
        }
        else {
            // Show results as text
            response = www.downloadHandler.text;
 
            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }

        callback(was_success, response);
    }
}
