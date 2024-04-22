using System.Collections.Generic;
using UnityEngine;

public class PlayerPositionManager : MonoBehaviour
{

 public List<Transform> PlayerPositions = new List<Transform>();
 public GameObject Player;

 private void Start()
 {
  SetPlayerPosition();
 }

 void SetPlayerPosition()
 {
  var planetSelectedNum = PlayerPrefsManager.Instance.SelectPlanetNum;

  switch (planetSelectedNum)
  {
   case 3:
    AssignTransform(PlayerPositions[0]);
    break;
   case 8:
    AssignTransform(PlayerPositions[1]); 
    break;
   case 9:
    AssignTransform(PlayerPositions[2]);
    break;
  }
 }

 void AssignTransform(Transform t)
 {
  if (Player)
  {
   Player.transform.position = t.position;
  }
 }
}
