using Godot;
using System;

public class Path2D : Godot.Path2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private float timeElapsed = 0.0f;
	private float timeToNextSpawn = 2.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
//	AddChild(node.instance());
//	timeElapsed += delta;
	timeToNextSpawn -= delta;
	if (timeToNextSpawn <= 0.0f) {
		AddChild((ResourceLoader.Load("train.tscn") as PackedScene).Instance());
		timeToNextSpawn += 2.0f;
	}
  }
}
