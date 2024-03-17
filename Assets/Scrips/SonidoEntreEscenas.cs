using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SonidoEntreEscenas : MonoBehaviour
{
    AudioSource _audioSource;

    public Slider sliderVeloDiana;
    public float sliderValueDiana;

    public static SonidoEntreEscenas instance;

    #region Generic Script
    public float MainMotionSpeed;
    private string mainMotionSpeed = "VeloDiana";
    #endregion
    public void Awake()
    {
        if (SonidoEntreEscenas.instance == null)
        {
            SonidoEntreEscenas.instance = this;
            LeerDatos();

            DontDestroyOnLoad(gameObject);
            _audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sliderVeloDiana.value = PlayerPrefs.GetFloat("VeloDiana", 2);
        MainMotionSpeed = sliderVeloDiana.value;
    }

    public static void Pausar()
    {
        instance._audioSource.Pause();
    }
    public static void Despausar()
    {
        instance._audioSource.UnPause();
    }
    private void GuardarDatos()
    {
        PlayerPrefs.SetFloat(mainMotionSpeed, MainMotionSpeed);
    }

    private void LeerDatos()
    {
        MainMotionSpeed = PlayerPrefs.GetFloat(mainMotionSpeed, MainMotionSpeed);
    }

    public  void SliderFuncion( float otrovalor)
    {
        Debug.Log(MainMotionSpeed);
        sliderValueDiana = otrovalor;
        PlayerPrefs.SetFloat("VeloDiana", otrovalor);
        MainMotionSpeed = sliderVeloDiana.value;
        
    }




}
