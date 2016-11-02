using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextScroll : MonoBehaviour {

	public Text content;

	// Use this for initialization
	void Start () {
		string txt = "a\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\na\nb\nc\nd\n";
		content.text = txt;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
