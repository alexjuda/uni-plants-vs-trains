using Godot;
using System;

public class plant : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	
	private bool canShoot = true;
	private double timeToShoot;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	public bool CanShoot(){
		return canShoot;
	}

	public void shot(){
		canShoot = false;
		timeToShoot = 1.0f;
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	if(!canShoot){
	  timeToShoot -= delta;
		if(timeToShoot<=0){
			canShoot = true;
		}
	}
  }
}
