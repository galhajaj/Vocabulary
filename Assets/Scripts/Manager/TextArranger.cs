using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextArranger : MonoBehaviour 
{
    public Canvas WordsCanvas;
    public Button WordButton;
    public string Text;

	// Use this for initialization
	void Start () 
    {
        addWordsButtons();
        // BUG of unity... the buttons not arranged properly until the disabled/enabled thingy
        // and the Invoke is used because if it happens immediately it doesn't work
        Invoke("refreshLayout", 0.1f);
    }
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    private void addWordsButtons()
    {
        var words = Text.Split(' ');
        foreach (string word in words)
        {
            Button button = Instantiate(WordButton) as Button;
            button.transform.FindChild("Text").GetComponent<Text>().text = word;
            button.transform.SetParent(WordsCanvas.transform, false);
            //button.GetComponent<RectTransform>().SetAsFirstSibling();
            //WordsCanvas.GetComponent<RectTransform>().SetAsFirstSibling();
        }
    }

    private void refreshLayout()
    {
        FlowLayoutGroup layout = WordsCanvas.GetComponent<FlowLayoutGroup>();
        layout.enabled = false; 
        layout.enabled = true;
    }
}
