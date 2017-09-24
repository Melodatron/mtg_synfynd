using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNameButton : MonoBehaviour
{
    public InputField input_field;
    public DeckbrewRequester requester;
    public Text output_field;

    public void HandleRequest()
    {
        string search_string = input_field.text;

        requester.DoRequest(OnRequestComplete, search_string);
    }

    public void OnRequestComplete(bool was_success, string response)
    {
        output_field.text = response;
    }
}