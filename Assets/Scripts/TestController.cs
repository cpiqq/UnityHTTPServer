using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour
{
    // Url: http://127.0.0.1:{port}/SimpleMethod
    // change {port} to the port set on your UnityHttpController component
    public void SimpleMethod()
    {
        Debug.Log("Cool, fire via http connect");
    }
    // Url: http://127.0.0.1:{port}/SimpleStringMethod
    // change {port} to the port set on your UnityHttpController component
    public string[] SimpleStringMethod()
    {
        return new string[]{
            "result","result2"
        };
    }
    // Url: http://127.0.0.1:{port}/SimpleIntMethod
    // change {port} to the port set on your UnityHttpController component
    public int[] SimpleIntMethod()
    {
        return new int[]{
            1,2
        };
    }
    // Url: http://127.0.0.1:{port}/CustomObjectReturnMethod
    // change {port} to the port set on your UnityHttpController component
    public ReturnResult CustomObjectReturnMethod()
    {
        ReturnResult result = new ReturnResult
        {
            code = 1,
            msg = "testing"
        };
        return result;
    }
    // Url: http://127.0.0.1:{port}/CustomObjectReturnMethodWithQuery?code=1111&msg=wow_it_is_so_cool
    // change {port} to the port set on your UnityHttpController component
    public ReturnResult CustomObjectReturnMethodWithQuery(int code, string msg)
    {
        ReturnResult result = new ReturnResult
        {
            code = code,
            msg = msg
        };
        return result;
    }

    //Mark as Serializable to make Unity's JsonUtility works.
    [System.Serializable]
    public class ReturnResult
    {
        public string msg;
        public int code;
    }

}
