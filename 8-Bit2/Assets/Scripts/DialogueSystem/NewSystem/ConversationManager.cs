using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;

public class ConversationManager : MonoBehaviour
{

	public static ConversationManager instance;

    public GameObject dialogueCanvas;
    //public GameObject conversationBox;

    public Animator animator;
    public TextMeshProUGUI dialogName;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI dialogNoNameText;
    //public Image dialogPortrait;

    //Define text delay
    public float delay;

    //Get text from dialog
    public Queue<DialogueBase.Info> dialogInfo;

    public bool done;

    private bool isCurrentlyTyping;
    private string completeText;
    //private string completeNoNameText;

	public StudioEventEmitter text;

	//GetComponent<FMODUnity.StudioEventEmitter>().Play();
	//GetComponent<FMODUnity.StudioEventEmitter>().Stop();

	private void Awake()
    {
		if(instance != null)
        {
			Debug.LogWarning("Fix this!" + gameObject.name);
		} 
        else 
        {
			instance = this;
		}

		text.Stop();
	}

	public void Start()
    {
		done = false;

		dialogInfo = new Queue<DialogueBase.Info>();

        dialogueCanvas.SetActive(false);
    }

	public void Update()
	{
		if(dialogueCanvas.activeSelf)
		{
			//Freeze player
        	GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = true;
		}
	}

	//Open up dialog
	public void EnqueueDialog(DialogueBase db)
    {
        //Turn on dialogue canvas
        dialogueCanvas.SetActive(true);

        //Move dialogue box into scene
        //animator.SetBool("isOpen", true);

        dialogInfo.Clear();

		foreach(DialogueBase.Info info in db.dialogInfo){
			dialogInfo.Enqueue(info);
		}

		DequeueDialog();
	}

	//Run dialog until the end
	public void DequeueDialog()
    {
		if(isCurrentlyTyping == true)
        {
			CompleteText();
			StopAllCoroutines();
			isCurrentlyTyping = false;
			return;
		}

		if(dialogInfo.Count == 0)
        {
			EndDialog();
			return;
		}

        DialogueBase.Info info = dialogInfo.Dequeue();

		completeText = info.text;
		//completeNoNameText = info.noNameText;

		dialogName.text = info.name;
		dialogText.text = info.text;
		dialogNoNameText.text = info.noNameText;
		//dialogPortrait.sprite = info.portrait;

		dialogText.text = "";
		StartCoroutine(TypeText(info));
	}

	//Each character appears
	IEnumerator TypeText(DialogueBase.Info info)
    {
		text.Play();

		isCurrentlyTyping = true;
		foreach(char c in info.text.ToCharArray())
		{
			yield return new WaitForSeconds(delay);
			dialogText.text += c;
			//dialogNoNameText.text += c;

		}
		isCurrentlyTyping = false;

		text.Stop();
	}

	private void CompleteText()
    {
		dialogText.text = completeText;
		//dialogNoNameText.text = completeNoNameText;
		text.Stop();
	}

	public void EndDialog()
    {
		text.Stop();
		
        dialogueCanvas.SetActive(false);

        done = true;

		//Unfreeze player
        GameObject.Find("Player").GetComponent<PlayerMovement>().isFrozen = false;
	}
}
