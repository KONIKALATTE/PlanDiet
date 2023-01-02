﻿namespace PlanDiet;
using PlanDiet.Page;
using PlanDiet.Model;

public partial class MainPage : ContentPage
{
    Users users = new Users();

    public MainPage()
	{
		InitializeComponent();
	}
	public async void btndone_Clicked(object sender, EventArgs e)
	{
        var result = await users.DietPlan(txtprodid.Text, txtmed.Text, txtbbyprod.Text, txtschool.Text, txtgrocery.Text, txtmssg.Text);
        if (result == true)
        {
            await DisplayAlert("register", "successfully", "ok");
        }
        else
        {
            await DisplayAlert("Warning", "account exist", "ok");
        }

    }
    private async void btncancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
    
    private async void btndietlist_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WeeklyDietList());
    }

}

