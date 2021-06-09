using Godot;
using System;

public class train : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PathFollow2D pathFollow;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.pathFollow = GetNode<PathFollow2D>("/root/Node2D/Path2D/PathFollow2D");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
//	var pos = this.pathFollow.GetGlobalPosition();
	var speed = 200.0f;
	this.pathFollow.Offset = this.pathFollow.Offset + speed * delta;
//	var pos = this.pathFollow.GetGlobalPosition();
	var other = GetNode<Area2D>("/root/Node2D/instrybutor");
	GD.Print(GlobalPosition);
	GD.Print("overlaps? " + OverlapsArea(other));
  }
}
