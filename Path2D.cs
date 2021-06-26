using Godot;
using System;

public class Path2D : Godot.Path2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private float timeElapsed = 0.0f;
	private float timeToNextSpawn = 2.0f;
	private float trainSpeed = 100.0f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public void increaseTrainSpeed(float diff) {
		this.trainSpeed += diff;
	}
	
	

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
//	AddChild(node.instance());
//	timeElapsed += delta;
	timeToNextSpawn -= delta;
	if (timeToNextSpawn <= 0.0f) {
		train train = (ResourceLoader.Load("train.tscn") as PackedScene).Instance() as train;
		train.setSpeed(this.trainSpeed);
		AddChild(train);
				
		main main = GetParent() as main;
		main.registerTrain(train);
		
		timeToNextSpawn += 2.0f;
	}
  }
}
