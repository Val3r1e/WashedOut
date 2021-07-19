using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class DialogueBase : ScriptableObject {

	[System.Serializable]
	public class Info 
    {
        //public GameObject speaker;

	    public string name;

	    [TextArea(4, 8)]
	    public string text;

	    [TextArea(4, 8)]
	    public string noNameText;

	}

	[Header ("Insert Dialog Info below")]

	public Info[] dialogInfo;

}