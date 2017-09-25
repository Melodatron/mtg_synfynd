using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardNameButton : MonoBehaviour
{
    public InputField input_field;
    public DeckbrewRequester requester;
    // public Text output_field;
    public CardDisplay cardDisplay;

    public DeckbrewCardObject lastCardObject;

    public void HandleRequest()
    {
        string cardID = input_field.text;

        requester.RequestCardByID(OnRequestComplete, cardID);
    }

    private void OnRequestComplete(bool was_success, DeckbrewCardObject cardObject)
    {
        cardDisplay.cardName.text = cardObject.name;

        StartCoroutine(LoadRemoteAssets(cardObject));
    }

    private IEnumerator LoadRemoteAssets(DeckbrewCardObject cardObject)
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        WWW www = new WWW(cardObject.editions[0].image_url);
        yield return www;

        www.LoadImageIntoTexture(tex);

        Sprite cardSprite = Sprite.Create(tex,
                                          new Rect(0f, 0f, tex.width, tex.height),
                                          new Vector2(0.5f, 0.5f),
                                          100f);
        cardDisplay.cardImage.sprite = cardSprite;
    }

    private void Start()
    {
        input_field.text = "abzan-ascendancy";
    }
}