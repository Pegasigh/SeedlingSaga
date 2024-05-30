using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;
using TMPro;

enum Seasons
{
    spring,
    summer,
    autumn,
    winter
}

public class S_CalendarSystem : MonoBehaviour
{
    private Seasons season = Seasons.spring;
    private int day = 1;
    private int year = 1;
    //TODO: add time

    public Sprite springImage;
    public Sprite summerImage;
    public Sprite autumnImage;
    public Sprite winterImage;
    public Image seasonImage;
    public TextMeshProUGUI dayText;

    private void Start()
    {
        UpdateGUI();
    }

    public void NextDay()
    {
        //TODO: search through scene hierarchy for every object containing scripts that implement the I_OnNextDay interface and call OnNextDay() on each of them
        foreach (I_OnNextDay component in FindObjectsOfType<MonoBehaviour>().OfType<I_OnNextDay>().ToArray())
        {
            component.OnNextDay();
        }

        day++;
        if(day > 28)
        {
            day = 1;
            if (season == Seasons.winter) year++;
            season = (Seasons)(((int)season + 1) % System.Enum.GetValues(typeof(Seasons)).Length); //cycles to next season (loops)

            Debug.Log(day);
            Debug.Log(season);
        }
        UpdateGUI();
    }

    private void UpdateGUI()
    {
        dayText.text = day.ToString();
        if (season == Seasons.spring) seasonImage.sprite = springImage;
        if (season == Seasons.summer) seasonImage.sprite = summerImage;
        if (season == Seasons.autumn) seasonImage.sprite = autumnImage;
        if (season == Seasons.winter) seasonImage.sprite = winterImage;
    }
}
