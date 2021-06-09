using Godot;
using System;

public class Area2D : Godot.Area2D
{
	private Area2D instrybutor;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		instrybutor = GetNode<Area2D>("/root/Node2D/instrybutor");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	if (OverlapsArea(instrybutor)) {
		GD.Print("overlaps");
		
		GetParent().QueueFree();
	}
  }
}
