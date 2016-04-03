var attackRange = 30.0;
var shootAngleDistance = 10.0;
var target : Transform;
var TargetTagName:String;

function Start () {
		target = GameObject.FindWithTag(TargetTagName).transform;
}

function Update () {
	if (target == null){
		if (GameObject.FindWithTag(TargetTagName)) target = GameObject.FindWithTag(TargetTagName).transform;
		else return;
	}
	
	// Rotate towards target	
	
	var targetPoint = target.position;
	var targetRotation = Quaternion.LookRotation (targetPoint - transform.position, Vector3.up);
	transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 25.0);

	// If we are almost rotated towards target - fire one clip of ammo
	var forward = transform.TransformDirection(Vector3.forward);
	var targetDir = target.position - transform.position;
	if (Vector3.Angle(forward, targetDir) < shootAngleDistance)
		SendMessage("Fire");
}

function CanSeeTarget () : boolean
{
	if (Vector3.Distance(transform.position, target.position) > attackRange)
		return false;
		
	var hit : RaycastHit;
	if (Physics.Linecast (transform.position, target.position, hit))
		return hit.transform == target;

	return false;
}