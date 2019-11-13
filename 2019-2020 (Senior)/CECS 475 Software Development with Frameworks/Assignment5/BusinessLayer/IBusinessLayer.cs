using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        IEnumerable<Standard> getAllStandards();
        Standard GetStandardByID(int id);
        void addStandard(Standard standard);
        void updateStandard(Standard standard);
        void removeStandard(Standard standard);
        IEnumerable<Student> getAllStudents();
        Student GetStudentByID(int id);
        void addStudent(Student student);
        void UpdateStudent(Student student);
        void RemoveStudent(Student student);
    }
}