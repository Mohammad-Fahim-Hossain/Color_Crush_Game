using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	int widht=10;
	int height=10;

	int startX=260;
	int startY=350;

	int blockwidht=32;
	int blockheight=32;

	GameObject[,] grid;

	public GameObject Prefabs;
	public GameObject Canvas;

	public GameObject ScoreObject;


	int score=0;


	// Use this for initialization
	void Start () {
		grid = new GameObject[widht, height];

		int x = startX;
		int y = startY;

		for (int i = 0; i < height; i++) {
			for (int j = 0; j < widht; j++) {
				GameObject block = Instantiate (Prefabs);
				grid [i, j] = block;
				block.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (x, y);
				block.transform.SetParent (Canvas.transform);
				int random = Random.Range (0, 6);
				switch (random) {
				case 0:
					block.GetComponent<BlockController> ().SetType (BlockController.BlockType.Blue);
					break;
				case 1:
					block.GetComponent<BlockController> ().SetType (BlockController.BlockType.Green);
					break;
				case 2:
					block.GetComponent<BlockController> ().SetType (BlockController.BlockType.Purple);
					break;
				case 3:
					block.GetComponent<BlockController> ().SetType (BlockController.BlockType.Red);
					break;
				case 4:
					block.GetComponent<BlockController> ().SetType (BlockController.BlockType.Yellow);
					break;




				}
			
				x += blockwidht;
			}

			y -= blockheight;
			x = startX;
		}
		while (Crush () > 0) {
		}
	}
	public int Crush(bool check=false){
		int numberOfcrushes = 0;
		//move right to check 3 or more similar to crush them
		for(int i=0;i<height;i++){
			for (int j = 0; j < widht; j++) {
				int counter = 1;
				BlockController.BlockType type = grid [i, j].GetComponent<BlockController> ().Type;
				//count the number of block that have same color
				for(int k=j+1;k<widht;k++){
					if (grid [i, j] == null)
						break;

					BlockController.BlockType currentType = grid [i, k].GetComponent<BlockController> ().Type;

					if (currentType == type) 
						counter++;
						else
							break ;
					



				}
				if(counter>=3)
				{
					numberOfcrushes++;
					//if the check is true,this that we don't want crush,we only want to check if there is...
					if(check)
						continue ;
					//crush
					for(int k=j;k<j+counter;k++){
						Destroy(grid[i,k]);
						grid[i,k]=null;

					}
					//shift call down in the grid
					for(int t=j;t<j+counter;t++){
						for (int r = i; r > 0; r--) {
							grid [r, t] = grid [r - 1, t];
						}
								grid[0,t]=null;
					}
						//this.DebugGrid

						score+=counter;
					


				}
			
			}


		
	
	}
		//move vertically 
		for(int i=0;i<height;i++){
			for(int j=0;j<widht;j++){
				if(grid[i,j]!=null)
				{
					int counter=1;
					BlockController.BlockType Type=grid[i,j].GetComponent<BlockController>().Type;
					//count the number of block that have the same color
					for(int K=i+1;K<i+counter;K++){
						if(grid[K,j]==null)
							break ;
						BlockController.BlockType currentType=grid[K,j].GetComponent<BlockController>().Type;
						if(currentType==Type)
							counter++;
						else 
							break ;
					}
					if(counter>=3)
					{
						numberOfcrushes++;
						if(check)
							continue;
						//crush
						for(int k=i;k<i+counter;k++){
							Destroy(grid[k,j]);
							grid[k,j]=null;
						}
						//shift calls down in the grid 

						for(int r=i-1;r>=0;r--){
							grid[r+counter,j]=grid[r,j];
							grid[r,j]=null;
						}
						score+=counter;
						
					}
				}
			}
		}
		UpdateScore();
		return numberOfcrushes;

}
	void UpdateScore(){
		ScoreObject.GetComponent<Text> ().text = "Score: " + score;
	
	}



	
		// Update is called once per frame
	void Update () {
		
	}
}
