using System.Collections.Generic;

namespace LINQhw
{
    public class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            if (x.StudentID == y.StudentID && x.StudentName.ToLower() == y.StudentName.ToLower() && x.Age == y.Age)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Student obj)
        {
            throw new System.NotImplementedException();
        }
    }
}