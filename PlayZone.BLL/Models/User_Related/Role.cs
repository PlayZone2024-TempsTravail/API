namespace PlayZone.BLL.Models.User_Related;

public class Role
{
    public int IdRole { get; set; }
    public string Name { get; set; }
    public bool IsRemovable { get; set; }
    public bool IsVisible { get; set; }
}
