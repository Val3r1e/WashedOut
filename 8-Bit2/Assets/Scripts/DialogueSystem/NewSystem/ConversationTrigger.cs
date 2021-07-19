using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationTrigger : MonoBehaviour
{
	public DialogueBase dialog;

	public void TriggerDialogue(){

        //Use to call dialogue!!
		ConversationManager.instance.EnqueueDialog(dialog);
	}

	private void Update(){
		
		/*if(Input.GetKeyDown(KeyCode.Space))
		{
			TriggerDialogue();
		}*/
	}
}
