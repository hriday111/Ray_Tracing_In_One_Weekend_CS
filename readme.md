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

## Update to Stage 3:
Since the build in Vector3 uses float, meanwhile the book uses double (likely due to its higher precision), I implemented a custom class vec3 and impleneted all the basic operators and vec3 functions.

## Stage 4:
Here I will implement Rays, a simple camera and Background

### Stage 4.1

A ray class was implemented with basic read only properties for origin and direction.

Also and At() method was implemented to to find the the vector at t for the following function P(t)=Origin + t* Direction

### Stage 4.2
This substage focused on create a camera object and defining the viewport. 
Then firing the rays and creating a background for our scene


## Stage 5
### Stage 5.1 & 5.2

Here we make a sphere in our scene. And using some math determine if our ray hits the sphere. if it does then it displays a differnt color than the background. In this case red. 

## Stage 6
### Stage 6.1

In the previous stage we only checked if the ray hit the sphere or not, now the method bool hit_sphere was modified to return a double value of the distance from the origin to the hit-point
