using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GenerateButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI leftReward;
    [SerializeField] private TextMeshProUGUI rightReward;
    
    // Start is called before the first frame update
    void OnDisable()
    {
        if (GameManager.Level % 2 == 0)
        {
            leftReward.text = "1";
        }
        else
        {
            int num1 = Random_();
            leftReward.text = num1.ToString();
        }
        int num2 = Random_();
        rightReward.text = num2.ToString();
    }

    private int Random_()
    {
        int random = Random.Range(1, 100);
        switch (random)
        {
            case int z when (z > 0 && z <= 15):
                return 2;
            case int z when (z >= 16 && z <= 30):
                return 3;
            case int z when (z >= 31 && z <= 45):
                return 4;
            case int z when (z >= 46 && z <= 50):
                return 5;
            case int z when (z >= 51 && z <= 65):
                return 6;
            case int z when (z >= 66 && z <= 80):
                return 7;
            case int z when (z >= 81 && z <= 95):
                return 8;
            case int z when (z >= 96 && z <= 100):
                return 9;
        }
        return 0;
    }
}
