using Godot;
using System;

public class Path2D : Godot.Path2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private float timeElapsed = 0.0f;
	private float timeToNextSpawn = 2.5f;
	private float timeToNextSpawnValue = 2.5f;
	private float minTimeToNextSpawn = 1.0f;
	private float trainSpeed = 100.0f;
	private float maxTrainSpeed = 300.0f;
	private int trainHp = 20;
	private int maxHp = 200;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}
	
	public void increaseTrainSpeed(float diff) {
		if (trainSpeed < maxTrainSpeed) {
			this.trainSpeed += diff;
		}
	}
	
	public void increaseTrainHp(int diff) {
		if (trainHp < maxHp) {
			this.trainHp += diff;
		}
	}
	
	public void decreaseTimeToNextSpawn(float diff) {
		if (timeToNextSpawnValue > minTimeToNextSpawn) {
			this.timeToNextSpawnValue -= diff;
		}
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
		train.setHp(this.trainHp);
		AddChild(train);
				
		main main = GetParent() as main;
		main.registerTrain(train);
		
		timeToNextSpawn += timeToNextSpawnValue;
	}
  }
}
