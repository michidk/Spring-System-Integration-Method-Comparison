# Spring System Integration Method Comparison

Following the lecture "Game Physics" at Technical University of Munich (WS17/18), I wanted to implement an actual spring system in [Unity](https://unity.com/) to compare the different integration methods.

![Screenshot](/images/screenshot.png)

## Requirements

Unity 2019.3

## Usage

Open the project with Unity, double click the scene "Scenes/Demo" and enter "Play"-mode. Now move the cube in the editor or the sphere in the game preview using the arrow/WASD keys.

The integration method can be changed in the Simulator component.

All integration method implementations are contained in the "Scripts/Integration" folder.

## Comparison

To compare the integrators a bit better, I created a [codepen](https://codepen.io/michidk/pen/VymawG) to visualize the performance on a exponential function:

![Comparison](/images/comparison.png)

The horizontal axis shows the timesteps, the vertical axis the estimated result of the exponential function.
As you can see, Runge-Kutta integration (RK4) ist the most accurate method. This was to be expected since its a fourth-order method, which is the highest order of all tested methods.
