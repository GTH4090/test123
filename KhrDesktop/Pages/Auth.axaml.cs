using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using static KhrDesktop.Classes.Helper;
using KhrDesktop.Models;

namespace KhrDesktop.Pages;

public partial class Auth : UserControl
{
    public Auth()
    {
        InitializeComponent();
    }

    

    private void PasCheck_OnChecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '\0';
    }

    private void PasCheck_OnUnchecked(object? sender, RoutedEventArgs e)
    {
        PasswordTbx.PasswordChar = '*';
    }

    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            if (Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text) != null)
            {
                var item = Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text);
                if (BCrypt.Net.BCrypt.Verify(PasswordTbx.Text, item.Password))
                {
                    Log = item;
                    Navigationn.Content = new MainMenu();
                }
                else
                {
                    Error("Не верный пароль");
                }
            }
            else
            {
                Error("Не верный логин");
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Registration();
    }

    private void GuestBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            
            
            Navigationn.Content = new MainMenu();
        }
        catch (Exception exception)
        {
            Error();
        }
    }
}