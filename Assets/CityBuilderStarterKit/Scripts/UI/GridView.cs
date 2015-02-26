using UnityEngine;
using System.Collections;

public class GridView : MonoBehaviour {

	public string gridSpriteName;
	public UIAtlas gridAtlas;
	public Color buildingModeAvailable;
	public Color buildingModeUnavailable;
	public Color pathModeAvailable;
	public Color pathModeUnavailable;
	public Color normal = new Color (0,0,0,0);

	protected UISprite[,] sprites;

	protected bool init;

	void Awake()

	{
		Instance= this;
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(GenerateGridView());
	}
	
	/// <summary>
	/// Generates the grid sprites.
	/// </summary>
	/// <returns>The grid view.</returns>
	virtual protected IEnumerator GenerateGridView () {
		yield return true;
		int size = BuildingModeGrid.GetInstance().gridSize;
		sprites = new UISprite[size,size];
		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				IGridObject gridObject = BuildingModeGrid.GetInstance().GetObjectAtPosition(new GridPosition(x, y));
				if (!(gridObject is UnusableGrid))
				{
					CreateSprite(x, y);
				}
			}
		}

	}

	virtual protected void CreateSprite(int x, int y)
	{
		GameObject go = new GameObject();
		go.transform.parent = transform;
		go.layer = gameObject.layer;
		UISprite sprite = go.AddComponent<UISprite>();
		sprites[x, y] = sprite;
		sprite.atlas = gridAtlas;
		sprite.spriteName = gridSpriteName;
		Vector3 position = BuildingModeGrid.GetInstance().GridPositionToWorldPosition(new GridPosition(x,y));
		position.z = 0;
		go.transform.localPosition = position;
		sprite.depth = 5;
		sprite.MakePixelPerfect();
		sprite.color = normal;
	}

	public void NormalMode()
	{
		int size = BuildingModeGrid.GetInstance().gridSize;
		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				if (sprites[x,y] != null)
				{
					sprites[x,y].color = normal;
				}
			}
		}
	}

	public void BuildingMode()
	{
		int size = BuildingModeGrid.GetInstance().gridSize;
		
		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				if (sprites[x,y] != null)
				{
					if ( BuildingModeGrid.GetInstance().CanObjectBePlacedAtPosition(GridPosition.DefaultShape, new GridPosition(x,y)))
					    sprites[x,y].color = buildingModeAvailable;
					else
					    sprites[x,y].color = buildingModeUnavailable;
				}
			}
		}
	}

	public void PathMode()
	{
		int size = BuildingModeGrid.GetInstance().gridSize;
		
		for (int x = 0; x < size; x++) {
			for (int y = 0; y < size; y++) {
				if (sprites[x,y] != null)
				{
					if ( BuildingModeGrid.GetInstance().CanObjectBePlacedAtPosition(GridPosition.DefaultShape, new GridPosition(x,y)))
						sprites[x,y].color = pathModeAvailable;
					else
						sprites[x,y].color = pathModeUnavailable;
				}
			}
		}
	}

	public static GridView Instance
	{
		get; protected set;
	}
}
