using Godot;
using System;

public class Area2D : Godot.Area2D
{
	private instrybutor instrybutor;
	private main main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		instrybutor = GetNode<instrybutor>("/root/Node2D/instrybutor");
		main = GetNode<main>("/root/Node2D");
		GD.Print(main);
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	if (main == null) {
		return;
	}
	
	if (OverlapsArea(instrybutor)) {
		instrybutor.doDamage(1);
		
		train train = GetParent() as train;
		
		main.unregisterTrain(train);
		
		return;
	}

	foreach(plant plant1 in main.getPlants()) {
		var plantArea = plant1.GetNode<Godot.Area2D>("Area2D");
		if (OverlapsArea(plantArea)) {
			bool plantDead = plant1.doDamage(10);

			train train = GetParent() as train;

			if (plantDead) {
				plant1.setToDelete();
			}

			main.unregisterTrain(train);
		}

	}

	main.getPlants().RemoveAll(pl => pl.getToDelete());
	
  }
}
