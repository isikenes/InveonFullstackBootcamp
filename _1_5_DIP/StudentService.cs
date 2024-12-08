namespace _1_5_DIP
{
    internal class StudentService
    {
        private IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void AddStudent()
        {
            _studentRepository.AddStudent();
        }
        public void DeleteStudent()
        {
            _studentRepository.DeleteStudent();
        }
    }
}
