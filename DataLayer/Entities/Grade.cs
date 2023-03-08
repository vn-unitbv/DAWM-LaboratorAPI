namespace DataLayer.Entities;

public class Grade
{
    public int Id { get; set; }
    public double Value { get; set; }
    public CourseType Course { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; }
}
