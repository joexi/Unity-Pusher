Unity-Pusher
============

A simple class which helping developers perform methods on main thread in unity

#### Provides
 * simply perform on main thread
 * global gameobject and wont destroy when scenes has changed
 * thread-safe using 
 * perform methods in Sytem.Action way 

#### Example
 * call initial when your application start

``` c#
  Pusher.Instantiate();
```

  * simply run your method
  
``` c#
  Pusher.Run(() =>
  {
    //do something
  });
```
