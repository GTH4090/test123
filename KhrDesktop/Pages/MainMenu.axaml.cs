using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KhrDesktop.Models;
using Microsoft.EntityFrameworkCore;
using static KhrDesktop.Classes.Helper;

namespace KhrDesktop.Pages;

public partial class MainMenu : UserControl
{
    private void LoadData()
    {
        List<Visit> visits = Db.Visits.Where(el => el.UserId == Log.Id)
            .Include(el => el.Employee)
            .ThenInclude(el => el.Division).Include(el => el.Type)
            .Include(el => el.Status).Include(el => el.Target)
            .ToList();

        if (visits.Count() != 0)
        {
            VisitDg.Items = visits;
        }
    }
    public MainMenu()
    {
        InitializeComponent();
        LoadData();
    }


    private void AddVisitBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new VisitPage();
    }
}