using System.Collections;
using System.Collections.Generic;
using UnityEngine;



	[CreateAssetMenu(fileName = "New Info", menuName = "InformationInventory/Information")]
	public class Information : ScriptableObject
	{

		new public string name = "New Info";    
		public Sprite icon = null;              

		public void RemoveFromInventory()
		{
			InformationInventory.instance.Remove(this);
		}




	}