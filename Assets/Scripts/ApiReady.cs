using System;
using System.Collections;
using UnityEngine;
using YandexSDK.Scripts;

namespace Assets
{
    public class ApiReady : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine(CallApiReady());
        }

        private IEnumerator CallApiReady()
        {
            yield return new WaitForEndOfFrame();
            YandexGamesManager.ApiReady();
        }
    }
}