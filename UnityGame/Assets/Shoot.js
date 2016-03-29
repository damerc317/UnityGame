#pragma strict

var theEmitter = ParticleEmitter;
var isEmitting : boolean = true;
 
function Start() 
{
    // finds the particle emitter on this gameObject
    // change this to find your particle effect,
    // or simply comment out this line, and drop your particle emitter into the Inspector
    theEmitter = GetComponent(ParticleEmitter); // finds the particle emitter on this gameObject
}

function Update()
{
    if (Input.GetKeyDown(KeyCode.H))
    {
        if (isEmitting)
        {
            isEmitting = false;
            theEmitter.emit = false;
        }
        else
        {
            isEmitting = true;
            theEmitter.emit = true;
        }
    }
}