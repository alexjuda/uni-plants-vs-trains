using Godot;
using System;

public class main : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public override void _Input(InputEvent @event)
	{
		// Mouse in viewport coordinates.
		if (@event is InputEventMouseButton eventMouseButton) {
			if (eventMouseButton.Pressed) {
				GD.Print("Mouse Click/Unclick at: ", eventMouseButton.Position);
				Node2D plant = ((ResourceLoader.Load("plant.tscn") as PackedScene).Instance() as Node2D);
				plant.Position = eventMouseButton.Position;
				AddChild(plant);
			}
		}
//		else if (@event is InputEventMouseMotion eventMouseMotion)
//			GD.Print("Mouse Motion at: ", eventMouseMotion.Position);

		// Print the size of the viewport.
//		GD.Print("Viewport Resolution is: ", GetViewportRect().Size);
	}

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
