using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using KhrDesktop.Models;
using static KhrDesktop.Classes.Helper;

namespace KhrDesktop.Pages;

public partial class GroupVisitPage : UserControl
{
    private void LoadCbx()
    {
        try
        {
            DivisionCbx.Items = Db.Divisions.ToList();
            TargetCbx.Items = Db.Targets.ToList();
            BirthDp.DisplayDateEnd = DateTime.Now.AddYears(-16);
            StartDp.DisplayDateStart = DateTime.Now.AddDays(1);
            StartDp.DisplayDateEnd = DateTime.Now.AddDays(15);
            EndDp.DisplayDateStart = DateTime.Now.AddDays(1);
            EndDp.DisplayDateEnd = DateTime.Now.AddDays(15);

        }
        catch (Exception e)
        {
            Error();
        }
    }
    public GroupVisitPage()
    {
        InitializeComponent();
        LoadCbx();
        VisitGrid.DataContext = new Visit();
        VisitorGrid.DataContext = new Visitor();
        (VisitGrid.DataContext as Visit).StatusId = 1;
        (VisitGrid.DataContext as Visit).TypeId = 2;
        if (Log != null)
        {
            (VisitGrid.DataContext as Visit).UserId = Log.Id;
        }
        DivisionCbx.SelectedIndex = 0;
        EmployeeCbx.SelectedIndex = 0;
        TargetCbx.SelectedIndex = 0;
        StartDp.SelectedDate = DateTime.Now.AddDays(1);
        EndDp.SelectedDate = DateTime.Now.AddDays(1);
        BirthDp.SelectedDate = DateTime.Now.AddYears(-16);
    }


    private void DivisionCbx_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        try
        {
            var item = DivisionCbx.SelectedItem as Division;
            EmployeeCbx.Items = Db.Employees.Where(el => el.DivisionId == item.Id);
            EmployeeCbx.SelectedIndex = 0;

        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void StartDp_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        EndDp.DisplayDateStart = StartDp.SelectedDate;
    }

    private async void DocsBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            OpenFileDialog open = new OpenFileDialog();
            open.AllowMultiple = false;
            open.Filters.Add(new FileDialogFilter(){Name = "pdf", Extensions = new List<string>(){"pdf"}});
            var item = await open.ShowAsync(Win);
            if (item != null)
            {
                (VisitorGrid.DataContext as Visitor).PassportScan = File.ReadAllBytes(item[0]);
            }

        }
        catch (Exception exception)
        {
            Error();
        }
    }

    

    private void ClearBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new VisitPage();
    }

    private void OkBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (!PhoneTbx.Text.Contains('_') && !SerialTbx.Text.Contains('_') && !NumberTbx.Text.Contains('_') &&
                EmailTbx.Text[0] != '@' && EmailTbx.Text[^1] != '@' && EmailTbx.Text.Count(el => el == '@') == 1)
            {
                Db.Visits.Add(VisitGrid.DataContext as Visit);
                Db.SaveChanges();
                (VisitorGrid.DataContext as Visitor).VisitId = (VisitGrid.DataContext as Visit).Id;
                Db.Visitors.Add(VisitorGrid.DataContext as Visitor);
                Db.SaveChanges();
                Navigationn.Content = new MainMenu();
            }
            else
            {
                Error("Неправильно заполнено поле");
            }
        }
        catch (Exception exception)
        {
            Error("Не заполнены все обязательные поля");
            try
            {
                Db.Visits.Remove(VisitGrid.DataContext as Visit);
                Db.SaveChanges();
            }
            catch (Exception e1)
            {
                Error();
            }
            
        }
    }

    
}