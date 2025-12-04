public class Student
{
    public string MSSV { get; set; }
    public string TenSinhVien { get; set; }
    public string Khoa { get; set; }
    public float DiemTB { get; set; }

    public Student() { }

    public Student(string id, string name, string faculty, float score)
    {
        MSSV = id;
        TenSinhVien = name;
        Khoa = faculty;
        DiemTB = score;
    }
}