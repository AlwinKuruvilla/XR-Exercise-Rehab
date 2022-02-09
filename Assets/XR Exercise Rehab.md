# XR Exercise Rehab

## Exercise 1 - Forward Arm Rotations
### Description
Arms will be placed shoulder width apart, in front of user. Rotations will be done in circles both clockwise/counter clockwise for each arm.
### Initialization 
- Controllers will be placed on shoulders to get the X & Y values of circle center.
- Arms will move out infront to get the Z values
### Mechanics
- X, Y, & Z values will represent the center of the circle rotations
- Radius will be calculated as (shoulder length)/2 - 0.1m
- Rotations of arms will be opposite of each other. (If left is counter-clockwise, right will be clockwise and vice versa)
- Use several colliders (16) create circle. 
    - Minimum time between collision to make sure the user is doing the exericise at the right pace.
### Visuals
- User should see a circle in front of them and as they rotate, the circle will fill up.
- Vertical gauge to left and right will show the progress of the set.
- Timer?

## Exercise 2 - Lateral Neck Stretch
### Description
Neck will move laterally to the side to stretch the opposite side's trapizeus muscle. Either neck alone or neck with hand 

## Exercise 3 - Squat with Arm Raise
Users will perform squats as they raise their hand out in front