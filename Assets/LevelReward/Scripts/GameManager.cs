using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int Level = 0;
    [SerializeField] private Button levelUp;
    [SerializeField] private Button getReward;
    [SerializeField] private Button get;
    [SerializeField] private Button leftReward;
    [SerializeField] private Button rightReward;

    [SerializeField] private GameObject canvasGetReward;
    [SerializeField] private GameObject canvasReward;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private TextMeshProUGUI leftRewardText;
    [SerializeField] private TextMeshProUGUI rightRewardText;
    
    private void Start()
    {
        levelUp.GetComponent<Button>().onClick.AddListener(LevelUp);
        getReward.GetComponent<Button>().onClick.AddListener(GetReward);
        get.GetComponent<Button>().onClick.AddListener(Get);
        leftReward.GetComponent<Button>().onClick.AddListener(LeftReward);
        rightReward.GetComponent<Button>().onClick.AddListener(RightReward);
    }
    
    private void LevelUp()
    {
        canvasGetReward.SetActive(true);
        levelUp.interactable = false;
        Level++;
        levelText.text = "Level: " + Level;
    }

    private void GetReward()
    {
        canvasGetReward.SetActive(false);
        canvasReward.SetActive(true);
        get.interactable = false;
        SetColor(leftReward, Color.white);
        SetColor(rightReward, Color.white);
    }

    private void Get()
    {
        string num;
        canvasReward.SetActive(false);
        levelUp.interactable = true;
        if (!leftReward.interactable)
            num = leftRewardText.text;
        else
            num = rightRewardText.text;
        GameObject _text = GameObject.Find("x" + num);
        string[] counts = _text.GetComponent<TextMeshProUGUI>().text.Split(' ');
        int count = int.Parse(counts[1]);
        count++;
        _text.GetComponent<TextMeshProUGUI>().text = "x " + count;
        
        leftReward.interactable = true;
        rightReward.interactable = true;
    }
    
    private void LeftReward()
    {
        SetColor(leftReward, Color.green);
        SetColor(rightReward, Color.white);
        leftReward.interactable = false;
        rightReward.interactable = true;
        get.interactable = true;
    }
    
    private void RightReward()
    {
        SetColor(leftReward, Color.white);
        SetColor(rightReward, Color.green);
        leftReward.interactable = true;
        rightReward.interactable = false;
        get.interactable = true;
    }

    private void SetColor(Button button, Color color)
    {
        button.GetComponent<Graphic>().color = color;
    }
}
