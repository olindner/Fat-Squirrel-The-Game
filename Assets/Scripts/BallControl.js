#pragma strict

var rotationSpeed = 100;
var jumpHeight = 8;
var spinSpeed = 2;

private var isFalling = false;
private var isDead = false;

function OnCollisionEnter(collision: Collision)
{
	isFalling = false;
}

function Update ()
{

	if (isFalling == false)
	{
		//Movement controls
		var rotation : float = Input.GetAxis ("Horizontal") * rotationSpeed;
		var rotation2 : float = Input.GetAxis ("Vertical") * rotationSpeed;
		rotation *= Time.deltaTime;
		rotation2 *= Time.deltaTime;
		GetComponent.<Rigidbody>().AddForce (Vector3.right * rotation);
		GetComponent.<Rigidbody>().AddForce (Vector3.forward * rotation2);
	}
	if (isFalling == true)
	{
		var spin : float = Input.GetAxis ("Horizontal") * spinSpeed;
		var spin2 : float = Input.GetAxis ("Vertical") * spinSpeed;
		spin *= Time.deltaTime;
		spin2 *= Time.deltaTime;
		GetComponent.<Rigidbody>().AddTorque (Vector3.back * spin);
		GetComponent.<Rigidbody>().AddTorque (Vector3.right * spin2);
	}
	
	//Jumping control
	if (Input.GetKey(KeyCode.Space) && (isFalling == false))
	{
		GetComponent.<Rigidbody>().velocity.y = jumpHeight;
		isFalling = true;
	}
	
}
