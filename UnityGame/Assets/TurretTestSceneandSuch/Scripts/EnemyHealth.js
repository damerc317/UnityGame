#pragma strict

var MaxHP:float=100; //Maximum health
var HP:float;       //Current health
var Invincible:boolean;
var BloodChunk: GameObject[];
var PositionOfBlood:GameObject[]; 
var BloodAmount:float=0.5; 
var DeadPrefab:Rigidbody; 
private var coun:int;

function Start () {
HP=MaxHP; 
}

function Update () {
if(Input.GetMouseButton(0)) PlayerDamage(Random.Range(1.0,4.0));
}

function PlayerDamage(dam:float)
{
	if(HP<1.0) return; 
	if (!Invincible) HP-=dam;
	if(HP<=1.0)	{ 
	var deadEnemy=Instantiate(DeadPrefab,transform.position,transform.rotation);
	Destroy(gameObject); 
	}
}