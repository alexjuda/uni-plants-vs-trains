using Godot;
using System;

public class train : PathFollow2D
{
	private PathFollow2D pathFollow;
	private int hp = 30;
	private float speed = 0.0f;

	public int getHp(){
		return this.hp;
	}
	
	public bool doDamage(int damage) {
		this.hp -= damage;
		return hp <= 0;
	}
	
	public train() {
	}
	
	public void setSpeed(float speed) {
		this.speed = speed;
	}
	
	public void setHp(int hp) {
		this.hp = hp;
	}
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{

	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	Offset = Offset + this.speed * delta;
  }


}
