using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Weather : MonoBehaviour
{
    public float enableTime;

    abstract public void MakeWeather();
    abstract public void Function();
}
