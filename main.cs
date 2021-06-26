using Godot;
using System;
using System.Collections.Generic;

public class main : Node2D
{
	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";
	private const int PLANT_RANGE = 100;
	
	private List<train> trains = new List<train>();
	private List<plant> plants = new List<plant>();
	private List<Path2D> paths = new List<Path2D>();
	private List<Tuple<bullet, train>> bullets = new List<Tuple<bullet, train>>();
	private Godot.RichTextLabel label;
	private Godot.RichTextLabel trainsLabel;
	
	
	private int destroyedTrains = 0;
	private int money = 20;
	
	public List<plant> getPlants() {
		return this.plants;
	}
	
	public override void _Ready() {
		Path2D path1 = GetNode<Path2D>("/root/Node2D/Path2D");
		Path2D path2 = GetNode<Path2D>("/root/Node2D/Path2D2");
		Path2D path3 = GetNode<Path2D>("/root/Node2D/Path2D3");
		
		paths.Add(path1);
		paths.Add(path2);
		paths.Add(path3);
		
		label = GetNode<Godot.RichTextLabel>("/root/Node2D/MoneyLabel");
		trainsLabel = GetNode<Godot.RichTextLabel>("/root/Node2D/TrainsDestroyedLabel");
		this.updateLabels();
	}
	
	
	public override void _Input(InputEvent @event)
	{
		// Mouse in viewport coordinates.
		if (@event is InputEventMouseButton eventMouseButton) {
			this.buyAndAddPlant(eventMouseButton);
		}
	}
	
	public void registerTrain(train train) {
		trains.Add(train);
	}
	
	public void unregisterTrain(train train) {
		train.QueueFree();
		trains.Remove(train);
		foreach (var tuple in bullets){
			if(tuple.Item2 == train){
				tuple.Item1.QueueFree();
			}
		}
		bullets.RemoveAll(tuple => tuple.Item2 == train);
	}

  // Called every frame. 'delta' is the elapsed time since the previous frame.
  public override void _Process(float delta)
  {
	 foreach(var plant in plants){
		if(!plant.CanShoot()) {
			continue;
		}
		var range = plant.GetNode<Godot.Area2D>("Area2D2");
		foreach(var train in trains){
			var trainArea = train.GetNode<Godot.Area2D>("Area2D");
			
			if(range.OverlapsArea(trainArea)){
				plant.shot();
				var bullet = ((ResourceLoader.Load("bullet.tscn") as PackedScene).Instance() as bullet);
				bullet.Position = plant.Position;
				AddChild(bullet);
				bullets.Add(new Tuple<bullet, train>(bullet, train));
			}
		}
	}
	
	List<train> trainsToRemove = new List<train>();
	
	foreach(var bullet1 in bullets){
		(var bullet, var train) = bullet1;
		var bulletSpeed = 250f;
		bullet.Position += (train.GlobalPosition - bullet.GlobalPosition).Normalized() * bulletSpeed * delta;
		var trainArea = train.GetNode<Godot.Area2D>("Area2D");
		if (bullet.OverlapsArea(trainArea)) {
			if (train.doDamage(10)) { // train nie zyje
				trainsToRemove.Add(train);
			}
			bullet.setToDelete();
			bullet1.Item1.QueueFree();
		}
	}
	
	foreach(var trainToRm in trainsToRemove) {
		deleteTrainByShooting(trainToRm);
	}
	

	
	
	bullets.RemoveAll(tuple => tuple.Item1.getToDelete());
  }

	private void buyAndAddPlant(InputEventMouseButton eventMouseButton) {
		if (eventMouseButton.Pressed && this.money >= 10) {
			plant plant = ((ResourceLoader.Load("plant.tscn") as PackedScene).Instance() as plant);
			plants.Add(plant);
			plant.Position = eventMouseButton.Position;
			AddChild(plant);
			this.money -= 20;
			this.updateLabels();
		}
	}
	
	private void deleteTrainByShooting(train trainToRm) {
		this.destroyedTrains += 1;
		this.money += 2;
		this.updateLabels();
			if (this.destroyedTrains % 10 == 0) {
				foreach(Path2D path in paths) {
					path.increaseTrainSpeed(20.0f);
				}
			}
			if (this.destroyedTrains % 20 == 0) {
				foreach(Path2D path in paths) {
					path.increaseTrainHp(10);
				}
			}
			if (this.destroyedTrains % 30 == 0) {
				foreach(Path2D path in paths) {
					path.decreaseTimeToNextSpawn(0.1f);
				}
			}
		unregisterTrain(trainToRm);
	}

	private void updateLabels() {
		label.Text = "Money: " + money.ToString();
		trainsLabel.Text = "TrainsDestroyed: " + destroyedTrains.ToString();
	}
}
