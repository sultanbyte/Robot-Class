# Robot Class (Object-Oriented Development)

This project is basically a design of a robot using Object-Oritend development principles. 

The main three components of the project are the Robot class, Sensor class, and Actuator class. The add-on classes are the Rotating Robot class, Translating Robot class, and the Submersible class.

### Actuator Class:
  This is the class that actually drives the movement of the Robot as does an actuator in real life. Its sole purpose is to drive the robot.
  
### Sensor Class: 
  This class has also a single function; to be used as a sensor to check if a spot is empty before moving the robot.
  
### Robot Class:
  The robot class is the main class using the Actuator and the Sensor classes to move in one direction in the grid (forward).
  
### Rotating Robot Class:
  This class inherits all the functions of the Robot class and adds a rotation functionality that allows the robot to rotate to get more options in moving around the grid.
  
### Translating Robot Class:
  This class inherits all the functions of the Robot class and adds a translation function that allows the robot to move (translate) in other directions in the grid.
  
 ### Submersible Robot Class:
  This class inherits all the functions of the Robot class and adds a submersing functionality that allows the robot to "submerse" within multiple grids if provided and the corresponding location is empty. 
  
