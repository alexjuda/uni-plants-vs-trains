using Godot;
using System;

public class instrybutor : Area2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	private int maxHp = 10;
	private int hp = 10;
	private Godot.RichTextLabel hpLabel;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		hpLabel = GetNode<Godot.RichTextLabel>("HpLabel");
		updateLabel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
//		GD.Print(GlobalPosition);
	}
	
	public void doDamage(int damage) {
		hp -= damage;
		updateLabel();
		
		if (hp <= 0) {
			GetTree().ChangeScene("res://GameOverScreen.tscn");
		}
	}
	
	private void updateLabel() {
		hpLabel.Text = "Hp: " + hp.ToString() + "/" + maxHp.ToString();
	}
}
