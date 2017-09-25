using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


[System.Serializable]
public class DeckbrewCardObject
{
    public string name;
    public string id;
    public string url;
    public string[] types;
    public string[] colors;
    public uint cmc;
    public string cost;
    public string text;

    // public struct Format
    // {
    //   "commander": "legal",
    //   "legacy": "legal",
    //   "modern": "legal",
    //   "vintage": "legal"
    // }

    [System.Serializable]
    public class Edition
    {
        public string set;
        public string set_id;
        public string rarity;
        public string artist;
        public uint multiverse_id;
        public string number;
        public string layout;
        public string url;
        public string image_url;
    }
    public Edition[] editions;

      // {
      //   "set": "Prerelease Events",
      //   "set_id": "pPRE",
      //   "rarity": "special",
      //   "artist": "Mark Winters",
      //   "multiverse_id": 0,
      //   "number": "88",
      //   "layout": "normal",
      //   "price": {
      //     "low": 0,
      //     "median": 0,
      //     "high": 0
      //   },
      //   "url": "https://api.deckbrew.com/mtg/cards?multiverseid=0",
      //   "image_url": "https://image.deckbrew.com/mtg/multiverseid/0.jpg",
      //   "set_url": "https://api.deckbrew.com/mtg/sets/pPRE",
      //   "store_url": "http://store.tcgplayer.com/magic/prerelease-events/abzan-ascendancy?partner=DECKBREW",
      //   "html_url": "https://deckbrew.com/mtg/cards/0"
      // },
}


public class DeckbrewRequester : MonoBehaviour
{
    public delegate void CallBack(bool was_success, DeckbrewCardObject card_object);
    // public delegate void CallBack(bool was_success, string response);

    public void RequestCardByID(CallBack callback, string card_id)
    {
        Debug.Assert(callback != null, "CallBack cannot be null");
        StartCoroutine(RequestCardObject(callback, card_id));
    }

    private IEnumerator RequestCardObject(CallBack callback, string card_id)
    {
        UnityWebRequest www = UnityWebRequest.Get("https://api.deckbrew.com/mtg/cards/" + card_id);
        yield return www.Send();
 
        string response = "";
        bool was_success = false;

        // if(www.isNetworkError) {
        //     response = www.error;
        // }
        // else

        Debug.Assert(!www.isNetworkError, "Error attempting to request card from Deckbrew");
        {
            // Show results as text
            response = www.downloadHandler.text;
 
            // Or retrieve results as binary data
            // byte[] results = www.downloadHandler.data;
        }

        DeckbrewCardObject cardObject = JsonUtility.FromJson<DeckbrewCardObject>(response);
        callback(was_success, cardObject);
    }
}


/**
[
  {
    "name": "Abzan Ascendancy",
    "id": "abzan-ascendancy",
    "url": "https://api.deckbrew.com/mtg/cards/abzan-ascendancy",
    "store_url": "http://store.tcgplayer.com/magic/product/show?partner=DECKBREW\u0026ProductName=abzan-ascendancy",
    "types": [
      "enchantment"
    ],
    "colors": [
      "black",
      "green",
      "white"
    ],
    "cmc": 3,
    "cost": "{W}{B}{G}",
    "text": "When Abzan Ascendancy enters the battlefield, put a +1/+1 counter on each creature you control.\nWhenever a nontoken creature you control dies, create a 1/1 white Spirit creature token with flying.",
    "formats": {
      "commander": "legal",
      "legacy": "legal",
      "modern": "legal",
      "vintage": "legal"
    },
    "editions": [
      {
        "set": "Khans of Tarkir",
        "set_id": "KTK",
        "watermark": "Abzan",
        "rarity": "rare",
        "artist": "Mark Winters",
        "multiverse_id": 386464,
        "number": "160",
        "layout": "normal",
        "price": {
          "low": 0,
          "median": 0,
          "high": 0
        },
        "url": "https://api.deckbrew.com/mtg/cards?multiverseid=386464",
        "image_url": "https://image.deckbrew.com/mtg/multiverseid/386464.jpg",
        "set_url": "https://api.deckbrew.com/mtg/sets/KTK",
        "store_url": "http://store.tcgplayer.com/magic/khans-of-tarkir/abzan-ascendancy?partner=DECKBREW",
        "html_url": "https://deckbrew.com/mtg/cards/386464"
      }
    ]
  }
]
**/