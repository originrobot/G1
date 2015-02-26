using UnityEngine;
using System.Collections;

/**
 * Place the building on the map.
 */ 
public class PlaceBuildingButton : MonoBehaviour {

	public void OnClick() {

		if (BuildingManager.ActiveBuilding.State == BuildingState.MOVING) {
			// Moving
			if (BuildingModeGrid.GetInstance ().CanObjectBePlacedAtPosition (BuildingManager.ActiveBuilding, BuildingManager.ActiveBuilding.MovePosition)) {
				if (BuildingManager.GetInstance().MoveBuilding()) {
					UIGamePanel.ShowPanel(PanelType.DEFAULT);
				}
			}
		} else {
			// Placing
			if (BuildingModeGrid.GetInstance ().CanObjectBePlacedAtPosition (BuildingManager.ActiveBuilding, BuildingManager.ActiveBuilding.Position)) {
				if (BuildingManager.GetInstance().PlaceBuilding()) {
					UIGamePanel.ShowPanel(PanelType.DEFAULT);
				}
			}
		}
	}
}
