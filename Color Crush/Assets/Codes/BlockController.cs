using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockController : MonoBehaviour {
	public BlockType Type;
	public enum BlockType{
		Red,
		Green,
		Blue,
		Yellow,
		Purple
		}

	public Sprite[] sprites;

	public void SetType(BlockType t){
	   switch (t) {
		case BlockType.Red:
			this.GetComponent<Image> ().sprite = sprites [0];
			Type = BlockType.Red;
			break;
		case BlockType.Green:
			this.GetComponent<Image> ().sprite = sprites [1];
			Type = BlockType.Green;
			break;
		case BlockType.Blue:
			this.GetComponent<Image> ().sprite = sprites [2];
			Type = BlockType.Blue;
			break;
		case BlockType.Yellow:
			this.GetComponent<Image> ().sprite = sprites [3];
			Type = BlockType.Yellow;
			break;
		case BlockType.Purple:
			this.GetComponent<Image> ().sprite = sprites [4];
			break;
		}
	}





	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
