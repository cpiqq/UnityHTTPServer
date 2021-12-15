using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class TestClient : MonoBehaviour
{
    public RawImage rawImage;
    private const string uri = "http://localhost:7888/";
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);

        StartCoroutine(RequestMethod("SimpleMethod"));
        StartCoroutine(RequestMethod("SimpleStringMethod"));
        StartCoroutine(RequestMethod("SimpleIntMethod"));
        StartCoroutine(RequestMethod("CustomObjectReturnMethod"));
        StartCoroutine(RequestMethod("CustomObjectReturnMethodWithQuery?code=1111&msg=wow_it_is_so_cool"));

        StartCoroutine(RequestTexture("logo.png"));

    }

    IEnumerator RequestMethod(string methodName)
    {
        UnityWebRequest webRequest = UnityWebRequest.Get(uri + methodName);
        yield return webRequest.SendWebRequest();
        if (webRequest.result == UnityWebRequest.Result.Success)
        {
            Debug.Log(methodName + "的返回值： " + webRequest.downloadHandler.text);
        }
        else
        {
            Debug.Log(methodName + "调用错误： " + webRequest.error);
        }
    }

    IEnumerator RequestTexture(string imagePath)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(uri + imagePath))
        {
            yield return uwr.SendWebRequest();

            if (uwr.result == UnityWebRequest.Result.Success)
            {
                var texture = DownloadHandlerTexture.GetContent(uwr);
                rawImage.texture = texture;
            }
            else
            {
                Debug.Log(uwr.error);
            }
        }
    }


}
