 var range : float = 100;
 var target : Transform;
 var damp : float = 2.5;
 var bulletPrefab : GameObject;
 var fireRate : float = 10.0;
 private var nextFire : float = 0.0;
 private var savedTime : float = 0;
 
 function Update ()
 {
      target = GameObject.FindWithTag("Enemy").transform;
      
      if(target)
      {
           var rotate = Quaternion.LookRotation(target.position - transform.position); 
           transform.rotation = Quaternion.Slerp(transform.rotation, rotate, Time.deltaTime * damp); 
           var seconds : float = Time.time;
           var oddeven = (seconds);
           if(oddeven) 
               Shoot(seconds);
           transform.LookAt(target);
      }
 }
 
 function Shoot(seconds)
 {
  var distance = Vector3.Distance(target.transform.position, transform.position);
    if (distance <= range){
      if(seconds!=savedTime && Time.time > nextFire)   {
 nextFire = Time.time + fireRate;
           var bullet = Instantiate(bulletPrefab,transform.Find("TSP").transform.position , transform.rotation);
      }
      savedTime=seconds;
     }
 }