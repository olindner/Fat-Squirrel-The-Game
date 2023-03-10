using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Instructions : MonoBehaviour {

	public GameObject Instr0Box;
	public GameObject Instr0Text;
	private bool Instr0 = false;

	public GameObject Instr1Box;
	public GameObject Instr1Text;
	public GameObject Instr1Arrow;
	private bool Instr1 = false;

	public GameObject Instr2Box;
	public GameObject Instr2Text;
	public GameObject Instr2Arrow;
	private bool Instr2 = false;

	public GameObject Instr3Box;
	public GameObject Instr3Text;
	public GameObject Instr3Arrow;
	public GameObject Instr3Student;
	public GameObject Instr3Dog;
	private bool Instr3 = false;

	public GameObject Instr4Box;
	public GameObject Instr4Text;
	public GameObject Instr4Arrow;
	private bool Instr4 = false;

	public GameObject ArrowInstrText;
	public GameObject ShiftInstrText;
	public GameObject ControlInstrText;

	void Start ()
	{
		var objectsToInit = new List<GameObject> 
		{
			Instr1Box, Instr1Text, Instr1Arrow,
			Instr2Box, Instr2Text, Instr2Arrow,
			Instr3Box, Instr3Text, Instr3Arrow, Instr3Student, Instr3Dog,
			Instr4Box, Instr4Text, Instr4Arrow,
			ArrowInstrText, ShiftInstrText, ControlInstrText,
		};
		Init(objectsToInit);
		Time.timeScale = 0;
	}
	
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && Instr0 == false)
		{
			Helper.SetAllTF(new List<GameObject> {Instr0Box, Instr0Text}, false);
			Helper.SetAllTF(new List<GameObject> {Instr1Box, Instr1Text, Instr1Arrow}, true);
			Instr0 = false;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr1 == false)
		{
			Helper.SetAllTF(new List<GameObject> {Instr1Box, Instr1Text, Instr1Arrow}, false);
			Helper.SetAllTF(new List<GameObject> {Instr2Box, Instr2Text, Instr2Arrow}, true);
			Instr1 = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr2 == false)
		{
			Helper.SetAllTF(new List<GameObject> {Instr2Box, Instr2Text, Instr2Arrow}, false);
			Helper.SetAllTF(new List<GameObject> {Instr3Box, Instr3Text, Instr3Arrow, Instr3Student, Instr3Dog}, true);
			Instr2 = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr3 == false)
		{
			Helper.SetAllTF(new List<GameObject> {Instr3Box, Instr3Text, Instr3Arrow, Instr3Student, Instr3Dog}, false);
			Helper.SetAllTF(new List<GameObject> {Instr4Box, Instr4Text, Instr4Arrow}, true);
			Instr3 = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr4 == false)
		{
			Helper.SetAllTF(new List<GameObject> {Instr4Box, Instr4Text, Instr4Arrow}, false);
			Helper.SetAllTF(new List<GameObject> {ArrowInstrText, ShiftInstrText, ControlInstrText}, true);
			Instr4 = true;
			Time.timeScale = 1;
		}
	}

	void Init(List<GameObject> objs)
	{
		Instr0Box.SetActive(true);
		Instr0Text.SetActive(true);

		foreach (var obj in objs)
		{
			obj.SetActive(false);
		}
	}
}
