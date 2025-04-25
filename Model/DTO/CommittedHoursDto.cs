namespace Model.DTO
{
    public class CommittedHoursRequest
    {
        public CommittedHoursDto CommittedHoursDto { get; set; }
    }

    public class CommittedHoursDto
    {
        public int ProjectId { get; set; }
        public int StaffId { get; set; }
        public decimal CommittedHours { get; set; }
        public decimal CompletedHours { get; set; }
        public string? Remarks { get; set; }
    }
}
