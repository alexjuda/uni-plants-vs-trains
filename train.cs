using Godot;
using System;

public class train : PathFollow2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private PathFollow2D pathFollow;
	private int hp = 30;
	private float speed = 0.0f;

	public int getHp(){
		return this.hp;
	}
	
	public bool doDamage(int damage) {
		this.hp -= damage;
		GD.Print("got damage, hp: " + hp);
		return hp <= 0;
	}
	
	public train() {
		GD.Print("train created");
	}
	
	public void setSpeed(float speed) {
		this.speed = speed;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
//		this.pathFollow = GetNode<PathFollow2D>("/root/Node2D/Path2D/PathFollow2D");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
//	var pos = this.pathFollow.GetGlobalPosition();
	Offset = Offset + this.speed * delta;
//	this.pathFollow.Offset = this.pathFollow.Offset + speed * delta;
//	var pos = this.pathFollow.GetGlobalPosition();
//	var other = GetNode<Area2D>("/root/Node2D/instrybutor");
//	GD.Print(GlobalPosition);
//	GD.Print("overlaps? " + OverlapsArea(other));
  }


}
