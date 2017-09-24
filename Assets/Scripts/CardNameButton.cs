using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNameButton : MonoBehaviour
{
    public InputField input_field;
    public DeckbrewRequester requester;
    public Text output_field;

    public DeckbrewCardObject lastCardObject;

    public void HandleRequest()
    {
        string cardID = input_field.text;

        requester.RequestCardByID(OnRequestComplete, cardID);
    }

    public void OnRequestComplete(bool was_success, DeckbrewCardObject cardObject)
    {
        lastCardObject = cardObject;
    }

    private void Start()
    {
        input_field.text = "abzan-ascendancy";
    }
}