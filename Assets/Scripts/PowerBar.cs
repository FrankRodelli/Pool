using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour {

    float powerLevel;
    public Slider powerBarSlider;

    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        //Gets multiplier variable from cueball 
        powerLevel = GameObject.Find("cueball").GetComponent<CueBall>().multiplier;

        changePower();

        if (Input.GetMouseButtonUp(0))
        {
            powerBarSlider.value = 0;
        }

	}

    void changePower()
    {
        powerBarSlider.value = powerLevel/4;
    }
}
