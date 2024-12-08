namespace _1_5_DIP
{
    internal class StudentRepository : IStudentRepository
    {
        public void AddStudent()
        {
            Console.WriteLine("Student added");
        }

        public void DeleteStudent()
        {
            Console.WriteLine("Student deleted");
        }
    }
}
