using Godot;
using System;

public class plant : Node2D
{

	private bool canShoot = true;
	private double timeToShoot;
	private int hp = 100;
	
	private bool toDelete = false;
	
	public void setToDelete() {
		this.toDelete = true;
	}
	
	public bool getToDelete() {
		return this.toDelete;
	}

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
	
	public bool doDamage(int damage) {
		hp -= damage;
		GD.Print("plant hp:" + hp);
		
		if (hp <= 0) {
			this.QueueFree();
		}
		
		return hp <= 0;
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
