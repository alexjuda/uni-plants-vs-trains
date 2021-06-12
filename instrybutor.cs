using Godot;
using System;

public class instrybutor : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private int hp = 3;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print(GlobalPosition);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
//		GD.Print(GlobalPosition);
	}
	
	public void doDamage(int damage) {
		hp -= damage;
		GD.Print(hp);
		
		if (hp <= 0) {
			GetTree().ChangeScene("res://GameOverScreen.tscn");
		}
	}
}
