using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;

public sealed class Test : MonoBehaviour
{
    private readonly Lazy<string> url = new (static () => Application.absoluteURL);

    [DllImport("__Internal")]
    private static extern void ChangeURL(string url);

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(5);
        yield return wait;
        ChangeURL("/test");

        yield return wait;
        ChangeURL("/test2");

        yield return wait;
        ChangeURL(url.Value);
    }
}