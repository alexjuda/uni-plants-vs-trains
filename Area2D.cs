using Godot;
using System;
using System.Collections.Generic;

public class Area2D : Godot.Area2D
{
	private List<instrybutor> instrybutors = new List<instrybutor>();
	private main main;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		instrybutor instrybutor1 = GetNode<instrybutor>("/root/Node2D/instrybutor");
		instrybutor instrybutor2 = GetNode<instrybutor>("/root/Node2D/instrybutor2");
		instrybutor instrybutor3 = GetNode<instrybutor>("/root/Node2D/instrybutor3");
		
		instrybutors.Add(instrybutor1);
		instrybutors.Add(instrybutor2);
		instrybutors.Add(instrybutor3);
		
		
		main = GetNode<main>("/root/Node2D");
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	if (main == null) {
		return;
	}
	
	foreach(instrybutor i in instrybutors) {
		if (OverlapsArea(i)) {
			i.doDamage(1);
			
			train train = GetParent() as train;
			
			main.unregisterTrain(train);
			
			return;
		}
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
