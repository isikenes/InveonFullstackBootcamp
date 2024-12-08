namespace _1_5_DIP
{
    public class BadStudentService
    {
        private BadStudentRepository _badStudentRepository;

        public BadStudentService()
        {
            _badStudentRepository = new BadStudentRepository();
        }

        public void AddStudent()
        {
            _badStudentRepository.AddStudent();
        }
        public void DeleteStudent()
        {
            _badStudentRepository.DeleteStudent();
        }
    }
}
