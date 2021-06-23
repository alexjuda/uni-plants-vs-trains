using Godot;
using System;

public class Area2D : Godot.Area2D
{
	private instrybutor instrybutor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		instrybutor = GetNode<instrybutor>("/root/Node2D/instrybutor");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	if (OverlapsArea(instrybutor)) {
		instrybutor.doDamage(1);
		
		train train = GetParent() as train;
		
		main main = GetNode<main>("/root/Node2D");
		main.unregisterTrain(train);
	}
  }
}
