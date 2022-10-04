﻿using Firebase.Database;

namespace PlanDiet;

public partial class App : Application
{
    public static FirebaseClient client = new("https://dietplan-62de5-default-rtdb.asia-southeast1.firebasedatabase.app/");
    public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}
}
