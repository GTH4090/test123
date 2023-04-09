using Avalonia.Controls;
using KhrDesktop.Models;
using MessageBox.Avalonia;
using MessageBox.Avalonia.Enums;


namespace KhrDesktop.Classes;

public class Helper
{
    public static KhrDbContext Db = new KhrDbContext();

    public static Window Win = null;

    public static ContentControl Navigationn = null;

    public static User Log = null;

    public static void Error(string err = "Ошибка подключения к БД")
    {
        MessageBoxManager.GetMessageBoxStandardWindow("Ошибка", err, ButtonEnum.Ok, Icon.Error).ShowDialog(Win);
        
    }
    
    public static void Info(string err = "Внимание")
    {
        MessageBoxManager.GetMessageBoxStandardWindow("Информация", err, ButtonEnum.Ok, Icon.Info).ShowDialog(Win);
        
    }
    
}