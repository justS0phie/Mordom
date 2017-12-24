using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;

public class Save_Data : MonoBehaviour {

	private PhaseControl control;

	// Use this for initialization
	void Start () {
		control = gameObject.GetComponent<PhaseControl> ();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void save(){
		if (control.phase != GamePhase.Game)
			return;
		string path = Application.persistentDataPath + "/Save.dat";
		if (!System.IO.File.Exists(path))
		{
			System.IO.FileStream file = null;
			file = new System.IO.FileStream(path, System.IO.FileMode.Create);
			file.Close();
		}
		using (StreamWriter outfile = new StreamWriter(path))
		{
			outfile.WriteLine ("Save_Data");
		}
	}
}
