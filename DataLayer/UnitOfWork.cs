using DataLayer.Repositories;

namespace DataLayer
{
    public class UnitOfWork
    {
        public StudentsRepository Students { get; }
        public ClassRepository Classes { get; }
        public ProfessorsRepository Professors { get; }
        public GradesRepository Grades { get; }

        private readonly AppDbContext _dbContext;

        public UnitOfWork
        (
            AppDbContext dbContext,
            StudentsRepository studentsRepository,
            ClassRepository classes,
            ProfessorsRepository professorsRepository,
            GradesRepository gradesRepository
        )
        {
            _dbContext = dbContext;
            Students = studentsRepository;
            Classes = classes;
            Professors = professorsRepository;
            Grades = gradesRepository;
        }

        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();
            }
            catch(Exception exception)
            {
                var errorMessage = "Error when saving to the database: "
                    + $"{exception.Message}\n\n"
                    + $"{exception.InnerException}\n\n"
                    + $"{exception.StackTrace}\n\n";

                Console.WriteLine(errorMessage);
            }
        }
    }
}
