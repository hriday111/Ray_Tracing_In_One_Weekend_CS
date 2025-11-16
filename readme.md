# Ray Tracer in One Weekend

# In C Sharp

This project mimics the book “Ray Tracing in One Weekend”, however in C\# rather than C++.   
The first step is creating an image using C\#

**Stage 1:**  
A ppm image was generated using C\#   
Check: images/stage1.ppm


**Stage 2:**
The stage 2 is for implementing the vec3 class and using color as a vec3.
C sharp's built in System.Numerics provides a thorougly tested Vector3 implementation. All that was needed to be done was making a ColorUtils class that implements the WriteColor method. 

I also renamed the System.Numerics.Vector3 as Color using the ``using'' keyword.

**Stage 3:**
TODO