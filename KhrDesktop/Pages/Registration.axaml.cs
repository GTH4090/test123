using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using static KhrDesktop.Classes.Helper;
using KhrDesktop.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace KhrDesktop.Pages;

public partial class Registration : UserControl
{
    public Registration()
    {
        InitializeComponent();
    }


    private void LoginBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        try
        {
            string nums = "1234567890";
            string lwLet = "qwertyuiopasdfghjklzxcvbnm";
            string upLet = lwLet.ToUpper();
            string spec = "!@#$%^&*()";
            if (LoginTbx.Text[0] != '@' && LoginTbx.Text[^1] != '@' &&
                Db.Users.FirstOrDefault(el => el.Login == LoginTbx.Text) == null &&
                LoginTbx.Text.Count(el => el == '@') == 1 && PasswordTbx.Text.Intersect(nums).Count() > 0
                && PasswordTbx.Text.Intersect(lwLet).Count() > 0 && PasswordTbx.Text.Intersect(upLet).Count() > 0
                && PasswordTbx.Text.Intersect(spec).Count() > 0 && PasswordTbx.Text.Length >= 8 &&
                PasswordTbx.Text == Password2Tbx.Text)
            {
                User user = new User();
                user.Login = LoginTbx.Text;
                user.Password = BCrypt.Net.BCrypt.HashPassword(PasswordTbx.Text);
                Db.Users.Add(user);
                Db.SaveChanges();
                Navigationn.Content = new Auth();
            }
            else
            {
                Info("Логин или пароль не соответствуют требованиям");
            }
        }
        catch (Exception exception)
        {
            Error();
        }
    }

    private void RegBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Navigationn.Content = new Auth();
    }
}