using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "Best Score: " +(MemoryManager.Instance.highScorePlayerName) + ": "+(MemoryManager.Instance.highScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
