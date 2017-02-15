using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Instructions : MonoBehaviour {

	public Image Instr0Box;
	public Text Instr0Text;
	private bool Instr0 = false;

	public Image Instr1Box;
	public Text Instr1Text;
	public Image Instr1Arrow;
	private bool Instr1 = false;

	public Image Instr2Box;
	public Text Instr2Text;
	public Image Instr2Arrow;
	private bool Instr2 = false;

	public Image Instr3Box;
	public Text Instr3Text;
	public Image Instr3Arrow;
	public Image Instr3Student;
	public Image Instr3Dog;
	private bool Instr3 = false;

	public Image Instr4Box;
	public Text Instr4Text;
	public Image Instr4Arrow;
	private bool Instr4 = false;

	public Text ArrowInstrText;
	public Text ShiftInstrText;
	public Text ControlInstrText;

	// Use this for initialization
	void Start () {
		Time.timeScale = 0;
		Instr0Box.enabled = Instr0Text.enabled = true;
		Instr1Box.enabled = Instr1Text.enabled = Instr1Arrow.enabled = Instr2Box.enabled = Instr2Text.enabled = Instr2Arrow.enabled =
			Instr3Box.enabled = Instr3Text.enabled = Instr3Arrow.enabled = Instr3Student.enabled = Instr3Dog.enabled = 
				Instr4Box.enabled = Instr4Text.enabled = Instr4Arrow.enabled = ArrowInstrText.enabled = ShiftInstrText.enabled = ControlInstrText.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && Instr0 == false) {
			Instr0Box.enabled = Instr0Text.enabled = false;
			Instr0 = true;
			Instr1Box.enabled = Instr1Text.enabled = Instr1Arrow.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr1 == false) {
			Instr1Box.enabled = Instr1Text.enabled = Instr1Arrow.enabled = false;
			Instr1 = true;
			Instr2Box.enabled = Instr2Text.enabled = Instr2Arrow.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr2 == false) {
			Instr2Box.enabled = Instr2Text.enabled = Instr2Arrow.enabled = false;
			Instr2 = true;
			Instr3Box.enabled = Instr3Text.enabled = Instr3Arrow.enabled = Instr3Student.enabled = Instr3Dog.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr3 == false) {
			Instr3Box.enabled = Instr3Text.enabled = Instr3Arrow.enabled = Instr3Student.enabled = Instr3Dog.enabled = false;
			Instr3 = true;
			Instr4Box.enabled = Instr4Text.enabled = Instr4Arrow.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Space) && Instr4 == false) {
			Instr4Box.enabled = Instr4Text.enabled = Instr4Arrow.enabled = false;
			Instr4 = true;
			ArrowInstrText.enabled = ShiftInstrText.enabled = ControlInstrText.enabled = true;
			Time.timeScale = 1;
		}
	}
}
