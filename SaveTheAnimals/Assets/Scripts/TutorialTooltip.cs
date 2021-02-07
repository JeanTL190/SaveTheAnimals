using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TutorialTooltip : MonoBehaviour
{

    [TextArea]
    [SerializeField]
    string tutorialText;

    private TextMeshProUGUI tooltipText;

    private void Awake ()
    {
        tooltipText = GameObject.Find("TutorialTooltip").GetComponent<TextMeshProUGUI>();
        tooltipText.text = "";
    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tooltipText.text = tutorialText;
        }
    }

    private void OnTriggerExit2D (Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            tooltipText.text = "";
            Destroy(this.gameObject);
        }
    }

}
