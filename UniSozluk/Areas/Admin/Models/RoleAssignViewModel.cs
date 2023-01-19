namespace UniSozluk.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleID { get; set; }
        public string Name { get; set; }
        public bool Exists { get; set; } //Bu kullanıcı var mı yok mu
    }
}
