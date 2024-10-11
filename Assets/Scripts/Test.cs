#if UNITY_WEBGL && !UNITY_EDITOR
#define ENABLE_JSLIB
#endif

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public sealed class Test : MonoBehaviour
{
    private readonly Lazy<string> url = new (static () => Application.absoluteURL);

    [Conditional("ENABLE_JSLIB")]
    [DllImport("__Internal")]
    private static extern void ChangeURL(string url);

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(5);
        yield return wait;
        ChangeURL("/test");

        yield return wait;
        ChangeURL("");

        yield return wait;
        ChangeURL("/test2");

        yield return wait;
        ChangeURL(url.Value);
    }
}