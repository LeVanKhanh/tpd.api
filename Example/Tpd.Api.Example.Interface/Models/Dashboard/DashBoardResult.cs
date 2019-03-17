namespace Tpd.Api.Interface.Models.Dashboard
{
    public class DashBoardResult
    {
        public DashBoardResult()
        {
            East = new AreaModel();
            West = new AreaModel();
            Center = new AreaModel();
        }

        public AreaModel East { get; set; }
        public AreaModel West { get; set; }
        public AreaModel Center { get; set; }
    }
}
