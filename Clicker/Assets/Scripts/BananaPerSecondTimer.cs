using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPerSecondTimer : MonoBehaviour
{
    public float TimerDuration = 1f;

    public double BananasPerSecond { get; set; }

    private float _counter;

    private void Update()
    {
        _counter += Time.deltaTime;

        if (_counter >= TimerDuration)
        {
            GameManager.instance.SimpleBananaIncrease(BananasPerSecond);

            _counter = 0;
        }
    }
}
