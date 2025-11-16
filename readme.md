# Ray Tracer in One Weekend

# In C Sharp

This project mimics the book “Ray Tracing in One Weekend”, however in C\# rather than C++.   
The first step is creating an image using C\#

## Stage 1 and 2:
A ppm image was generated using C\#   
Check: images/stage1.ppm


## Stage 3:
The stage 3 is for implementing the vec3 struct called Vector3 and using color as a Vector3.
C sharp's built in System.Numerics provides a thorougly tested Vector3 implementation. All that was needed to be done was making a ColorUtils class that implements the WriteColor method. 

I also renamed the System.Numerics.Vector3 as Color using the ``using'' keyword.

## Update to stage 3:
Since the build in Vector3 uses float, meanwhile the book uses double (likely due to its higher precision), I implemented a custom class vec3 and impleneted all the basic operators and vec3 functions.

## Stage 4:
Here I will implement Rays, a simple camera and Background

### Stage4.1

A ray class was implemented with basic read only properties for origin and direction.

Also and At() method was implemented to to find the the vector at t for the following function P(t)=Origin + t* Direction

### Stage 4.2
TODO: sending rays into the scene
