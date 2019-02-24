using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPDisplay : MonoBehaviour
{
    [SerializeField]
    public Slider hpSlider;
    public float max = 100;

    private void Start()
    {
        hpSlider.value = 1;
        display(max);
    }

    public void setmax(float max)
	{
		this.max = max;
		display(max);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void display(float current)
	{
        hpSlider.value = current;
	}
}
